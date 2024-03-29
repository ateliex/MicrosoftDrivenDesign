﻿// <auto-generated />
using System;
using Ateliex.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ateliex.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Modelo", "cadastro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tati Model 01"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Tati Model 02"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Tati Model 03"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Tati Model 04"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Tati Model 05"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Tati Model 06"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Tati Model 07"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Tati Model 08"
                        },
                        new
                        {
                            Id = 9,
                            Nome = "Tati Model 09"
                        },
                        new
                        {
                            Id = 10,
                            Nome = "Tati Model 10"
                        });
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Custo")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.Property<int>("Unidades")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.HasIndex("TipoId");

                    b.ToTable("ModeloRecurso", "cadastro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Custo = 20m,
                            Descricao = "Tecido",
                            ModeloId = 1,
                            TipoId = 1,
                            Unidades = 2
                        },
                        new
                        {
                            Id = 2,
                            Custo = 4m,
                            Descricao = "Linha",
                            ModeloId = 1,
                            TipoId = 1,
                            Unidades = 20
                        },
                        new
                        {
                            Id = 3,
                            Custo = 5m,
                            Descricao = "Outros",
                            ModeloId = 1,
                            TipoId = 1,
                            Unidades = 1
                        },
                        new
                        {
                            Id = 4,
                            Custo = 100m,
                            Descricao = "Transporte",
                            ModeloId = 1,
                            TipoId = 2,
                            Unidades = 50
                        },
                        new
                        {
                            Id = 5,
                            Custo = 5m,
                            Descricao = "Costureira",
                            ModeloId = 1,
                            TipoId = 3,
                            Unidades = 1
                        });
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoAnexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Arquivo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RecursoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecursoId");

                    b.ToTable("ModeloRecursoAnexo", "cadastro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Arquivo = new byte[0],
                            Nome = "Arquivo 1",
                            RecursoId = 2
                        },
                        new
                        {
                            Id = 2,
                            Arquivo = new byte[0],
                            Nome = "Arquivo 2",
                            RecursoId = 2
                        },
                        new
                        {
                            Id = 3,
                            Arquivo = new byte[0],
                            Nome = "Arquivo 1",
                            RecursoId = 3
                        });
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoObservacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RecursoId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecursoId")
                        .IsUnique();

                    b.ToTable("ModeloRecursoObservacao", "cadastro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RecursoId = 3,
                            Texto = "Sit lorem torquent sociosqu molestie litora mauris commodo, inceptos vel dui fames tellus pulvinar curabitur luctus, faucibus integer augue pretium neque justo. senectus elementum pulvinar justo cubilia vivamus laoreet enim per, habitant ullamcorper condimentum elementum ultrices erat pretium neque ornare, proin quisque ultricies libero vulputate aliquet sollicitudin. accumsan porttitor aliquam conubia nec netus sapien euismod nam laoreet sociosqu, quisque semper nullam nostra euismod odio amet accumsan pellentesque, aenean elit convallis sodales elementum tristique dictumst vulputate mi. torquent aliquam augue condimentum pulvinar fames platea suscipit donec, conubia sodales ad viverra nam euismod vivamus bibendum, fermentum at rutrum semper augue egestas tortor."
                        });
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoTipo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ModeloRecursoTipo", "cadastro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Material"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Transporte"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Humano"
                        });
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoTipoDescricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoId")
                        .IsUnique();

                    b.ToTable("ModeloRecursoTipoDescricao", "cadastro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Texto = "Lorem ipsum urna elit aptent euismod vulputate tristique, etiam eget arcu class tempus eu id class, tristique senectus commodo aenean consequat velit. ornare nisi class torquent nunc elementum nostra elementum condimentum sapien convallis, orci aptent maecenas sed mauris pretium diam nulla quisque, metus sem integer ornare aliquam vitae taciti dictumst eros. enim sit curabitur eleifend etiam aenean quisque in quis interdum nulla dolor porta consequat etiam vehicula maecenas platea placerat vitae, bibendum nunc aenean tempor nulla ultrices nec sem sociosqu dictum iaculis aliquam vulputate pellentesque dapibus per elit. amet eu suspendisse condimentum a porttitor nulla quam proin, curabitur feugiat semper eros placerat iaculis proin, maecenas senectus quisque phasellus luctus convallis rutrum.",
                            TipoId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "identity");
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecurso", b =>
                {
                    b.HasOne("Ateliex.Areas.Cadastro.Models.Modelo", "Modelo")
                        .WithMany("Recursos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ateliex.Areas.Cadastro.Models.ModeloRecursoTipo", "Tipo")
                        .WithMany("Recursos")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Modelo");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoAnexo", b =>
                {
                    b.HasOne("Ateliex.Areas.Cadastro.Models.ModeloRecurso", "Recurso")
                        .WithMany("Anexos")
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoObservacao", b =>
                {
                    b.HasOne("Ateliex.Areas.Cadastro.Models.ModeloRecurso", "Recurso")
                        .WithOne("Observacao")
                        .HasForeignKey("Ateliex.Areas.Cadastro.Models.ModeloRecursoObservacao", "RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoTipoDescricao", b =>
                {
                    b.HasOne("Ateliex.Areas.Cadastro.Models.ModeloRecursoTipo", "Tipo")
                        .WithOne("Descricao")
                        .HasForeignKey("Ateliex.Areas.Cadastro.Models.ModeloRecursoTipoDescricao", "TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.Modelo", b =>
                {
                    b.Navigation("Recursos");
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecurso", b =>
                {
                    b.Navigation("Anexos");

                    b.Navigation("Observacao");
                });

            modelBuilder.Entity("Ateliex.Areas.Cadastro.Models.ModeloRecursoTipo", b =>
                {
                    b.Navigation("Descricao");

                    b.Navigation("Recursos");
                });
#pragma warning restore 612, 618
        }
    }
}
