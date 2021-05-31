using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SuperInovacoes.Business.Models;
using SuperInovacoes.Data.Data.Mappings;

namespace SuperInovacoes.Data.Data
{
    public class DataContext : DbContext
    {
       // public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=111.111.11.11;Database=ProvaSuperInovacoes;user=Bruno;password=xxxxxxxx;",
                p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))// utilizado para dividir a consulta e otimizar o trafego de dados
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);//desabilita o track de consultas porem mantem
                                                                                                  //a identidade da consulta, mantendo a performace da consulta aonde o notracking nao tem.
                                                                                                  //  .EnableSensitiveDataLogging(); mostra variaveis de parametros no entity framework(pode conter dados sensiveis)
                                                                                                  //  .EnableDetailedErrors(); erros detalhados relacionados a modelo de dados e variaveis,


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMappings());
          

        }





    }
}
