using AppcentNetCase.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppcentNetCase.Models.Repository
{
    public class DBContext : DbContext, IdbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public int SaveChange()
        {
            return 0;
        }
    }
}
