using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaorun.samples.SimpleMVVM.WPF.Models
{
    public class PersonFullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            set
            {
                var names = value.Split(new[] {' '});
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
            }
        }
        public int Age { get; set; }
    }
}
