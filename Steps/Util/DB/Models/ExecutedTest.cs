using System;
namespace Steps.Util.DB.Models
{
    public class ExecutedTest
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int? ScenarioId { get; set; }
        public Scenario Scenario { get; set; }

        public int? BrowserId { get; set; }
        public Browser Browser { get; set; }

        public int? ScreenId { get; set; }
        public Screen Screen { get; set; }

        public int? ResultStatusId { get; set; }
        public ResultStatus ResultStatus { get; set; }
    }
}
