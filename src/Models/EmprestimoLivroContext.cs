﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMPRESTIMO.LIVROS.Models
{
    public partial class EmprestimoLivroContext : DbContext
    {
        public EmprestimoLivroContext()
        {
        }

        public EmprestimoLivroContext(DbContextOptions<EmprestimoLivroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ANALISTA_MAIN")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
            {
                entity.Property(e => e.Lceentregue).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}