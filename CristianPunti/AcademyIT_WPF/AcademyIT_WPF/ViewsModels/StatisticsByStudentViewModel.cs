using Academy.Lib.Models;
using Academy.UI;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Academy.App.WPF.ViewsModels
{
    public class StatisticsByStudentViewModel : ViewModelBase
    {
        #region Propierties
        private string _dniSVM;
        public string DniSVM
        {
            get { return _dniSVM; }
            set
            {
                _dniSVM = value;
                OnPropertyChanged();
            }
        }

        private string _nameSVM;
        public string NameSVM
        {
            get { return _nameSVM; }
            set
            {
                _nameSVM = value;
                OnPropertyChanged();
            }
        }


        private Student _currentStudentSVM;
        public Student CurrentStudentSVM
        {
            get { return _currentStudentSVM; }
            set
            {
                _currentStudentSVM = value;
                OnPropertyChanged();
            }
        }

        private string _currentSubjectNameSVM;
        public string CurrentSubjectNameSVM
        {
            get
            {
                return _currentSubjectNameSVM;
            }
            set
            {
                _currentSubjectNameSVM = value;
                OnPropertyChanged();
            }
        }


        private string _errorsSVM;
        public string ErrorsSVM
        {
            get
            {
                return _errorsSVM;
            }
            set
            {
                _errorsSVM = value;
                OnPropertyChanged();
            }
        }


        private Subject _currentSubjectSVM;
        public Subject CurrentSubjectSVM
        {
            get { return _currentSubjectSVM; }
            set
            {
                _currentSubjectSVM = value;
                OnPropertyChanged();
            }
        }

        private double _markSVM;
        public double MarkSVM
        {
            get
            {
                return _markSVM;
            }
            set
            {
                _markSVM = value;
                OnPropertyChanged();
            }

        }


        List<string> _subjectsNameListSVM;
        public List<string> SubjectsNameListSVM
        {
            get
            {
                return _subjectsNameListSVM;
            }
            set
            {
                _subjectsNameListSVM = value;
                OnPropertyChanged();
            }

        }

        List<StudentSubject> _subjectsByStudentList;
        public List<StudentSubject> SubjectsByStudentList
        {
            get
            {
                return _subjectsByStudentList;
            }
            set
            {
                _subjectsByStudentList = value;

                OnPropertyChanged();
            }
        }


        List<StudentExam> _studentExamsListSVM;
        public List<StudentExam> StudentExamsListSVM
        {
            get
            {
                return _studentExamsListSVM;
            }
            set
            {
                _studentExamsListSVM = value;
                OnPropertyChanged();
            }
        }

        List<StudentExam> _studentExamsBySubjectListSVM;
        public List<StudentExam> StudentExamsBySubjectListSVM
        {
            get
            {
                return _studentExamsBySubjectListSVM;
            }
            set
            {
                _studentExamsBySubjectListSVM = value;
                OnPropertyChanged();
            }
        }

        List<StudentExam> _maxMinListSVM;
        public List<StudentExam> MaxMinListSVM
        {
            get
            {
                return _maxMinListSVM;
            }
            set
            {
                _maxMinListSVM = value;
                OnPropertyChanged();
            }
        }





        #endregion
        public StatisticsByStudentViewModel()
        {
            FindStudentSVMCommand = new RouteCommand(FindStudentSVM);
            GetStudentExamsSVMCommand = new RouteCommand(GetStudentExamsSVM);
            GetAllStudentExamsSVMCommand = new RouteCommand(GetAllStudentExamsSVM);
            AvgMarkSVMCommand = new RouteCommand(AvgMarkSVM);
            MaxMarkSVMCommand = new RouteCommand(MaxMarkSVM);
            MinMarkSVMCommand = new RouteCommand(MinMarkSVM);

        }

        #region  Statistics
        bool exams = false;

       

        private List<double> MarksListSVM()
        {
            ErrorsSVM = "";
            if (exams)
            {
                if (CurrentStudentSVM != null)
                {
                    if (CurrentSubjectNameSVM != null)
                    {
                        var marksList = new List<double>();

                        foreach (StudentExam stuEx in StudentExamsBySubjectListSVM)
                        {
                            marksList.Add(stuEx.Mark);
                        }

                        return marksList;
                    }
                    else
                    {
                        var marksList = new List<double>();

                        foreach (StudentExam stuEx in StudentExamsListSVM)
                        {
                            marksList.Add(stuEx.Mark);
                        }

                        return marksList;
                    }
                }
                else
                {
                    ErrorsSVM = "No hay ningún Student seleccionado";
                    return null;
                }


                
            }
            else
            {
                ErrorsSVM = "No hay exámenes para calcular";
                return null;
            }
        }



        private void MinMarkSVM()
        {
            MarkSVM = 0;
            var marksList = new List<double>();
            marksList = MarksListSVM();

            if (marksList != null)
            {
                MarkSVM = marksList.Min();
                MaxMinListSVM = StudentExamsBySubjectListSVM.FindAll(x => x.Mark == MarkSVM).ToList();
            }

        }


        private void MaxMarkSVM()
        {
            MarkSVM = 0;
            var marksList = new List<double>();
            marksList = MarksListSVM();

            if (marksList != null)
            {
                MarkSVM = marksList.Max();
                MaxMinListSVM = StudentExamsBySubjectListSVM.FindAll(x => x.Mark == MarkSVM).ToList();
            }
        }

        private void AvgMarkSVM()
        {
            MarkSVM = 0;
            var marksList = new List<double>();
            marksList = MarksListSVM();

            if (marksList != null)
            {
                MarkSVM = marksList.Average();
                MaxMinListSVM = StudentExamsBySubjectListSVM.FindAll(x => x.Mark == MarkSVM).ToList();
            }
        }

        #endregion

        #region Métodos de Búsqueda

        private void GetAllStudentExamsSVM()
        {
            CurrentSubjectNameSVM = null;
            //ErrorsSVM = "";
            GetStudentExamsSVM();
            exams = true;
        }

        private void GetStudentExamsSVM()
        {
            ErrorsSVM = "";

            Student student = new Student();
            Exam exam = new Exam();
            StudentExam studentExam = new StudentExam();

            if(CurrentStudentSVM != null)
            {
                student = CurrentStudentSVM;
                studentExam.StudentId = student.Id;

                StudentExamsListSVM = studentExam.StudentByExams(studentExam.StudentId);

                if (CurrentSubjectNameSVM != null)
                {
                    StudentExamsBySubjectListSVM = StudentExamsListSVM.FindAll(x => x.Exam.Subject.Name == CurrentSubjectNameSVM).ToList();
                    exams = true;
                }
                else
                {
                    StudentExamsBySubjectListSVM = StudentExamsListSVM;
                    exams = true;
                }
                
                if (StudentExamsBySubjectListSVM.Count == 0)
                {
                    ErrorsSVM = "El estudiante no ha realizado exámenes de " + CurrentSubjectNameSVM;
                    exams = false;

                }

            }
        }

        private void FindStudentSVM()
        {
            ErrorsSVM = "";
            var studentsVM = new StudentsViewModel();

            studentsVM.GetStudents();

            CurrentStudentSVM = studentsVM.Students.FirstOrDefault(x => x.Dni == DniSVM);
           
           

            if (CurrentStudentSVM != null)
            {
                if(DniSVM == CurrentStudentSVM.Dni)
                {
                    DniSVM = CurrentStudentSVM.Dni;
                    NameSVM = CurrentStudentSVM.Name;
                    GetSubjectsNameEV();
                }
               
            }
            else
            {
                ErrorsSVM = "Student no Existe";
                Student student = new Student();
                CurrentStudentSVM = student;

                GetSubjectsNameEV();

                DniSVM = "";
                NameSVM = "";

            }

        }

        private void GetSubjectsNameEV()
        {
            SubjectsNameListSVM = GetSubjectsByName();
        }

        private List<string> GetSubjectsByName()
        {
            GetSubjectsToStudent();
            List<string> SubjectsNameListEV = new List<string>();
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();

            foreach (StudentSubject subj in SubjectsByStudentList)
            {
                var studentSubject = new StudentSubject();
                var subject = new Subject();

                subject = repo.QueryAll().FirstOrDefault(x=> x.Id == subj.SubjectId);

                SubjectsNameListEV.Add(subject.Name);
            }

            return SubjectsNameListEV;
        }

        private void GetSubjectsToStudent()
        {
            Student student = new Student();
            StudentSubject studentSubjects = new StudentSubject();

            if(CurrentStudentSVM != null)
            {
                student = CurrentStudentSVM;
                studentSubjects.StudentId = student.Id;

                SubjectsByStudentList = studentSubjects.StudentBySubjects(studentSubjects.StudentId);
            }
        }

        #endregion

        public RouteCommand FindStudentSVMCommand { get; set; }
        public RouteCommand GetStudentExamsSVMCommand { get;  set; }
        public RouteCommand GetAllStudentExamsSVMCommand { get; set; }
        public RouteCommand AvgMarkSVMCommand { get;  set; }
        public RouteCommand MaxMarkSVMCommand { get;  set; }
        public RouteCommand MinMarkSVMCommand { get;  set; }
    }
}
