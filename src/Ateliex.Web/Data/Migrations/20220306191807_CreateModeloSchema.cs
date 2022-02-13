using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ateliex.Data.Migrations
{
    public partial class CreateModeloSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cadastro");

            migrationBuilder.CreateTable(
                name: "Modelo",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursoTipo",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecurso",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecurso_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalSchema: "cadastro",
                        principalTable: "Modelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModeloRecurso_ModeloRecursoTipo_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecursoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursoTipoDescricao",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoTipoDescricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecursoTipoDescricao_ModeloRecursoTipo_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecursoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursoAnexo",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Arquivo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoAnexo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecursoAnexo_ModeloRecurso_RecursoId",
                        column: x => x.RecursoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeloRecursoObservacao",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecursoId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloRecursoObservacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloRecursoObservacao_ModeloRecurso_RecursoId",
                        column: x => x.RecursoId,
                        principalSchema: "cadastro",
                        principalTable: "ModeloRecurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "Modelo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tati Model 01" },
                    { 2, "Tati Model 02" },
                    { 3, "Tati Model 03" },
                    { 4, "Tati Model 04" },
                    { 5, "Tati Model 05" },
                    { 6, "Tati Model 06" },
                    { 7, "Tati Model 07" },
                    { 8, "Tati Model 08" },
                    { 9, "Tati Model 09" },
                    { 10, "Tati Model 10" }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoTipo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Material" },
                    { 2, "Transporte" },
                    { 3, "Humano" }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecurso",
                columns: new[] { "Id", "Custo", "Descricao", "ModeloId", "TipoId", "Unidades" },
                values: new object[,]
                {
                    { 1, 20m, "Tecido", 1, 1, 2 },
                    { 2, 4m, "Linha", 1, 1, 20 },
                    { 3, 5m, "Outros", 1, 1, 1 },
                    { 4, 100m, "Transporte", 1, 2, 50 },
                    { 5, 5m, "Costureira", 1, 3, 1 }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricao",
                columns: new[] { "Id", "Texto", "TipoId" },
                values: new object[] { 1, "Lorem ipsum urna elit aptent euismod vulputate tristique, etiam eget arcu class tempus eu id class, tristique senectus commodo aenean consequat velit. ornare nisi class torquent nunc elementum nostra elementum condimentum sapien convallis, orci aptent maecenas sed mauris pretium diam nulla quisque, metus sem integer ornare aliquam vitae taciti dictumst eros. enim sit curabitur eleifend etiam aenean quisque in quis interdum nulla dolor porta consequat etiam vehicula maecenas platea placerat vitae, bibendum nunc aenean tempor nulla ultrices nec sem sociosqu dictum iaculis aliquam vulputate pellentesque dapibus per elit. amet eu suspendisse condimentum a porttitor nulla quam proin, curabitur feugiat semper eros placerat iaculis proin, maecenas senectus quisque phasellus luctus convallis rutrum.", 2 });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoAnexo",
                columns: new[] { "Id", "Arquivo", "Nome", "RecursoId" },
                values: new object[,]
                {
                    { 1, new byte[0], "Arquivo 1", 2 },
                    { 2, new byte[0], "Arquivo 2", 2 },
                    { 3, new byte[0], "Arquivo 1", 3 }
                });

            migrationBuilder.InsertData(
                schema: "cadastro",
                table: "ModeloRecursoObservacao",
                columns: new[] { "Id", "RecursoId", "Texto" },
                values: new object[] { 1, 3, "Sit lorem torquent sociosqu molestie litora mauris commodo, inceptos vel dui fames tellus pulvinar curabitur luctus, faucibus integer augue pretium neque justo. senectus elementum pulvinar justo cubilia vivamus laoreet enim per, habitant ullamcorper condimentum elementum ultrices erat pretium neque ornare, proin quisque ultricies libero vulputate aliquet sollicitudin. accumsan porttitor aliquam conubia nec netus sapien euismod nam laoreet sociosqu, quisque semper nullam nostra euismod odio amet accumsan pellentesque, aenean elit convallis sodales elementum tristique dictumst vulputate mi. torquent aliquam augue condimentum pulvinar fames platea suscipit donec, conubia sodales ad viverra nam euismod vivamus bibendum, fermentum at rutrum semper augue egestas tortor." });

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecurso_ModeloId",
                schema: "cadastro",
                table: "ModeloRecurso",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecurso_TipoId",
                schema: "cadastro",
                table: "ModeloRecurso",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursoAnexo_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoAnexo",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursoObservacao_RecursoId",
                schema: "cadastro",
                table: "ModeloRecursoObservacao",
                column: "RecursoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModeloRecursoTipoDescricao_TipoId",
                schema: "cadastro",
                table: "ModeloRecursoTipoDescricao",
                column: "TipoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloRecursoAnexo",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecursoObservacao",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecursoTipoDescricao",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecurso",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Modelo",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "ModeloRecursoTipo",
                schema: "cadastro");
        }
    }
}
