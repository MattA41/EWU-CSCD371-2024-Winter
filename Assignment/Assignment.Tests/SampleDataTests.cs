using System;
using System.Collections.Generic;
using System.Drawing;
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

        [InlineData("MT")]
        [InlineData("FL")]
        [InlineData("CA")]
        [Theory]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodeVals_correct(string row)
        {
            IEnumerable<string> states = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            //TODO find assert statement
            Assert.Contains(row, states);

        }

        [Fact]
        public void GetAggregateSortedListOfStatesUsingCsvRows_Output_NotNull()
        {
            string states = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.Equal("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
        }

        [Fact]
        public void People_IsPersonObject_true()
        {
            IEnumerable<IPerson> peopleList = new SampleData().People;
            Assert.Equal(50,peopleList.Count());
            
        }

    }
