using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WallFertas.Domains;

#nullable disable

namespace WallFertas.Contexts
{
    public partial class WallFertas_Context : DbContext
    {
        public WallFertas_Context()
        {
        }

        public WallFertas_Context(DbContextOptions<WallFertas_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<TiposProduto> TipoProdutos { get; set; }
        public virtual DbSet<TiposUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //optionsBuilder.UseSqlServer("Data Source=Daniel-PC\\SQLEXPRESS; Initial Catalog= WallFertas; user Id=sa; pwd=senai@132;");
                optionsBuilder.UseSqlServer("Data Source=Daniel-PC\\SQLEXPRESS; Initial Catalog= WallFertas; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Comentarios>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__Comentar__DDBEFBF987FD888C");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Comentari__IdPro__412EB0B6");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresas__5EF4033EB6FE440E");

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produtos__2E883C23D5CA7707");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Validade).HasColumnType("date");

                entity.HasOne(d => d.IdTipoProdutoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdTipoProduto)
                    .HasConstraintName("FK__Produtos__IdTipo__3E52440B");
            });

            modelBuilder.Entity<TiposProduto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProduto)
                    .HasName("PK__TipoProd__F71CDF61A97557EA");

                entity.Property(e => e.TituloTipoProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BF8685771");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97F6C4D2EF");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053459BCDE8D")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
