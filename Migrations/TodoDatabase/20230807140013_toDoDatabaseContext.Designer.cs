﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Note_API.EntityFramwork.ToDoEntityFramework;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace My_Note_API.Migrations.TodoDatabase
{
    [DbContext(typeof(TodoDatabaseContext))]
    [Migration("20230807140013_toDoDatabaseContext")]
    partial class toDoDatabaseContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Archived_Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("archive_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime>("ToDo_Goal")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("todo_goal");

                    b.Property<int>("ToDo_Id")
                        .HasColumnType("integer")
                        .HasColumnName("todo_id");

                    b.HasKey("Id");

                    b.ToTable("archive_todo");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.Create_ToDo_Log<My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_Id")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_id");

                    b.Property<int>("ToDo_IdId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ToDo_IdId");

                    b.ToTable("create_todo_log");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("Goal")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("goal");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("todo");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.UpDate_Logger<My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Log")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("log");

                    b.Property<int>("ToDoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Update_Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("ToDoId");

                    b.ToTable("update_logger");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.Create_ToDo_Log<My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo>", b =>
                {
                    b.HasOne("My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo", "ToDo_Id")
                        .WithMany()
                        .HasForeignKey("ToDo_IdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDo_Id");
                });

            modelBuilder.Entity("My_Note_API.EntityFramwork.ToDoEntityFramework.UpDate_Logger<My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo>", b =>
                {
                    b.HasOne("My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo", "ToDo")
                        .WithMany()
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDo");
                });
#pragma warning restore 612, 618
        }
    }
}