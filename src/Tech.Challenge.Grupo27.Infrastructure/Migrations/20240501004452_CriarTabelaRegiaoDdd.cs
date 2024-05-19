using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tech.Challenge.Grupo27.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaRegiaoDdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_RegiaoDdd",
                schema: "techchanllenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "Varchar(2)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(50)", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 1, 0, 44, 52, 505, DateTimeKind.Utc).AddTicks(9049)),
                    DataDeAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_RegiaoDdd", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "techchanllenge",
                table: "Tb_RegiaoDdd",
                columns: new[] { "Id", "Codigo", "DataDeAlteracao", "DataDeCriacao", "Descricao", "Estado" },
                values: new object[,]
                {
                    { new Guid("0589f76f-cca7-4f8b-bfe6-81528fb284b0"), 61, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1282), "Centro-Oeste", "MG" },
                    { new Guid("0eed422d-15b6-472f-a9ef-41dce135994e"), 47, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1274), "Sul", "SC" },
                    { new Guid("138b7ed3-e4a5-47bc-89fa-7116eded119f"), 65, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1285), "Centro-Oeste", "MT" },
                    { new Guid("157329da-793c-4be1-94e8-995df5155938"), 18, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1216), "Sudeste", "SP" },
                    { new Guid("1707bf2c-eb82-4428-b11a-ef3541e50222"), 37, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1265), "Sudeste", "MG" },
                    { new Guid("2479c04d-ccb8-4e41-8fda-17cf33bd3e75"), 73, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1301), "Nordeste", "BA" },
                    { new Guid("249cc8ca-0b77-47f6-a8a5-f23758854907"), 22, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1219), "Sudeste", "RJ" },
                    { new Guid("27065733-0912-4d1d-aa13-43de66180b06"), 89, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1315), "Nordeste", "PI" },
                    { new Guid("2e1a6526-2840-4e48-916c-ad63962dd702"), 96, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1292), "Norte", "AP" },
                    { new Guid("3136e301-6608-4f6a-8d51-6cd72a606aa0"), 75, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1303), "Nordeste", "BA" },
                    { new Guid("3307e912-fa12-4600-9970-c055f3f5a058"), 51, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1276), "Sul", "RS" },
                    { new Guid("35a7e32c-1f28-4e6d-955c-631acf59fb75"), 44, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1271), "Sul", "PR" },
                    { new Guid("35b68b80-6311-449d-8cc5-9b707d55bc5d"), 24, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1220), "Sudeste", "RJ" },
                    { new Guid("363b50c0-46a8-4290-af2d-21d2b1c3232c"), 48, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1275), "Sul", "SC" },
                    { new Guid("3641630e-86a3-451d-affa-23965228c9c4"), 13, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1201), "Sudeste", "SP" },
                    { new Guid("3905cc59-a07c-41c4-a38b-7104e52fcc1f"), 92, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1293), "Norte", "AM" },
                    { new Guid("391e1a45-0c3e-462f-8390-51711129847f"), 79, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1318), "Nordeste", "SE" },
                    { new Guid("3df42706-728d-498c-8567-8f5891e8dfe1"), 53, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1280), "Sul", "RS" },
                    { new Guid("4d4bc72f-fd26-4fb1-8e72-2161d58c1a15"), 85, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1306), "Nordeste", "CE" },
                    { new Guid("50410a0e-d7f0-40db-8207-d72ef5fd8740"), 97, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1294), "Norte", "AM" },
                    { new Guid("5490b2c3-7f99-4c44-8a07-41b0ac6bec6f"), 46, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1273), "Sul", "PR" },
                    { new Guid("56c2c878-d4b4-401e-b8cd-aec150b046a8"), 19, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1217), "Sudeste", "SP" },
                    { new Guid("59949c4a-046b-4aef-bd42-56040862d827"), 12, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1200), "Sudeste", "SP" },
                    { new Guid("62abcc16-660f-4dc1-8756-48adc3418c66"), 21, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1218), "Sudeste", "RJ" },
                    { new Guid("64680cc5-908f-47c5-8da4-4f1af348cdcf"), 11, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1197), "Sudeste", "SP" },
                    { new Guid("6a6ba9ed-ca1d-4ff7-835e-f5d87b7e1a11"), 33, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1262), "Sudeste", "MG" },
                    { new Guid("6a986fe4-573c-497b-996f-959e81eed721"), 84, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1316), "Nordeste", "RN" },
                    { new Guid("6bf8ae60-cf2f-41ed-9b80-d5aa726effc7"), 55, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1281), "Sul", "RS" },
                    { new Guid("6faae7be-0399-4aef-a683-f75088234e2c"), 49, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1275), "Sul", "SC" },
                    { new Guid("704a2903-c63b-4edd-9460-45739c1fa958"), 17, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1206), "Sudeste", "SP" },
                    { new Guid("721e10fd-fa65-4363-9075-5fab8bbf9216"), 98, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1308), "Nordeste", "MA" },
                    { new Guid("7d3f2ef0-9717-4799-b138-1937afecc90a"), 91, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1295), "Norte", "PA" },
                    { new Guid("82473912-6cfa-4f6d-ac6a-e8aa112d8268"), 83, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1310), "Nordeste", "PB" },
                    { new Guid("846aa5cb-c149-41b2-9279-d03b4dd4e607"), 99, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1309), "Nordeste", "MA" },
                    { new Guid("86e527e3-e71b-4659-b8c8-42d2380b8f76"), 86, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1313), "Nordeste", "PI" },
                    { new Guid("8c325796-8046-4dff-b798-0d70798b9150"), 67, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1289), "Centro-Oeste", "MS" },
                    { new Guid("93282d5c-b803-4581-a7d8-add528d7a199"), 28, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1222), "Sudeste", "ES" },
                    { new Guid("96d5748b-2b80-4fbb-97f1-d7b6200457d9"), 69, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1291), "Norte", "RO" },
                    { new Guid("9aa8d2ef-fb90-40c0-88e2-22c9e6bd9046"), 54, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1280), "Sul", "RS" },
                    { new Guid("9fb12816-1d16-41cd-9e79-d929f4bda83a"), 42, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1267), "Sul", "PR" },
                    { new Guid("a04e03a9-371a-44d8-9666-e0fc8538bf4d"), 82, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1317), "Nordeste", "AL" },
                    { new Guid("a18aed3b-30a7-4d9e-bd43-fdd74b6246cd"), 27, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1221), "Sudeste", "ES" },
                    { new Guid("a292cb13-e393-4279-9258-32ac278f97ed"), 93, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1297), "Norte", "PA" },
                    { new Guid("aa07ec60-9023-4749-9e62-dcac760f26b0"), 14, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1202), "Sudeste", "SP" },
                    { new Guid("ad643600-348e-4620-9817-308282f1b45f"), 41, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1266), "Sul", "PR" },
                    { new Guid("b3b086ea-2125-4198-ab7f-17f78f4dcbf2"), 74, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1302), "Nordeste", "BA" },
                    { new Guid("b41fd644-eaaa-4855-8145-e8d157ca017f"), 35, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1264), "Sudeste", "MG" },
                    { new Guid("b860f49b-d952-4e9f-a004-310759ed7e2d"), 88, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1307), "Nordeste", "CE" },
                    { new Guid("b9211ec6-1220-4e33-999e-8cf869d41dc2"), 66, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1286), "Centro-Oeste", "MT" },
                    { new Guid("b93cd4f2-219e-4c55-9609-12e72f010a6c"), 31, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1223), "Sudeste", "MG" },
                    { new Guid("ba63163f-61e7-47a5-8386-24ee269d7f9f"), 71, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1300), "Nordeste", "BA" },
                    { new Guid("bdcd959b-db78-4906-9315-9553e11cb601"), 16, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1205), "Sudeste", "SP" },
                    { new Guid("beac6cf9-ccfc-451e-8d77-4216881554e4"), 15, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1203), "Sudeste", "SP" },
                    { new Guid("bf2e0270-4db0-427f-ac69-3afe5610d471"), 63, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1290), "Norte", "TO" },
                    { new Guid("bf97db69-908e-4a69-b2e6-c14a652662e7"), 62, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1283), "Centro-Oeste", "GO" },
                    { new Guid("c63f095b-f0db-4f37-a476-25c4388557c0"), 87, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1312), "Nordeste", "PE" },
                    { new Guid("c6a4756c-e952-490a-a5bb-a069e2965053"), 81, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1311), "Nordeste", "PE" },
                    { new Guid("cb2a0e90-39ee-4e74-800a-1bbc0effaa44"), 64, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1284), "Centro-Oeste", "GO" },
                    { new Guid("cb2ce430-1d3e-4c9f-951e-4e5e86042494"), 77, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1304), "Nordeste", "BA" },
                    { new Guid("cd446ee0-b75a-40be-adb9-4c6c1a4d3719"), 95, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1299), "Norte", "RR" },
                    { new Guid("d4debec4-d8ed-4360-9b8e-92f609ce2679"), 45, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1272), "Sul", "PR" },
                    { new Guid("d70092d6-7fae-430e-ba02-a14b5bc42f52"), 34, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1263), "Sudeste", "MG" },
                    { new Guid("e2a7f7a2-0777-42df-9008-f904f6d85dc9"), 38, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1266), "Sudeste", "MG" },
                    { new Guid("e5e41bc0-7428-46bc-8a2a-9468202bbbeb"), 43, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1270), "Sul", "PR" },
                    { new Guid("f2f23922-620a-4c2d-86b9-faa5a71029ea"), 94, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1298), "Norte", "PA" },
                    { new Guid("f3ce76c6-c23c-4b4d-827e-04cc71479604"), 68, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1290), "Norte", "AC" },
                    { new Guid("fc337cca-c279-4885-baeb-48006096afcf"), 32, null, new DateTime(2024, 5, 1, 0, 44, 52, 506, DateTimeKind.Utc).AddTicks(1226), "Sudeste", "MG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RegiaoDdd_Codigo",
                schema: "techchanllenge",
                table: "Tb_RegiaoDdd",
                column: "Codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_RegiaoDdd",
                schema: "techchanllenge");
        }
    }
}
