// See https://aka.ms/new-console-template for more information

using Codetest.Model;
using Codetest.Service;
using System.Xml;
using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("This is a simple console app that will read the text from Example.txt, parse and output it as xml to output.xml.");
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        var currentDir = AppDomain.CurrentDomain.BaseDirectory;
        var file = Path.Combine(currentDir, "../../../Example.txt");
        var path = Path.GetFullPath(file);

        var text = File.ReadAllLines(path);

        var converter = new TextParser();

        var parsedPeople = converter.ParseText(text);

        var serializer = new XmlSerializer(typeof(List<Person>));
        var writePath = Path.Combine(currentDir, "../../../output.xml");
        using (var writer = new StreamWriter(writePath))
        {
            serializer.Serialize(writer, parsedPeople);
        }

        Console.WriteLine("Output should now be written to output.xml.");
        Console.WriteLine("Press any key to finish.");
        Console.ReadKey();
    }
}