using CityApi.Models;
using CityApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityApi.Data
{
    public class CityManagementContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
        
        private readonly IUserInfoService _userInfoService;

        //public TourManagementContext(DbContextOptions<TourManagementContext> options )
        //  : base(options)
        //{ 

        //}
        public CityManagementContext(DbContextOptions<CityManagementContext> options,
            IUserInfoService userInfoService)
           : base(options)
        {
            // userInfoService is a required argument
            _userInfoService = userInfoService ?? throw new ArgumentNullException(nameof(userInfoService));
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>().ToTable("City");
        //    modelBuilder.Entity<PointOfInterest>().ToTable("PointOfInterest");

        //    //modelBuilder.Entity<City>().HasData(
        //    //    new City()
        //    //    {
        //    //        CityId = 1,
        //    //        Name = "Gama",
        //    //        Description = "The Villains World City.",
        //    //        IsCapital = false,
        //    //        PointsOfInterest = new List<PointOfInterest>()
        //    //        {
        //    //            new PointOfInterest() {
        //    //                PointOfInterestId = 1,
        //    //                Name = "Cine Itapuã",
        //    //                Description = "Cinema da Cidade aponsetado"//,
        //    //                //CityId = 1
        //    //            },
        //    //            new PointOfInterest() {
        //    //                PointOfInterestId = 2,
        //    //                Name = "Igreja São Sebastião",
        //    //                Description = "Paróquia da Cidade"//,
        //    //                //CityId = 1
        //    //            },
        //    //            new PointOfInterest() {
        //    //                PointOfInterestId = 3,
        //    //                Name = "Sayonara",
        //    //                Description = "Referência Entrada da Cidade"//,
        //    //                //CityId = 1
        //    //            }
        //    //        }
        //    //    },
        //    //    new City()
        //    //    {
        //    //        //CityId = 2,
        //    //        Name = "Octogonal",
        //    //        Description = "The Middle City.",
        //    //        IsCapital = false,
        //    //        PointsOfInterest = new List<PointOfInterest>()
        //    //        {
        //    //            new PointOfInterest() {
        //    //                PointOfInterestId = 1,
        //    //                Name = "Terraço Shopping",
        //    //                Description = "Shopping da Cidade"//,
        //    //                //CityId = 2
        //    //            },
        //    //            new PointOfInterest() {
        //    //                PointOfInterestId = 2,
        //    //                Name = "HFA",
        //    //                Description = "Hospital da Cidade"//,
        //    //                //CityId = 2
        //    //            }
        //    //        }
        //    //    }
        //    //    );
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // get added or updated entries
            var addedOrUpdatedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            //// fill out the audit fields
            //foreach (var entry in addedOrUpdatedEntries)
            //{
            //    var entity = entry.Entity as AuditableEntity;

            //    if (entry.State == EntityState.Added)
            //    {
            //        entity.CreatedBy = _userInfoService.UserId;
            //        entity.CreatedOn = DateTime.UtcNow;
            //    }

            //    entity.UpdatedBy = _userInfoService.UserId;
            //    entity.UpdatedOn = DateTime.UtcNow;
            //}

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}