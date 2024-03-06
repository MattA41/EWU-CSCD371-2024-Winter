using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace Assignment;

    public class SampleData : ISampleData
    {
    readonly string path = "People.csv";
        // 1.
        public IEnumerable<string> CsvRows
        {
            get
            { 
                foreach(string line in File.ReadLines(path).Skip(1))
                {
                    yield return line;
                }
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()  
        {
            return CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            return string.Join(", ", states);
        }
           

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<IPerson> people = CsvRows.Select(row => row.Split(',')).OrderBy(currPerson => currPerson[5]).ThenBy(currPerson => currPerson[6]).ThenBy(currPerson => currPerson[7]).Select(currPerson => new Person(currPerson[1], currPerson[2], new Address(currPerson[4], currPerson[5], currPerson[6], currPerson[7]), currPerson[3]));
                return people;
            }
        }
  

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(currPerson => filter(currPerson.EmailAddress)).Select(currPerson => (currPerson.FirstName, currPerson.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => People.Select(currPerson => currPerson.Address.State).Distinct().Aggregate((first, second) => $"{first}, {second}");
    }

 