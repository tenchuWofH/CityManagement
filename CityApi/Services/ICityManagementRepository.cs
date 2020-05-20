using CityApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApi.Services
{
    public interface ICityManagementRepository
    {
        Task<bool> CityExists(int cityId);
        Task<IEnumerable<City>> GetCities(bool includePointsOfInterest = false);
        Task<City> GetCity(int cityId, bool includePointsOfInterest = false);
        Task AddCity(City city);
        Task UpdateCity(City city);
        Task DeleteCity(City city);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCity(int cityId);
        Task AddPointOfInterest(int cityId, PointOfInterest pointOfInterest);
        Task<bool> SaveAsync();
    }
}
