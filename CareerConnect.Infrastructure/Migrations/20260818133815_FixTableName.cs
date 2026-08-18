using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_CandidateProfiles_CandidateId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_JobPostings_JobPostingId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Resumes_ResumeId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewSchedules_Applications_ApplicationId",
                table: "InterviewSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_RecruiterProfiles_RecruiterId",
                table: "JobPostings");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "JobApplications");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ResumeId",
                table: "JobApplications",
                newName: "IX_JobApplications_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobPostingId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobPostingId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_CandidateId",
                table: "JobApplications",
                newName: "IX_JobApplications_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewSchedules_JobApplications_ApplicationId",
                table: "InterviewSchedules",
                column: "ApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_CandidateProfiles_CandidateId",
                table: "JobApplications",
                column: "CandidateId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobPostings_JobPostingId",
                table: "JobApplications",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Resumes_ResumeId",
                table: "JobApplications",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_RecruiterProfiles_RecruiterId",
                table: "JobPostings",
                column: "RecruiterId",
                principalTable: "RecruiterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewSchedules_JobApplications_ApplicationId",
                table: "InterviewSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_CandidateProfiles_CandidateId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobPostings_JobPostingId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Resumes_ResumeId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_RecruiterProfiles_RecruiterId",
                table: "JobPostings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_ResumeId",
                table: "Applications",
                newName: "IX_Applications_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobPostingId",
                table: "Applications",
                newName: "IX_Applications_JobPostingId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_CandidateId",
                table: "Applications",
                newName: "IX_Applications_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_CandidateProfiles_CandidateId",
                table: "Applications",
                column: "CandidateId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_JobPostings_JobPostingId",
                table: "Applications",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Resumes_ResumeId",
                table: "Applications",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewSchedules_Applications_ApplicationId",
                table: "InterviewSchedules",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_RecruiterProfiles_RecruiterId",
                table: "JobPostings",
                column: "RecruiterId",
                principalTable: "RecruiterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
