using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using feedTheDuck.Context;
using feedTheDuck.Interfaces;
using feedTheDuck.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Response<Guid>> GetRecords(DuckRecordRequest request)
        {
            var target = _context.UserAccess.FirstOrDefault(x => x.User == request.CreatedBy);
            var userId = target?.Id;
            if (target == null)
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

        public async Task<Response<List<DuckFeedRecords>>> GetAllRecords()
        {
            var result = await _context.DuckFeedRecords.ToListAsync();
            return Response<List<DuckFeedRecords>>.Ok(result, "Feed Records Fetched");
        }

        public async Task<Response<Guid>> UpdateRecord(DuckRecordRequest request)
        {
            var accessResponse = await CanAccessRecord(request);
            if (accessResponse == null || !accessResponse.IsSuccess)
                return Response<Guid>.Error(accessResponse.Message);

            var target = await _context.DuckFeedRecords.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(target == null)
                return Response<Guid>.Error("Record not found");

            target.Location = request.Location;
            target.DuckType = request.DuckType;
            target.DuckAmount = request.DuckAmount;
            target.Food = request.Food;
            target.FoodAmount = request.FoodAmount;
            target.FoodMetric = request.FoodMetric;
            target.UpdatedOn = DateTime.Now;

            _context.DuckFeedRecords.Update(target);
            await _context.SaveChangesAsync();

            return Response<Guid>.Ok(target.Id, "Record updated successfully");
        }

        public async Task<Response<bool>> DeleteRecord(DuckRecordRequest request)
        {
            var accessResponse = await CanAccessRecord(request);
            if (accessResponse == null || !accessResponse.IsSuccess)
                return Response<bool>.Error(accessResponse.Message);

            var target = await _context.DuckFeedRecords.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (target == null)
                return Response<bool>.Error("Record not found");

            _context.DuckFeedRecords.Remove(target);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Record deleted successfully");
        }

        private async Task<Response<bool>> CanAccessRecord(DuckRecordRequest request)
        {
            var target = await _context.UserAccess.FirstOrDefaultAsync(x => x.Id.ToString() == request.CreatedBy && x.Code == request.Code);
            if(target == null)
            {
                return Response<bool>.Error("Cannot access record");
            }
            else
            {
                return Response<bool>.Ok(true, "Can access record");
            }
        }
    }
}
