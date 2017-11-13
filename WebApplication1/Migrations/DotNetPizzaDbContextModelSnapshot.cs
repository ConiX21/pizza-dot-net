﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using DotNetPizza.Data;

namespace DotNetPizza.Migrations
{
    [DbContext(typeof(DotNetPizzaDbContext))]
    partial class DotNetPizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetPizza.Models.Command", b =>
                {
                    b.Property<int>("CommandID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CommandDate");

                    b.Property<decimal>("Total");

                    b.HasKey("CommandID");

                    b.ToTable("Command");
                });

            modelBuilder.Entity("DotNetPizza.Models.DetailCommand", b =>
                {
                    b.Property<int>("DetailCommandID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommandID");

                    b.Property<int>("PizzaID");

                    b.Property<int>("Qty");

                    b.HasKey("DetailCommandID");

                    b.HasIndex("CommandID");

                    b.HasIndex("PizzaID");

                    b.ToTable("DetailCommand");
                });

            modelBuilder.Entity("DotNetPizza.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("PizzaID");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("DotNetPizza.Models.DetailCommand", b =>
                {
                    b.HasOne("DotNetPizza.Models.Command", "Command")
                        .WithMany("DetailCommand")
                        .HasForeignKey("CommandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNetPizza.Models.Pizza", "Pizza")
                        .WithMany("DetailCommand")
                        .HasForeignKey("PizzaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
