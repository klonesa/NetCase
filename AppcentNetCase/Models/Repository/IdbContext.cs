using AppcentNetCase.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppcentNetCase.Models.Repository
{
    public interface IdbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Tasks> Tasks { get; set; }
        DbSet<Project> Projects { get; set; }


        int SaveChange();
    }
}
