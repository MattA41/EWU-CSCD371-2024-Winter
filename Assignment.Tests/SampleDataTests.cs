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
<<<<<<< HEAD
            bool test = states.Zip(states, (first, second) => String.Compare(first, second, StringComparison.Ordinal) < 0 || first.Equals(second, StringComparison.Ordinal)).All(rows => rows);
=======
            bool test = states.Zip(states, (first, second) => string.Compare(first,second) < 0 || first.Equals(second, StringComparison.Ordinal)).All(rows => rows);
>>>>>>> 3455ce4af45cffdab772222182373d99dfc6a2b7
            Assert.True(test);
            
        }

        [InlineData("MT")]
        [InlineData("FL")]
        [InlineData("CA")]
        [Theory]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodeVals_correct(string row)
        {
            IEnumerable<string> states = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            Assert.Contains(row, states);

        }

        [Fact]
        public void GetAggregateSortedListOfStatesUsingCsvRows_Output_NotNull()
        {
            string states = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.Equal("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
        }

        [Fact]
        public void People_HasNumOfPeople_true()
        {
            IEnumerable<IPerson> peopleList = new SampleData().People;
            Assert.Equal(50,peopleList.Count());
            
        }

        [Fact]
        public void People_FirstPerson_IsCorrect()
        {
            IEnumerable<IPerson> peopleList = new SampleData().People;
            Assert.Equal("Fremont",peopleList.ElementAt(0).FirstName);
        }

        [Fact]
        public void People_FilterByEmail_FirstPerson_IsCorrect()
        {
            
            IEnumerable<(string firstname, string lastname)> peopleList = new SampleData().FilterByEmailAddress(email=> email.Contains(".edu"));

            Assert.Equal("Fremont", peopleList.ElementAt(0).firstname);
        }
        [Fact]
        public void People_GetAggregateListOfStatesGivenPeopleCollection_ReturnsExpectedPerson()
        {
            IEnumerable<IPerson> people = new SampleData().People;
            IEnumerable<string> outState = new SampleData().GetAggregateListOfStatesGivenPeopleCollection(people).Split(", ").OrderBy(state => state).ToList();
            string states = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows();

            string statesStr = string.Join(", ", outState);

            Assert.Contains(states, statesStr);
        }

    }
