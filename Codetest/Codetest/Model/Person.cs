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

        public Person (List<string> parsedRowValues)
        {
            FirstName = parsedRowValues[0];
            LastName = parsedRowValues[1];
        }

        public Person(string firstName, string lastName) : base()
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
