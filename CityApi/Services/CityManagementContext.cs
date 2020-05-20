using CityApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityApi.Services
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