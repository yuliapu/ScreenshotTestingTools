using System;
using System.Collections.Generic;

namespace Steps.Util.DB.Models
{
    public class ResultStatus
    {
        public int Id { get; set; }
        public string TestStatus { get; set; }
        public ICollection<ExecutedTest> ExecutedTests { get; set; }

        public ResultStatus()
        {
            ExecutedTests = new List<ExecutedTest>();
        }
    }
}
