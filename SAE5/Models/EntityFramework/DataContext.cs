﻿using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> buildings { get; set; } = null!;
        public virtual DbSet<Room> rooms { get; set; } = null!;
        public virtual DbSet<RoomType> roomTypes { get; set; } = null!;
        public virtual DbSet<Door> doors { get; set; } = null!;
        public virtual DbSet<Heater> heaters { get; set; } = null!;
        public virtual DbSet<Lamp> lamps { get; set; } = null!;
        public virtual DbSet<Plug> plugs { get; set; } = null!;
        public virtual DbSet<RoomObject> roomObjects { get; set; } = null!; //to get the table of all room objects ?
        public virtual DbSet<ConnectedObject> connectedObjects { get; set; } = null!; //same as previous for connected objects ?
        public virtual DbSet<CustomObject> customObjects { get; set; } = null!;
        public virtual DbSet<Sensor6in1> sensors6In1 { get; set; } = null!;
        public virtual DbSet<Sensor9in1> sensors9In1 { get; set; } = null!;
        public virtual DbSet<SensorCO2> sensorsCO2 { get; set; } = null!;
        public virtual DbSet<Siren> sirens { get; set; } = null!;
        public virtual DbSet<Table> tables { get; set; } = null!;
        public virtual DbSet<Window> windows { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("SAE_DB_Local");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().OwnsMany(e => e.Base, d => d.ToJson());
        }
    }
}
