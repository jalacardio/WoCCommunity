using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WoCMvc.Models
{
    public class WoCMvcContext : DbContext
    {
        public WoCMvcContext (DbContextOptions<WoCMvcContext> options)
            : base(options)
        {
        }

        public DbSet<WoCMvc.Models.Member> Member { get; set; }
    }
}
