using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ExerciseAPI.Repositories
{
    public interface IAccounts
    {
        string GetAccounts();
        DataTable AccountsToDataTable();
    }
}
