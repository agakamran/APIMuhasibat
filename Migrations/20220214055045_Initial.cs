using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMuhasibat.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    providerId = table.Column<long>(type: "bigint", nullable: true),
                    providername = table.Column<long>(type: "bigint", nullable: true),
                    photoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bolmes",
                columns: table => new
                {
                    bId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    bolmeName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolmes", x => x.bId);
                });

            migrationBuilder.CreateTable(
                name: "Emeliyyatdets",
                columns: table => new
                {
                    EmdetId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    QId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    AId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DhesId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    KhesId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    MushId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    VergiId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    VId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Miqdar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Submiqdar = table.Column<int>(type: "int", nullable: true),
                    Vahidqiymeti_alish = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Vahidqiymeti_satish = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Edv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Edvye_celbedilen = table.Column<int>(type: "int", nullable: true),
                    Edvye_celbedilmeyen = table.Column<int>(type: "int", nullable: true),
                    Emeltarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Kurs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qeyd = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emeliyyatdets", x => x.EmdetId);
                });

            migrationBuilder.CreateTable(
                name: "fealsahes",
                columns: table => new
                {
                    fsId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    fs_CODE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    fsADI = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fealsahes", x => x.fsId);
                });

            migrationBuilder.CreateTable(
                name: "Hesabs",
                columns: table => new
                {
                    HesId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Hesnom = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Hesname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    MId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ActivId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    TipId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesabs", x => x.HesId);
                });

            migrationBuilder.CreateTable(
                name: "loggers",
                columns: table => new
                {
                    lId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entityname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    opername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createduser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loggers", x => x.lId);
                });

            migrationBuilder.CreateTable(
                name: "Maddes",
                columns: table => new
                {
                    MId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    MaddeName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maddes", x => x.MId);
                });

            migrationBuilder.CreateTable(
                name: "Navbars",
                columns: table => new
                {
                    nid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    pid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ntitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    npath = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    nicon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nlan = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ncsay = table.Column<int>(type: "int", nullable: false),
                    nrol = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ink = table.Column<int>(type: "int", nullable: false),
                    nisparent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navbars", x => x.nid);
                });

            migrationBuilder.CreateTable(
                name: "Navroles",
                columns: table => new
                {
                    nrid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    nid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navroles", x => x.nrid);
                });

            migrationBuilder.CreateTable(
                name: "Shirkets",
                columns: table => new
                {
                    ShId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Bankadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bankvoen = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SWIFT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Muxbirhesab = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bankkodu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Aznhesab = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shiricrachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shirvoen = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cavabdehshexs = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unvan = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    userId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Shirpercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirkets", x => x.ShId);
                });

            migrationBuilder.CreateTable(
                name: "Tiplers",
                columns: table => new
                {
                    TipId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    TipName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiplers", x => x.TipId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aktivs",
                columns: table => new
                {
                    ActivId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ActivName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmeliyyatdetEmdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivs", x => x.ActivId);
                    table.ForeignKey(
                        name: "FK_Aktivs_Emeliyyatdets_EmeliyyatdetEmdetId",
                        column: x => x.EmeliyyatdetEmdetId,
                        principalTable: "Emeliyyatdets",
                        principalColumn: "EmdetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qrups",
                columns: table => new
                {
                    QId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Qrupname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmeliyyatdetEmdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qrups", x => x.QId);
                    table.ForeignKey(
                        name: "FK_Qrups_Emeliyyatdets_EmeliyyatdetEmdetId",
                        column: x => x.EmeliyyatdetEmdetId,
                        principalTable: "Emeliyyatdets",
                        principalColumn: "EmdetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mushteris",
                columns: table => new
                {
                    MushId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Voen = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Muqavilenom = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Muqaviletar = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valyuta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Odemesherti = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Temsilchi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmeliyyatdetEmdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mushteris", x => x.MushId);
                    table.ForeignKey(
                        name: "FK_Mushteris_Emeliyyatdets_EmeliyyatdetEmdetId",
                        column: x => x.EmeliyyatdetEmdetId,
                        principalTable: "Emeliyyatdets",
                        principalColumn: "EmdetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vahids",
                columns: table => new
                {
                    VId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Vahidadi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmeliyyatdetEmdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vahids", x => x.VId);
                    table.ForeignKey(
                        name: "FK_Vahids_Emeliyyatdets_EmeliyyatdetEmdetId",
                        column: x => x.EmeliyyatdetEmdetId,
                        principalTable: "Emeliyyatdets",
                        principalColumn: "EmdetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valyutas",
                columns: table => new
                {
                    ValId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Valnominal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmeliyyatdetEmdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valyutas", x => x.ValId);
                    table.ForeignKey(
                        name: "FK_Valyutas_Emeliyyatdets_EmeliyyatdetEmdetId",
                        column: x => x.EmeliyyatdetEmdetId,
                        principalTable: "Emeliyyatdets",
                        principalColumn: "EmdetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vergis",
                columns: table => new
                {
                    VergiId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Vergikodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Vergikodununadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Edv_tar = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmeliyyatdetEmdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vergis", x => x.VergiId);
                    table.ForeignKey(
                        name: "FK_Vergis_Emeliyyatdets_EmeliyyatdetEmdetId",
                        column: x => x.EmeliyyatdetEmdetId,
                        principalTable: "Emeliyyatdets",
                        principalColumn: "EmdetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktivs_EmeliyyatdetEmdetId",
                table: "Aktivs",
                column: "EmeliyyatdetEmdetId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Qrups_EmeliyyatdetEmdetId",
                table: "Qrups",
                column: "EmeliyyatdetEmdetId");

            migrationBuilder.CreateIndex(
                name: "IX_Mushteris_EmeliyyatdetEmdetId",
                table: "Mushteris",
                column: "EmeliyyatdetEmdetId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vahids_EmeliyyatdetEmdetId",
                table: "Vahids",
                column: "EmeliyyatdetEmdetId");

            migrationBuilder.CreateIndex(
                name: "IX_Valyutas_EmeliyyatdetEmdetId",
                table: "Valyutas",
                column: "EmeliyyatdetEmdetId");

            migrationBuilder.CreateIndex(
                name: "IX_Vergis_EmeliyyatdetEmdetId",
                table: "Vergis",
                column: "EmeliyyatdetEmdetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktivs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bolmes");

            migrationBuilder.DropTable(
                name: "fealsahes");

            migrationBuilder.DropTable(
                name: "Hesabs");

            migrationBuilder.DropTable(
                name: "Qrups");

            migrationBuilder.DropTable(
                name: "loggers");

            migrationBuilder.DropTable(
                name: "Maddes");

            migrationBuilder.DropTable(
                name: "Mushteris");

            migrationBuilder.DropTable(
                name: "Navbars");

            migrationBuilder.DropTable(
                name: "Navroles");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Shirkets");

            migrationBuilder.DropTable(
                name: "Tiplers");

            migrationBuilder.DropTable(
                name: "Vahids");

            migrationBuilder.DropTable(
                name: "Valyutas");

            migrationBuilder.DropTable(
                name: "Vergis");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Emeliyyatdets");
        }
    }
}
