using Ateliex.Areas.Cadastro.Models;
using Ateliex.Areas.Comercial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ateliex.Data
{
    public class AteliexDbContextFactory : IDesignTimeDbContextFactory<AteliexDbContext>
    {
        public AteliexDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AteliexDbContext>();
            optionsBuilder.UseSqlite(@"Data Source=Ateliex.db");

            return new AteliexDbContext(optionsBuilder.Options);
        }
    }

    public class AteliexDbContext : DbContext
    {
        public DbSet<Modelo> ModeloSet { get; set; }
        
        public DbSet<ModeloRecursoTipo> ModeloRecursoTipoSet { get; set; }

        public DbSet<PlanoComercial> PlanoComercialSet { get; set; }

        public AteliexDbContext(DbContextOptions<AteliexDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(@"Data Source=Ateliex.db");

            //optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Modelo>()
            //    .HasKey(p => p.Codigo);

            modelBuilder.Entity<Modelo>().ToTable("Modelo", "cadastro");
            modelBuilder.Entity<Modelo>().Ignore(p => p.State);

            //modelBuilder.Entity<Recurso>().HasKey(p => new { p.ModeloId, p.Id });

            modelBuilder.Entity<ModeloRecurso>().ToTable("ModeloRecurso", "cadastro");
            modelBuilder.Entity<ModeloRecurso>().Ignore(p => p.State);

            modelBuilder.Entity<ModeloRecursoTipo>().Property(a => a.Id).ValueGeneratedNever();

            modelBuilder.Entity<PlanoComercial>().Ignore(p => p.State);

            //modelBuilder.Entity<PlanoComercialCusto>().HasKey(p => new { p.PlanoComercialId, p.Id });

            modelBuilder.Entity<PlanoComercialCusto>().Ignore(p => p.State);

            modelBuilder.Entity<PlanoComercialCustoTipo>().ToTable("PlanoComercialCustoTipo", "cadastro");
            modelBuilder.Entity<PlanoComercialCustoTipo>().Property(a => a.Id).ValueGeneratedNever();

            //modelBuilder.Entity<PlanoComercialItem>().HasKey(p => new { p.PlanoComercialId, p.ModeloId });

            modelBuilder.Entity<PlanoComercialItem>().Ignore(p => p.State);

            // Seed.

            modelBuilder.Entity<Modelo>().HasData(
                new Modelo { Id = 1, Nome = "Tati Model 01" },
                new Modelo { Id = 2, Nome = "Tati Model 02" },
                new Modelo { Id = 3, Nome = "Tati Model 03" },
                new Modelo { Id = 4, Nome = "Tati Model 04" },
                new Modelo { Id = 5, Nome = "Tati Model 05" },
                new Modelo { Id = 6, Nome = "Tati Model 06" },
                new Modelo { Id = 7, Nome = "Tati Model 07" },
                new Modelo { Id = 8, Nome = "Tati Model 08" },
                new Modelo { Id = 9, Nome = "Tati Model 09" },
                new Modelo { Id = 10, Nome = "Tati Model 10" }
            );

            modelBuilder.Entity<ModeloRecursoTipo>().HasData(
                new ModeloRecursoTipo { Id = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Nome = "Material" },
                new ModeloRecursoTipo { Id = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Transporte, Nome = "Transporte" },
                new ModeloRecursoTipo { Id = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Humano, Nome = "Humano" }
            );

            modelBuilder.Entity<ModeloRecurso>().HasData(
                new ModeloRecurso { Id = 1, ModeloId = 1, TipoId = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Descricao = "Tecido", Custo = 20, Unidades = 2 },
                new ModeloRecurso { Id = 2, ModeloId = 1, TipoId = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Descricao = "Linha", Custo = 4, Unidades = 20 },
                new ModeloRecurso { Id = 3, ModeloId = 1, TipoId = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Material, Descricao = "Outros", Custo = 5, Unidades = 1 },
                new ModeloRecurso { Id = 4, ModeloId = 1, TipoId = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Transporte, Descricao = "Transporte", Custo = 100, Unidades = 50 },
                new ModeloRecurso { Id = 5, ModeloId = 1, TipoId = (int)Ateliex.Areas.Cadastro.Enums.ModeloRecursoTipo.Humano, Descricao = "Costureira", Custo = 5, Unidades = 1 }
            );

            modelBuilder.Entity<PlanoComercial>().HasData(
                new PlanoComercial { Id = 1, Nome = "Normal", RendaBrutaMensal = 6000 },
                new PlanoComercial { Id = 2, Nome = "Moderado" },
                new PlanoComercial { Id = 3, Nome = "Ousado" }
            );

            modelBuilder.Entity<PlanoComercialCustoTipo>().HasData(
                new PlanoComercialCustoTipo { Id = Ateliex.Areas.Comercial.Enums.PlanoComercialCustoTipo.Fixo, Nome = "Fixo" },
                new PlanoComercialCustoTipo { Id = Ateliex.Areas.Comercial.Enums.PlanoComercialCustoTipo.Variavel, Nome = "Variável" }
            );

            modelBuilder.Entity<PlanoComercialCusto>().HasData(
                new PlanoComercialCusto { Id = 1, PlanoComercialId = 1, TipoId = Ateliex.Areas.Comercial.Enums.PlanoComercialCustoTipo.Fixo, Descricao = "Prolabore", Valor = 1000 },
                new PlanoComercialCusto { Id = 2, PlanoComercialId = 1, TipoId = Ateliex.Areas.Comercial.Enums.PlanoComercialCustoTipo.Fixo, Descricao = "Aluguel", Valor = 900 },
                new PlanoComercialCusto { Id = 3, PlanoComercialId = 1, TipoId = Ateliex.Areas.Comercial.Enums.PlanoComercialCustoTipo.Variavel, Descricao = "Cartão", Percentual = 10 },
                new PlanoComercialCusto { Id = 4, PlanoComercialId = 1, TipoId = Ateliex.Areas.Comercial.Enums.PlanoComercialCustoTipo.Variavel, Descricao = "Comissão", Percentual = 10 },
                new PlanoComercialCusto { Id = 5, PlanoComercialId = 1, TipoId = Ateliex.Areas.Comercial.Enums.PlanoComercialCustoTipo.Variavel, Descricao = "Perda", Percentual = 2 }
            );

            modelBuilder.Entity<PlanoComercialItem>().HasData(
                new PlanoComercialItem { Id = 1, PlanoComercialId = 1, ModeloId = 1, MargemPercentual = 1.93m },
                new PlanoComercialItem { Id = 2, PlanoComercialId = 1, ModeloId = 2 },
                new PlanoComercialItem { Id = 3, PlanoComercialId = 1, ModeloId = 3 },
                new PlanoComercialItem { Id = 4, PlanoComercialId = 1, ModeloId = 10 },
                new PlanoComercialItem { Id = 5, PlanoComercialId = 2, ModeloId = 1 },
                new PlanoComercialItem { Id = 6, PlanoComercialId = 2, ModeloId = 2 },
                new PlanoComercialItem { Id = 7, PlanoComercialId = 2, ModeloId = 3 },
                new PlanoComercialItem { Id = 8, PlanoComercialId = 2, ModeloId = 4 },
                new PlanoComercialItem { Id = 9, PlanoComercialId = 2, ModeloId = 5 },
                new PlanoComercialItem { Id = 10, PlanoComercialId = 2, ModeloId = 6 },
                new PlanoComercialItem { Id = 11, PlanoComercialId = 2, ModeloId = 7 },
                new PlanoComercialItem { Id = 12, PlanoComercialId = 2, ModeloId = 8 },
                new PlanoComercialItem { Id = 13, PlanoComercialId = 2, ModeloId = 9 },
                new PlanoComercialItem { Id = 14, PlanoComercialId = 2, ModeloId = 10 },
                new PlanoComercialItem { Id = 15, PlanoComercialId = 3, ModeloId = 5 },
                new PlanoComercialItem { Id = 16, PlanoComercialId = 3, ModeloId = 6 },
                new PlanoComercialItem { Id = 17, PlanoComercialId = 3, ModeloId = 7 },
                new PlanoComercialItem { Id = 18, PlanoComercialId = 3, ModeloId = 8 },
                new PlanoComercialItem { Id = 19, PlanoComercialId = 3, ModeloId = 9 },
                new PlanoComercialItem { Id = 20, PlanoComercialId = 3, ModeloId = 10 }
           );
        }
    }
}
