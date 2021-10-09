using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseAPI.Repositories;
using ExerciseAPI.Models;
using System.Web.Http.Cors;
using Newtonsoft.Json;

namespace ExerciseAPI.Controllers
{
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExerciseController : ControllerBase
    {
        [HttpGet("/home")]
        public ActionResult Home()
        {
            return Content("Welcome to Exercise API\n\nCommands:\n/getAccounts - List test accounts\n/meter-reading-uploads - Uploads csv file\n/getMeterData - List saved valid readings");
        }

        [HttpGet("/get-accounts")]
        public string GetAccounts()
        {
            var accounts = new Repositories.Accounts();
        
            return accounts.GetAccounts();
        }

        [HttpPost("/meter-reading-uploads")]
        public string MeterReadingUploads(UploadData data)
        {
            var meterData = new MeterData();
            var reportData = new UploadReport();
            meterData.SaveMeterData(data.Csv, reportData);
            
            return JsonConvert.SerializeObject(reportData);
        }

        [HttpGet("/get-meter-data")]
        public string GetMeterData()
        {
            var meterData = new MeterData();

            return meterData.ReadMeterData();
        }
    }
}
