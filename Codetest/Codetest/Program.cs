// See https://aka.ms/new-console-template for more information

using Codetest.Model;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var currentDir = AppDomain.CurrentDomain.BaseDirectory;
        var file = Path.Combine(currentDir, "../../../Example.txt");
        var path = Path.GetFullPath(file);

        var text = File.ReadAllLines(path);

        var splitRows = text.Select(t => t.Split('|')).ToList();

        var xdoc = new XDocument(new XElement("people"));

        var people = new List<Person>();
        Person? currentPerson = null;
        Family? currentFamily = null;

        foreach (var splitRow in splitRows)
        {
            var key = splitRow[0];

            switch (key)
            {
                case "P":
                    currentPerson = new Person(firstName: splitRow[1], lastName: splitRow[2]);
                    currentFamily = null;
                    people.Add(currentPerson);
                    break;
                case "T":
                    if (currentPerson != null)
                    {
                        currentPerson.Phone = new Phone { MobileNumber = splitRow[1],/* LandlineNumber = splitRow[2]*/ };
                    }
                    break;
                case "A":
                    if (currentPerson != null)
                    {
                        currentPerson.Address = new Address { Street = splitRow[1]/*, City = splitRow[2], PostalCode = splitRow[3]*/ };
                    }
                    break;
                case "F":
                    if (currentPerson != null)
                    {
                        currentFamily = new Family { Name = splitRow[1], BirthYear = splitRow[2] };
                        currentPerson.Family.Add(currentFamily);
                    }
                    break;
                default:
                    break;
            }

            var serializer = new XmlSerializer(typeof(List<Person>));
            var writePath = Path.Combine(currentDir, "../../../testOutput.xml");
            using (var writer = new StreamWriter(writePath))
            {
                serializer.Serialize(writer, people);
            }
        }
        

        Console.ReadLine();
    }
}