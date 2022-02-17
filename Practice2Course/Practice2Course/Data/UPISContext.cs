using Microsoft.EntityFrameworkCore;
using Practice2Course.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2Course.Data
{
    public class UPISContext : DbContext
    {
        // Страны
        public DbSet<Countries> AllCountries { get; set; }
        // Города
        public DbSet<Cities> AllCities { get; set; }
        // Типы объектов
        public DbSet<UrbanType> AllUrbanTypes { get; set; }
        // Объекты города
        public DbSet<UrbanObject> AllUrbanObjects { get; set; }
        // Типы улиц
        public DbSet<RoadType> AllRoadTypes { get; set; }
        // Все дороги
        public DbSet<RoadSystem> AllRoads { get; set; }

        public UPISContext(DbContextOptions<UPISContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
