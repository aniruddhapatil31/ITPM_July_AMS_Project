using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AMS.Models
{
    public class AMSDbContext : DbContext
    {
        public DbSet<User> Users {  get; set; } 
        public DbSet<Setting> Settings {  get; set; } 
        public DbSet<Attendance> Attendances {  get; set; } 
    }
}