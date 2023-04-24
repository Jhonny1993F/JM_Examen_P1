using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JM_Examen_P1.Models;

namespace JM_Examen_P1.Data
{
    public class JM_Examen_P1Context : DbContext
    {
        public JM_Examen_P1Context (DbContextOptions<JM_Examen_P1Context> options)
            : base(options)
        {
        }

        public DbSet<JM_Examen_P1.Models.Montero> Montero { get; set; } = default!;
    }
}
