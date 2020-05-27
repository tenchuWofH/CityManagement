using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityApi.Models;
using CityApi.Models.Form;
using CityApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityManagementRepository _cityManagementRepository;
        private IMapper _mapper;

        public CityController(ICityManagementRepository cityManagementRepository, IMapper mapper)
        {
            _cityManagementRepository = cityManagementRepository;
            _mapper = mapper;
        }

        //[HttpGet(Name = "GetCities")]
        [HttpGet]
        public async Task<IActionResult> GetCities(bool includePointsOfInterest = false)
        {
            
            var citiesFromRepo = await _cityManagementRepository.GetCities(includePointsOfInterest);

            var cities = _mapper.Map<IEnumerable<City>>(citiesFromRepo);
            return Ok(cities);
        }

        //[HttpGet(Name = "GetCityWithPoints")]
        //public async Task<IActionResult> GetCities()
        //{

        //    var citiesFromRepo = await _cityManagementRepository.GetCities(true);

        //    var cities = _mapper.Map<IEnumerable<City>>(citiesFromRepo);
        //    return Ok(cities);
        //}

        [HttpGet("{cityId}", Name = "GetCity")]
        public async Task<IActionResult> GetCity(int cityId, bool includePointsOfInterest = false)
        {
            var cityFromRepo = await _cityManagementRepository.GetCity(cityId, includePointsOfInterest);

            if (cityFromRepo == null)
            {
                return BadRequest();
            }

            var city = _mapper.Map<City>(cityFromRepo);

            return Ok(city);
        }

        [HttpPost]
        //[RequestHeaderMatchesMediaType("Content-Type",
        //    new[] { "application/json",
        //            "application/vnd.marvin.cityforcreation+json" })]
        public async Task<IActionResult> AddCity([FromBody] CityForCreation city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            // validation of the DTO happens here

            return await AddSpecificCity(city);
        }

        [HttpPost]
        //[RequestHeaderMatchesMediaType("Content-Type",
        //    new[] { "application/json",
        //            "application/vnd.marvin.cityforcreation+json" })]
        public async Task<IActionResult> UpdateCity([FromBody] CityForUpdate city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            // validation of the DTO happens here

            return await AddSpecificCity(city);
        }

        private async Task<IActionResult> GetSpecificCity<T>(int cityId, bool includePointsOfInterest = false) where T : class
        {
            var cityFromRepo = await _cityManagementRepository.GetCity(cityId, includePointsOfInterest);

            if (cityFromRepo == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<T>(cityFromRepo));
        }

        public async Task<IActionResult> AddSpecificCity<T>(T city) where T : class
        {
            var cityEntity = _mapper.Map<City>(city);

            //if (cityEntity.CityId == int.)
            //{
            //    cityEntity.CityId = new int("fec0a4d6-5830-4eb8-8024-272bd5d6d2bb");
            //}

            await _cityManagementRepository.AddCity(cityEntity);

            if (!await _cityManagementRepository.SaveAsync())
            {
                throw new Exception("Adding a city failed on save.");
            }

            var cityToReturn = _mapper.Map<City>(cityEntity);

            return CreatedAtRoute("GetCity",
                new { cityId = cityToReturn.CityId },
                cityToReturn);
        }

        //[HttpGet("{cityId}")]
        //public async Task<IActionResult> GetDefaultCity(int cityId)
        //{
        //    if (Request.Headers.TryGetValue("Accept",
        //        out StringValues values))
        //    {
        //        Debug.WriteLine($"Accept header(s): {string.Join(",", values)}");
        //    }

        //    return await GetSpecificCity<City>(cityId);
        //}

        //[HttpGet("{cityId}", Name = "GetCity")]
        //[RequestHeaderMatchesMediaType("Accept",
        //    new[] { "application/vnd.marvin.city+json" })]
        //public async Task<IActionResult> GetCity(int cityId)
        //{
        //    return await GetSpecificCity<City>(cityId);
        //}

        //[HttpGet("{cityId}")]
        //[RequestHeaderMatchesMediaType("Accept",
        //    new[] { "application/vnd.marvin.citywithestimatedprofits+json" })]
        //public async Task<IActionResult> GetCityWithEstimatedProfits(int cityId)
        //{
        //    return await GetSpecificCity<CityWithEstimatedProfits>(cityId);
        //}

        //[HttpGet("{cityId}")]
        //[RequestHeaderMatchesMediaType("Accept",
        //    new[] { "application/vnd.marvin.citywithshows+json" })]
        //public async Task<IActionResult> GetCityWithShows(int cityId)
        //{
        //    return await GetSpecificCity<CityWithShows>(cityId, true);
        //}

        //[HttpGet("{cityId}")]
        //[RequestHeaderMatchesMediaType("Accept",
        //    new[] { "application/vnd.marvin.citywithestimatedprofitsandshows+json" })]
        //public async Task<IActionResult> GetCityWithEstimatedProfitsAndShows(int cityId)
        //{
        //    return await GetSpecificCity<CityWithEstimatedProfitsAndShows>(cityId, true);
        //}


        //[HttpPost]
        //[RequestHeaderMatchesMediaType("Content-Type",
        //    new[] { "application/vnd.marvin.citywithmanagerforcreation+json" })]
        //public async Task<IActionResult> AddCityWithManager(
        //    [FromBody] CityWithManagerForCreation city)
        //{
        //    if (city == null)
        //    {
        //        return BadRequest();
        //    }

        //    // validation of the DTO happens here

        //    return await AddSpecificCity(city);
        //}

        //[HttpPost]
        //[RequestHeaderMatchesMediaType("Content-Type",
        //    new[] { "application/vnd.marvin.citywithshowsforcreation+json" })]
        //public async Task<IActionResult> AddCityWithShows(
        //    [FromBody] CityWithShowsForCreation city)
        //{
        //    if (city == null)
        //    {
        //        return BadRequest();
        //    }

        //    // validation of the DTO happens here

        //    // the rest is the same as for other actions. 
        //    return await AddSpecificCity(city);
        //}

        //[HttpPost]
        //[RequestHeaderMatchesMediaType("Content-Type",
        //    new[] { "application/vnd.marvin.citywithmanagerandshowsforcreation+json" })]
        //public async Task<IActionResult> AddCityWithManagerAndShows(
        //    [FromBody] CityWithManagerAndShowsForCreation city)
        //{
        //    if (city == null)
        //    {
        //        return BadRequest();
        //    }

        //    // validation of the DTO happens here

        //    // the rest is the same as for other actions. 
        //    return await AddSpecificCity(city);
        //}
    }
}
