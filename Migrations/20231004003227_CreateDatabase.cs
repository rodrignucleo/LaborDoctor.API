using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LaborDoctor.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_clinica",
                columns: table => new
                {
                    id_clinica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false),
                    nome_fantasia = table.Column<string>(type: "longtext", nullable: false),
                    cnpj = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: false),
                    telefone = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    senha = table.Column<string>(type: "longtext", nullable: false),
                    senha_antiga = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clinica", x => x.id_clinica);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_medico",
                columns: table => new
                {
                    id_medico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false),
                    crm = table.Column<string>(type: "longtext", nullable: false),
                    cpf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    especilidade = table.Column<string>(type: "longtext", nullable: false),
                    telefone = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_medico", x => x.id_medico);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_paciente",
                columns: table => new
                {
                    id_paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false),
                    cpf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    telefone = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    senha = table.Column<string>(type: "longtext", nullable: false),
                    senha_antiga = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_paciente", x => x.id_paciente);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_schedule",
                columns: table => new
                {
                    id_schedule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_medico = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_schedule", x => x.id_schedule);
                    table.ForeignKey(
                        name: "FK_tb_schedule_tb_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "tb_medico",
                        principalColumn: "id_medico",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_consulta",
                columns: table => new
                {
                    id_consulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_paciente = table.Column<int>(type: "int", nullable: false),
                    id_medico = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    id_schedule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consulta", x => x.id_consulta);
                    table.ForeignKey(
                        name: "FK_tb_consulta_tb_medico_id_medico",
                        column: x => x.id_medico,
                        principalTable: "tb_medico",
                        principalColumn: "id_medico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_consulta_tb_paciente_id_paciente",
                        column: x => x.id_paciente,
                        principalTable: "tb_paciente",
                        principalColumn: "id_paciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_consulta_tb_schedule_id_schedule",
                        column: x => x.id_schedule,
                        principalTable: "tb_schedule",
                        principalColumn: "id_schedule",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tb_clinica",
                columns: new[] { "id_clinica", "cnpj", "email", "nome", "nome_fantasia", "senha", "senha_antiga", "telefone" },
                values: new object[,]
                {
                    { 1, "11.777.5555/0001-99", "root", "root Clinica", "root Clinica", "$2a$11$rTpo3B4ptIbhr362BlZp2OflmtP4BmRUdae.1g/UZt2216F29lMUK", "$2a$11$ItYL4MDrrcm7f6PhwCJ9Y.yJT4DHkWEmojFr82sLIOcZGEwEit2Pu", "(45) 96666-1234" },
                    { 2, "10.136.4860/0001-85", "gndi@clinica.com", "GNDI", "GNDI", "$2a$11$tusVPV9fLFVeDVdZY1RJYuEpht93qQtpGcgT.v6pcnxb.1w0hnb6.", "$2a$11$AM3lWaOGY8JcrB3Lu0RHHeS2DSJsNKj7gjyUuFp24HB2rBrSaiFPS", "(11) 98524-5698" }
                });

            migrationBuilder.InsertData(
                table: "tb_medico",
                columns: new[] { "id_medico", "cpf", "crm", "email", "especilidade", "nome", "telefone" },
                values: new object[,]
                {
                    { 1, "12345678910", "045465/SP", "rodrignucleo@labordoctor.com", "Cardiologista", "Rodrigo Ribeiro", "11992668225" },
                    { 2, "98765412398", "221748/PR", "patricia.oliveira@labordoctor.com", "Ginecologista", "Patricia Oliveira", "9899265826597" }
                });

            migrationBuilder.InsertData(
                table: "tb_paciente",
                columns: new[] { "id_paciente", "cpf", "email", "nome", "senha", "senha_antiga", "telefone" },
                values: new object[,]
                {
                    { 1, "111.222.333-44", "root", "root Paciente", "$2a$11$SUAEicHbAD4DGXySJC99kOfAf5NU09wqGsqhttNQtRfAcsyORzVCm", "$2a$11$ni054ic4B7/tV5baUBOMD.lk7A.N3oUXkmAO7pK6qdxMhPG8W5XkG", "(45) 96666-1234" },
                    { 2, "987.458.236-98", "estevao@labordoctor.com", "Estevão Rocha", "$2a$11$Wimac5qBxvI7tEYgRVZUuu8Es9JyORY1HFKtJ3ctumxYcOV.zv9B.", "$2a$11$dYo7k9UAE.ZnpNMqEFSquef32Bg1.iFK9R6kW3o0eOQH5uEiWV5We", "(11) 99478-5200" }
                });

            migrationBuilder.InsertData(
                table: "tb_schedule",
                columns: new[] { "id_schedule", "data", "id_medico", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 3, 21, 32, 26, 597, DateTimeKind.Local).AddTicks(7699), 1, true },
                    { 2, new DateTime(2023, 10, 31, 10, 32, 26, 597, DateTimeKind.Local).AddTicks(7728), 1, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_id_medico",
                table: "tb_consulta",
                column: "id_medico");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta",
                column: "id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_id_schedule",
                table: "tb_consulta",
                column: "id_schedule");

            migrationBuilder.CreateIndex(
                name: "IX_tb_schedule_id_medico",
                table: "tb_schedule",
                column: "id_medico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_clinica");

            migrationBuilder.DropTable(
                name: "tb_consulta");

            migrationBuilder.DropTable(
                name: "tb_paciente");

            migrationBuilder.DropTable(
                name: "tb_schedule");

            migrationBuilder.DropTable(
                name: "tb_medico");
        }
    }
}
