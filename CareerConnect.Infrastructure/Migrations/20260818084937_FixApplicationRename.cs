using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixApplicationRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Applicati__Candi__6D0D32F4",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK__Applicati__JobPo__6E01572D",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK__Applicati__Resum__6EF57B66",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK__Candidate__UserI__5070F446",
                table: "CandidateProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK__Candidate__Candi__59FA5E80",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK__Candidate__Skill__5AEE82B9",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK__Interview__Appli__72C60C4A",
                table: "InterviewSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK__JobPostin__Recru__5FB337D6",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK__JobPostin__JobPo__628FA481",
                table: "JobPostingSkills");

            migrationBuilder.DropForeignKey(
                name: "FK__JobPostin__Skill__6383C8BA",
                table: "JobPostingSkills");

            migrationBuilder.DropForeignKey(
                name: "FK__Recruiter__UserI__5441852A",
                table: "RecruiterProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK__Resumes__Candida__68487DD7",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__3214EC079E029BCB",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Skills__3214EC070CF1D3D0",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Resumes__3214EC076E9115AB",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__RefreshT__3214EC0793B029E2",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Recruite__3214EC07C8E8C124",
                table: "RecruiterProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__JobPosti__58F0A2D16D591C01",
                table: "JobPostingSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK__JobPosti__3214EC0728DF0328",
                table: "JobPostings");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Intervie__3214EC07826CAFB6",
                table: "InterviewSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Candidat__C0E72DC8CDDF0F58",
                table: "CandidateSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Candidat__3214EC07EDFA4F08",
                table: "CandidateProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Applicat__3214EC07DCE370C2",
                table: "Applications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Resumes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "JobPostings",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InterviewSchedules",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppliedAt",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecruiterProfiles",
                table: "RecruiterProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPostingSkills",
                table: "JobPostingSkills",
                columns: new[] { "JobPostingId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPostings",
                table: "JobPostings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterviewSchedules",
                table: "InterviewSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateSkills",
                table: "CandidateSkills",
                columns: new[] { "CandidateProfileId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateProfiles",
                table: "CandidateProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

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
                name: "FK_CandidateProfiles_Users_UserId",
                table: "CandidateProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateProfileId",
                table: "CandidateSkills",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Skills_SkillId",
                table: "CandidateSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_Skills_SkillId",
                table: "JobPostingSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecruiterProfiles_Users_UserId",
                table: "RecruiterProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_CandidateProfiles_CandidateId",
                table: "Resumes",
                column: "CandidateId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_CandidateProfiles_Users_UserId",
                table: "CandidateProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateProfileId",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Skills_SkillId",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewSchedules_Applications_ApplicationId",
                table: "InterviewSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_RecruiterProfiles_RecruiterId",
                table: "JobPostings");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_Skills_SkillId",
                table: "JobPostingSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_RecruiterProfiles_Users_UserId",
                table: "RecruiterProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_CandidateProfiles_CandidateId",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecruiterProfiles",
                table: "RecruiterProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPostingSkills",
                table: "JobPostingSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPostings",
                table: "JobPostings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterviewSchedules",
                table: "InterviewSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateSkills",
                table: "CandidateSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateProfiles",
                table: "CandidateProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Resumes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "JobPostings",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "InterviewSchedules",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AppliedAt",
                table: "Applications",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__3214EC079E029BCB",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Skills__3214EC070CF1D3D0",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Resumes__3214EC076E9115AB",
                table: "Resumes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__RefreshT__3214EC0793B029E2",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Recruite__3214EC07C8E8C124",
                table: "RecruiterProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__JobPosti__58F0A2D16D591C01",
                table: "JobPostingSkills",
                columns: new[] { "JobPostingId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__JobPosti__3214EC0728DF0328",
                table: "JobPostings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Intervie__3214EC07826CAFB6",
                table: "InterviewSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Candidat__C0E72DC8CDDF0F58",
                table: "CandidateSkills",
                columns: new[] { "CandidateProfileId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Candidat__3214EC07EDFA4F08",
                table: "CandidateProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Applicat__3214EC07DCE370C2",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Applicati__Candi__6D0D32F4",
                table: "Applications",
                column: "CandidateId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Applicati__JobPo__6E01572D",
                table: "Applications",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Applicati__Resum__6EF57B66",
                table: "Applications",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Candidate__UserI__5070F446",
                table: "CandidateProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Candidate__Candi__59FA5E80",
                table: "CandidateSkills",
                column: "CandidateProfileId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Candidate__Skill__5AEE82B9",
                table: "CandidateSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Interview__Appli__72C60C4A",
                table: "InterviewSchedules",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__JobPostin__Recru__5FB337D6",
                table: "JobPostings",
                column: "RecruiterId",
                principalTable: "RecruiterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__JobPostin__JobPo__628FA481",
                table: "JobPostingSkills",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__JobPostin__Skill__6383C8BA",
                table: "JobPostingSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Recruiter__UserI__5441852A",
                table: "RecruiterProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Resumes__Candida__68487DD7",
                table: "Resumes",
                column: "CandidateId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
