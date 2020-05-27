using CityApi.Data;
using CityApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApi.Services
{
    public class CityManagementRepository: ICityManagementRepository
    {
        private CityManagementContext _context;

        public CityManagementRepository(CityManagementContext context)
        {
            _context = context;
        }

        public async Task<bool> CityExists(int cityId)
        {
            return await _context.Cities.AnyAsync(c => c.CityId == cityId);
        }

        public async Task<IEnumerable<City>> GetCities(bool includePointsOfInterest = false)
        {
            if (includePointsOfInterest)
            {
                return await _context.Cities.Include(p => p.PointsOfInterest).ToListAsync();
            }
            else
            {
                return await _context.Cities.ToListAsync();
            }
        }

        //public async Task<IEnumerable<City>> GetCitiesForManager(Guid managerId, bool includeShows = false)
        //{
        //    if (includeShows)
        //    {
        //        return await _context.Cities.Where(t => t.ManagerId == managerId)
        //            .Include(t => t.Band).Include(t => t.Shows).ToListAsync();
        //    }
        //    else
        //    {
        //        return await _context.Cities.Where(t => t.ManagerId == managerId)
        //            .Include(t => t.Band).ToListAsync();
        //    }
        //}

        public async Task<City> GetCity(int cityId, bool includePointsOfInterest = false)
        {
            if (includePointsOfInterest)
            {
                return await _context.Cities.Include(p => p.PointsOfInterest)
                    .Where(c => c.CityId == cityId).FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Cities.Where(c => c.CityId == cityId).FirstOrDefaultAsync();
            }
        }

        //public async Task<bool> IsCityManager(Guid cityId, Guid managerId)
        //{
        //    return await _context.Cities.AnyAsync(t => t.CityId == cityId && t.ManagerId == managerId);
        //}

        public async Task AddCity(City city)
        {
            await _context.Cities.AddAsync(city);
        }

#pragma warning disable 1998
        // disable async warning - no code 
        public async Task UpdateCity(City city)
        {
            //var cityExist = await _context.Cities.Where(c => c.CityId == city.CityId).SingleAsync();
            //if (!cityExist) return NotFoundResult;

            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
#pragma warning restore 1998

#pragma warning disable 1998
        // disable async warning - no RemoveAsync available
        public async Task DeleteCity(City tour)
        {
            _context.Cities.Remove(tour);
        }
#pragma warning restore 1998

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCity(int cityId)
        {
            return await _context.PointsOfInterest.Where(c => c.CityId == cityId).ToListAsync();
        }

        //public async Task<IEnumerable<Show>> GetShows(Guid cityId, IEnumerable<Guid> showIds)
        //{
        //    return await _context.Shows
        //         .Where(s => s.CityId == cityId && showIds.Contains(s.ShowId)).ToListAsync();
        //}


        public async Task AddPointOfInterest(int cityId, PointOfInterest pointOfInterest)
        {
            var city = await GetCity(cityId);
            if (city == null)
            {
                // throw an exception - this is a race condition
                // that's mostly caught by checking if the tour exists
                // right before calling into this method - if that method is not
                // called the condition can happen, otherwise the tour
                // will already be loaded on the context
                throw new Exception($"Cannot add Point Of Interest to city with id {cityId}: city not found.");
            }
            city.PointsOfInterest.Add(pointOfInterest);
        }

        //public async Task<IEnumerable<Band>> GetBands()
        //{
        //    return await _context.Bands.ToListAsync();
        //}

        //public async Task<IEnumerable<Manager>> GetManagers()
        //{
        //    return await _context.Managers.ToListAsync();
        //}

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
