using System.Collections.Generic;

namespace Steps.Util.DB.Models
{ 
    public class Feature
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public ICollection<Scenario> Scenarios { get; set; }

        public Feature()
        {
            Scenarios = new List<Scenario>();
        }
    }
}
