using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTutoringPlatformPrototype.Migrations
{
	public partial class AddFirstAndLastNamePropertiesToStudentAndTeacher : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "UserId",
				table: "Tutor");

			migrationBuilder.DropColumn(
				name: "UserId",
				table: "Student");

			migrationBuilder.AddColumn<string>(
				name: "FirstName",
				table: "Tutor",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "LastName",
				table: "Tutor",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "FirstName",
				table: "Student",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "LastName",
				table: "Student",
				type: "nvarchar(max)",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "FirstName",
				table: "Tutor");

			migrationBuilder.DropColumn(
				name: "LastName",
				table: "Tutor");

			migrationBuilder.DropColumn(
				name: "FirstName",
				table: "Student");

			migrationBuilder.DropColumn(
				name: "LastName",
				table: "Student");

			migrationBuilder.AddColumn<int>(
				name: "UserId",
				table: "Tutor",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "UserId",
				table: "Student",
				type: "int",
				nullable: false,
				defaultValue: 0);
		}
	}
}
