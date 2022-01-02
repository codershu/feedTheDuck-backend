using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using feedTheDuck.Context;
using feedTheDuck.Models;

namespace feedTheDuck.Interfaces
{
    public interface IDuckService
    {
        Task<Response<Guid>> AddRecord(DuckRecordRequest request);
        Task<Response<List<DuckFeedRecords>>> GetAllRecords();
        Task<Response<Guid>> UpdateRecord(DuckRecordRequest request);
        Task<Response<Guid>> DeleteRecord(DuckRecordRequest request);
    }
}
