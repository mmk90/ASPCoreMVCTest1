using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Data
{
    public class WebsiteDatabaseContext:DbContext
    {
        public WebsiteDatabaseContext(DbContextOptions<WebsiteDatabaseContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
