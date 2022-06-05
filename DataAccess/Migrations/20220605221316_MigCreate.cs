using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigCreate : Migration
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
                name: "audio_records",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    record_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    record_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    recording_length = table.Column<float>(type: "real", nullable: false),
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
                    table.PrimaryKey("pk_audio_records", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    original_book_name = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false),
                    cover_cap_id = table.Column<byte>(type: "smallint", nullable: false),
                    cover_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_page_people_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_number_id = table.Column<Guid>(type: "uuid", nullable: false),
                    edition_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
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
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
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
                name: "e_material_files",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    file_size_mb = table.Column<double>(type: "double precision", nullable: false),
                    is_secret = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_files", x => x.id);
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
                name: "dimensions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    width = table.Column<double>(type: "double precision", nullable: false),
                    height = table.Column<double>(type: "double precision", nullable: false),
                    length = table.Column<double>(type: "double precision", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    audio_record_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimensions", x => x.id);
                    table.ForeignKey(
                        name: "fk_dimensions_audio_records_audio_record_id",
                        column: x => x.audio_record_id,
                        principalTable: "audio_records",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "book_series",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    book_ids = table.Column<Guid>(type: "uuid", nullable: false),
                    book_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false),
                    cover_cap_id = table.Column<byte>(type: "smallint", nullable: false),
                    cover_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_page_people_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_number_id = table.Column<Guid>(type: "uuid", nullable: false),
                    edition_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series", x => x.id);
                    table.ForeignKey(
                        name: "fk_book_series_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_category",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    categories_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_category", x => new { x.academic_journals_id, x.categories_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_category_academic_journals_academic_journa",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_category_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audio_record_category",
                columns: table => new
                {
                    audio_records_id = table.Column<Guid>(type: "uuid", nullable: false),
                    categories_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio_record_category", x => new { x.audio_records_id, x.categories_id });
                    table.ForeignKey(
                        name: "fk_audio_record_category_audio_records_audio_records_id",
                        column: x => x.audio_records_id,
                        principalTable: "audio_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_audio_record_category_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_category",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    categories_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_category", x => new { x.books_id, x.categories_id });
                    table.ForeignKey(
                        name: "fk_book_category_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_category_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "book_cover_cap",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cover_caps_id = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_cover_cap", x => new { x.books_id, x.cover_caps_id });
                    table.ForeignKey(
                        name: "fk_book_cover_cap_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_cover_cap_cover_caps_cover_caps_id",
                        column: x => x.cover_caps_id,
                        principalTable: "cover_caps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_e_material_file",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_e_material_file", x => new { x.academic_journals_id, x.e_material_files_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_e_material_file_academic_journals_academic",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_e_material_file_e_material_files_e_materia",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audio_record_e_material_file",
                columns: table => new
                {
                    audio_records_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio_record_e_material_file", x => new { x.audio_records_id, x.e_material_files_id });
                    table.ForeignKey(
                        name: "fk_audio_record_e_material_file_audio_records_audio_records_id",
                        column: x => x.audio_records_id,
                        principalTable: "audio_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_audio_record_e_material_file_e_material_files_e_material_fi",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_e_material_file",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_e_material_file", x => new { x.books_id, x.e_material_files_id });
                    table.ForeignKey(
                        name: "fk_book_e_material_file_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_e_material_file_e_material_files_e_material_files_id",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_image",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cover_images_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_image", x => new { x.books_id, x.cover_images_id });
                    table.ForeignKey(
                        name: "fk_book_image_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_image_images_cover_images_id",
                        column: x => x.cover_images_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_technical_number",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_numbers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_technical_number", x => new { x.books_id, x.technical_numbers_id });
                    table.ForeignKey(
                        name: "fk_book_technical_number_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_technical_number_technical_numbers_technical_numbers_id",
                        column: x => x.technical_numbers_id,
                        principalTable: "technical_numbers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_dimension",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_dimension", x => new { x.academic_journals_id, x.dimensions_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_dimension_academic_journals_academic_journ",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_dimension_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_dimension",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_dimension", x => new { x.books_id, x.dimensions_id });
                    table.ForeignKey(
                        name: "fk_book_dimension_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_dimension_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_category",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    categories_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_category", x => new { x.book_series_id, x.categories_id });
                    table.ForeignKey(
                        name: "fk_book_series_category_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_category_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_cover_cap",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cover_caps_id = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_cover_cap", x => new { x.book_series_id, x.cover_caps_id });
                    table.ForeignKey(
                        name: "fk_book_series_cover_cap_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_cover_cap_cover_caps_cover_caps_id",
                        column: x => x.cover_caps_id,
                        principalTable: "cover_caps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_dimension",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_dimension", x => new { x.book_series_id, x.dimensions_id });
                    table.ForeignKey(
                        name: "fk_book_series_dimension_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_dimension_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_e_material_file",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_e_material_file", x => new { x.book_series_id, x.e_material_files_id });
                    table.ForeignKey(
                        name: "fk_book_series_e_material_file_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_e_material_file_e_material_files_e_material_fil",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_image",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cover_images_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_image", x => new { x.book_series_id, x.cover_images_id });
                    table.ForeignKey(
                        name: "fk_book_series_image_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_image_images_cover_images_id",
                        column: x => x.cover_images_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_technical_number",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_numbers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_technical_number", x => new { x.book_series_id, x.technical_numbers_id });
                    table.ForeignKey(
                        name: "fk_book_series_technical_number_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_technical_number_technical_numbers_technical_nu",
                        column: x => x.technical_numbers_id,
                        principalTable: "technical_numbers",
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
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publishers", x => x.id);
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
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technical_placeholders", x => x.id);
                    table.ForeignKey(
                        name: "fk_technical_placeholders_libraries_library_id",
                        column: x => x.library_id,
                        principalTable: "libraries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_publisher",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    publishers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_publisher", x => new { x.academic_journals_id, x.publishers_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_publisher_academic_journals_academic_journ",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_publisher_publishers_publishers_id",
                        column: x => x.publishers_id,
                        principalTable: "publishers",
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
                name: "first_page_person_base",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    sur_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    consultant_name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    which_to_language = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    other_people_name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    researcher_name_pre_attachment = table.Column<string>(type: "text", nullable: true),
                    specialty = table.Column<string>(type: "text", nullable: true),
                    university_id = table.Column<Guid>(type: "uuid", nullable: true),
                    writer_name_pre_attachment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_first_page_person_base", x => x.id);
                    table.ForeignKey(
                        name: "fk_first_page_person_base_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_technical_placeholder",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_technical_placeholder", x => new { x.academic_journals_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_technical_placeholder_academic_journals_ac",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_technical_placeholder_technical_placeholde",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audio_record_technical_placeholder",
                columns: table => new
                {
                    audio_records_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio_record_technical_placeholder", x => new { x.audio_records_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_audio_record_technical_placeholder_audio_records_audio_reco",
                        column: x => x.audio_records_id,
                        principalTable: "audio_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_audio_record_technical_placeholder_technical_placeholders_t",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_technical_placeholder",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_technical_placeholder", x => new { x.book_series_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_book_series_technical_placeholder_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_technical_placeholder_technical_placeholders_te",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_technical_placeholder",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_technical_placeholder", x => new { x.books_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_book_technical_placeholder_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_technical_placeholder_technical_placeholders_technical",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_edition",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_edition", x => new { x.books_id, x.editions_id });
                    table.ForeignKey(
                        name: "fk_book_edition_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_edition_editions_editions_id",
                        column: x => x.editions_id,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_edition",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_edition", x => new { x.book_series_id, x.editions_id });
                    table.ForeignKey(
                        name: "fk_book_series_edition_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_edition_editions_editions_id",
                        column: x => x.editions_id,
                        principalTable: "editions",
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
                        name: "fk_academic_journal_editor_first_page_person_base_editors_id",
                        column: x => x.editors_id,
                        principalTable: "first_page_person_base",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "fk_academic_journal_researcher_first_page_person_base_research",
                        column: x => x.researchers_id,
                        principalTable: "first_page_person_base",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_first_page_person_base",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_page_people_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_first_page_person_base", x => new { x.books_id, x.first_page_people_id });
                    table.ForeignKey(
                        name: "fk_book_first_page_person_base_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_first_page_person_base_first_page_person_base_first_pa",
                        column: x => x.first_page_people_id,
                        principalTable: "first_page_person_base",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_first_page_person_base",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_page_people_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_first_page_person_base", x => new { x.book_series_id, x.first_page_people_id });
                    table.ForeignKey(
                        name: "fk_book_series_first_page_person_base_book_series_book_series_",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_first_page_person_base_first_page_person_base_f",
                        column: x => x.first_page_people_id,
                        principalTable: "first_page_person_base",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_category_categories_id",
                table: "academic_journal_category",
                column: "categories_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_dimension_dimensions_id",
                table: "academic_journal_dimension",
                column: "dimensions_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_e_material_file_e_material_files_id",
                table: "academic_journal_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_editor_editors_id",
                table: "academic_journal_editor",
                column: "editors_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_publisher_publishers_id",
                table: "academic_journal_publisher",
                column: "publishers_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_researcher_researchers_id",
                table: "academic_journal_researcher",
                column: "researchers_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_technical_placeholder_technical_placeholde",
                table: "academic_journal_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_city_id",
                table: "addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_country_id",
                table: "addresses",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_audio_record_category_categories_id",
                table: "audio_record_category",
                column: "categories_id");

            migrationBuilder.CreateIndex(
                name: "ix_audio_record_e_material_file_e_material_files_id",
                table: "audio_record_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_audio_record_technical_placeholder_technical_placeholders_id",
                table: "audio_record_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_category_categories_id",
                table: "book_category",
                column: "categories_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_cover_cap_cover_caps_id",
                table: "book_cover_cap",
                column: "cover_caps_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_dimension_dimensions_id",
                table: "book_dimension",
                column: "dimensions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_e_material_file_e_material_files_id",
                table: "book_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_edition_editions_id",
                table: "book_edition",
                column: "editions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_first_page_person_base_first_page_people_id",
                table: "book_first_page_person_base",
                column: "first_page_people_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_image_cover_images_id",
                table: "book_image",
                column: "cover_images_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_book_id",
                table: "book_series",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_category_categories_id",
                table: "book_series_category",
                column: "categories_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_cover_cap_cover_caps_id",
                table: "book_series_cover_cap",
                column: "cover_caps_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_dimension_dimensions_id",
                table: "book_series_dimension",
                column: "dimensions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_e_material_file_e_material_files_id",
                table: "book_series_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_edition_editions_id",
                table: "book_series_edition",
                column: "editions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_first_page_person_base_first_page_people_id",
                table: "book_series_first_page_person_base",
                column: "first_page_people_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_image_cover_images_id",
                table: "book_series_image",
                column: "cover_images_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_technical_number_technical_numbers_id",
                table: "book_series_technical_number",
                column: "technical_numbers_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_technical_placeholder_technical_placeholders_id",
                table: "book_series_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_technical_number_technical_numbers_id",
                table: "book_technical_number",
                column: "technical_numbers_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_technical_placeholder_technical_placeholders_id",
                table: "book_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimensions_audio_record_id",
                table: "dimensions",
                column: "audio_record_id");

            migrationBuilder.CreateIndex(
                name: "ix_editions_publisher_id",
                table: "editions",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "ix_first_page_person_base_university_id",
                table: "first_page_person_base",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_libraries_address_id",
                table: "libraries",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_libraries_communication_id",
                table: "libraries",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "ix_publishers_address_id",
                table: "publishers",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_publishers_communication_id",
                table: "publishers",
                column: "communication_id");

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
                name: "academic_journal_category");

            migrationBuilder.DropTable(
                name: "academic_journal_dimension");

            migrationBuilder.DropTable(
                name: "academic_journal_e_material_file");

            migrationBuilder.DropTable(
                name: "academic_journal_editor");

            migrationBuilder.DropTable(
                name: "academic_journal_publisher");

            migrationBuilder.DropTable(
                name: "academic_journal_researcher");

            migrationBuilder.DropTable(
                name: "academic_journal_technical_placeholder");

            migrationBuilder.DropTable(
                name: "audio_record_category");

            migrationBuilder.DropTable(
                name: "audio_record_e_material_file");

            migrationBuilder.DropTable(
                name: "audio_record_technical_placeholder");

            migrationBuilder.DropTable(
                name: "book_category");

            migrationBuilder.DropTable(
                name: "book_cover_cap");

            migrationBuilder.DropTable(
                name: "book_dimension");

            migrationBuilder.DropTable(
                name: "book_e_material_file");

            migrationBuilder.DropTable(
                name: "book_edition");

            migrationBuilder.DropTable(
                name: "book_first_page_person_base");

            migrationBuilder.DropTable(
                name: "book_image");

            migrationBuilder.DropTable(
                name: "book_series_category");

            migrationBuilder.DropTable(
                name: "book_series_cover_cap");

            migrationBuilder.DropTable(
                name: "book_series_dimension");

            migrationBuilder.DropTable(
                name: "book_series_e_material_file");

            migrationBuilder.DropTable(
                name: "book_series_edition");

            migrationBuilder.DropTable(
                name: "book_series_first_page_person_base");

            migrationBuilder.DropTable(
                name: "book_series_image");

            migrationBuilder.DropTable(
                name: "book_series_technical_number");

            migrationBuilder.DropTable(
                name: "book_series_technical_placeholder");

            migrationBuilder.DropTable(
                name: "book_technical_number");

            migrationBuilder.DropTable(
                name: "book_technical_placeholder");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "academic_journals");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "cover_caps");

            migrationBuilder.DropTable(
                name: "dimensions");

            migrationBuilder.DropTable(
                name: "e_material_files");

            migrationBuilder.DropTable(
                name: "editions");

            migrationBuilder.DropTable(
                name: "first_page_person_base");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "book_series");

            migrationBuilder.DropTable(
                name: "technical_numbers");

            migrationBuilder.DropTable(
                name: "technical_placeholders");

            migrationBuilder.DropTable(
                name: "audio_records");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "universities");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "libraries");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "communications");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
