using Microsoft.EntityFrameworkCore;
using PersonalTrainerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainerWeb.Data
{
    public class PersonalTrainerContext : DbContext
    {
        public PersonalTrainerContext(DbContextOptions<PersonalTrainerContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Supliment> Supliment { get; set; }
    }
}
