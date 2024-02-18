using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingCompanyIdInJobApplicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobQuestionAnswers_JobQuestions_JobQuestionId",
                table: "JobQuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Jobs_JobId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Jobs_JobId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_JobId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Languages_JobId",
                table: "Languages");

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

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Languages");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobQuestionId",
                table: "JobQuestionAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "JobApplicants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CreatorName", "DeleteName", "DeletedBy", "DeletedOn", "IsActive", "LastModifiedBy", "LastModifiedOn", "ModifierName", "Title" },
                values: new object[,]
                {
                    { new Guid("0c8085fa-7e6a-42d0-aa87-d589a5b6ba67"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Russian" },
                    { new Guid("26e7d175-9b19-4f11-8185-ba9765acffa1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Japanese" },
                    { new Guid("3ec47398-b601-447d-b751-76675bc1dec2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Arabic" },
                    { new Guid("4078e2ae-e354-4c41-b007-ed4675d4b711"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Turkish" },
                    { new Guid("47233c71-8858-44d9-94fb-ff29c9bce560"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Bengali" },
                    { new Guid("518c5b75-0de2-4676-a4bf-21198cf5fa70"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "German" },
                    { new Guid("53357126-90f6-4942-bf3b-c09c899bc0f0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "French" },
                    { new Guid("59cb9edc-2a2e-4e5c-8fbd-28bdc3b7f932"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Spanish" },
                    { new Guid("6be69e2c-f11e-4e58-8641-19c75e60afe3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "English" },
                    { new Guid("7387ea43-de4c-4f68-ae98-078608ce1c15"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Portuguese" },
                    { new Guid("79b661c2-cab6-4f4d-bc3a-b031479d8c10"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Italian" },
                    { new Guid("989ba373-3f5c-4ec1-bd2f-2268668916a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Hindi" },
                    { new Guid("cfe4878e-5234-495e-ab6b-30cd76a830b0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Korean" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CreatorName", "DeleteName", "DeletedBy", "DeletedOn", "IsActive", "LastModifiedBy", "LastModifiedOn", "ModifierName", "Title" },
                values: new object[,]
                {
                    { new Guid("23dcfd68-54fb-44d2-a9f3-555cf3ff47e3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Analytical" },
                    { new Guid("4548977b-96e2-49c2-9b7b-6ca1fa5ac831"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Critical Thinking" },
                    { new Guid("5c4ca50d-02b7-48b7-807d-074551d1564e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Project Management" },
                    { new Guid("61ac556c-5501-4b1e-a6e0-46f4c3ead46a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Time Management" },
                    { new Guid("69dbd7b9-f9e0-4b83-8222-3313ae4c59a1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Interpersonal" },
                    { new Guid("7d01ba3b-3474-4d2d-bebc-a73b7d994191"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Communication" },
                    { new Guid("8abcedaf-8fbd-47b1-8b96-244fff2bb009"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Leadership" },
                    { new Guid("a5da79b2-c885-42da-9e3c-f3f0ec7fdea2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Attention to Detail" },
                    { new Guid("b72f7af5-e6b9-4cb3-9618-7c5b0697334e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Organizational" },
                    { new Guid("b7c12daf-4c32-40e7-91b2-288a4bf859c7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Technical" },
                    { new Guid("cadfadef-a7bd-4ef1-a87b-cdc30de81cb0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Adaptability" },
                    { new Guid("eb81f68e-199f-46fd-aac7-c535a5b48f24"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Creativity" },
                    { new Guid("f36143a3-2e81-45e4-b8b4-f7c9294c68c2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Problem Solving" },
                    { new Guid("f594d568-c436-450d-a1ca-968d553d2a56"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Teamwork" },
                    { new Guid("fdd6c066-4029-49dd-8b7c-88de1c2b9cc9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Communication" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobQuestionAnswers_JobQuestions_JobQuestionId",
                table: "JobQuestionAnswers",
                column: "JobQuestionId",
                principalTable: "JobQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobQuestionAnswers_JobQuestions_JobQuestionId",
                table: "JobQuestionAnswers");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("0c8085fa-7e6a-42d0-aa87-d589a5b6ba67"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("26e7d175-9b19-4f11-8185-ba9765acffa1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("3ec47398-b601-447d-b751-76675bc1dec2"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4078e2ae-e354-4c41-b007-ed4675d4b711"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("47233c71-8858-44d9-94fb-ff29c9bce560"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("518c5b75-0de2-4676-a4bf-21198cf5fa70"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("53357126-90f6-4942-bf3b-c09c899bc0f0"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("59cb9edc-2a2e-4e5c-8fbd-28bdc3b7f932"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("6be69e2c-f11e-4e58-8641-19c75e60afe3"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7387ea43-de4c-4f68-ae98-078608ce1c15"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("79b661c2-cab6-4f4d-bc3a-b031479d8c10"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("989ba373-3f5c-4ec1-bd2f-2268668916a9"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("cfe4878e-5234-495e-ab6b-30cd76a830b0"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("23dcfd68-54fb-44d2-a9f3-555cf3ff47e3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("4548977b-96e2-49c2-9b7b-6ca1fa5ac831"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5c4ca50d-02b7-48b7-807d-074551d1564e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("61ac556c-5501-4b1e-a6e0-46f4c3ead46a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("69dbd7b9-f9e0-4b83-8222-3313ae4c59a1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("7d01ba3b-3474-4d2d-bebc-a73b7d994191"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("8abcedaf-8fbd-47b1-8b96-244fff2bb009"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5da79b2-c885-42da-9e3c-f3f0ec7fdea2"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b72f7af5-e6b9-4cb3-9618-7c5b0697334e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b7c12daf-4c32-40e7-91b2-288a4bf859c7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("cadfadef-a7bd-4ef1-a87b-cdc30de81cb0"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("eb81f68e-199f-46fd-aac7-c535a5b48f24"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f36143a3-2e81-45e4-b8b4-f7c9294c68c2"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f594d568-c436-450d-a1ca-968d553d2a56"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("fdd6c066-4029-49dd-8b7c-88de1c2b9cc9"));

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobApplicants");

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JobQuestionId",
                table: "JobQuestionAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "IX_Skills_JobId",
                table: "Skills",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_JobId",
                table: "Languages",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobQuestionAnswers_JobQuestions_JobQuestionId",
                table: "JobQuestionAnswers",
                column: "JobQuestionId",
                principalTable: "JobQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Jobs_JobId",
                table: "Languages",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Jobs_JobId",
                table: "Skills",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
