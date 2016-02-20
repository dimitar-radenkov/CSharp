namespace SimpleMVVM
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;
    using System.Windows;
    using System.Windows.Input;

    public class MainWindowViewModel : BindableBase
    {
        private string firstName;
        private string lastName;
        private int age;

        private string buttonContent;
        private ICommand buttonCommand;

        private string messageToShow;
        private ICommand buttonShowCommand;

        public MainWindowViewModel()
        {
            this.ButtonContent = "Increment Age";
            this.ButtonCommand = new DelegateCommand(() => 
            {
                ++this.Age;
            });

            this.MessageToShow = "Hello";
            this.ButtonShowCommand = new DelegateCommand<string>((x) =>    
            {
                MessageBox.Show(x);
            });
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                    base.OnPropertyChanged(nameof(this.FirstName));
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    base.OnPropertyChanged(nameof(this.LastName));
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    base.OnPropertyChanged(nameof(this.Age));
                }
            }
        }

        public string ButtonContent
        {
            get
            {
                return this.buttonContent;
            }

            set
            {
                if (this.buttonContent != value)
                {
                    buttonContent = value;
                    base.OnPropertyChanged(nameof(this.ButtonContent));
                }
            }
        }

        public ICommand ButtonCommand
        {
            get
            {
                return this.buttonCommand;
            }

            set
            {
                this.buttonCommand = value;
            }
        }

        public string MessageToShow
        {
            get
            {
                return this.messageToShow;
            }

            set
            {
                if (this.messageToShow != value)
                {
                    this.messageToShow = value;
                    base.OnPropertyChanged(nameof(this.MessageToShow));
                }
            }

        }

        public ICommand ButtonShowCommand
        {
            get
            {
                return this.buttonShowCommand;
            }

            set
            {
                this.buttonShowCommand = value;
            }
        }
    }
}
