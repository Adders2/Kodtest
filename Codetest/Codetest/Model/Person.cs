using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codetest.Model
{
    internal class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public Address? Address { get; set; }
        public Phone? Phone { get; set; }
        public List<Family> Family { get; set; } = new List<Family>();
    }
}
