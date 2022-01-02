using System;
using System.Linq;
using System.Threading.Tasks;
using feedTheDuck.Context;
using feedTheDuck.Interfaces;
using feedTheDuck.Models;

namespace feedTheDuck.Services
{
    public class DuckService : IDuckService
    {
        private readonly DuckContext _context;

        public DuckService(DuckContext context)
        {
            _context = context;
        }

        public async Task<Response<Guid>> AddUser(DuckRecordRequest request)
        {
            var user = new UserAccess()
            {
                User = request.CreatedBy,
                Code = request.Code,
                CreatedOn = DateTime.Now
            };

            _context.UserAccess.Add(user);
            await _context.SaveChangesAsync();

            return Response<Guid>.Ok(user.Id, "New User Added");
        }

        public async Task<Response<Guid>> AddRecord(DuckRecordRequest request)
        {
            var target = _context.UserAccess.FirstOrDefault(x => x.User == request.CreatedBy);
            var userId = target?.Id;
            if(target == null)
            {
                var addUserResponse = await AddUser(request);
                if (addUserResponse != null && addUserResponse.IsSuccess)
                    userId = addUserResponse.Result;
            }
            else
            {
                if (target.Code != request.Code)
                    return Response<Guid>.Error("Duplicate User Name Found, please use a different user name");
            }

            var record = new DuckFeedRecords()
            {
                Location = request.Location,
                DuckType = request.DuckType,
                DuckAmount = request.DuckAmount,
                Food = request.Food,
                FoodAmount = request.FoodAmount,
                FoodMetric = request.FoodMetric,
                CreatedBy = (Guid)userId,
                CreatedOn = DateTime.Now,
                UpdatedBy = (Guid)userId,
                UpdatedOn = DateTime.Now
            };

            _context.DuckFeedRecords.Add(record);
            await _context.SaveChangesAsync();

            return Response<Guid>.Ok(record.Id, "New Record Added");
        }
    }
}
