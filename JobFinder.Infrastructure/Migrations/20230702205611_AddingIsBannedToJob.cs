using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsBannedToJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CreatorName", "DeleteName", "DeletedBy", "DeletedOn", "IsActive", "LastModifiedBy", "LastModifiedOn", "ModifierName", "Title" },
                values: new object[,]
                {
                    { new Guid("0582d12a-cdc8-42db-a994-559456ba6724"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Bengali" },
                    { new Guid("0841ff55-1fd9-40bf-ae59-4292830a274f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Russian" },
                    { new Guid("15652e38-1a53-41e7-a073-7cec99754e1e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Spanish" },
                    { new Guid("41668b49-8ac2-4b2a-af4a-a064ee11233d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "English" },
                    { new Guid("5df67031-9f46-49e9-8c8f-0e9ee6dd5004"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "French" },
                    { new Guid("6027067f-91b0-48d6-950c-2ea54a0fd17f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Portuguese" },
                    { new Guid("6d0f2300-2dba-4651-9a75-ba589de6f04c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Arabic" },
                    { new Guid("903c590a-ef32-48a3-89f7-8270c02622a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Japanese" },
                    { new Guid("be60385a-ec23-478e-903a-161256bc4761"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Hindi" },
                    { new Guid("db8af18c-5bd5-4356-af0c-ebc4be9c1fb8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "German" },
                    { new Guid("e7315f28-1930-4ad4-88cb-43fd8275e413"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Korean" },
                    { new Guid("e889bf8a-39f5-4b9b-8224-2add23e9b3ca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Italian" },
                    { new Guid("f61e35ea-c839-4044-908c-347a4eaf0067"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Turkish" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CreatorName", "DeleteName", "DeletedBy", "DeletedOn", "IsActive", "LastModifiedBy", "LastModifiedOn", "ModifierName", "Title" },
                values: new object[,]
                {
                    { new Guid("083a210a-a431-47a6-b711-c4eb6308dea7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Creativity" },
                    { new Guid("2d8e1661-3ef6-4c7d-a5c4-60494e7e60f8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Communication" },
                    { new Guid("31216474-2c91-4e13-b196-c83ecf24a781"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Critical Thinking" },
                    { new Guid("336062e2-146c-4591-8737-ccbe9c52c0ad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Time Management" },
                    { new Guid("503995e6-8a36-4dfb-8e61-bf841e4686f4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Adaptability" },
                    { new Guid("521c912b-5a02-40e0-9847-365cea59a7ca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Communication" },
                    { new Guid("5374b2b8-2b79-4da6-aa6b-993cb9b8c00c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Leadership" },
                    { new Guid("6c61fe33-90cc-42e0-84a7-0bcd0534bf93"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Problem Solving" },
                    { new Guid("78ea44ac-c803-4019-8836-204a661fda76"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Technical" },
                    { new Guid("89c26bf7-5092-40ec-b8ae-eba033a547b8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Project Management" },
                    { new Guid("939dc987-e634-40e0-a9d3-acc391977eb3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Organizational" },
                    { new Guid("af138d7b-42b0-4d9c-9d5e-6a978dffdba3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Interpersonal" },
                    { new Guid("b7e646e7-b446-4379-b947-745883bfbfa1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Teamwork" },
                    { new Guid("bf233bc1-9516-4c23-bc67-b992f6e16179"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Attention to Detail" },
                    { new Guid("f62b903b-78a3-4dab-813a-bfda644f3ae8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, true, null, null, null, "Analytical" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("0582d12a-cdc8-42db-a994-559456ba6724"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("0841ff55-1fd9-40bf-ae59-4292830a274f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("15652e38-1a53-41e7-a073-7cec99754e1e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41668b49-8ac2-4b2a-af4a-a064ee11233d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5df67031-9f46-49e9-8c8f-0e9ee6dd5004"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("6027067f-91b0-48d6-950c-2ea54a0fd17f"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("6d0f2300-2dba-4651-9a75-ba589de6f04c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("903c590a-ef32-48a3-89f7-8270c02622a6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("be60385a-ec23-478e-903a-161256bc4761"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("db8af18c-5bd5-4356-af0c-ebc4be9c1fb8"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("e7315f28-1930-4ad4-88cb-43fd8275e413"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("e889bf8a-39f5-4b9b-8224-2add23e9b3ca"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f61e35ea-c839-4044-908c-347a4eaf0067"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("083a210a-a431-47a6-b711-c4eb6308dea7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2d8e1661-3ef6-4c7d-a5c4-60494e7e60f8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("31216474-2c91-4e13-b196-c83ecf24a781"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("336062e2-146c-4591-8737-ccbe9c52c0ad"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("503995e6-8a36-4dfb-8e61-bf841e4686f4"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("521c912b-5a02-40e0-9847-365cea59a7ca"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5374b2b8-2b79-4da6-aa6b-993cb9b8c00c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("6c61fe33-90cc-42e0-84a7-0bcd0534bf93"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("78ea44ac-c803-4019-8836-204a661fda76"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("89c26bf7-5092-40ec-b8ae-eba033a547b8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("939dc987-e634-40e0-a9d3-acc391977eb3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("af138d7b-42b0-4d9c-9d5e-6a978dffdba3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b7e646e7-b446-4379-b947-745883bfbfa1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("bf233bc1-9516-4c23-bc67-b992f6e16179"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f62b903b-78a3-4dab-813a-bfda644f3ae8"));

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Jobs");

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
        }
    }
}
