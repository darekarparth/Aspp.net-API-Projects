﻿using Microsoft.EntityFrameworkCore;
using StateInfo.API.Contexts;
using StateInfo.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;//field 

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        //public IEnumerable<City> GetCities()
        //{
        //    return _context.Cities.OrderBy(c => c.Name).ToList();//the cities returned are ordered by Name// ToList() ensures that thae query is executed at the specific time.
        //}

        //public City GetCity(int cityId, bool includePointsOfInterest)
        //{
        //    if (includePointsOfInterest)
        //    {
        //        return _context.Cities.Include(c => c.PointsOfInterest)
        //            .Where(c => c.Id == cityId).FirstOrDefault();
        //    }

        //    return _context.Cities
        //            .Where(c => c.Id == cityId).FirstOrDefault();
        //}

        //public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        //{
        //    return _context.PointsOfInterest
        //  .Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        //}


        //public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        //{
        //    return _context.PointsOfInterest
        //                .Where(p => p.CityId == cityId).ToList();
        //}


       

        //public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        //{
        //    var city = GetCity(cityId, false);
        //    // city.PointsOfInterest.Add(pointOfInterest);
        //}

        //public void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        //{

        //}

        //public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        //{
        //    _context.PointsOfInterest.Remove(pointOfInterest);
        //}

        //public bool Save()
        //{
        //    return (_context.SaveChanges() >= 0);
        //}



        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefault();
            }

            return _context.Cities
                    .Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestsForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest
           .Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestsForCity(int cityId)
        {
            return _context.PointsOfInterest
                        .Where(p => p.CityId == cityId).ToList();
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }


        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
               city.PointsOfInterest.Add(pointOfInterest);
        }

        public void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {

        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
