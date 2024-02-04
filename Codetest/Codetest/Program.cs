// See https://aka.ms/new-console-template for more information

using Codetest.Model;
using Codetest.Service;
using System.Reflection.Metadata.Ecma335;
using System.Text;
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

        var converter = new TextParser();

        var parsedPeople = converter.ParseText(text);

        var serializer = new XmlSerializer(typeof(List<Person>));
        var writePath = Path.Combine(currentDir, "../../../testOutput.xml");
        using (var writer = new StreamWriter(writePath))
        {
            serializer.Serialize(writer, parsedPeople);
        }


        Console.ReadLine();
    }
}