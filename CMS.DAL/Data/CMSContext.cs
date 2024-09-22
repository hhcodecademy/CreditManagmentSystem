using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Data
{
    public class CMSContext:DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options):base(options)
        {
            
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
