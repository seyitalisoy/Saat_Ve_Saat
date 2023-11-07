using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations.EmployeeDb
{
    /// <inheritdoc />
    public partial class migx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "Questions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "Answers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "AnnouncementId", "Content", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "23 Nisan Ulusual Egemenlik ve Çocuk Bayramımız kutlu olsun.", "/images/1.jpg", "23 Nisan" },
                    { 2, "Eylül ayı toplantılarımız başlıyor.", "/images/2.jpg", "Toplantılar Başlıyor" },
                    { 3, "Geleneksel Saat fuarı İstanbul'da başlıyor.", "/images/3.jpg", "Saat Fuarı" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "İnsan Kaynakları" },
                    { 2, "Bilgi İşlem" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "PositionName" },
                values: new object[,]
                {
                    { 1, "Yönetici" },
                    { 2, "Stajyer" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "Bugünkü yemekleri beğendiniz mi?" },
                    { 2, "Düzenleyeceğimiz gezide nereye gitmek istersiniz?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Beğendim", 1 },
                    { 2, "Beğenmedim", 1 },
                    { 3, "İstanbul", 2 },
                    { 4, "Ankara", 2 },
                    { 5, "İzmir", 2 },
                    { 6, "Trabzon", 2 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDay", "DateOfHire", "DepartmentId", "FirstName", "LastName", "PhoneNumber", "PositionId", "TcNo" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahmet", "Yılmaz", "5303232131", 1, "12345678912" },
                    { 2, new DateTime(1998, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mehmet", "Hakan", "5303232141", 2, "22245678912" },
                    { 3, new DateTime(1989, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cevdet", "DeliGül", "5303232145", 1, "22245678455" },
                    { 4, new DateTime(1991, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Haldun", "Kara", "5373232174", 2, "22245678488" },
                    { 5, new DateTime(1989, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zeynep", "Arkadaş", "5553232193", 2, "22245678404" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
