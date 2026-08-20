using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkills_Skills_SkillsId",
                table: "JobPostingSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPostingSkills",
                table: "JobPostingSkills");

            migrationBuilder.RenameTable(
                name: "JobPostingSkills",
                newName: "JobPostingSkill");

            migrationBuilder.RenameColumn(
                name: "CompanyWebsite",
                table: "RecruiterProfiles",
                newName: "Position");

            migrationBuilder.RenameIndex(
                name: "IX_JobPostingSkills_SkillsId",
                table: "JobPostingSkill",
                newName: "IX_JobPostingSkill_SkillsId");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "RecruiterProfiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RecruiterProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPostingSkill",
                table: "JobPostingSkill",
                columns: new[] { "JobPostingId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkill_JobPostings_JobPostingId",
                table: "JobPostingSkill",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkill_Skills_SkillsId",
                table: "JobPostingSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkill_JobPostings_JobPostingId",
                table: "JobPostingSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingSkill_Skills_SkillsId",
                table: "JobPostingSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPostingSkill",
                table: "JobPostingSkill");

            migrationBuilder.DropColumn(
                name: "City",
                table: "RecruiterProfiles");

            migrationBuilder.RenameTable(
                name: "JobPostingSkill",
                newName: "JobPostingSkills");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "RecruiterProfiles",
                newName: "CompanyWebsite");

            migrationBuilder.RenameIndex(
                name: "IX_JobPostingSkill_SkillsId",
                table: "JobPostingSkills",
                newName: "IX_JobPostingSkills_SkillsId");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "RecruiterProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPostingSkills",
                table: "JobPostingSkills",
                columns: new[] { "JobPostingId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_JobPostings_JobPostingId",
                table: "JobPostingSkills",
                column: "JobPostingId",
                principalTable: "JobPostings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingSkills_Skills_SkillsId",
                table: "JobPostingSkills",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
