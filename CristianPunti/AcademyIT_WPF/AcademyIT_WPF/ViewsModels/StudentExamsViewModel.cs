using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

using Academy.Lib.Models;
using Academy.UI;
using Academy.Lib.Repositories;
using Academy.Lib.DAL.Repositories;
using Academy.Lib.DAL;
using Common.Lib.Core;
using Common.Lib.Infrastructure;
using Common.Lib.Core.Context;

namespace Academy.App.WPF.ViewsModels
{
    public class StudentExamsViewModel : ViewModelBase
    {

        private string _dniS;


        public string DniS
        {
            get
            {
                return _dniS;
            }
            set
            {
                _dniS = value;
                OnPropertyChanged();
            }
        }


        private string _nameS;
        public string NameS
        {
            get
            {
                return _nameS;
            }
            set
            {
                _nameS = value;
                OnPropertyChanged();
            }
        }


        private string _titleS;

        public string TitleS
        {
            get
            {
                return _titleS;
            }
            set
            {
                _titleS = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateS;
        public DateTime DateS
        {
            get
            {
                return _dateS;
            }
            set
            {
                _dateS = value;
                OnPropertyChanged();
            }
        }

        private double _markSEVM;
        public double MarkSEVM
        {
            get
            {
                return _markSEVM;
            }
            set
            {
                _markSEVM = value;


                OnPropertyChanged();
            }

        }


        private string _markTextS;
        public string MarkTextS
        {
            get
            {
                return _markTextS;
            }
            set
            {
                _markTextS = value;
                OnPropertyChanged();
            }

        }



        private bool _hasCheatedSEVM;
        public bool HasCheatedSEVM
        {
            get
            {
                return _hasCheatedSEVM;
            }
            set
            {
                _hasCheatedSEVM = value;
                OnPropertyChanged();
            }

        }


        private string _subjectNameS;
        public string SubjectNameS
        {
            get
            {
                return _subjectNameS;
            }
            set
            {
                _subjectNameS = value;
                OnPropertyChanged();
            }
        }


        private Student _currentStudentSEVM;
        public Student CurrentStudentSEVM
        {
            get
            {
                return _currentStudentSEVM;
            }
            set
            {
                _currentStudentSEVM = value;

                OnPropertyChanged();
            }
        }


        private Exam _currentExamS;
        public Exam CurrentExamS
        {
            get
            {
                return _currentExamS;
            }
            set
            {
                _currentExamS = value;
                OnPropertyChanged();
            }
        }


        private StudentExam _currentStudentExamSEVM;
        public StudentExam CurrentStudentExamSEVM
        {
            get
            {
                return _currentStudentExamSEVM;
            }
            set
            {
                _currentStudentExamSEVM = value;

                if (CurrentStudentExamSEVM != null)
                {
                    this.MarkTextS = Convert.ToString(CurrentStudentExamSEVM.Mark);
                    this.HasCheatedSEVM = CurrentStudentExamSEVM.HasCheated;
                }
                OnPropertyChanged();
            }
        }

        List<Exam> _examsListSEVM;
        public List<Exam> ExamsListSEVM
        {
            get
            {
                return _examsListSEVM;
            }
            set
            {
                _examsListSEVM = value;
                OnPropertyChanged();
            }
        }

        List<StudentExam> _studentExamsListSEVM;
        public List<StudentExam> StudentExamsListSEVM
        {
            get
            {
                return _studentExamsListSEVM;
            }
            set
            {
                _studentExamsListSEVM = value;
                OnPropertyChanged();
            }
        }

        StudentExam examToUpdate = new StudentExam();


        private Guid _id = default;
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public StudentExamsViewModel()
        {
            FindStudentSEVMCommand = new RouteCommand(FindStudentSEVM);
            GetExamsSEVMCommand = new RouteCommand(GetExamsSEVM);
            SelExamSEVMCommand = new RouteCommand(SelExamSEVM);
            EditStudentExamsSEVMCommand = new RouteCommand(EditStudentExamsSEVM);
            DelStudentExamsSEVMCommand = new RouteCommand(DelStudentExamsSEVM);
            SaveStudentExamsSEVMCommand = new RouteCommand(SaveStudentExamsSEVM);

        }

        public void EditStudentExamsSEVM()
        {
            if (CurrentStudentSEVM != null)
            {
                StudentExam stexam = new StudentExam();
                _ = new Student();
                _ = new Exam();
                MarkStringToDoubleS();

                // Exam exam = CurrentExamS;
                //  Student student = CurrentStudentSEVM;
                examToUpdate.StudentId = CurrentStudentExamSEVM.StudentId;
                examToUpdate.ExamId = CurrentStudentExamSEVM.ExamId;
                examToUpdate.HasCheated = HasCheatedSEVM;

                var vrstex = examToUpdate.Save();

                if (vrstex.IsSuccess)
                {
                    MessageBox.Show($"La nota del examen del estudiante se ha editado correctamente");
                   // CurrentStudentExamSEVM = vrstex.Entity;
                    StudentExamsListSEVM = examToUpdate.StudentByExams(examToUpdate.StudentId);
                }
                else
                {
                    MessageBox.Show($"La nota del examen del estudiante no se ha editado correctamente");

                }

                CurrentStudentSEVM = null;
                CurrentExamS = null;
                DniS = "";
                NameS = "";
                TitleS = "";
                SubjectNameS = "";
                DateS = default;
                MarkTextS = "";
                HasCheatedSEVM = default;
                this.Id = default;

                //GetStudentExamsSEVM();


            }
            else
            {
                MessageBox.Show("Se tiene que seleccionar un examen de un estudiante antes de editarlo");
            }


        }
        public void MarkStringToDoubleS()
        {
            ValidationResult<double> vrmark;

            if (!(vrmark = StudentExam.ValidateMark(this.MarkTextS)).IsSuccess)
            {
                MessageBox.Show(vrmark.AllErrors);
            }

            if (CurrentStudentExamSEVM != null)
            {
                if (!(vrmark = StudentExam.ValidateMark(this.MarkTextS, CurrentStudentExamSEVM.Id)).IsSuccess)
                {
                    MessageBox.Show(vrmark.AllErrors);
                }

            }

            if (!vrmark.IsSuccess)
            {

                CurrentStudentSEVM = null;
                CurrentExamS = null;
                DniS = "";
                NameS = "";
                MarkTextS = "";
                HasCheatedSEVM = false;
            }
            else
            {
                if (CurrentStudentExamSEVM == null)
                {
                    MarkSEVM = vrmark.ValidatedResult;

                }
                else
                {
                    examToUpdate = CurrentStudentExamSEVM.Clone();

                    examToUpdate.Mark = vrmark.ValidatedResult;
                }
            }
        }

        public void DelStudentExamsSEVM()
        {
            _ = new StudentExam();

            if (CurrentStudentExamSEVM == null)
            {

                MessageBox.Show("Se tiene que seleccionar un examen del estudiante antes de eliminarla");
            }
            else
            {
                MessageBox.Show("El examen del estudiante se ha eliminado correctamente");

                StudentExam studentExamMVM = CurrentStudentExamSEVM;
                studentExamMVM.Delete();

                StudentExamsListSEVM = studentExamMVM.StudentByExams(studentExamMVM.StudentId);


            }
        }

        public void SaveStudentExamsSEVM()
        {
            MarkStringToDoubleS();

            StudentExam stexam = new StudentExam();
            _ = new Student();
            _ = new Exam();

            Exam exam = CurrentExamS;
            Student student = CurrentStudentSEVM;

            if (MarkSEVM != 0)
            {
                if (CurrentStudentExamSEVM != null)
                {
                    stexam = CurrentStudentExamSEVM;
                }

                stexam.Mark = MarkSEVM;

                stexam.HasCheated = HasCheatedSEVM;

                if (CurrentStudentSEVM != null)
                {

                    stexam.StudentId = student.Id;

                    if (CurrentExamS != null)
                    {

                        stexam.ExamId = exam.Id;

                    }
                    if (CurrentStudentSEVM != null || CurrentStudentExamSEVM != null)
                    {

                        GetStudentExamsSEVM();

                        MarkTextS = "";
                        HasCheatedSEVM = default;

                    }
                }
            }

            stexam.Mark = MarkSEVM;

            var vrstex = stexam.Save();

            if (vrstex.IsSuccess)
            {
                MessageBox.Show($"La nota del examen del estudiante se ha guardado correctamente");
                StudentExamsListSEVM = stexam.StudentByExams(stexam.StudentId);

            }
            else
            {
                MessageBox.Show($"La nota del examen del estudiante no se ha guardado correctamente");

            }

            CurrentStudentSEVM = null;
            CurrentExamS = null;
            DniS = "";
            NameS = "";
            TitleS = "";
            SubjectNameS = "";
            DateS = default;
            MarkTextS = "";
            HasCheatedSEVM = default;
            this.Id = default;

            // GetStudentExamsSEVM();
        }

        private void SelExamSEVM()
        {

            Exam exam = new Exam();
            //StudentExam stex = new StudentExam();
            //var stsbVResult = stex.ValidateStudentSubject(CurrentStudentExamSEVM.StudentId, CurrentStudentExamSEVM.ExamId);
            if (CurrentStudentSEVM == null)
            {
               // MessageBox.Show(stsbVResult.ValidatedResult);
                MessageBox.Show("No hay ningún estudiante seleccionado");
                TitleS = "";
                SubjectNameS = "";
                DateS = default;
                MarkTextS = "";
            }
            else
            {

                if (CurrentExamS != null)
                {
                    TitleS = CurrentExamS.Title;
                    SubjectNameS = CurrentExamS.Subject.Name;
                    DateS = CurrentExamS.Date;
                    MarkTextS = "";
                }

            }
        }

        private void FindStudentSEVM()
        {
            var studentsVM = new StudentsViewModel();
            StudentSubject studentSubjectMVM = new StudentSubject();
            studentsVM.GetStudents();

            CurrentStudentSEVM = studentsVM.Students.FirstOrDefault(x => x.Dni == DniS);

            if (CurrentStudentSEVM != null)
            {
                DniS = CurrentStudentSEVM.Dni;
                NameS = CurrentStudentSEVM.Name;

                GetStudentExamsSEVM();
            }
            else
            {
                MessageBox.Show("Este estudiante no existe.");
                
                
            }
        }

        public void GetStudentExamsSEVM()
        {
            Student student = new Student();
            Exam exam = new Exam();

            StudentExam studentExam = new StudentExam();

            if (CurrentStudentSEVM != null)
            {

                student = CurrentStudentSEVM;
                exam = CurrentExamS;


                studentExam.StudentId = student.Id;

                StudentExamsListSEVM = studentExam.StudentByExams(studentExam.StudentId);

            }
        }

        public void GetExamsSEVM()
        {
            _ = new Exam();
            var repo = Student.DepCon.Resolve<IRepository<Exam>>();
            ExamsListSEVM = repo.QueryAll().ToList();
        }

        public ICommand FindStudentSEVMCommand { get; set; }
        public ICommand GetExamsSEVMCommand { get; set; }
        public ICommand SelExamSEVMCommand { get; set; }
        public ICommand EditStudentExamsSEVMCommand { get; set; }
        public ICommand DelStudentExamsSEVMCommand { get; set; }
        public ICommand SaveStudentExamsSEVMCommand { get; set; }
    }
}
