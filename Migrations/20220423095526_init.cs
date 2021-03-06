using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMuhasibat.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "kRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CanAccess = table.Column<bool>(type: "bit", nullable: false),
                    CanAdd = table.Column<bool>(type: "bit", nullable: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    providerId = table.Column<long>(type: "bigint", nullable: true),
                    providername = table.Column<long>(type: "bigint", nullable: true),
                    photoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_kUsers", x => x.Id);
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
                name: "operations",
                columns: table => new
                {
                    OpId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Miqdar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Submiqdar = table.Column<int>(type: "int", nullable: true),
                    Alishqiy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Satishqiy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Aksizderecesi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Yolvergisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PdetId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Qeyd = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operations", x => x.OpId);
                });

            migrationBuilder.CreateTable(
                name: "Bolmes",
                columns: table => new
                {
                    bId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    bolmeName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    HesabHesId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolmes", x => x.bId);
                    table.ForeignKey(
                        name: "FK_Bolmes_Hesabs_HesabHesId",
                        column: x => x.HesabHesId,
                        principalTable: "Hesabs",
                        principalColumn: "HesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maddes",
                columns: table => new
                {
                    MId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    MaddeName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    HesabHesId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maddes", x => x.MId);
                    table.ForeignKey(
                        name: "FK_Maddes_Hesabs_HesabHesId",
                        column: x => x.HesabHesId,
                        principalTable: "Hesabs",
                        principalColumn: "HesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tiplers",
                columns: table => new
                {
                    TipId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    TipName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HesabHesId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiplers", x => x.TipId);
                    table.ForeignKey(
                        name: "FK_Tiplers_Hesabs_HesabHesId",
                        column: x => x.HesabHesId,
                        principalTable: "Hesabs",
                        principalColumn: "HesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
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
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_kRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "kRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kUserClaims",
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
                    table.PrimaryKey("PK_kUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kUserClaims_kUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "kUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_kUserLogins_kUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "kUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_kUserRoles_kRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "kRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kUserRoles_kUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "kUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_kUserTokens_kUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "kUsers",
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
                        name: "FK_RefreshToken_kUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "kUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productdetals",
                columns: table => new
                {
                    PdetId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    PmasId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Maladi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Barkod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VergiId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    VId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Edv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Qeyd = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    operationOpId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productdetals", x => x.PdetId);
                    table.ForeignKey(
                        name: "FK_Productdetals_operations_operationOpId",
                        column: x => x.operationOpId,
                        principalTable: "operations",
                        principalColumn: "OpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productmasters",
                columns: table => new
                {
                    PmasId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    MushId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Kimden_voen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Kimden_sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Emeltarixi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pay = table.Column<bool>(type: "bit", nullable: false),
                    Vo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ActivId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    AnbId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ValId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Kurs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ShId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ProductdetalPdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productmasters", x => x.PmasId);
                    table.ForeignKey(
                        name: "FK_Productmasters_Productdetals_ProductdetalPdetId",
                        column: x => x.ProductdetalPdetId,
                        principalTable: "Productdetals",
                        principalColumn: "PdetId",
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
                    ProductdetalPdetId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vergis", x => x.VergiId);
                    table.ForeignKey(
                        name: "FK_Vergis_Productdetals_ProductdetalPdetId",
                        column: x => x.ProductdetalPdetId,
                        principalTable: "Productdetals",
                        principalColumn: "PdetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aktivs",
                columns: table => new
                {
                    ActivId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ActivName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HesabHesId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    ProductmasterPmasId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivs", x => x.ActivId);
                    table.ForeignKey(
                        name: "FK_Aktivs_Hesabs_HesabHesId",
                        column: x => x.HesabHesId,
                        principalTable: "Hesabs",
                        principalColumn: "HesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aktivs_Productmasters_ProductmasterPmasId",
                        column: x => x.ProductmasterPmasId,
                        principalTable: "Productmasters",
                        principalColumn: "PmasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "anbars",
                columns: table => new
                {
                    AnbId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Anbarname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductmasterPmasId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anbars", x => x.AnbId);
                    table.ForeignKey(
                        name: "FK_anbars_Productmasters_ProductmasterPmasId",
                        column: x => x.ProductmasterPmasId,
                        principalTable: "Productmasters",
                        principalColumn: "PmasId",
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
                    ProductmasterPmasId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mushteris", x => x.MushId);
                    table.ForeignKey(
                        name: "FK_Mushteris_Productmasters_ProductmasterPmasId",
                        column: x => x.ProductmasterPmasId,
                        principalTable: "Productmasters",
                        principalColumn: "PmasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qrups",
                columns: table => new
                {
                    QId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Qrupname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DhesId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    KhesId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ProductmasterPmasId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qrups", x => x.QId);
                    table.ForeignKey(
                        name: "FK_Qrups_Productmasters_ProductmasterPmasId",
                        column: x => x.ProductmasterPmasId,
                        principalTable: "Productmasters",
                        principalColumn: "PmasId",
                        onDelete: ReferentialAction.Restrict);
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
                    Shirpercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductmasterPmasId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirkets", x => x.ShId);
                    table.ForeignKey(
                        name: "FK_Shirkets_Productmasters_ProductmasterPmasId",
                        column: x => x.ProductmasterPmasId,
                        principalTable: "Productmasters",
                        principalColumn: "PmasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valyutas",
                columns: table => new
                {
                    ValId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Valname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Valnominal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarix = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductmasterPmasId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valyutas", x => x.ValId);
                    table.ForeignKey(
                        name: "FK_Valyutas_Productmasters_ProductmasterPmasId",
                        column: x => x.ProductmasterPmasId,
                        principalTable: "Productmasters",
                        principalColumn: "PmasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vahids",
                columns: table => new
                {
                    VId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Vahidadi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProductdetalPdetId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    VergiId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vahids", x => x.VId);
                    table.ForeignKey(
                        name: "FK_Vahids_Productdetals_ProductdetalPdetId",
                        column: x => x.ProductdetalPdetId,
                        principalTable: "Productdetals",
                        principalColumn: "PdetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vahids_Vergis_VergiId",
                        column: x => x.VergiId,
                        principalTable: "Vergis",
                        principalColumn: "VergiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktivs_HesabHesId",
                table: "Aktivs",
                column: "HesabHesId");

            migrationBuilder.CreateIndex(
                name: "IX_Aktivs_ProductmasterPmasId",
                table: "Aktivs",
                column: "ProductmasterPmasId");

            migrationBuilder.CreateIndex(
                name: "IX_anbars_ProductmasterPmasId",
                table: "anbars",
                column: "ProductmasterPmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolmes_HesabHesId",
                table: "Bolmes",
                column: "HesabHesId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "kRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_kUserClaims_UserId",
                table: "kUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_kUserLogins_UserId",
                table: "kUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_kUserRoles_RoleId",
                table: "kUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "kUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "kUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Maddes_HesabHesId",
                table: "Maddes",
                column: "HesabHesId");

            migrationBuilder.CreateIndex(
                name: "IX_Mushteris_ProductmasterPmasId",
                table: "Mushteris",
                column: "ProductmasterPmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Productdetals_operationOpId",
                table: "Productdetals",
                column: "operationOpId");

            migrationBuilder.CreateIndex(
                name: "IX_Productmasters_ProductdetalPdetId",
                table: "Productmasters",
                column: "ProductdetalPdetId");

            migrationBuilder.CreateIndex(
                name: "IX_Qrups_ProductmasterPmasId",
                table: "Qrups",
                column: "ProductmasterPmasId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Shirkets_ProductmasterPmasId",
                table: "Shirkets",
                column: "ProductmasterPmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiplers_HesabHesId",
                table: "Tiplers",
                column: "HesabHesId");

            migrationBuilder.CreateIndex(
                name: "IX_Vahids_ProductdetalPdetId",
                table: "Vahids",
                column: "ProductdetalPdetId");

            migrationBuilder.CreateIndex(
                name: "IX_Vahids_VergiId",
                table: "Vahids",
                column: "VergiId");

            migrationBuilder.CreateIndex(
                name: "IX_Valyutas_ProductmasterPmasId",
                table: "Valyutas",
                column: "ProductmasterPmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Vergis_ProductdetalPdetId",
                table: "Vergis",
                column: "ProductdetalPdetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktivs");

            migrationBuilder.DropTable(
                name: "anbars");

            migrationBuilder.DropTable(
                name: "Bolmes");

            migrationBuilder.DropTable(
                name: "fealsahes");

            migrationBuilder.DropTable(
                name: "kUserClaims");

            migrationBuilder.DropTable(
                name: "kUserLogins");

            migrationBuilder.DropTable(
                name: "kUserRoles");

            migrationBuilder.DropTable(
                name: "kUserTokens");

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
                name: "Qrups");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Shirkets");

            migrationBuilder.DropTable(
                name: "Tiplers");

            migrationBuilder.DropTable(
                name: "Vahids");

            migrationBuilder.DropTable(
                name: "Valyutas");

            migrationBuilder.DropTable(
                name: "kUsers");

            migrationBuilder.DropTable(
                name: "kRoles");

            migrationBuilder.DropTable(
                name: "Hesabs");

            migrationBuilder.DropTable(
                name: "Vergis");

            migrationBuilder.DropTable(
                name: "Productmasters");

            migrationBuilder.DropTable(
                name: "Productdetals");

            migrationBuilder.DropTable(
                name: "operations");
        }
    }
}
