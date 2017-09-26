using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasicApp1.Models;

namespace BasicApp1.Models
{
    public class BasicApp1Context : DbContext
    {
        public BasicApp1Context (DbContextOptions<BasicApp1Context> options)
            : base(options)
        {
        }

        public DbSet<BasicApp1.Models.Movie> Movie { get; set; }

        public DbSet<BasicApp1.Models.Class> Class { get; set; }
    }
}
