﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Note_API.EntityFramwork.ToDoEntityFramework;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace My_Note_API.Migrations.TodoDatabase
{
    [DbContext(typeof(TodoDatabaseContext))]
    partial class TodoDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.Archive_ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Archived_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ToDo_Goal")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ToDo_Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Archive_ToDos");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.Create_ToDo_Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Id")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ToDo_IdId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ToDo_IdId");

                    b.ToTable("Create_ToDo_Logs");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Goal")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.Create_ToDo_Log", b =>
                {
                    b.HasOne("My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo", "ToDo_Id")
                        .WithMany()
                        .HasForeignKey("ToDo_IdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDo_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
