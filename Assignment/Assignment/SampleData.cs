using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace Assignment;

    public class SampleData : ISampleData
    {
        string path = "People.csv";
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
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }

