using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingJobSkillAndLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobLanguages_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CreatorName", "DeleteName", "DeletedBy", "DeletedOn", "IsActive", "JobId", "LastModifiedBy", "LastModifiedOn", "ModifierName", "Title" },
                values: new object[,]
                {
                    { new Guid("04d1b30a-785b-4f14-8a4c-786f80e10c93"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Hindi" },
                    { new Guid("113841aa-e1dc-4ac4-860a-6652fed491ef"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Turkish" },
                    { new Guid("1c811356-8bae-4882-9019-6a749ebf75d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Spanish" },
                    { new Guid("2047629e-32d2-41e7-b85d-fa2ec4136622"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Arabic" },
                    { new Guid("2b52bfac-1f54-4ccf-8845-917fe79ca18b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Italian" },
                    { new Guid("5358c76f-ecdc-4b81-8795-c47867a43375"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Russian" },
                    { new Guid("63b1e3bd-f88a-48fa-bf4c-8898adf94a80"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Korean" },
                    { new Guid("7ad5c897-b7bc-499f-b7ff-ceec2c190455"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "English" },
                    { new Guid("7d0a010e-ca58-45b9-903f-e1f6a934ca69"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Portuguese" },
                    { new Guid("87a63211-7822-4346-ae2b-680856edc9f2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "German" },
                    { new Guid("9d985ebb-8f0d-493b-9b4f-8abc759252d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Japanese" },
                    { new Guid("a68a5450-fab8-4452-b99f-b06d8b486ffa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "French" },
                    { new Guid("bc25afa9-4b14-4e25-884b-6e3069bddfc8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Bengali" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CreatorName", "DeleteName", "DeletedBy", "DeletedOn", "IsActive", "JobId", "LastModifiedBy", "LastModifiedOn", "ModifierName", "Title" },
                values: new object[,]
                {
                    { new Guid("05908c37-6a98-4ca2-b926-8b9ea1652ce8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Creativity" },
                    { new Guid("1ab5d6f8-a3a1-4dd7-a584-be70ec431f6c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Communication" },
                    { new Guid("29f5ff46-a66b-415d-815e-daf5221c16e1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Attention to Detail" },
                    { new Guid("2c34837c-4ab1-49b5-9115-3910f1d77c6f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Interpersonal" },
                    { new Guid("46c97259-0db2-4319-8d30-49a12a31e4a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Organizational" },
                    { new Guid("4950dc41-7ea4-40a5-b966-96b6c854c29e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Time Management" },
                    { new Guid("5fd3627a-9eb5-4008-ab3e-e97556e56305"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Analytical" },
                    { new Guid("785db25e-a4d3-4820-aa6f-7f5978c121a4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Adaptability" },
                    { new Guid("866d7f3d-b349-46a3-bf5b-117bfb4dad83"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Leadership" },
                    { new Guid("93d0a4fd-910f-4c6f-b494-6473dfd961f5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Communication" },
                    { new Guid("bfeb000a-fe13-447e-bd40-ab0c373f7320"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Teamwork" },
                    { new Guid("cadd34d0-3d75-48ff-a6f6-81af9884ebcf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Problem Solving" },
                    { new Guid("e30683d9-500d-474b-818d-5fe7e543777e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Project Management" },
                    { new Guid("ebbf0dd1-403b-4df4-b42b-bf6706700f1d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Technical" },
                    { new Guid("f3f26849-b462-49f6-b2e5-a7dab3b58059"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, null, null, null, "Critical Thinking" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobLanguages_JobId",
                table: "JobLanguages",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobLanguages_LanguageId",
                table: "JobLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobId",
                table: "JobSkills",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobLanguages");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("04d1b30a-785b-4f14-8a4c-786f80e10c93"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("113841aa-e1dc-4ac4-860a-6652fed491ef"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("1c811356-8bae-4882-9019-6a749ebf75d8"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("2047629e-32d2-41e7-b85d-fa2ec4136622"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("2b52bfac-1f54-4ccf-8845-917fe79ca18b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5358c76f-ecdc-4b81-8795-c47867a43375"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("63b1e3bd-f88a-48fa-bf4c-8898adf94a80"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7ad5c897-b7bc-499f-b7ff-ceec2c190455"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7d0a010e-ca58-45b9-903f-e1f6a934ca69"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a63211-7822-4346-ae2b-680856edc9f2"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("9d985ebb-8f0d-493b-9b4f-8abc759252d5"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("a68a5450-fab8-4452-b99f-b06d8b486ffa"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bc25afa9-4b14-4e25-884b-6e3069bddfc8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("05908c37-6a98-4ca2-b926-8b9ea1652ce8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1ab5d6f8-a3a1-4dd7-a584-be70ec431f6c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("29f5ff46-a66b-415d-815e-daf5221c16e1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2c34837c-4ab1-49b5-9115-3910f1d77c6f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("46c97259-0db2-4319-8d30-49a12a31e4a5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("4950dc41-7ea4-40a5-b966-96b6c854c29e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5fd3627a-9eb5-4008-ab3e-e97556e56305"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("785db25e-a4d3-4820-aa6f-7f5978c121a4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("866d7f3d-b349-46a3-bf5b-117bfb4dad83"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("93d0a4fd-910f-4c6f-b494-6473dfd961f5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("bfeb000a-fe13-447e-bd40-ab0c373f7320"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("cadd34d0-3d75-48ff-a6f6-81af9884ebcf"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e30683d9-500d-474b-818d-5fe7e543777e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ebbf0dd1-403b-4df4-b42b-bf6706700f1d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f3f26849-b462-49f6-b2e5-a7dab3b58059"));
        }
    }
}
