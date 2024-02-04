using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codetest.Model
{
    public class Family
    {
        public string Name { get; set; } 
        public string BirthYear { get; set; } 
        public Phone? Phone { get; set; }
        public Address? Address { get; set; }

        public Family()
        {
            
        }
        public Family(List<string> parsedRowValues)
        {
            Name = parsedRowValues.ElementAtOrDefault(0) ?? string.Empty;
            BirthYear = parsedRowValues.ElementAtOrDefault(1) ?? string.Empty;
        }
    }
}
