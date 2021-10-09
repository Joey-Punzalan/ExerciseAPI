using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using ExerciseAPI.Repositories;
using ExerciseAPI.Models;

namespace ExerciseAPI.Repositories
{
    public class MeterData : IMeterData
    {
        private readonly string savePath = Directory.GetCurrentDirectory() + "\\MeterData.csv";

        public string ReadMeterData()
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(savePath);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }

        public void SaveMeterData(string data, UploadReport reportData)
        {
            DataTable dtReadings = JsonConvert.DeserializeObject<DataTable>(data);
            DataTable dtAccounts = new Accounts().AccountsToDataTable();
            reportData.Valid = dtReadings.AsEnumerable()
                                .Where(r => dtAccounts.AsEnumerable().
                                Any(a => a.Field<string>("AccountId") == r.Field<string>("AccountId")
                                        && !r.Field<string>("MeterReadValue").Equals("")
                                        && r.Field<string>("MeterReadValue").All(char.IsNumber)
                                        && !((r.Field<string>("MeterReadValue").All(char.IsNumber) && !r.Field<string>("MeterReadValue").Equals("")) ? (Convert.ToInt32(r.Field<string>("MeterReadValue")) < 0 || Convert.ToInt32(r.Field<string>("MeterReadValue")) > 99999) : true)
                                    )).CopyToDataTable();
            reportData.Invalid = dtReadings.AsEnumerable()
                                .Where(r => !dtAccounts.AsEnumerable().Select(a => a.Field<string>("AccountId")).Contains(r.Field<string>("AccountId"))
                                            || !r.Field<string>("MeterReadValue").All(char.IsNumber)
                                            || ((r.Field<string>("MeterReadValue").All(char.IsNumber) && !r.Field<string>("MeterReadValue").Equals("")) ? (Convert.ToInt32(r.Field<string>("MeterReadValue")) < 0 || Convert.ToInt32(r.Field<string>("MeterReadValue")) > 99999) : true)
                                    ).CopyToDataTable();



            for ( var i = 0; i < reportData.Valid.Rows.Count; i++ )
            {
                    
            }
        }

    }
}
