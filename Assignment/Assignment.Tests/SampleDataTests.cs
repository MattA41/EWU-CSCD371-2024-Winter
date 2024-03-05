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
    [InlineData("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577")]
        [Theory]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodeVals_correct(string row)
        {
            IEnumerable<string> states = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            //TODO find assert statement
            Assert.Contains(row, states);

        }

    }
