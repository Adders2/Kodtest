using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codetest.Model
{
    public class Family
    {
        public string Name { get; set; } = string.Empty;
        public string BirthYear { get; set; } = string.Empty;
        public Phone? Phone { get; set; }
        public Address? Address { get; set; }
    }
}
