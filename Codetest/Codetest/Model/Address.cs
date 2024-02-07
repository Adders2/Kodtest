namespace Codetest.Model
{
    public class Address
    {
        public string? Street { get; set; } 
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public Address()
        {
            
        }
        public Address(List<string> parsedRowValues)
        {
            Street = parsedRowValues.ElementAtOrDefault(0);
            City = parsedRowValues.ElementAtOrDefault(1);
            PostalCode = parsedRowValues.ElementAtOrDefault(2);
        }
    }
}
