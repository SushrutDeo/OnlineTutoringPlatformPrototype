using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTutoringPlatformPrototype.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "EducationLevel",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_EducationLevel", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Gender",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Gender", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Role",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Role", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Subject",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Subject", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "TeachingPreference",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TeachingPreference", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "TimeRange",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TimeRange", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "WeekDay",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_WeekDay", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Student",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
					EducationLevelId = table.Column<int>(type: "int", nullable: false),
					GenderId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Student", x => x.Id);
					table.ForeignKey(
						name: "FK_Student_EducationLevel_EducationLevelId",
						column: x => x.EducationLevelId,
						principalTable: "EducationLevel",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Student_Gender_GenderId",
						column: x => x.GenderId,
						principalTable: "Gender",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Tutor",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<int>(type: "int", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
					City = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					GenderId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tutor", x => x.Id);
					table.ForeignKey(
						name: "FK_Tutor_Gender_GenderId",
						column: x => x.GenderId,
						principalTable: "Gender",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "StudentSubject",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					StudentId = table.Column<int>(type: "int", nullable: false),
					SubjectId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StudentSubject", x => x.Id);
					table.ForeignKey(
						name: "FK_StudentSubject_Student_StudentId",
						column: x => x.StudentId,
						principalTable: "Student",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_StudentSubject_Subject_SubjectId",
						column: x => x.SubjectId,
						principalTable: "Subject",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TutorAvailibilityTimeRange",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TutorId = table.Column<int>(type: "int", nullable: false),
					TimeRangeId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TutorAvailibilityTimeRange", x => x.Id);
					table.ForeignKey(
						name: "FK_TutorAvailibilityTimeRange_TimeRange_TimeRangeId",
						column: x => x.TimeRangeId,
						principalTable: "TimeRange",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TutorAvailibilityTimeRange_Tutor_TutorId",
						column: x => x.TutorId,
						principalTable: "Tutor",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TutorAvailibilityWeekDay",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TutorId = table.Column<int>(type: "int", nullable: false),
					WeekDayId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TutorAvailibilityWeekDay", x => x.Id);
					table.ForeignKey(
						name: "FK_TutorAvailibilityWeekDay_Tutor_TutorId",
						column: x => x.TutorId,
						principalTable: "Tutor",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TutorAvailibilityWeekDay_WeekDay_WeekDayId",
						column: x => x.WeekDayId,
						principalTable: "WeekDay",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TutorSubject",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TutorId = table.Column<int>(type: "int", nullable: false),
					SubjectId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsDeleted = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TutorSubject", x => x.Id);
					table.ForeignKey(
						name: "FK_TutorSubject_Subject_SubjectId",
						column: x => x.SubjectId,
						principalTable: "Subject",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TutorSubject_Tutor_TutorId",
						column: x => x.TutorId,
						principalTable: "Tutor",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TutorTeachingPreference",
				columns: table => new
				{
					TutorId = table.Column<int>(type: "int", nullable: false),
					TeachingPreferenceId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TutorTeachingPreference", x => new { x.TeachingPreferenceId, x.TutorId });
					table.ForeignKey(
						name: "FK_TutorTeachingPreference_TeachingPreference_TeachingPreferenceId",
						column: x => x.TeachingPreferenceId,
						principalTable: "TeachingPreference",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_TutorTeachingPreference_Tutor_TutorId",
						column: x => x.TutorId,
						principalTable: "Tutor",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Student_EducationLevelId",
				table: "Student",
				column: "EducationLevelId");

			migrationBuilder.CreateIndex(
				name: "IX_Student_GenderId",
				table: "Student",
				column: "GenderId");

			migrationBuilder.CreateIndex(
				name: "IX_StudentSubject_StudentId",
				table: "StudentSubject",
				column: "StudentId");

			migrationBuilder.CreateIndex(
				name: "IX_StudentSubject_SubjectId",
				table: "StudentSubject",
				column: "SubjectId");

			migrationBuilder.CreateIndex(
				name: "IX_Tutor_GenderId",
				table: "Tutor",
				column: "GenderId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorAvailibilityTimeRange_TimeRangeId",
				table: "TutorAvailibilityTimeRange",
				column: "TimeRangeId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorAvailibilityTimeRange_TutorId",
				table: "TutorAvailibilityTimeRange",
				column: "TutorId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorAvailibilityWeekDay_TutorId",
				table: "TutorAvailibilityWeekDay",
				column: "TutorId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorAvailibilityWeekDay_WeekDayId",
				table: "TutorAvailibilityWeekDay",
				column: "WeekDayId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorSubject_SubjectId",
				table: "TutorSubject",
				column: "SubjectId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorSubject_TutorId",
				table: "TutorSubject",
				column: "TutorId");

			migrationBuilder.CreateIndex(
				name: "IX_TutorTeachingPreference_TutorId",
				table: "TutorTeachingPreference",
				column: "TutorId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Role");

			migrationBuilder.DropTable(
				name: "StudentSubject");

			migrationBuilder.DropTable(
				name: "TutorAvailibilityTimeRange");

			migrationBuilder.DropTable(
				name: "TutorAvailibilityWeekDay");

			migrationBuilder.DropTable(
				name: "TutorSubject");

			migrationBuilder.DropTable(
				name: "TutorTeachingPreference");

			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "Student");

			migrationBuilder.DropTable(
				name: "TimeRange");

			migrationBuilder.DropTable(
				name: "WeekDay");

			migrationBuilder.DropTable(
				name: "Subject");

			migrationBuilder.DropTable(
				name: "TeachingPreference");

			migrationBuilder.DropTable(
				name: "Tutor");

			migrationBuilder.DropTable(
				name: "EducationLevel");

			migrationBuilder.DropTable(
				name: "Gender");
		}
	}
}
