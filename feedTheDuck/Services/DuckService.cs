using System;
using System.Threading.Tasks;
using feedTheDuck.Interfaces;
using feedTheDuck.Models;

namespace feedTheDuck.Services
{
    public class DuckService : IDuckService
    {
        public DuckService()
        {
        }

        public Task<Response<bool>> AddRecord(DuckRecordRequest request)
        {
            return Task.FromResult(Response<bool>.Ok(true, "New Record Added"));
        }
    }
}
