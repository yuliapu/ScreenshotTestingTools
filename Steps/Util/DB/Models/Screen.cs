using System;
using System.Collections.Generic;
namespace Steps.Util.DB.Models
{
    public class Screen
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public ICollection<ExecutedTest> ExecutedTests { get; set; }

        public Screen()
        {
            ExecutedTests = new List<ExecutedTest>();
        }
    }
}
