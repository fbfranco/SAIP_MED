using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAIP_MED.DATA.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentroRef",
                columns: table => new
                {
                    IdCentroRef = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCentro = table.Column<string>(maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Estado = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroRef", x => x.IdCentroRef);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreDocumento = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.IdDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreEspecialidad = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 60, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    IdDocumento = table.Column<int>(nullable: false),
                    NroDocumento = table.Column<string>(maxLength: 12, nullable: false),
                    IdEmpleado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cargo = table.Column<string>(maxLength: 20, nullable: false),
                    Estado = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Documento_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 60, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    IdDocumento = table.Column<int>(nullable: false),
                    NroDocumento = table.Column<string>(maxLength: 15, nullable: false),
                    IdSeguro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.IdSeguro);
                    table.ForeignKey(
                        name: "FK_Seguro_Documento_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 60, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    IdDocumento = table.Column<int>(nullable: false),
                    NroDocumento = table.Column<string>(maxLength: 12, nullable: false),
                    IdMedico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEspecialidad = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medico_Documento_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidad_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 60, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    IdDocumento = table.Column<int>(nullable: false),
                    NroDocumento = table.Column<string>(maxLength: 12, nullable: false),
                    IdPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSeguro = table.Column<int>(nullable: true),
                    Sexo = table.Column<string>(maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Documento_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Seguro_IdSeguro",
                        column: x => x.IdSeguro,
                        principalTable: "Seguro",
                        principalColumn: "IdSeguro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 60, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    IdDocumento = table.Column<int>(nullable: true),
                    NroDocumento = table.Column<string>(maxLength: 12, nullable: true),
                    IdContacto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Relacion = table.Column<string>(nullable: true),
                    IdPaciente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.IdContacto);
                    table.ForeignKey(
                        name: "FK_Contacto_Documento_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacto_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentroRef_NombreCentro",
                table: "CentroRef",
                column: "NombreCentro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdDocumento",
                table: "Contacto",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdPaciente",
                table: "Contacto",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_NombreDocumento",
                table: "Documento",
                column: "NombreDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdDocumento",
                table: "Empleado",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidad_NombreEspecialidad",
                table: "Especialidad",
                column: "NombreEspecialidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdDocumento",
                table: "Medico",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdEspecialidad",
                table: "Medico",
                column: "IdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdDocumento",
                table: "Paciente",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdSeguro",
                table: "Paciente",
                column: "IdSeguro");

            migrationBuilder.CreateIndex(
                name: "IX_Seguro_IdDocumento",
                table: "Seguro",
                column: "IdDocumento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CentroRef");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Seguro");

            migrationBuilder.DropTable(
                name: "Documento");
        }
    }
}
