using System;

namespace Steps.Util.DB
{
    public class TestResultModel
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public string ScenarioName { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
