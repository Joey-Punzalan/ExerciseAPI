using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ExerciseAPI.Models;

namespace ExerciseAPI.Repositories
{
    public interface IMeterData
    {
        string ReadMeterData();
        void SaveMeterData(string data, UploadReport reportData);
    }
}
