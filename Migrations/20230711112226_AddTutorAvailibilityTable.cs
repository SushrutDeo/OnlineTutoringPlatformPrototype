using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTutoringPlatformPrototype.Migrations
{
	public partial class AddTutorAvailibilityTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "TutorAvailibility",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TutorId = table.Column<int>(type: "int", nullable: false),
					WeekDayId = table.Column<int>(type: "int", nullable: false),
					TimeRangeId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TutorAvailibility", x => x.Id);
					table.ForeignKey(
						name: "FK_TutorAvailibility_TimeRange_TimeRangeId",
						column: x => x.TimeRangeId,
						principalTable: "TimeRange",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TutorAvailibility_Tutor_TutorId",
						column: x => x.TutorId,
						principalTable: "Tutor",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TutorAvailibility_WeekDay_WeekDayId",
						column: x => x.WeekDayId,
						principalTable: "WeekDay",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_TutorAvailibility_TimeRangeId",
				table: "TutorAvailibility",
				column: "TimeRangeId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorAvailibility_TutorId",
				table: "TutorAvailibility",
				column: "TutorId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorAvailibility_WeekDayId",
				table: "TutorAvailibility",
				column: "WeekDayId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "TutorAvailibility");
		}
	}
}
