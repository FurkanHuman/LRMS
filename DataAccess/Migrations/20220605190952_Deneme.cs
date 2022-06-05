using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "academic_journals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    researcher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    publisher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date_of_year = table.Column<int>(type: "integer", nullable: false),
                    volume = table.Column<int>(type: "integer", nullable: false),
                    aj_number = table.Column<int>(type: "integer", nullable: false),
                    start_page_number = table.Column<int>(type: "integer", nullable: false),
                    end_page_number = table.Column<int>(type: "integer", nullable: false),
                    is_secret = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_branches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "communications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    communication_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    fax_number = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    web_site = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_communications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "composers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_composers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "consultants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_consultants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country_name = table.Column<string>(type: "text", nullable: false),
                    country_code = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cover_caps",
                columns: table => new
                {
                    id = table.Column<byte>(type: "smallint", nullable: false),
                    book_skin_type = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cover_caps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "directors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_directors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "editors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_editors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "graphic_design",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphic_design", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "graphic_directors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphic_directors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_path = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "interpreters",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    which_to_language = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interpreters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    language_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "other_peoples",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_other_peoples", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "redactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_redactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "technical_numbers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    barcode = table.Column<long>(type: "bigint", nullable: false),
                    isbn = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    issn = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    certificate_code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technical_numbers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "writers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_pre_attachment = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_writers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    academic_journal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_academic_journals_academic_journal_id",
                        column: x => x.academic_journal_id,
                        principalTable: "academic_journals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "dimensions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    width = table.Column<double>(type: "double precision", nullable: false),
                    height = table.Column<double>(type: "double precision", nullable: false),
                    length = table.Column<double>(type: "double precision", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    academic_journal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimensions", x => x.id);
                    table.ForeignKey(
                        name: "fk_dimensions_academic_journals_academic_journal_id",
                        column: x => x.academic_journal_id,
                        principalTable: "academic_journals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "e_material_files",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    file_size_mb = table.Column<double>(type: "double precision", nullable: false),
                    is_secret = table.Column<bool>(type: "boolean", nullable: false),
                    academic_journal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_files", x => x.id);
                    table.ForeignKey(
                        name: "fk_e_material_files_academic_journals_academic_journal_id",
                        column: x => x.academic_journal_id,
                        principalTable: "academic_journals",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_name = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    postal_code = table.Column<string>(type: "text", nullable: false),
                    address_line1 = table.Column<string>(type: "text", nullable: false),
                    address_line2 = table.Column<string>(type: "text", nullable: false),
                    geo_location = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                    table.ForeignKey(
                        name: "fk_addresses_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_addresses_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_editor",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_editor", x => new { x.academic_journals_id, x.editors_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_editor_academic_journals_academic_journals",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_editor_editors_editors_id",
                        column: x => x.editors_id,
                        principalTable: "editors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "libraries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    library_name = table.Column<string>(type: "text", nullable: false),
                    library_type = table.Column<byte>(type: "smallint", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    communication_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_destroyed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_libraries", x => x.id);
                    table.ForeignKey(
                        name: "fk_libraries_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_libraries_communications_communication_id",
                        column: x => x.communication_id,
                        principalTable: "communications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    communication_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date_of_publication = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    academic_journal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publishers", x => x.id);
                    table.ForeignKey(
                        name: "fk_publishers_academic_journals_academic_journal_id",
                        column: x => x.academic_journal_id,
                        principalTable: "academic_journals",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_publishers_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_publishers_communications_communication_id",
                        column: x => x.communication_id,
                        principalTable: "communications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "universities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    university_name = table.Column<string>(type: "text", nullable: false),
                    institute = table.Column<string>(type: "text", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_universities", x => x.id);
                    table.ForeignKey(
                        name: "fk_universities_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_universities_branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "technical_placeholders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    library_id = table.Column<Guid>(type: "uuid", nullable: false),
                    stock_code = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    stock_number = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    where_is_material = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    academic_journal_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technical_placeholders", x => x.id);
                    table.ForeignKey(
                        name: "fk_technical_placeholders_academic_journals_academic_journal_id",
                        column: x => x.academic_journal_id,
                        principalTable: "academic_journals",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_technical_placeholders_libraries_library_id",
                        column: x => x.library_id,
                        principalTable: "libraries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "editions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    publisher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    edition_number = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_editions", x => x.id);
                    table.ForeignKey(
                        name: "fk_editions_publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "researchers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    specialty = table.Column<string>(type: "text", nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_researchers", x => x.id);
                    table.ForeignKey(
                        name: "fk_researchers_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_researcher",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    researchers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_researcher", x => new { x.academic_journals_id, x.researchers_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_researcher_academic_journals_academic_jour",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_researcher_researchers_researchers_id",
                        column: x => x.researchers_id,
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_editor_editors_id",
                table: "academic_journal_editor",
                column: "editors_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_researcher_researchers_id",
                table: "academic_journal_researcher",
                column: "researchers_id");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_city_id",
                table: "addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_country_id",
                table: "addresses",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_academic_journal_id",
                table: "categories",
                column: "academic_journal_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimensions_academic_journal_id",
                table: "dimensions",
                column: "academic_journal_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_files_academic_journal_id",
                table: "e_material_files",
                column: "academic_journal_id");

            migrationBuilder.CreateIndex(
                name: "ix_editions_publisher_id",
                table: "editions",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "ix_libraries_address_id",
                table: "libraries",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_libraries_communication_id",
                table: "libraries",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "ix_publishers_academic_journal_id",
                table: "publishers",
                column: "academic_journal_id");

            migrationBuilder.CreateIndex(
                name: "ix_publishers_address_id",
                table: "publishers",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_publishers_communication_id",
                table: "publishers",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_university_id",
                table: "researchers",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_technical_placeholders_academic_journal_id",
                table: "technical_placeholders",
                column: "academic_journal_id");

            migrationBuilder.CreateIndex(
                name: "ix_technical_placeholders_library_id",
                table: "technical_placeholders",
                column: "library_id");

            migrationBuilder.CreateIndex(
                name: "ix_universities_address_id",
                table: "universities",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_universities_branch_id",
                table: "universities",
                column: "branch_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academic_journal_editor");

            migrationBuilder.DropTable(
                name: "academic_journal_researcher");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "composers");

            migrationBuilder.DropTable(
                name: "consultants");

            migrationBuilder.DropTable(
                name: "cover_caps");

            migrationBuilder.DropTable(
                name: "dimensions");

            migrationBuilder.DropTable(
                name: "directors");

            migrationBuilder.DropTable(
                name: "e_material_files");

            migrationBuilder.DropTable(
                name: "editions");

            migrationBuilder.DropTable(
                name: "graphic_design");

            migrationBuilder.DropTable(
                name: "graphic_directors");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "interpreters");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "other_peoples");

            migrationBuilder.DropTable(
                name: "redactions");

            migrationBuilder.DropTable(
                name: "technical_numbers");

            migrationBuilder.DropTable(
                name: "technical_placeholders");

            migrationBuilder.DropTable(
                name: "writers");

            migrationBuilder.DropTable(
                name: "editors");

            migrationBuilder.DropTable(
                name: "researchers");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "libraries");

            migrationBuilder.DropTable(
                name: "universities");

            migrationBuilder.DropTable(
                name: "academic_journals");

            migrationBuilder.DropTable(
                name: "communications");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
