using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTaskITPD.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Production : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreateDate", "ProjectName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3d210c1b-41fd-4a02-beab-526315fccce6"), new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4784), "TestProject1", new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4792) },
                    { new Guid("b41627fb-c020-4c4d-b503-e45e60ff1ea7"), new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4794), "TestProject2", new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4795) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CancelDate", "CreateDate", "ProjectId", "StartDate", "TaskName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("23c10d0a-6a76-4b1e-872e-090455da1f6e"), new DateTime(2022, 12, 5, 22, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4889), new Guid("3d210c1b-41fd-4a02-beab-526315fccce6"), new DateTime(2022, 12, 4, 22, 34, 0, 0, DateTimeKind.Unspecified), "TestTask1", new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4890) },
                    { new Guid("749e270c-9b66-4954-abc1-d2cdea203a9e"), null, new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4978), new Guid("3d210c1b-41fd-4a02-beab-526315fccce6"), null, "EditedTask2", new DateTime(2022, 12, 4, 23, 5, 5, 971, DateTimeKind.Local).AddTicks(4979) }
                });

            migrationBuilder.InsertData(
                table: "TaskComments",
                columns: new[] { "Id", "CommentType", "Content", "TaskId" },
                values: new object[,]
                {
                    { new Guid("aa1c412f-a734-416b-3e80-08dad62e9f56"), (byte)1, new byte[] { 84, 101, 115, 116, 68, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110, 32, 65, 100, 100, 101, 100, 32, 102, 114, 111, 109, 32, 116, 120, 116, 32, 102, 105, 108, 101 }, new Guid("749e270c-9b66-4954-abc1-d2cdea203a9e") },
                    { new Guid("cc8ba1d9-b394-4b78-3e7f-08dad62e9f56"), (byte)0, new byte[] { 84, 101, 115, 116, 68, 101, 115, 99, 114, 105, 112, 116, 105, 111, 110, 13, 10, 65, 100, 100, 101, 100, 32, 102, 114, 111, 109, 32, 116, 120, 116, 32, 102, 105, 108, 101 }, new Guid("3d210c1b-41fd-4a02-beab-526315fccce6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskComments");
        }
    }
}
