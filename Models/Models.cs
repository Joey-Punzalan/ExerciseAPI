using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ExerciseAPI.Models
{
    public class Accounts
    {
        public long AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MeterReadings
    {
        public string UploadData { get; set; }
        public long AccountId { get; set; }
        public string MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
    }

    public class UploadData
    {
        public string Csv { get; set; }
    }

    public class UploadReport
    {
        public DataTable Valid { get; set; }
        public DataTable Invalid { get; set; }
    }
}
