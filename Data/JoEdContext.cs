using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JoEdAngular2;

namespace DAL
{
    public class JoEdContext : DbContext
    {
        public JoEdContext (DbContextOptions<JoEdContext> options)
            : base(options)
        {
        }

        public DbSet<JoEdAngular2.AllMailsModel> AllMailsModel { get; set; }
    }
}
