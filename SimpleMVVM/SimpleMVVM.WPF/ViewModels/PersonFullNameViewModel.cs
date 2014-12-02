using System;
using System.ComponentModel;

namespace kaorun.samples.SimpleMVVM.WPF.ViewModels
{
    public class PersonFullNameViewModel : INotifyPropertyChanged
    {
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
}
