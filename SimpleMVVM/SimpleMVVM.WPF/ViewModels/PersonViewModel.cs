using System;
using System.ComponentModel;

namespace kaorun.samples.SimpleMVVM.WPF.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private string firstNameVal;
        public string FirstName
        {
            get { return firstNameVal; }
            set
            {
                firstNameVal = value;
                NotifyPropertyChanged("FirstName");
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
