using System.Collections.Generic;

namespace Steps.Util.DB.Models
{
    public class Scenario
    {
        public int Id { get; set; }
        public string ScenarioName { get; set; }
        public int? FeatureId { get; set; }
        public Feature Feature { get; set; }
        public ICollection<ExecutedTest> ExecutedTests { get; set; }

        public Scenario()
        {
            ExecutedTests = new List<ExecutedTest>();
        }
    }
}
