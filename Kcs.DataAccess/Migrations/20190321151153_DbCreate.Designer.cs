﻿// <auto-generated />
using System;
using Kcs.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kcs.DataAccess.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    [Migration("20190321151153_DbCreate")]
    partial class DbCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kcs.Entity.Concrete.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistrictId");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("PersonBirthday");

                    b.Property<string>("PersonEmail")
                        .IsRequired();

                    b.Property<string>("PersonName")
                        .IsRequired();

                    b.Property<string>("PersonPhone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("PersonSurname")
                        .IsRequired();

                    b.Property<int>("ProvinceId");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
