﻿using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data.Repository
{
    public class DbTravelPackageRepo : ITravelPackageRepo
    {
        ApplicationDbContext _ctx;
        public DbTravelPackageRepo(ApplicationDbContext ctx) {
            _ctx = ctx;
        }
        public void Create(TravelPackage item, List<Destination> destinations)
        {
            TravelPackage travelPackage = new TravelPackage();
            travelPackage = item;
            travelPackage.Destinations = destinations;
            _ctx.TravelPackages.Add(travelPackage);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TravelPackage Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TravelPackage> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<TravelPackage> GetAll()
        {
            return _ctx.TravelPackages.Include("Category").Include("Destinations").ToList();
        }

        public void Update(TravelPackage item, List<Destination> destinations)
        {
            throw new NotImplementedException();
        }
    }
}
