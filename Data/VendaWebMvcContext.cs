using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendaWebMvc.Models
{
    public class VendaWebMvcContext : DbContext
    {
        public VendaWebMvcContext (DbContextOptions<VendaWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<VendaWebMvc.Models.Department> Department { get; set; } = default!;
    }
}
