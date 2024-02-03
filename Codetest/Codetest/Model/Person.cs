using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codetest.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address? Address { get; set; }
        public Phone? Phone { get; set; }
        public List<Family> Family { get; set; } = new List<Family>();

        public Person()
        {

        }

        public Person(string firstName, string lastName) : base()
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
