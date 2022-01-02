using System;
namespace feedTheDuck.Models
{
    public class DuckRecordRequest
    {
        public DuckRecordRequest()
        {
        }

        public string Location { get; set; }
        public string DuckType { get; set; }
        public string Food { get; set; }
        public string FoodMetric { get; set; }
        public string CreatedBy { get; set; }
        public string Code { get; set; }
        public long FoodAmount { get; set; }
        public long DuckAmount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

