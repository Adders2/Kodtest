// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;

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

        foreach (var splitRow in splitRows)
        {
            var key = splitRow[0];

            switch (key)
            {
                case "P":
                    xdoc.Root.Add(new XElement("person"));
                    break;
                case "T":
                    xdoc.Root.Element("person").Add(new XElement("phone"));
                    break;
                case "A":
                    xdoc.Root.Element("person").Add(new XElement("address"));
                    break;
                case "F":
                    xdoc.Root.Element("person").Add(new XElement("family"));
                    break;
                default:
                    break;
            }
        }

        foreach (var thing in xdoc.Elements())
        {
            Console.WriteLine(thing);
        }
        

        Console.ReadLine();
    }
}