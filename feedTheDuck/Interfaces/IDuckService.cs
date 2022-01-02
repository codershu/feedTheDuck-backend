using System;
using System.Threading.Tasks;
using feedTheDuck.Models;

namespace feedTheDuck.Interfaces
{
    public interface IDuckService
    {
        Task<Response<Guid>> AddRecord(DuckRecordRequest request);
    }
}
