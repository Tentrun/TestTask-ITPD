﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTaskITPD.DAL;

#nullable disable

namespace TestTaskITPD.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestTaskITPD.Domain.Entity.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d210c1b-41fd-4a02-beab-526315fccce6"),
                            CreateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4784),
                            ProjectName = "TestProject1",
                            UpdateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4792)
                        },
                        new
                        {
                            Id = new Guid("b41627fb-c020-4c4d-b503-e45e60ff1ea7"),
                            CreateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4794),
                            ProjectName = "TestProject2",
                            UpdateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4795)
                        });
                });

            modelBuilder.Entity("TestTaskITPD.Domain.Entity.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CancelDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Task");

                    b.HasData(
                        new
                        {
                            Id = new Guid("23c10d0a-6a76-4b1e-872e-090455da1f6e"),
                            CancelDate = new DateTime(2022, 12, 5, 22, 40, 0, 0, DateTimeKind.Unspecified),
                            CreateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4889),
                            ProjectId = new Guid("3d210c1b-41fd-4a02-beab-526315fccce6"),
                            StartDate = new DateTime(2022, 12, 4, 22, 34, 0, 0, DateTimeKind.Unspecified),
                            TaskName = "TestTask1",
                            UpdateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4890)
                        },
                        new
                        {
                            Id = new Guid("749e270c-9b66-4954-abc1-d2cdea203a9e"),
                            CreateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4978),
                            ProjectId = new Guid("3d210c1b-41fd-4a02-beab-526315fccce6"),
                            TaskName = "EditedTask2",
                            UpdateDate = new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4979)
                        });
                });

            modelBuilder.Entity("TestTaskITPD.Domain.Entity.TaskComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("CommentType")
                        .HasColumnType("tinyint");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TaskComments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cc8ba1d9-b394-4b78-3e7f-08dad62e9f56"),
                            CommentType = (byte)0,
                            Content = new byte[] { 84, 101, 115, 116, 68, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110, 13, 10, 65, 100, 100, 101, 100, 32, 102, 114, 111, 109, 32, 116, 120, 116, 32, 102, 105, 108, 101 },
                            TaskId = new Guid("3d210c1b-41fd-4a02-beab-526315fccce6")
                        },
                        new
                        {
                            Id = new Guid("aa1c412f-a734-416b-3e80-08dad62e9f56"),
                            CommentType = (byte)1,
                            Content = new byte[] { 84, 101, 115, 116, 68, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110, 32, 65, 100, 100, 101, 100, 32, 102, 114, 111, 109, 32, 116, 120, 116, 32, 102, 105, 108, 101 },
                            TaskId = new Guid("749e270c-9b66-4954-abc1-d2cdea203a9e")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
