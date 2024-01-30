// See https://aka.ms/new-console-template for more information


using Codetest.Model;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var currentDir = AppDomain.CurrentDomain.BaseDirectory;
        var file = Path.Combine(currentDir, "../../../Example.txt");
        var path = Path.GetFullPath(file);

        var text = File.ReadAllLines(path);

        var splitRows = text.Select(t => t.Split('|')).ToList();

        foreach (var splitRow in splitRows)
        {
            
        }
        

        Console.ReadLine();
    }
}