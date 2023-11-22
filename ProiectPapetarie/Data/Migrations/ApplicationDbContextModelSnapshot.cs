﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectPapetarie.Data;

#nullable disable

namespace ProiectPapetarie.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProiectPapetarie.Models.Categorie", b =>
                {
                    b.Property<int>("IDCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCategorie"));

                    b.Property<string>("DenumireCategorie")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IDCategorie");

                    b.ToTable("Categorii");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.Comanda", b =>
                {
                    b.Property<int>("IDComanda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDComanda"));

                    b.Property<DateTime>("DataCreare")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDStatusComanda")
                        .HasColumnType("int");

                    b.Property<string>("IDUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("StatusComandaIDStatusComanda")
                        .HasColumnType("int");

                    b.HasKey("IDComanda");

                    b.HasIndex("StatusComandaIDStatusComanda");

                    b.ToTable("Comenzi");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.CosCumparaturi", b =>
                {
                    b.Property<int>("IDCos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCos"));

                    b.Property<string>("IDUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("IDCos");

                    b.ToTable("CosuriCumparaturi");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.DetaliiComanda", b =>
                {
                    b.Property<int>("IDDetaliiComanda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDetaliiComanda"));

                    b.Property<int>("Cantitate")
                        .HasColumnType("int");

                    b.Property<int>("ComandaIDComanda")
                        .HasColumnType("int");

                    b.Property<int>("IDComanda")
                        .HasColumnType("int");

                    b.Property<int>("IDProdus")
                        .HasColumnType("int");

                    b.Property<double>("PretBucata")
                        .HasColumnType("float");

                    b.Property<int>("ProdusIDProdus")
                        .HasColumnType("int");

                    b.HasKey("IDDetaliiComanda");

                    b.HasIndex("ComandaIDComanda");

                    b.HasIndex("ProdusIDProdus");

                    b.ToTable("DetaliiComenzi");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.DetaliiCosCump", b =>
                {
                    b.Property<int>("IDDetalii")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDetalii"));

                    b.Property<int>("Cantitate")
                        .HasColumnType("int");

                    b.Property<int>("CosCumparaturiIDCos")
                        .HasColumnType("int");

                    b.Property<int>("IDCosC")
                        .HasColumnType("int");

                    b.Property<int>("IDProdus")
                        .HasColumnType("int");

                    b.Property<double>("Pret")
                        .HasColumnType("float");

                    b.Property<int>("ProdusIDProdus")
                        .HasColumnType("int");

                    b.HasKey("IDDetalii");

                    b.HasIndex("CosCumparaturiIDCos");

                    b.HasIndex("ProdusIDProdus");

                    b.ToTable("DetaliiCosCump");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.Produs", b =>
                {
                    b.Property<int>("IDProdus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDProdus"));

                    b.Property<int>("CategorieIDCategorie")
                        .HasColumnType("int");

                    b.Property<string>("DenumireProdus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriereProdus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDCategorie")
                        .HasColumnType("int");

                    b.Property<string>("ImagineProdus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PretProdus")
                        .HasColumnType("float");

                    b.HasKey("IDProdus");

                    b.HasIndex("CategorieIDCategorie");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.StatusComanda", b =>
                {
                    b.Property<int>("IDStatusComanda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDStatusComanda"));

                    b.Property<int>("IDStatus")
                        .HasColumnType("int");

                    b.Property<string>("numeStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IDStatusComanda");

                    b.ToTable("StatusuriComenzi");
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

            modelBuilder.Entity("ProiectPapetarie.Models.Comanda", b =>
                {
                    b.HasOne("ProiectPapetarie.Models.StatusComanda", "StatusComanda")
                        .WithMany()
                        .HasForeignKey("StatusComandaIDStatusComanda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusComanda");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.DetaliiComanda", b =>
                {
                    b.HasOne("ProiectPapetarie.Models.Comanda", "Comanda")
                        .WithMany("DetaliiComanda")
                        .HasForeignKey("ComandaIDComanda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectPapetarie.Models.Produs", "Produs")
                        .WithMany("DetaliiComanda")
                        .HasForeignKey("ProdusIDProdus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Produs");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.DetaliiCosCump", b =>
                {
                    b.HasOne("ProiectPapetarie.Models.CosCumparaturi", "CosCumparaturi")
                        .WithMany("detaliiCosCumps")
                        .HasForeignKey("CosCumparaturiIDCos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProiectPapetarie.Models.Produs", "Produs")
                        .WithMany("DetaliiCosCump")
                        .HasForeignKey("ProdusIDProdus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CosCumparaturi");

                    b.Navigation("Produs");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.Produs", b =>
                {
                    b.HasOne("ProiectPapetarie.Models.Categorie", "Categorie")
                        .WithMany("Produse")
                        .HasForeignKey("CategorieIDCategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.Categorie", b =>
                {
                    b.Navigation("Produse");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.Comanda", b =>
                {
                    b.Navigation("DetaliiComanda");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.CosCumparaturi", b =>
                {
                    b.Navigation("detaliiCosCumps");
                });

            modelBuilder.Entity("ProiectPapetarie.Models.Produs", b =>
                {
                    b.Navigation("DetaliiComanda");

                    b.Navigation("DetaliiCosCump");
                });
#pragma warning restore 612, 618
        }
    }
}
