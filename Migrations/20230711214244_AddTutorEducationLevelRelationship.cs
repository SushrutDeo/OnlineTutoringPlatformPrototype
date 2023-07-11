using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTutoringPlatformPrototype.Migrations
{
	public partial class AddTutorEducationLevelRelationship : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "TutorEducationLevel",
				columns: table => new
				{
					TutorId = table.Column<int>(type: "int", nullable: false),
					EducationLevelId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TutorEducationLevel", x => new { x.EducationLevelId, x.TutorId });
					table.ForeignKey(
						name: "FK_TutorEducationLevel_EducationLevel_EducationLevelId",
						column: x => x.EducationLevelId,
						principalTable: "EducationLevel",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TutorEducationLevel_Tutor_TutorId",
						column: x => x.TutorId,
						principalTable: "Tutor",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_TutorEducationLevel_TutorId",
				table: "TutorEducationLevel",
				column: "TutorId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "TutorEducationLevel");
		}
	}
}
