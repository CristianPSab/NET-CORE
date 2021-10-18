using Academy.Lib.Models;
using Academy.UI;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Academy.App.WPF.ViewsModels
{
    public class StatisticsByExamsViewModel : ViewModelBase
    {
        #region Propierties
        private string _subjectNameEV;

        public string SubjectNameEV
        {
            get
            {
                return _subjectNameEV;
            }
            set
            {
                _subjectNameEV = value;
                OnPropertyChanged();
            }
        }




        private string _titleEV;

        public string TitleEV
        {
            get
            {
                return _titleEV;
            }
            set
            {
                _titleEV = value;
                OnPropertyChanged();
            }
        }



        private Exam _currentExamE;
        public Exam CurrentExamE
        {
            get { return _currentExamE; }
            set
            {
                _currentExamE = value;
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






        List<Exam> _examsListEV;
        public List<Exam> ExamsListEV
        {
            get
            {
                return _examsListEV;
            }
            set
            {
                _examsListEV = value;
                OnPropertyChanged();
            }
        }


        List<StudentExam> _studentExamsListEV;
        public List<StudentExam> StudentExamsListEV
        {
            get
            {
                return _studentExamsListEV;
            }
            set
            {
                _studentExamsListEV = value;
                OnPropertyChanged();
            }
        }



        #endregion


        public StatisticsByExamsViewModel()
        {
            GetExamsEVCommand = new RouteCommand(GetExamsEV);
            EditExamEVCommand = new RouteCommand(EditExamEV);
            ClearSelEVCommand = new RouteCommand(ClearSelEV);
            AvgMarkSVMCommand = new RouteCommand(AvgMarkSVM);
            MaxMarkSVMCommand = new RouteCommand(MaxMarkSVM);
            MinMarkSVMCommand = new RouteCommand(MinMarkSVM);

        }

        #region  Statistics

        private void MinMarkSVM()
        {
            MarkSVM = 0;

            var marksList = new List<double>();
            marksList = MarksListSVM();

            if (marksList == null) { }

            else
            {
                MarkSVM = marksList.Min();

                StudentExamsListEV = StudentExamsListEV.FindAll(x => x.Mark == MarkSVM).ToList();
            }
        }

        private List<double> MarksListSVM()
        {
            ErrorsSVM = "";
            GetStudentExamsEV();


            if (CurrentExamE != null)
            {


                var marksList = new List<double>();

                foreach (StudentExam stuEx in StudentExamsListEV)
                {
                    marksList.Add(stuEx.Mark);
                }

                return marksList;
            }


            else
            {

                var repo = Subject.DepCon.Resolve<IRepository<StudentExam>>();
                List<StudentExam> StudentExamsList = new List<StudentExam>();
                StudentExamsList = repo.QueryAll().ToList();


                var marksList = new List<double>();

                foreach (StudentExam stuEx in StudentExamsListEV)
                {
                    marksList.Add(stuEx.Mark);
                }

                return marksList;
            }
        }

        private void GetStudentExamsEV()
        {
            Exam exam = new Exam();
            var repo = Student.DepCon.Resolve<IRepository<Exam>>();
            ExamsListEV = repo.QueryAll().ToList();
        }

        private void MaxMarkSVM()
        {
            MarkSVM = 0;

            var marksList = new List<double>();
            marksList = MarksListSVM();

            if (marksList == null) { }

            else
            {
                MarkSVM = marksList.Max();
                StudentExamsListEV = StudentExamsListEV.FindAll(x => x.Mark == MarkSVM).ToList();

            }
        }

        private void AvgMarkSVM()
        {
            MarkSVM = 0;
            var marksList = new List<double>();
            marksList = MarksListSVM();

            if (marksList == null) { }

            else
            {
                MarkSVM = marksList.Average();
                StudentExamsListEV.Clear();
            }
        }

        #endregion

        #region Métodos de Búsqueda
        bool isEdit = false;

        private void ClearSelEV()
        {
            TitleEV = "";
            SubjectNameEV = "";
            CurrentExamE = null;
            GetStudentExamsEV();
            StudentExamsListEV.Clear();
            MarkSVM = 0;
        }

        private void EditExamEV()
        {
            ErrorsSVM = "";


            if (CurrentExamE != null)
            {
                Subject subject = new Subject();

                var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
                var subjectsList = new List<Subject>();
                subjectsList = repo.QueryAll().ToList();

                subject = subjectsList.FirstOrDefault(x => x.Id == CurrentExamE.SubjectId);


                TitleEV = CurrentExamE.Title;
                SubjectNameEV = subject.Name;

                GetStudentExamsEV();

            }

            else
                ErrorsSVM = "No nas seleccionado ningún Examen";

            isEdit = true;
        }


            private void GetExamsEV()
        {
            Exam exam = new Exam();
            var repo = Student.DepCon.Resolve<IRepository<Exam>>();
           
        }

        #endregion



        public ICommand GetExamsEVCommand { get; set; }
        public ICommand EditExamEVCommand { get; set; }
        public ICommand ClearSelEVCommand { get; set; }
        public ICommand AvgMarkSVMCommand { get; set; }
        public ICommand MaxMarkSVMCommand { get; set; }
        public ICommand MinMarkSVMCommand { get; set; }
    }
}
