using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Mall.Models;

namespace Mall.DAL
{
    public class DataBase:DbContext
    {
        public DataBase() : base("DbMall")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Footprint>().ToTable("Footprint");
        }
        public DbSet<Users> UsersDAL { get; set; }
        public DbSet<Footprint> FootprintDAL { get; set; }
    }
}