namespace AdvancedMVVM.Models.ViewModels
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    public class MainWindowViewModel : BindableBase
    {
        private ICommand talkToMeCommand;
        private StudentViewModel selectedStudent;

        public ObservableCollection<StudentViewModel> StudentsList { get; private set; }

        public StudentViewModel SelectedStudent
        {
            get
            {
                return this.selectedStudent;
            }

            set
            {
                if (this.SelectedStudent != value)
                {
                    this.selectedStudent = value;
                    base.OnPropertyChanged(nameof(this.SelectedStudent));
                }
            }
        }

        public ICommand TalkToMeCommand
        {
            get
            {
                return this.talkToMeCommand;
            }

            set
            {
                if (this.TalkToMeCommand != value)
                {
                    this.talkToMeCommand = value;
                }
            }
        }

        public MainWindowViewModel()
        {
            this.TalkToMeCommand = new DelegateCommand(() => 
            {
                MessageBox.Show("Updated");
            });

            this.StudentsList = new ObservableCollection<StudentViewModel>()
            {
                new StudentViewModel( 
                    new Student("Dimitar",
                        "Radenkov", 
                        "F40029",
                        30,
                        new List<string>()
                            {
                                "Math",
                                "Informatique"
                            }
                    )),

                new StudentViewModel(
                    new Student("Alexander", 
                        "Radenkov", 
                        "F40221",
                        15, 
                        new List<string>()
                            {
                                "Math",
                                "Science"
                            }
                    )),
            };
        }      
    }
}
