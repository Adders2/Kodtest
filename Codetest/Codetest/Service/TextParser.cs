using Codetest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Codetest.Service
{
    internal class TextParser
    {
        public List<Person> ParseText(string[]? text)
        {
            var parsedPeople = new List<Person>();

            if (text != null && text.Any())
            {
                Person? currentPerson = null;
                Family? currentFamily = null;

                var splitRows = text
                    .Select(t => t.Split('|'))
                    .ToList();

                foreach (var splitRow in splitRows)
                {
                    var key = splitRow[0];
                    var rowValues = splitRow.Skip(1).ToList();

                    switch (key)
                    {
                        case "P":
                            currentPerson = new Person(rowValues);
                            currentFamily = null;
                            parsedPeople.Add(currentPerson);
                            break;
                        case "T":
                            if (currentFamily != null)
                            {
                                currentFamily.Phone = new Phone(rowValues);
                            }
                            else if (currentPerson != null)
                            {
                                currentPerson.Phone = new Phone(rowValues);
                            }
                            break;
                        case "A":
                            if (currentFamily != null)
                            {
                                currentFamily.Address = new Address(rowValues);
                            }
                            else if (currentPerson != null)
                            {
                                currentPerson.Address = new Address(rowValues);
                            }
                            break;
                        case "F":
                            if (currentPerson != null)
                            {
                                currentFamily = new Family(rowValues);
                                currentPerson.Family.Add(currentFamily);
                            }
                            break;
                        default:
                            break;
                    }
                }

            }

            return parsedPeople;
        }
    }
}
