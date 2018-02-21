using ModeloDDD.Domain.Entities;
using System.Data.Entity;

namespace ModeloDDD.Infra.Data.Context
{
    public class ModeloDDDContext : DbContext
    {
        public ModeloDDDContext() : base("ModeloDDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
