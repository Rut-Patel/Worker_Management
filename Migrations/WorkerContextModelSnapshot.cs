﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Worker_Management.Models;

namespace Worker_Management.Migrations
{
    [DbContext(typeof(WorkerContext))]
    partial class WorkerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Worker_Management.Models.Supervisior", b =>
                {
                    b.Property<int>("supervisiorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("supervisiorID");

                    b.ToTable("Supervisiors");
                });

            modelBuilder.Entity("Worker_Management.Models.Worker", b =>
                {
                    b.Property<int>("workerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SupervisiorFK")
                        .HasColumnType("int");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("hired_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("workerID");

                    b.HasIndex("SupervisiorFK");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Worker_Management.Models.Worker", b =>
                {
                    b.HasOne("Worker_Management.Models.Supervisior", "Supervisior")
                        .WithMany()
                        .HasForeignKey("SupervisiorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
