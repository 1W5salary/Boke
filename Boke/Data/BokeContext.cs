using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Boke.Models;

namespace Boke.Data
{
    public class BokeContext : DbContext
    {

        public BokeContext (DbContextOptions<BokeContext> options)
            : base(options)
        {

        }
        public BokeContext() { }

        public DbSet<User> User { get; set; }

        public DbSet<Article> Article { get; set; }


    }
}
