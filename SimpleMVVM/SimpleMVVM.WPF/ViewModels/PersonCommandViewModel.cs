using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using kaorun.samples.SimpleMVVM.WPF.Common;

namespace kaorun.samples.SimpleMVVM.WPF.ViewModels
{
    public class PersonCommandViewModel : INotifyPropertyChanged
    {
        public ICommand IncrementAge { get; set; }
        public ICommand DecrementAge { get; set; }
        public ICommand Submit { get; set; }

        public PersonCommandViewModel()
        {
            IncrementAge = new RelayCommand(() => { Age++; });
            DecrementAge = new DecrementAgeCommand(this);
            Submit = new RelayCommand(SubmitNow);
        }

        private void SubmitNow()
        {
            MessageBox.Show(string.Format("User: {0}\nAge: {1}\nSubmitted!", FullName, Age));
        }

        private string firstNameVal;
        public string FirstName
        {
            get { return firstNameVal; }
            set
            {
                firstNameVal = value;
                NotifyPropertyChanged("FirstName");
                NotifyPropertyChanged("FullName");
            }
        }

        private string lastNameVal;
        public string LastName
        {
            get { return lastNameVal; }
            set
            {
                lastNameVal = value;
                NotifyPropertyChanged("LastName");
                NotifyPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
            set
            {
                var names = value.Split(new[] { ' ' });
                if (names.Length == 2)
                {
                    FirstName = names[0];
                    LastName = names[1];
                }
                else
                {
                    FirstName = value;
                    LastName = "";
                }
                NotifyPropertyChanged("FullName");
            }
        }

        private int ageVal;
        public int Age
        {
            get { return ageVal; }
            set
            {
                ageVal = value;
                NotifyPropertyChanged("Age");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

    public class DecrementAgeCommand : ICommand
    {
        private PersonCommandViewModel vm;

        public DecrementAgeCommand(PersonCommandViewModel viewmodel)
        {
            vm = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return vm.Age > 0;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            vm.Age--;
        }
    }
}
