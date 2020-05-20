using CityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityApi.Services
{
    public static class CityManagementContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityManagementContext context)
        {
            // first, clear the database.  This ensures we can always start 
            // fresh with each demo.  Not advised for production environments, obviously :-)
            context.Cities.RemoveRange(context.Cities);
            
            context.SaveChanges();

            // init seed data
            var cities = new List<City>()
            {
                new City()
                {
                    CityId = 1,
                    Name = "Gama",
                    Description = "The Villains World City.",
                    IsCapital = false,
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest() {
                            PointsOfInterestId = 1,
                            Name = "Cine Itapuã",
                            Description = "Cinema da Cidade aponsetado"
                        },
                        new PointOfInterest() {
                            PointsOfInterestId = 2,
                            Name = "Igreja São Sebastião",
                            Description = "Paróquia da Cidade"
                        },
                        new PointOfInterest() {
                            PointsOfInterestId = 3,
                            Name = "Sayonara",
                            Description = "Referência Entrada da Cidade"
                        }
                    }
                },
                new City()
                {
                    CityId = 2,
                    Name = "Octogonal",
                    Description = "The Middle City.",
                    IsCapital = false,
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest() {
                            PointsOfInterestId = 1,
                            Name = "Terraço Shopping",
                            Description = "Shopping da Cidade"
                        },
                        new PointOfInterest() {
                            PointsOfInterestId = 2,
                            Name = "HFA",
                            Description = "Hospital da Cidade"
                        }
                    }
                }
             };

            context.Cities.AddRange(cities);

            context.SaveChanges();
        }
    }
}