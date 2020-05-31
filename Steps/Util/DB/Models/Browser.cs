using System.Collections.Generic;
namespace Steps.Util.DB.Models
{
    public class Browser
    {
        public int Id { get; set; }
        public string BrowserName { get; set; }
        public ICollection<ExecutedTest> ExecutedTests { get; set; }

        public Browser()
        {
            ExecutedTests = new List<ExecutedTest>();
        }
    }
}
