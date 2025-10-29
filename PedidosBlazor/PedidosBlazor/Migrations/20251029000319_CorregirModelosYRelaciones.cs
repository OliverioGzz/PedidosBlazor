using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PedidosBlazor.Migrations
{
    /// <inheritdoc />
    public partial class CorregirModelosYRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsPedido_Platillos_PlatilloId",
                table: "ItemsPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Empleados_EmpleadoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_MesaId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Mesas_Numero",
                table: "Mesas");

            migrationBuilder.DeleteData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platillos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platillos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "ItemsPedido");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Empleados");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Platillos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Platillos",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Pedidos",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "Pendiente");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Mesas",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldDefaultValue: "Libre");

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Juan Pérez");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Estado",
                value: "Disponible");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Estado",
                value: "Disponible");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Estado",
                value: "Disponible");

            migrationBuilder.UpdateData(
                table: "Platillos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descripcion", "Nombre", "Precio" },
                values: new object[] { null, "Tacos", 45.00m });

            migrationBuilder.UpdateData(
                table: "Platillos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "Nombre", "Precio" },
                values: new object[] { null, "Quesadillas", 35.00m });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsPedido_Platillos_PlatilloId",
                table: "ItemsPedido",
                column: "PlatilloId",
                principalTable: "Platillos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Empleados_EmpleadoId",
                table: "Pedidos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_MesaId",
                table: "Pedidos",
                column: "MesaId",
                principalTable: "Mesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsPedido_Platillos_PlatilloId",
                table: "ItemsPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Empleados_EmpleadoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mesas_MesaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Platillos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Platillos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: "Pendiente",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Mesas",
                type: "TEXT",
                nullable: false,
                defaultValue: "Libre",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "ItemsPedido",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Empleados",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nombre", "Rol" },
                values: new object[] { "Mesero Principal", "Mesero" });

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Estado",
                value: "Libre");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Estado",
                value: "Libre");

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Estado",
                value: "Libre");

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "Estado", "Numero" },
                values: new object[,]
                {
                    { 4, "Libre", 4 },
                    { 5, "Libre", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Platillos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nombre", "Precio" },
                values: new object[] { "Hamburguesa", 8.99m });

            migrationBuilder.UpdateData(
                table: "Platillos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nombre", "Precio" },
                values: new object[] { "Pizza", 12.50m });

            migrationBuilder.InsertData(
                table: "Platillos",
                columns: new[] { "Id", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 3, "Ensalada", 6.75m },
                    { 4, "Sopa", 4.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_Numero",
                table: "Mesas",
                column: "Numero",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsPedido_Platillos_PlatilloId",
                table: "ItemsPedido",
                column: "PlatilloId",
                principalTable: "Platillos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Empleados_EmpleadoId",
                table: "Pedidos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mesas_MesaId",
                table: "Pedidos",
                column: "MesaId",
                principalTable: "Mesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
