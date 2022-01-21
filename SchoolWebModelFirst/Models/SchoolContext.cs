using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolWebModelFirst.Models
{
    public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        //this is where you add another table
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (
                    @"Server=(localdb)\mssqllocaldb;Database=SchoolMVC;Trusted_Connection=True;"
                );
        }
    }
}
