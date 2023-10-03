using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaborDoctor.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "tb_schedule",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.UpdateData(
                table: "tb_clinica",
                keyColumn: "id_clinica",
                keyValue: 1,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$/RBkKz/9T.ArrFD9FzpvYeeLZwJeR/7V2vlN0tqmbNC6GO5pUdORW", "$2a$11$j.X5NOY32I8.dZVnvgMFeuQilVQkRmbai34yp4WUyRDmfsxzvd6Um" });

            migrationBuilder.UpdateData(
                table: "tb_clinica",
                keyColumn: "id_clinica",
                keyValue: 2,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$EIAHKn8lB/7hlDDfyN5QBeXt5obqEOc6hnaXAeYBGvtBieaPT/326", "$2a$11$j8eB7zhT5dpyswUv9trp..Kc/HfDRV1xM8LnPevp73E5FXIcOr5By" });

            migrationBuilder.UpdateData(
                table: "tb_paciente",
                keyColumn: "id_paciente",
                keyValue: 1,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$ldvApVZiSo8eUqAWQgYyzelH28inpkCQh8yyzrz8iwG9BghrLiJR6", "$2a$11$3u3rweKeYugjG.OxhXB9BOEhcIzLGpv/JqIxi/UTJLID8/p9KQXTm" });

            migrationBuilder.UpdateData(
                table: "tb_paciente",
                keyColumn: "id_paciente",
                keyValue: 2,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$he2o1bO0UNWWOIMf6/pM1eFyxOXtBakeLQdVkIbG2juOJ8E9ubqS6", "$2a$11$0mjM6ON0eTSrDV8zNrrbiOt/eFgJfNzL8t9HVk/jt0d4sxPRFRMK6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "tb_schedule",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.UpdateData(
                table: "tb_clinica",
                keyColumn: "id_clinica",
                keyValue: 1,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$19BcqD1injq6X4b0kjoIheO7ZVLQOlNEZR3h53JUWX2p0cBKM1cb.", "$2a$11$eBC.zEW1SYnM8Ai5J3.oFOfmicATeCxoKwikdzqcrP94Xnm6Wh10m" });

            migrationBuilder.UpdateData(
                table: "tb_clinica",
                keyColumn: "id_clinica",
                keyValue: 2,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$FsPKSrUlgkBEwNiJvmsEaeZiqBa/zNzUBFD2fpU8G3oUMvYmzlEhS", "$2a$11$Z9XDi7rBlbZPkQnKKVzDOudp8p0RlBQK1eljSHxWFgOgj6SoajeYK" });

            migrationBuilder.UpdateData(
                table: "tb_paciente",
                keyColumn: "id_paciente",
                keyValue: 1,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$2lFVphB3ncST3EityNCBj.CFzfzb70LUyRQJlL6B2G/sKwUHYKPku", "$2a$11$fnBFJAQGooSZIf.gaoa1keUbQkzStpNjNtRan.LnBj/ptag188GyO" });

            migrationBuilder.UpdateData(
                table: "tb_paciente",
                keyColumn: "id_paciente",
                keyValue: 2,
                columns: new[] { "senha", "senha_antiga" },
                values: new object[] { "$2a$11$6CGChrSicZCdxGRKImWO4u4rpbR9fUgkbHCw8EbgsDuqr/77nfm5i", "$2a$11$JnEILtUHKQtyOmbAG9yl0OfsqmjeiaaJN8RZX5r96fIlCQ.U6aSue" });
        }
    }
}
