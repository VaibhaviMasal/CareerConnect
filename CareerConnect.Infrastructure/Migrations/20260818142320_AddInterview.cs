using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInterview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterviewDate",
                table: "InterviewSchedules");

            migrationBuilder.DropColumn(
                name: "LocationOrLink",
                table: "InterviewSchedules");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "InterviewSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "Mode",
                table: "InterviewSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InterviewSchedules",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "MeetingLink",
                table: "InterviewSchedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledAt",
                table: "InterviewSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "InterviewSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingLink",
                table: "InterviewSchedules");

            migrationBuilder.DropColumn(
                name: "ScheduledAt",
                table: "InterviewSchedules");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InterviewSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "Mode",
                table: "InterviewSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InterviewSchedules",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "InterviewDate",
                table: "InterviewSchedules",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationOrLink",
                table: "InterviewSchedules",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "InterviewSchedules",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
