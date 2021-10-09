using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Newtonsoft.Json;

namespace ExerciseAPI.Repositories
{
    public class Accounts : IAccounts
    {
        private readonly string csvPath = Directory.GetCurrentDirectory() + "\\Test_Accounts.csv";

        public string GetAccounts()
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(csvPath);

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

        public DataTable AccountsToDataTable()
        {
            return JsonConvert.DeserializeObject<DataTable>(GetAccounts());
        }

    }
}
