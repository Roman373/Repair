using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCar.Model;

namespace WpfCar
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
        public DbSet<ConductWorks> ConductWorks { get; set; }
        public DbSet<EngineTypes> EngineTypes { get; set; }
        public DbSet<Repairs> Repairs { get; set; }
        public ApplicationContext() : base("CarConnection") { }
    }
}
