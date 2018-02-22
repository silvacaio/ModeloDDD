using ModeloDDD.Domain.Entities;
using ModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloDDD.Infra.Data.Context
{
    public class ModeloDDDContext : DbContext
    {
        public ModeloDDDContext() : base("ModeloDDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Configurando chaves da tabela, propriedades que terminam com "id"
            modelBuilder.Properties()
                .Where(a => a.Name == a.ReflectedType.Name + "Id")
                .Configure(a => a.IsKey());

            modelBuilder.Properties<string>()
                .Configure(a => a.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(a => a.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}
