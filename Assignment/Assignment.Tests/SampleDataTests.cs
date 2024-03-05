using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Tests;

    public class SampleDataTests
    {
        [Fact]
        public void CsvRows_Output_Correct()
        {
            IEnumerable<string> csvOut = new SampleData().CsvRows.ToList();
            Assert.Equal(50,csvOut.Count());
        }

        [Fact]
        public void GetUniqueSortedListOfStatesGivenCsvRows_Output_Correct()
        {
            IEnumerable<string> states = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            bool test = states.Zip(states, (first, second) => first.CompareTo(second) < 0 || first.Equals(second, StringComparison.Ordinal)).All(rows => rows);
            Assert.True(test);
            
        }

        [Fact]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodeVals_correct()
        {
            IEnumerable<string> states = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            string[] stateStrings = new[] { "WA", "MT", "FL", "GA" };
            //TODO find assert statement
            
        }

    }
