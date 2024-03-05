using System;
using System.Collections.Generic;
using System.Linq;
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
    }
