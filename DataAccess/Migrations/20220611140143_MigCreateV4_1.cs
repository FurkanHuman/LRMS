using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigCreateV4_1 : Migration
    {
        /// <inheritdoc />
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
                    reference_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    price = table.Column<decimal>(type: "numeric", nullable: false),
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
                    price = table.Column<decimal>(type: "numeric", nullable: false),
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
                    reference_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false),
                    cover_cap_id = table.Column<byte>(type: "smallint", nullable: false),
                    cover_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_design_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: true),
                    redaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    other_people_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                name: "cartographic_materials",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartographic_materials", x => x.id);
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
                name: "electronics_resources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    resource_url = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_electronics_resources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sequence_number = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false),
                    cover_cap_id = table.Column<byte>(type: "smallint", nullable: false),
                    cover_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_design_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: true),
                    redaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    other_people_id = table.Column<Guid>(type: "uuid", nullable: true),
                    technical_number_id = table.Column<Guid>(type: "uuid", nullable: false),
                    edition_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedias", x => x.id);
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
                name: "graphical_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_destroyed = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphical_images", x => x.id);
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
                name: "kits",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: true),
                    audio_records_id = table.Column<Guid>(type: "uuid", nullable: true),
                    books_id = table.Column<Guid>(type: "uuid", nullable: true),
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: true),
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: true),
                    depictions_id = table.Column<Guid>(type: "uuid", nullable: true),
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: true),
                    electronics_resources_id = table.Column<Guid>(type: "uuid", nullable: true),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphical_images_id = table.Column<Guid>(type: "uuid", nullable: true),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: true),
                    microforms_id = table.Column<Guid>(type: "uuid", nullable: true),
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: true),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: true),
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: true),
                    paintings_id = table.Column<Guid>(type: "uuid", nullable: true),
                    posters_id = table.Column<Guid>(type: "uuid", nullable: true),
                    theses_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kits", x => x.id);
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
                name: "magazines",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazine_type = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false),
                    cover_cap_id = table.Column<byte>(type: "smallint", nullable: false),
                    cover_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_design_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: true),
                    redaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    other_people_id = table.Column<Guid>(type: "uuid", nullable: true),
                    technical_number_id = table.Column<Guid>(type: "uuid", nullable: false),
                    edition_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_magazines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "microforms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    scale = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_microforms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "musical_notes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    composer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date_of_writing = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_secret = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_musical_notes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_papers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_paper_name = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_destroyed = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false),
                    cover_cap_id = table.Column<byte>(type: "smallint", nullable: false),
                    cover_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_design_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: true),
                    redaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    other_people_id = table.Column<Guid>(type: "uuid", nullable: true),
                    technical_number_id = table.Column<Guid>(type: "uuid", nullable: false),
                    edition_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_papers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "object3ds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_destroyed = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_object3ds", x => x.id);
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
                name: "posters",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_destroyed = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_posters", x => x.id);
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
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false),
                    cover_cap_id = table.Column<byte>(type: "smallint", nullable: false),
                    cover_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_design_id = table.Column<Guid>(type: "uuid", nullable: true),
                    graphic_director_id = table.Column<Guid>(type: "uuid", nullable: true),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: true),
                    redaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    other_people_id = table.Column<Guid>(type: "uuid", nullable: true),
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
                name: "cartographic_material_category",
                columns: table => new
                {
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: false),
                    categories_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartographic_material_category", x => new { x.cartographic_materials_id, x.categories_id });
                    table.ForeignKey(
                        name: "fk_cartographic_material_category_cartographic_materials_carto",
                        column: x => x.cartographic_materials_id,
                        principalTable: "cartographic_materials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cartographic_material_category_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                    table.ForeignKey(
                        name: "fk_cities_countries_country_id",
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
                name: "book_director",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    directors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_director", x => new { x.books_id, x.directors_id });
                    table.ForeignKey(
                        name: "fk_book_director_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_director_directors_directors_id",
                        column: x => x.directors_id,
                        principalTable: "directors",
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
                name: "book_editor",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_editor", x => new { x.books_id, x.editors_id });
                    table.ForeignKey(
                        name: "fk_book_editor_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_editor_editors_editors_id",
                        column: x => x.editors_id,
                        principalTable: "editors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_electronics_resource",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    electronics_resources_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_electronics_resource", x => new { x.categories_id, x.electronics_resources_id });
                    table.ForeignKey(
                        name: "fk_category_electronics_resource_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_electronics_resource_electronics_resources_electro",
                        column: x => x.electronics_resources_id,
                        principalTable: "electronics_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_encyclopedia",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_encyclopedia", x => new { x.categories_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_category_encyclopedia_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_encyclopedia_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cover_cap_encyclopedia",
                columns: table => new
                {
                    cover_caps_id = table.Column<byte>(type: "smallint", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cover_cap_encyclopedia", x => new { x.cover_caps_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_cover_cap_encyclopedia_cover_caps_cover_caps_id",
                        column: x => x.cover_caps_id,
                        principalTable: "cover_caps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cover_cap_encyclopedia_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "director_encyclopedia",
                columns: table => new
                {
                    directors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_director_encyclopedia", x => new { x.directors_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_director_encyclopedia_directors_directors_id",
                        column: x => x.directors_id,
                        principalTable: "directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_director_encyclopedia_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "editor_encyclopedia",
                columns: table => new
                {
                    editors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_editor_encyclopedia", x => new { x.editors_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_editor_encyclopedia_editors_editors_id",
                        column: x => x.editors_id,
                        principalTable: "editors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_editor_encyclopedia_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_graphic_designer",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphic_designs_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_graphic_designer", x => new { x.books_id, x.graphic_designs_id });
                    table.ForeignKey(
                        name: "fk_book_graphic_designer_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_graphic_designer_graphic_design_graphic_designs_id",
                        column: x => x.graphic_designs_id,
                        principalTable: "graphic_design",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_graphic_designer",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphic_designs_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_graphic_designer", x => new { x.encyclopedias_id, x.graphic_designs_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_graphic_designer_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_graphic_designer_graphic_design_graphic_design",
                        column: x => x.graphic_designs_id,
                        principalTable: "graphic_design",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_graphic_director",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphic_directors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_graphic_director", x => new { x.books_id, x.graphic_directors_id });
                    table.ForeignKey(
                        name: "fk_book_graphic_director_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_graphic_director_graphic_directors_graphic_directors_id",
                        column: x => x.graphic_directors_id,
                        principalTable: "graphic_directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_graphic_director",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphic_directors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_graphic_director", x => new { x.encyclopedias_id, x.graphic_directors_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_graphic_director_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_graphic_director_graphic_directors_graphic_dir",
                        column: x => x.graphic_directors_id,
                        principalTable: "graphic_directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_graphical_image",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    graphical_images_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_graphical_image", x => new { x.categories_id, x.graphical_images_id });
                    table.ForeignKey(
                        name: "fk_category_graphical_image_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_graphical_image_graphical_images_graphical_images_",
                        column: x => x.graphical_images_id,
                        principalTable: "graphical_images",
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
                name: "cartographic_material_image",
                columns: table => new
                {
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: false),
                    images_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartographic_material_image", x => new { x.cartographic_materials_id, x.images_id });
                    table.ForeignKey(
                        name: "fk_cartographic_material_image_cartographic_materials_cartogra",
                        column: x => x.cartographic_materials_id,
                        principalTable: "cartographic_materials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cartographic_material_image_images_images_id",
                        column: x => x.images_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "depictions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_depictions", x => x.id);
                    table.ForeignKey(
                        name: "fk_depictions_images_image_id",
                        column: x => x.image_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_image",
                columns: table => new
                {
                    cover_images_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_image", x => new { x.cover_images_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_image_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_image_images_cover_images_id",
                        column: x => x.cover_images_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paintings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_destroyed = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paintings", x => x.id);
                    table.ForeignKey(
                        name: "fk_paintings_images_image_id",
                        column: x => x.image_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_interpreters",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_interpreters", x => new { x.books_id, x.interpreters_id });
                    table.ForeignKey(
                        name: "fk_book_interpreters_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_interpreters_interpreters_interpreters_id",
                        column: x => x.interpreters_id,
                        principalTable: "interpreters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_interpreters",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_interpreters", x => new { x.encyclopedias_id, x.interpreters_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_interpreters_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_interpreters_interpreters_interpreters_id",
                        column: x => x.interpreters_id,
                        principalTable: "interpreters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_kit",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_kit", x => new { x.academic_journals_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_kit_academic_journals_academic_journals_id",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audio_record_kit",
                columns: table => new
                {
                    audio_records_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio_record_kit", x => new { x.audio_records_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_audio_record_kit_audio_records_audio_records_id",
                        column: x => x.audio_records_id,
                        principalTable: "audio_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_audio_record_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_kit",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_kit", x => new { x.books_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_book_kit_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartographic_material_kit",
                columns: table => new
                {
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartographic_material_kit", x => new { x.cartographic_materials_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_cartographic_material_kit_cartographic_materials_cartograph",
                        column: x => x.cartographic_materials_id,
                        principalTable: "cartographic_materials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cartographic_material_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_kit",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_kit", x => new { x.categories_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_category_kit_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    kit_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimensions", x => x.id);
                    table.ForeignKey(
                        name: "fk_dimensions_kits_kit_id",
                        column: x => x.kit_id,
                        principalTable: "kits",
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
                    kit_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_files", x => x.id);
                    table.ForeignKey(
                        name: "fk_e_material_files_kits_kit_id",
                        column: x => x.kit_id,
                        principalTable: "kits",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "electronics_resource_kit",
                columns: table => new
                {
                    electronics_resources_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_electronics_resource_kit", x => new { x.electronics_resources_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_electronics_resource_kit_electronics_resources_electronics_",
                        column: x => x.electronics_resources_id,
                        principalTable: "electronics_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_electronics_resource_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_kit",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_kit", x => new { x.encyclopedias_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_kit_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graphical_image_kit",
                columns: table => new
                {
                    graphical_images_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphical_image_kit", x => new { x.graphical_images_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_graphical_image_kit_graphical_images_graphical_images_id",
                        column: x => x.graphical_images_id,
                        principalTable: "graphical_images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_graphical_image_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_magazine",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_magazine", x => new { x.categories_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_category_magazine_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cover_cap_magazine",
                columns: table => new
                {
                    cover_caps_id = table.Column<byte>(type: "smallint", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cover_cap_magazine", x => new { x.cover_caps_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_cover_cap_magazine_cover_caps_cover_caps_id",
                        column: x => x.cover_caps_id,
                        principalTable: "cover_caps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cover_cap_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "director_magazine",
                columns: table => new
                {
                    directors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_director_magazine", x => new { x.directors_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_director_magazine_directors_directors_id",
                        column: x => x.directors_id,
                        principalTable: "directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_director_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "editor_magazine",
                columns: table => new
                {
                    editors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_editor_magazine", x => new { x.editors_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_editor_magazine_editors_editors_id",
                        column: x => x.editors_id,
                        principalTable: "editors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_editor_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graphic_designer_magazine",
                columns: table => new
                {
                    graphic_designs_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphic_designer_magazine", x => new { x.graphic_designs_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_graphic_designer_magazine_graphic_design_graphic_designs_id",
                        column: x => x.graphic_designs_id,
                        principalTable: "graphic_design",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_graphic_designer_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graphic_director_magazine",
                columns: table => new
                {
                    graphic_directors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphic_director_magazine", x => new { x.graphic_directors_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_graphic_director_magazine_graphic_directors_graphic_directo",
                        column: x => x.graphic_directors_id,
                        principalTable: "graphic_directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_graphic_director_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image_magazine",
                columns: table => new
                {
                    cover_images_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_image_magazine", x => new { x.cover_images_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_image_magazine_images_cover_images_id",
                        column: x => x.cover_images_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_image_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interpreters_magazine",
                columns: table => new
                {
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interpreters_magazine", x => new { x.interpreters_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_interpreters_magazine_interpreters_interpreters_id",
                        column: x => x.interpreters_id,
                        principalTable: "interpreters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_interpreters_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_magazine",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_magazine", x => new { x.kits_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_kit_magazine_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_microform",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    microforms_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_microform", x => new { x.categories_id, x.microforms_id });
                    table.ForeignKey(
                        name: "fk_category_microform_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_microform_microforms_microforms_id",
                        column: x => x.microforms_id,
                        principalTable: "microforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_microform",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    microforms_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_microform", x => new { x.kits_id, x.microforms_id });
                    table.ForeignKey(
                        name: "fk_kit_microform_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_microform_microforms_microforms_id",
                        column: x => x.microforms_id,
                        principalTable: "microforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_musical_note",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_musical_note", x => new { x.categories_id, x.musical_notes_id });
                    table.ForeignKey(
                        name: "fk_category_musical_note_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_musical_note_musical_notes_musical_notes_id",
                        column: x => x.musical_notes_id,
                        principalTable: "musical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "composer_musical_note",
                columns: table => new
                {
                    composers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_composer_musical_note", x => new { x.composers_id, x.musical_notes_id });
                    table.ForeignKey(
                        name: "fk_composer_musical_note_composers_composers_id",
                        column: x => x.composers_id,
                        principalTable: "composers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_composer_musical_note_musical_notes_musical_notes_id",
                        column: x => x.musical_notes_id,
                        principalTable: "musical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_musical_note",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_musical_note", x => new { x.kits_id, x.musical_notes_id });
                    table.ForeignKey(
                        name: "fk_kit_musical_note_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_musical_note_musical_notes_musical_notes_id",
                        column: x => x.musical_notes_id,
                        principalTable: "musical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_news_paper",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_news_paper", x => new { x.categories_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_category_news_paper_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cover_cap_news_paper",
                columns: table => new
                {
                    cover_caps_id = table.Column<byte>(type: "smallint", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cover_cap_news_paper", x => new { x.cover_caps_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_cover_cap_news_paper_cover_caps_cover_caps_id",
                        column: x => x.cover_caps_id,
                        principalTable: "cover_caps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cover_cap_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "director_news_paper",
                columns: table => new
                {
                    directors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_director_news_paper", x => new { x.directors_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_director_news_paper_directors_directors_id",
                        column: x => x.directors_id,
                        principalTable: "directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_director_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "editor_news_paper",
                columns: table => new
                {
                    editors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_editor_news_paper", x => new { x.editors_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_editor_news_paper_editors_editors_id",
                        column: x => x.editors_id,
                        principalTable: "editors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_editor_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graphic_designer_news_paper",
                columns: table => new
                {
                    graphic_designs_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphic_designer_news_paper", x => new { x.graphic_designs_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_graphic_designer_news_paper_graphic_design_graphic_designs_",
                        column: x => x.graphic_designs_id,
                        principalTable: "graphic_design",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_graphic_designer_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graphic_director_news_paper",
                columns: table => new
                {
                    graphic_directors_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphic_director_news_paper", x => new { x.graphic_directors_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_graphic_director_news_paper_graphic_directors_graphic_direc",
                        column: x => x.graphic_directors_id,
                        principalTable: "graphic_directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_graphic_director_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image_news_paper",
                columns: table => new
                {
                    cover_images_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_image_news_paper", x => new { x.cover_images_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_image_news_paper_images_cover_images_id",
                        column: x => x.cover_images_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_image_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interpreters_news_paper",
                columns: table => new
                {
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interpreters_news_paper", x => new { x.interpreters_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_interpreters_news_paper_interpreters_interpreters_id",
                        column: x => x.interpreters_id,
                        principalTable: "interpreters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_interpreters_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_news_paper",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_news_paper", x => new { x.kits_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_kit_news_paper_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_object3d",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_object3d", x => new { x.categories_id, x.object3ds_id });
                    table.ForeignKey(
                        name: "fk_category_object3d_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_object3d_object3ds_object3ds_id",
                        column: x => x.object3ds_id,
                        principalTable: "object3ds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image_object3d",
                columns: table => new
                {
                    images_id = table.Column<Guid>(type: "uuid", nullable: false),
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_image_object3d", x => new { x.images_id, x.object3ds_id });
                    table.ForeignKey(
                        name: "fk_image_object3d_images_images_id",
                        column: x => x.images_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_image_object3d_object3ds_object3ds_id",
                        column: x => x.object3ds_id,
                        principalTable: "object3ds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_object3d",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_object3d", x => new { x.kits_id, x.object3ds_id });
                    table.ForeignKey(
                        name: "fk_kit_object3d_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_object3d_object3ds_object3ds_id",
                        column: x => x.object3ds_id,
                        principalTable: "object3ds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_other_people",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    other_peoples_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_other_people", x => new { x.books_id, x.other_peoples_id });
                    table.ForeignKey(
                        name: "fk_book_other_people_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_other_people_other_peoples_other_peoples_id",
                        column: x => x.other_peoples_id,
                        principalTable: "other_peoples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_other_people",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    other_peoples_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_other_people", x => new { x.encyclopedias_id, x.other_peoples_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_other_people_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_other_people_other_peoples_other_peoples_id",
                        column: x => x.other_peoples_id,
                        principalTable: "other_peoples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "magazine_other_people",
                columns: table => new
                {
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false),
                    other_peoples_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_magazine_other_people", x => new { x.magazines_id, x.other_peoples_id });
                    table.ForeignKey(
                        name: "fk_magazine_other_people_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_magazine_other_people_other_peoples_other_peoples_id",
                        column: x => x.other_peoples_id,
                        principalTable: "other_peoples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_paper_other_people",
                columns: table => new
                {
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    other_peoples_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_paper_other_people", x => new { x.news_papers_id, x.other_peoples_id });
                    table.ForeignKey(
                        name: "fk_news_paper_other_people_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_news_paper_other_people_other_peoples_other_peoples_id",
                        column: x => x.other_peoples_id,
                        principalTable: "other_peoples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_poster",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    posters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_poster", x => new { x.categories_id, x.posters_id });
                    table.ForeignKey(
                        name: "fk_category_poster_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_poster_posters_posters_id",
                        column: x => x.posters_id,
                        principalTable: "posters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image_poster",
                columns: table => new
                {
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    posters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_image_poster", x => new { x.image_id, x.posters_id });
                    table.ForeignKey(
                        name: "fk_image_poster_images_image_id",
                        column: x => x.image_id,
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_image_poster_posters_posters_id",
                        column: x => x.posters_id,
                        principalTable: "posters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_poster",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    posters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_poster", x => new { x.kits_id, x.posters_id });
                    table.ForeignKey(
                        name: "fk_kit_poster_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_poster_posters_posters_id",
                        column: x => x.posters_id,
                        principalTable: "posters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_redaction",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    redactions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_redaction", x => new { x.books_id, x.redactions_id });
                    table.ForeignKey(
                        name: "fk_book_redaction_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_redaction_redactions_redactions_id",
                        column: x => x.redactions_id,
                        principalTable: "redactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_redaction",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    redactions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_redaction", x => new { x.encyclopedias_id, x.redactions_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_redaction_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_redaction_redactions_redactions_id",
                        column: x => x.redactions_id,
                        principalTable: "redactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "magazine_redaction",
                columns: table => new
                {
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false),
                    redactions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_magazine_redaction", x => new { x.magazines_id, x.redactions_id });
                    table.ForeignKey(
                        name: "fk_magazine_redaction_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_magazine_redaction_redactions_redactions_id",
                        column: x => x.redactions_id,
                        principalTable: "redactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_paper_redaction",
                columns: table => new
                {
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    redactions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_paper_redaction", x => new { x.news_papers_id, x.redactions_id });
                    table.ForeignKey(
                        name: "fk_news_paper_redaction_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_news_paper_redaction_redactions_redactions_id",
                        column: x => x.redactions_id,
                        principalTable: "redactions",
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
                name: "encyclopedia_technical_number",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_numbers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_technical_number", x => new { x.encyclopedias_id, x.technical_numbers_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_technical_number_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_technical_number_technical_numbers_technical_n",
                        column: x => x.technical_numbers_id,
                        principalTable: "technical_numbers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "magazine_technical_number",
                columns: table => new
                {
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_numbers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_magazine_technical_number", x => new { x.magazines_id, x.technical_numbers_id });
                    table.ForeignKey(
                        name: "fk_magazine_technical_number_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_magazine_technical_number_technical_numbers_technical_numbe",
                        column: x => x.technical_numbers_id,
                        principalTable: "technical_numbers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_paper_technical_number",
                columns: table => new
                {
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_numbers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_paper_technical_number", x => new { x.news_papers_id, x.technical_numbers_id });
                    table.ForeignKey(
                        name: "fk_news_paper_technical_number_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_news_paper_technical_number_technical_numbers_technical_num",
                        column: x => x.technical_numbers_id,
                        principalTable: "technical_numbers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "references",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sub_text = table.Column<string>(type: "text", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    start_page_number = table.Column<int>(type: "integer", nullable: false),
                    end_page_number = table.Column<int>(type: "integer", nullable: false),
                    technical_number_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference_date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_references", x => x.id);
                    table.ForeignKey(
                        name: "fk_references_technical_numbers_technical_number_id",
                        column: x => x.technical_number_id,
                        principalTable: "technical_numbers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_writer",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_writer", x => new { x.books_id, x.writers_id });
                    table.ForeignKey(
                        name: "fk_book_writer_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_writer_writers_writers_id",
                        column: x => x.writers_id,
                        principalTable: "writers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_writer",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_writer", x => new { x.encyclopedias_id, x.writers_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_writer_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_writer_writers_writers_id",
                        column: x => x.writers_id,
                        principalTable: "writers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "magazine_writer",
                columns: table => new
                {
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_magazine_writer", x => new { x.magazines_id, x.writers_id });
                    table.ForeignKey(
                        name: "fk_magazine_writer_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_magazine_writer_writers_writers_id",
                        column: x => x.writers_id,
                        principalTable: "writers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_paper_writer",
                columns: table => new
                {
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_paper_writer", x => new { x.news_papers_id, x.writers_id });
                    table.ForeignKey(
                        name: "fk_news_paper_writer_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_news_paper_writer_writers_writers_id",
                        column: x => x.writers_id,
                        principalTable: "writers",
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
                name: "book_series_director",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    directors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_director", x => new { x.book_series_id, x.directors_id });
                    table.ForeignKey(
                        name: "fk_book_series_director_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_director_directors_directors_id",
                        column: x => x.directors_id,
                        principalTable: "directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_editor",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    editors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_editor", x => new { x.book_series_id, x.editors_id });
                    table.ForeignKey(
                        name: "fk_book_series_editor_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_editor_editors_editors_id",
                        column: x => x.editors_id,
                        principalTable: "editors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_graphic_designer",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphic_designs_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_graphic_designer", x => new { x.book_series_id, x.graphic_designs_id });
                    table.ForeignKey(
                        name: "fk_book_series_graphic_designer_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_graphic_designer_graphic_design_graphic_designs",
                        column: x => x.graphic_designs_id,
                        principalTable: "graphic_design",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_graphic_director",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphic_directors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_graphic_director", x => new { x.book_series_id, x.graphic_directors_id });
                    table.ForeignKey(
                        name: "fk_book_series_graphic_director_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_graphic_director_graphic_directors_graphic_dire",
                        column: x => x.graphic_directors_id,
                        principalTable: "graphic_directors",
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
                name: "book_series_interpreters",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    interpreters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_interpreters", x => new { x.book_series_id, x.interpreters_id });
                    table.ForeignKey(
                        name: "fk_book_series_interpreters_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_interpreters_interpreters_interpreters_id",
                        column: x => x.interpreters_id,
                        principalTable: "interpreters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_kit",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_kit", x => new { x.book_series_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_book_series_kit_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_other_people",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    other_peoples_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_other_people", x => new { x.book_series_id, x.other_peoples_id });
                    table.ForeignKey(
                        name: "fk_book_series_other_people_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_other_people_other_peoples_other_peoples_id",
                        column: x => x.other_peoples_id,
                        principalTable: "other_peoples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_series_redaction",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    redactions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_redaction", x => new { x.book_series_id, x.redactions_id });
                    table.ForeignKey(
                        name: "fk_book_series_redaction_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_redaction_redactions_redactions_id",
                        column: x => x.redactions_id,
                        principalTable: "redactions",
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
                name: "book_series_writer",
                columns: table => new
                {
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    writers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_series_writer", x => new { x.book_series_id, x.writers_id });
                    table.ForeignKey(
                        name: "fk_book_series_writer_book_series_book_series_id",
                        column: x => x.book_series_id,
                        principalTable: "book_series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_series_writer_writers_writers_id",
                        column: x => x.writers_id,
                        principalTable: "writers",
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
                name: "dissertations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: false),
                    researcher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    date_time_year = table.Column<int>(type: "integer", nullable: false),
                    dissertation_number = table.Column<int>(type: "integer", nullable: false),
                    permission_status = table.Column<bool>(type: "boolean", nullable: false),
                    approval_status = table.Column<bool>(type: "boolean", nullable: false),
                    is_secret = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dissertations", x => x.id);
                    table.ForeignKey(
                        name: "fk_dissertations_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dissertations_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_depiction",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    depictions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_depiction", x => new { x.categories_id, x.depictions_id });
                    table.ForeignKey(
                        name: "fk_category_depiction_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_depiction_depictions_depictions_id",
                        column: x => x.depictions_id,
                        principalTable: "depictions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "depiction_kit",
                columns: table => new
                {
                    depictions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_depiction_kit", x => new { x.depictions_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_depiction_kit_depictions_depictions_id",
                        column: x => x.depictions_id,
                        principalTable: "depictions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_depiction_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_painting",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    paintings_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_painting", x => new { x.categories_id, x.paintings_id });
                    table.ForeignKey(
                        name: "fk_category_painting_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_painting_paintings_paintings_id",
                        column: x => x.paintings_id,
                        principalTable: "paintings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_painting",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    paintings_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_painting", x => new { x.kits_id, x.paintings_id });
                    table.ForeignKey(
                        name: "fk_kit_painting_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_painting_paintings_paintings_id",
                        column: x => x.paintings_id,
                        principalTable: "paintings",
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
                name: "audio_record_dimension",
                columns: table => new
                {
                    audio_records_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audio_record_dimension", x => new { x.audio_records_id, x.dimensions_id });
                    table.ForeignKey(
                        name: "fk_audio_record_dimension_audio_records_audio_records_id",
                        column: x => x.audio_records_id,
                        principalTable: "audio_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_audio_record_dimension_dimensions_dimensions_id",
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
                name: "cartographic_material_dimension",
                columns: table => new
                {
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartographic_material_dimension", x => new { x.cartographic_materials_id, x.dimensions_id });
                    table.ForeignKey(
                        name: "fk_cartographic_material_dimension_cartographic_materials_cart",
                        column: x => x.cartographic_materials_id,
                        principalTable: "cartographic_materials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cartographic_material_dimension_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "depiction_dimension",
                columns: table => new
                {
                    depictions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_depiction_dimension", x => new { x.depictions_id, x.dimensions_id });
                    table.ForeignKey(
                        name: "fk_depiction_dimension_depictions_depictions_id",
                        column: x => x.depictions_id,
                        principalTable: "depictions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_depiction_dimension_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_electronics_resource",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    electronics_resources_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_electronics_resource", x => new { x.dimensions_id, x.electronics_resources_id });
                    table.ForeignKey(
                        name: "fk_dimension_electronics_resource_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_electronics_resource_electronics_resources_electr",
                        column: x => x.electronics_resources_id,
                        principalTable: "electronics_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_encyclopedia",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_encyclopedia", x => new { x.dimensions_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_dimension_encyclopedia_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_encyclopedia_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_graphical_image",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphical_images_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_graphical_image", x => new { x.dimensions_id, x.graphical_images_id });
                    table.ForeignKey(
                        name: "fk_dimension_graphical_image_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_graphical_image_graphical_images_graphical_images",
                        column: x => x.graphical_images_id,
                        principalTable: "graphical_images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_magazine",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_magazine", x => new { x.dimensions_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_dimension_magazine_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_microform",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    microforms_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_microform", x => new { x.dimensions_id, x.microforms_id });
                    table.ForeignKey(
                        name: "fk_dimension_microform_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_microform_microforms_microforms_id",
                        column: x => x.microforms_id,
                        principalTable: "microforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_musical_note",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_musical_note", x => new { x.dimensions_id, x.musical_notes_id });
                    table.ForeignKey(
                        name: "fk_dimension_musical_note_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_musical_note_musical_notes_musical_notes_id",
                        column: x => x.musical_notes_id,
                        principalTable: "musical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_news_paper",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_news_paper", x => new { x.dimensions_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_dimension_news_paper_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_object3d",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_object3d", x => new { x.dimensions_id, x.object3ds_id });
                    table.ForeignKey(
                        name: "fk_dimension_object3d_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_object3d_object3ds_object3ds_id",
                        column: x => x.object3ds_id,
                        principalTable: "object3ds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_painting",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    paintings_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_painting", x => new { x.dimensions_id, x.paintings_id });
                    table.ForeignKey(
                        name: "fk_dimension_painting_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_painting_paintings_paintings_id",
                        column: x => x.paintings_id,
                        principalTable: "paintings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_poster",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    posters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_poster", x => new { x.dimensions_id, x.posters_id });
                    table.ForeignKey(
                        name: "fk_dimension_poster_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_poster_posters_posters_id",
                        column: x => x.posters_id,
                        principalTable: "posters",
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
                name: "cartographic_material_e_material_file",
                columns: table => new
                {
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartographic_material_e_material_file", x => new { x.cartographic_materials_id, x.e_material_files_id });
                    table.ForeignKey(
                        name: "fk_cartographic_material_e_material_file_cartographic_material",
                        column: x => x.cartographic_materials_id,
                        principalTable: "cartographic_materials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cartographic_material_e_material_file_e_material_files_e_ma",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "depiction_e_material_file",
                columns: table => new
                {
                    depictions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_depiction_e_material_file", x => new { x.depictions_id, x.e_material_files_id });
                    table.ForeignKey(
                        name: "fk_depiction_e_material_file_depictions_depictions_id",
                        column: x => x.depictions_id,
                        principalTable: "depictions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_depiction_e_material_file_e_material_files_e_material_files",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_electronics_resource",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    electronics_resources_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_electronics_resource", x => new { x.e_material_files_id, x.electronics_resources_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_electronics_resource_e_material_files_e_mat",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_electronics_resource_electronics_resources_",
                        column: x => x.electronics_resources_id,
                        principalTable: "electronics_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_encyclopedia",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_encyclopedia", x => new { x.e_material_files_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_encyclopedia_e_material_files_e_material_fi",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_encyclopedia_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_graphical_image",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphical_images_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_graphical_image", x => new { x.e_material_files_id, x.graphical_images_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_graphical_image_e_material_files_e_material",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_graphical_image_graphical_images_graphical_",
                        column: x => x.graphical_images_id,
                        principalTable: "graphical_images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_magazine",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_magazine", x => new { x.e_material_files_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_magazine_e_material_files_e_material_files_",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_microform",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    microforms_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_microform", x => new { x.e_material_files_id, x.microforms_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_microform_e_material_files_e_material_files",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_microform_microforms_microforms_id",
                        column: x => x.microforms_id,
                        principalTable: "microforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_musical_note",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_musical_note", x => new { x.e_material_files_id, x.musical_notes_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_musical_note_e_material_files_e_material_fi",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_musical_note_musical_notes_musical_notes_id",
                        column: x => x.musical_notes_id,
                        principalTable: "musical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_news_paper",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_news_paper", x => new { x.e_material_files_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_news_paper_e_material_files_e_material_file",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_object3d",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_object3d", x => new { x.e_material_files_id, x.object3ds_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_object3d_e_material_files_e_material_files_",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_object3d_object3ds_object3ds_id",
                        column: x => x.object3ds_id,
                        principalTable: "object3ds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_painting",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    paintings_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_painting", x => new { x.e_material_files_id, x.paintings_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_painting_e_material_files_e_material_files_",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_painting_paintings_paintings_id",
                        column: x => x.paintings_id,
                        principalTable: "paintings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_poster",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    posters_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_poster", x => new { x.e_material_files_id, x.posters_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_poster_e_material_files_e_material_files_id",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_poster_posters_posters_id",
                        column: x => x.posters_id,
                        principalTable: "posters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academic_journal_reference",
                columns: table => new
                {
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    references_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_journal_reference", x => new { x.academic_journals_id, x.references_id });
                    table.ForeignKey(
                        name: "fk_academic_journal_reference_academic_journals_academic_journ",
                        column: x => x.academic_journals_id,
                        principalTable: "academic_journals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academic_journal_reference_references_references_id",
                        column: x => x.references_id,
                        principalTable: "references",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_reference",
                columns: table => new
                {
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    references_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_book_reference", x => new { x.books_id, x.references_id });
                    table.ForeignKey(
                        name: "fk_book_reference_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_book_reference_references_references_id",
                        column: x => x.references_id,
                        principalTable: "references",
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
                name: "category_dissertation",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_dissertation", x => new { x.categories_id, x.dissertations_id });
                    table.ForeignKey(
                        name: "fk_category_dissertation_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_dissertation_dissertations_dissertations_id",
                        column: x => x.dissertations_id,
                        principalTable: "dissertations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_dissertation",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_dissertation", x => new { x.dimensions_id, x.dissertations_id });
                    table.ForeignKey(
                        name: "fk_dimension_dissertation_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_dissertation_dissertations_dissertations_id",
                        column: x => x.dissertations_id,
                        principalTable: "dissertations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dissertation_e_material_file",
                columns: table => new
                {
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dissertation_e_material_file", x => new { x.dissertations_id, x.e_material_files_id });
                    table.ForeignKey(
                        name: "fk_dissertation_e_material_file_dissertations_dissertations_id",
                        column: x => x.dissertations_id,
                        principalTable: "dissertations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dissertation_e_material_file_e_material_files_e_material_fi",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dissertation_kit",
                columns: table => new
                {
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false),
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dissertation_kit", x => new { x.dissertations_id, x.kits_id });
                    table.ForeignKey(
                        name: "fk_dissertation_kit_dissertations_dissertations_id",
                        column: x => x.dissertations_id,
                        principalTable: "dissertations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dissertation_kit_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
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
                    kit_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technical_placeholders", x => x.id);
                    table.ForeignKey(
                        name: "fk_technical_placeholders_kits_kit_id",
                        column: x => x.kit_id,
                        principalTable: "kits",
                        principalColumn: "id");
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
                name: "dissertation_university",
                columns: table => new
                {
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dissertation_university", x => new { x.dissertations_id, x.university_id });
                    table.ForeignKey(
                        name: "fk_dissertation_university_dissertations_dissertations_id",
                        column: x => x.dissertations_id,
                        principalTable: "dissertations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dissertation_university_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
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
                name: "theses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    university_id = table.Column<Guid>(type: "uuid", nullable: false),
                    thesis_degree = table.Column<byte>(type: "smallint", nullable: false),
                    researcher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    consultant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    date_time_year = table.Column<int>(type: "integer", nullable: false),
                    language_id = table.Column<int>(type: "integer", nullable: false),
                    thesis_number = table.Column<int>(type: "integer", nullable: false),
                    permission_status = table.Column<bool>(type: "boolean", nullable: false),
                    approval_status = table.Column<bool>(type: "boolean", nullable: false),
                    is_secret = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    state = table.Column<byte>(type: "smallint", nullable: false),
                    secret_level = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_theses", x => x.id);
                    table.ForeignKey(
                        name: "fk_theses_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_theses_consultants_consultant_id",
                        column: x => x.consultant_id,
                        principalTable: "consultants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_theses_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_theses_universities_university_id",
                        column: x => x.university_id,
                        principalTable: "universities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "cartographic_material_technical_placeholder",
                columns: table => new
                {
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartographic_material_technical_placeholder", x => new { x.cartographic_materials_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_cartographic_material_technical_placeholder_cartographic_ma",
                        column: x => x.cartographic_materials_id,
                        principalTable: "cartographic_materials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cartographic_material_technical_placeholder_technical_place",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "depiction_technical_placeholder",
                columns: table => new
                {
                    depictions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_depiction_technical_placeholder", x => new { x.depictions_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_depiction_technical_placeholder_depictions_depictions_id",
                        column: x => x.depictions_id,
                        principalTable: "depictions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_depiction_technical_placeholder_technical_placeholders_tech",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dissertation_technical_placeholder",
                columns: table => new
                {
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dissertation_technical_placeholder", x => new { x.dissertations_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_dissertation_technical_placeholder_dissertations_dissertati",
                        column: x => x.dissertations_id,
                        principalTable: "dissertations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dissertation_technical_placeholder_technical_placeholders_t",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "electronics_resource_technical_placeholder",
                columns: table => new
                {
                    electronics_resources_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_electronics_resource_technical_placeholder", x => new { x.electronics_resources_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_electronics_resource_technical_placeholder_electronics_reso",
                        column: x => x.electronics_resources_id,
                        principalTable: "electronics_resources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_electronics_resource_technical_placeholder_technical_placeh",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encyclopedia_technical_placeholder",
                columns: table => new
                {
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encyclopedia_technical_placeholder", x => new { x.encyclopedias_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_encyclopedia_technical_placeholder_encyclopedias_encycloped",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encyclopedia_technical_placeholder_technical_placeholders_t",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graphical_image_technical_placeholder",
                columns: table => new
                {
                    graphical_images_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_graphical_image_technical_placeholder", x => new { x.graphical_images_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_graphical_image_technical_placeholder_graphical_images_grap",
                        column: x => x.graphical_images_id,
                        principalTable: "graphical_images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_graphical_image_technical_placeholder_technical_placeholder",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "magazine_technical_placeholder",
                columns: table => new
                {
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_magazine_technical_placeholder", x => new { x.magazines_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_magazine_technical_placeholder_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_magazine_technical_placeholder_technical_placeholders_techn",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "microform_technical_placeholder",
                columns: table => new
                {
                    microforms_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_microform_technical_placeholder", x => new { x.microforms_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_microform_technical_placeholder_microforms_microforms_id",
                        column: x => x.microforms_id,
                        principalTable: "microforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_microform_technical_placeholder_technical_placeholders_tech",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "musical_note_technical_placeholder",
                columns: table => new
                {
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_musical_note_technical_placeholder", x => new { x.musical_notes_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_musical_note_technical_placeholder_musical_notes_musical_no",
                        column: x => x.musical_notes_id,
                        principalTable: "musical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_musical_note_technical_placeholder_technical_placeholders_t",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "news_paper_technical_placeholder",
                columns: table => new
                {
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_paper_technical_placeholder", x => new { x.news_papers_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_news_paper_technical_placeholder_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_news_paper_technical_placeholder_technical_placeholders_tec",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "object3d_technical_placeholder",
                columns: table => new
                {
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_object3d_technical_placeholder", x => new { x.object3ds_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_object3d_technical_placeholder_object3ds_object3ds_id",
                        column: x => x.object3ds_id,
                        principalTable: "object3ds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_object3d_technical_placeholder_technical_placeholders_techn",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "painting_technical_placeholder",
                columns: table => new
                {
                    paintings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_painting_technical_placeholder", x => new { x.paintings_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_painting_technical_placeholder_paintings_paintings_id",
                        column: x => x.paintings_id,
                        principalTable: "paintings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_painting_technical_placeholder_technical_placeholders_techn",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "poster_technical_placeholder",
                columns: table => new
                {
                    posters_id = table.Column<Guid>(type: "uuid", nullable: false),
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_poster_technical_placeholder", x => new { x.posters_id, x.technical_placeholders_id });
                    table.ForeignKey(
                        name: "fk_poster_technical_placeholder_posters_posters_id",
                        column: x => x.posters_id,
                        principalTable: "posters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_poster_technical_placeholder_technical_placeholders_technic",
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
                name: "edition_encyclopedia",
                columns: table => new
                {
                    editions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_edition_encyclopedia", x => new { x.editions_id, x.encyclopedias_id });
                    table.ForeignKey(
                        name: "fk_edition_encyclopedia_editions_editions_id",
                        column: x => x.editions_id,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_edition_encyclopedia_encyclopedias_encyclopedias_id",
                        column: x => x.encyclopedias_id,
                        principalTable: "encyclopedias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "edition_magazine",
                columns: table => new
                {
                    editions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_edition_magazine", x => new { x.editions_id, x.magazines_id });
                    table.ForeignKey(
                        name: "fk_edition_magazine_editions_editions_id",
                        column: x => x.editions_id,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_edition_magazine_magazines_magazines_id",
                        column: x => x.magazines_id,
                        principalTable: "magazines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "edition_news_paper",
                columns: table => new
                {
                    editions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_edition_news_paper", x => new { x.editions_id, x.news_papers_id });
                    table.ForeignKey(
                        name: "fk_edition_news_paper_editions_editions_id",
                        column: x => x.editions_id,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_edition_news_paper_news_papers_news_papers_id",
                        column: x => x.news_papers_id,
                        principalTable: "news_papers",
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
                        name: "fk_academic_journal_researcher_researchers_researchers_id",
                        column: x => x.researchers_id,
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dissertation_researcher",
                columns: table => new
                {
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false),
                    researcher_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dissertation_researcher", x => new { x.dissertations_id, x.researcher_id });
                    table.ForeignKey(
                        name: "fk_dissertation_researcher_dissertations_dissertations_id",
                        column: x => x.dissertations_id,
                        principalTable: "dissertations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dissertation_researcher_researchers_researcher_id",
                        column: x => x.researcher_id,
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_thesis",
                columns: table => new
                {
                    categories_id = table.Column<int>(type: "integer", nullable: false),
                    theses_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_thesis", x => new { x.categories_id, x.theses_id });
                    table.ForeignKey(
                        name: "fk_category_thesis_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_thesis_theses_theses_id",
                        column: x => x.theses_id,
                        principalTable: "theses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dimension_thesis",
                columns: table => new
                {
                    dimensions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    theses_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dimension_thesis", x => new { x.dimensions_id, x.theses_id });
                    table.ForeignKey(
                        name: "fk_dimension_thesis_dimensions_dimensions_id",
                        column: x => x.dimensions_id,
                        principalTable: "dimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dimension_thesis_theses_theses_id",
                        column: x => x.theses_id,
                        principalTable: "theses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "e_material_file_thesis",
                columns: table => new
                {
                    e_material_files_id = table.Column<Guid>(type: "uuid", nullable: false),
                    theses_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_e_material_file_thesis", x => new { x.e_material_files_id, x.theses_id });
                    table.ForeignKey(
                        name: "fk_e_material_file_thesis_e_material_files_e_material_files_id",
                        column: x => x.e_material_files_id,
                        principalTable: "e_material_files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_e_material_file_thesis_theses_theses_id",
                        column: x => x.theses_id,
                        principalTable: "theses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kit_thesis",
                columns: table => new
                {
                    kits_id = table.Column<Guid>(type: "uuid", nullable: false),
                    theses_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_kit_thesis", x => new { x.kits_id, x.theses_id });
                    table.ForeignKey(
                        name: "fk_kit_thesis_kits_kits_id",
                        column: x => x.kits_id,
                        principalTable: "kits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_kit_thesis_theses_theses_id",
                        column: x => x.theses_id,
                        principalTable: "theses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "technical_placeholder_thesis",
                columns: table => new
                {
                    technical_placeholders_id = table.Column<Guid>(type: "uuid", nullable: false),
                    theses_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_technical_placeholder_thesis", x => new { x.technical_placeholders_id, x.theses_id });
                    table.ForeignKey(
                        name: "fk_technical_placeholder_thesis_technical_placeholders_technic",
                        column: x => x.technical_placeholders_id,
                        principalTable: "technical_placeholders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_technical_placeholder_thesis_theses_theses_id",
                        column: x => x.theses_id,
                        principalTable: "theses",
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
                name: "ix_academic_journal_kit_kits_id",
                table: "academic_journal_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_publisher_publishers_id",
                table: "academic_journal_publisher",
                column: "publishers_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_reference_references_id",
                table: "academic_journal_reference",
                column: "references_id");

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
                name: "ix_audio_record_dimension_dimensions_id",
                table: "audio_record_dimension",
                column: "dimensions_id");

            migrationBuilder.CreateIndex(
                name: "ix_audio_record_e_material_file_e_material_files_id",
                table: "audio_record_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_audio_record_kit_kits_id",
                table: "audio_record_kit",
                column: "kits_id");

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
                name: "ix_book_director_directors_id",
                table: "book_director",
                column: "directors_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_e_material_file_e_material_files_id",
                table: "book_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_edition_editions_id",
                table: "book_edition",
                column: "editions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_editor_editors_id",
                table: "book_editor",
                column: "editors_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_graphic_designer_graphic_designs_id",
                table: "book_graphic_designer",
                column: "graphic_designs_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_graphic_director_graphic_directors_id",
                table: "book_graphic_director",
                column: "graphic_directors_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_image_cover_images_id",
                table: "book_image",
                column: "cover_images_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_interpreters_interpreters_id",
                table: "book_interpreters",
                column: "interpreters_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_kit_kits_id",
                table: "book_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_other_people_other_peoples_id",
                table: "book_other_people",
                column: "other_peoples_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_redaction_redactions_id",
                table: "book_redaction",
                column: "redactions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_reference_references_id",
                table: "book_reference",
                column: "references_id");

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
                name: "ix_book_series_director_directors_id",
                table: "book_series_director",
                column: "directors_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_e_material_file_e_material_files_id",
                table: "book_series_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_edition_editions_id",
                table: "book_series_edition",
                column: "editions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_editor_editors_id",
                table: "book_series_editor",
                column: "editors_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_graphic_designer_graphic_designs_id",
                table: "book_series_graphic_designer",
                column: "graphic_designs_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_graphic_director_graphic_directors_id",
                table: "book_series_graphic_director",
                column: "graphic_directors_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_image_cover_images_id",
                table: "book_series_image",
                column: "cover_images_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_interpreters_interpreters_id",
                table: "book_series_interpreters",
                column: "interpreters_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_kit_kits_id",
                table: "book_series_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_other_people_other_peoples_id",
                table: "book_series_other_people",
                column: "other_peoples_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_redaction_redactions_id",
                table: "book_series_redaction",
                column: "redactions_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_technical_number_technical_numbers_id",
                table: "book_series_technical_number",
                column: "technical_numbers_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_technical_placeholder_technical_placeholders_id",
                table: "book_series_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_writer_writers_id",
                table: "book_series_writer",
                column: "writers_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_technical_number_technical_numbers_id",
                table: "book_technical_number",
                column: "technical_numbers_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_technical_placeholder_technical_placeholders_id",
                table: "book_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_writer_writers_id",
                table: "book_writer",
                column: "writers_id");

            migrationBuilder.CreateIndex(
                name: "ix_cartographic_material_category_categories_id",
                table: "cartographic_material_category",
                column: "categories_id");

            migrationBuilder.CreateIndex(
                name: "ix_cartographic_material_dimension_dimensions_id",
                table: "cartographic_material_dimension",
                column: "dimensions_id");

            migrationBuilder.CreateIndex(
                name: "ix_cartographic_material_e_material_file_e_material_files_id",
                table: "cartographic_material_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_cartographic_material_image_images_id",
                table: "cartographic_material_image",
                column: "images_id");

            migrationBuilder.CreateIndex(
                name: "ix_cartographic_material_kit_kits_id",
                table: "cartographic_material_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_cartographic_material_technical_placeholder_technical_place",
                table: "cartographic_material_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_depiction_depictions_id",
                table: "category_depiction",
                column: "depictions_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_dissertation_dissertations_id",
                table: "category_dissertation",
                column: "dissertations_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_electronics_resource_electronics_resources_id",
                table: "category_electronics_resource",
                column: "electronics_resources_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_encyclopedia_encyclopedias_id",
                table: "category_encyclopedia",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_graphical_image_graphical_images_id",
                table: "category_graphical_image",
                column: "graphical_images_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_kit_kits_id",
                table: "category_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_magazine_magazines_id",
                table: "category_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_microform_microforms_id",
                table: "category_microform",
                column: "microforms_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_musical_note_musical_notes_id",
                table: "category_musical_note",
                column: "musical_notes_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_news_paper_news_papers_id",
                table: "category_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_object3d_object3ds_id",
                table: "category_object3d",
                column: "object3ds_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_painting_paintings_id",
                table: "category_painting",
                column: "paintings_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_poster_posters_id",
                table: "category_poster",
                column: "posters_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_thesis_theses_id",
                table: "category_thesis",
                column: "theses_id");

            migrationBuilder.CreateIndex(
                name: "ix_cities_country_id",
                table: "cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_composer_musical_note_musical_notes_id",
                table: "composer_musical_note",
                column: "musical_notes_id");

            migrationBuilder.CreateIndex(
                name: "ix_cover_cap_encyclopedia_encyclopedias_id",
                table: "cover_cap_encyclopedia",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_cover_cap_magazine_magazines_id",
                table: "cover_cap_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_cover_cap_news_paper_news_papers_id",
                table: "cover_cap_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_depiction_dimension_dimensions_id",
                table: "depiction_dimension",
                column: "dimensions_id");

            migrationBuilder.CreateIndex(
                name: "ix_depiction_e_material_file_e_material_files_id",
                table: "depiction_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_depiction_kit_kits_id",
                table: "depiction_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_depiction_technical_placeholder_technical_placeholders_id",
                table: "depiction_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_depictions_image_id",
                table: "depictions",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_dissertation_dissertations_id",
                table: "dimension_dissertation",
                column: "dissertations_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_electronics_resource_electronics_resources_id",
                table: "dimension_electronics_resource",
                column: "electronics_resources_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_encyclopedia_encyclopedias_id",
                table: "dimension_encyclopedia",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_graphical_image_graphical_images_id",
                table: "dimension_graphical_image",
                column: "graphical_images_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_magazine_magazines_id",
                table: "dimension_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_microform_microforms_id",
                table: "dimension_microform",
                column: "microforms_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_musical_note_musical_notes_id",
                table: "dimension_musical_note",
                column: "musical_notes_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_news_paper_news_papers_id",
                table: "dimension_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_object3d_object3ds_id",
                table: "dimension_object3d",
                column: "object3ds_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_painting_paintings_id",
                table: "dimension_painting",
                column: "paintings_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_poster_posters_id",
                table: "dimension_poster",
                column: "posters_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimension_thesis_theses_id",
                table: "dimension_thesis",
                column: "theses_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimensions_kit_id",
                table: "dimensions",
                column: "kit_id");

            migrationBuilder.CreateIndex(
                name: "ix_director_encyclopedia_encyclopedias_id",
                table: "director_encyclopedia",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_director_magazine_magazines_id",
                table: "director_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_director_news_paper_news_papers_id",
                table: "director_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertation_e_material_file_e_material_files_id",
                table: "dissertation_e_material_file",
                column: "e_material_files_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertation_kit_kits_id",
                table: "dissertation_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertation_researcher_researcher_id",
                table: "dissertation_researcher",
                column: "researcher_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertation_technical_placeholder_technical_placeholders_id",
                table: "dissertation_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertation_university_university_id",
                table: "dissertation_university",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertations_city_id",
                table: "dissertations",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertations_language_id",
                table: "dissertations",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_electronics_resource_electronics_resources_",
                table: "e_material_file_electronics_resource",
                column: "electronics_resources_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_encyclopedia_encyclopedias_id",
                table: "e_material_file_encyclopedia",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_graphical_image_graphical_images_id",
                table: "e_material_file_graphical_image",
                column: "graphical_images_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_magazine_magazines_id",
                table: "e_material_file_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_microform_microforms_id",
                table: "e_material_file_microform",
                column: "microforms_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_musical_note_musical_notes_id",
                table: "e_material_file_musical_note",
                column: "musical_notes_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_news_paper_news_papers_id",
                table: "e_material_file_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_object3d_object3ds_id",
                table: "e_material_file_object3d",
                column: "object3ds_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_painting_paintings_id",
                table: "e_material_file_painting",
                column: "paintings_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_poster_posters_id",
                table: "e_material_file_poster",
                column: "posters_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_file_thesis_theses_id",
                table: "e_material_file_thesis",
                column: "theses_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_files_kit_id",
                table: "e_material_files",
                column: "kit_id");

            migrationBuilder.CreateIndex(
                name: "ix_edition_encyclopedia_encyclopedias_id",
                table: "edition_encyclopedia",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_edition_magazine_magazines_id",
                table: "edition_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_edition_news_paper_news_papers_id",
                table: "edition_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_editions_publisher_id",
                table: "editions",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "ix_editor_encyclopedia_encyclopedias_id",
                table: "editor_encyclopedia",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_editor_magazine_magazines_id",
                table: "editor_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_editor_news_paper_news_papers_id",
                table: "editor_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_electronics_resource_kit_kits_id",
                table: "electronics_resource_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_electronics_resource_technical_placeholder_technical_placeh",
                table: "electronics_resource_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_graphic_designer_graphic_designs_id",
                table: "encyclopedia_graphic_designer",
                column: "graphic_designs_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_graphic_director_graphic_directors_id",
                table: "encyclopedia_graphic_director",
                column: "graphic_directors_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_image_encyclopedias_id",
                table: "encyclopedia_image",
                column: "encyclopedias_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_interpreters_interpreters_id",
                table: "encyclopedia_interpreters",
                column: "interpreters_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_kit_kits_id",
                table: "encyclopedia_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_other_people_other_peoples_id",
                table: "encyclopedia_other_people",
                column: "other_peoples_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_redaction_redactions_id",
                table: "encyclopedia_redaction",
                column: "redactions_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_technical_number_technical_numbers_id",
                table: "encyclopedia_technical_number",
                column: "technical_numbers_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_technical_placeholder_technical_placeholders_id",
                table: "encyclopedia_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_writer_writers_id",
                table: "encyclopedia_writer",
                column: "writers_id");

            migrationBuilder.CreateIndex(
                name: "ix_graphic_designer_magazine_magazines_id",
                table: "graphic_designer_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_graphic_designer_news_paper_news_papers_id",
                table: "graphic_designer_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_graphic_director_magazine_magazines_id",
                table: "graphic_director_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_graphic_director_news_paper_news_papers_id",
                table: "graphic_director_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_graphical_image_kit_kits_id",
                table: "graphical_image_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_graphical_image_technical_placeholder_technical_placeholder",
                table: "graphical_image_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_image_magazine_magazines_id",
                table: "image_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_image_news_paper_news_papers_id",
                table: "image_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_image_object3d_object3ds_id",
                table: "image_object3d",
                column: "object3ds_id");

            migrationBuilder.CreateIndex(
                name: "ix_image_poster_posters_id",
                table: "image_poster",
                column: "posters_id");

            migrationBuilder.CreateIndex(
                name: "ix_interpreters_magazine_magazines_id",
                table: "interpreters_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_interpreters_news_paper_news_papers_id",
                table: "interpreters_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_magazine_magazines_id",
                table: "kit_magazine",
                column: "magazines_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_microform_microforms_id",
                table: "kit_microform",
                column: "microforms_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_musical_note_musical_notes_id",
                table: "kit_musical_note",
                column: "musical_notes_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_news_paper_news_papers_id",
                table: "kit_news_paper",
                column: "news_papers_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_object3d_object3ds_id",
                table: "kit_object3d",
                column: "object3ds_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_painting_paintings_id",
                table: "kit_painting",
                column: "paintings_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_poster_posters_id",
                table: "kit_poster",
                column: "posters_id");

            migrationBuilder.CreateIndex(
                name: "ix_kit_thesis_theses_id",
                table: "kit_thesis",
                column: "theses_id");

            migrationBuilder.CreateIndex(
                name: "ix_libraries_address_id",
                table: "libraries",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_libraries_communication_id",
                table: "libraries",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "ix_magazine_other_people_other_peoples_id",
                table: "magazine_other_people",
                column: "other_peoples_id");

            migrationBuilder.CreateIndex(
                name: "ix_magazine_redaction_redactions_id",
                table: "magazine_redaction",
                column: "redactions_id");

            migrationBuilder.CreateIndex(
                name: "ix_magazine_technical_number_technical_numbers_id",
                table: "magazine_technical_number",
                column: "technical_numbers_id");

            migrationBuilder.CreateIndex(
                name: "ix_magazine_technical_placeholder_technical_placeholders_id",
                table: "magazine_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_magazine_writer_writers_id",
                table: "magazine_writer",
                column: "writers_id");

            migrationBuilder.CreateIndex(
                name: "ix_microform_technical_placeholder_technical_placeholders_id",
                table: "microform_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_musical_note_technical_placeholder_technical_placeholders_id",
                table: "musical_note_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_paper_other_people_other_peoples_id",
                table: "news_paper_other_people",
                column: "other_peoples_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_paper_redaction_redactions_id",
                table: "news_paper_redaction",
                column: "redactions_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_paper_technical_number_technical_numbers_id",
                table: "news_paper_technical_number",
                column: "technical_numbers_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_paper_technical_placeholder_technical_placeholders_id",
                table: "news_paper_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_news_paper_writer_writers_id",
                table: "news_paper_writer",
                column: "writers_id");

            migrationBuilder.CreateIndex(
                name: "ix_object3d_technical_placeholder_technical_placeholders_id",
                table: "object3d_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_painting_technical_placeholder_technical_placeholders_id",
                table: "painting_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_paintings_image_id",
                table: "paintings",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "ix_poster_technical_placeholder_technical_placeholders_id",
                table: "poster_technical_placeholder",
                column: "technical_placeholders_id");

            migrationBuilder.CreateIndex(
                name: "ix_publishers_address_id",
                table: "publishers",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_publishers_communication_id",
                table: "publishers",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "ix_references_technical_number_id",
                table: "references",
                column: "technical_number_id");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_university_id",
                table: "researchers",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_technical_placeholder_thesis_theses_id",
                table: "technical_placeholder_thesis",
                column: "theses_id");

            migrationBuilder.CreateIndex(
                name: "ix_technical_placeholders_kit_id",
                table: "technical_placeholders",
                column: "kit_id");

            migrationBuilder.CreateIndex(
                name: "ix_technical_placeholders_library_id",
                table: "technical_placeholders",
                column: "library_id");

            migrationBuilder.CreateIndex(
                name: "ix_theses_city_id",
                table: "theses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_theses_consultant_id",
                table: "theses",
                column: "consultant_id");

            migrationBuilder.CreateIndex(
                name: "ix_theses_language_id",
                table: "theses",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_theses_university_id",
                table: "theses",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "ix_universities_address_id",
                table: "universities",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_universities_branch_id",
                table: "universities",
                column: "branch_id");
        }

        /// <inheritdoc />
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
                name: "academic_journal_kit");

            migrationBuilder.DropTable(
                name: "academic_journal_publisher");

            migrationBuilder.DropTable(
                name: "academic_journal_reference");

            migrationBuilder.DropTable(
                name: "academic_journal_researcher");

            migrationBuilder.DropTable(
                name: "academic_journal_technical_placeholder");

            migrationBuilder.DropTable(
                name: "audio_record_category");

            migrationBuilder.DropTable(
                name: "audio_record_dimension");

            migrationBuilder.DropTable(
                name: "audio_record_e_material_file");

            migrationBuilder.DropTable(
                name: "audio_record_kit");

            migrationBuilder.DropTable(
                name: "audio_record_technical_placeholder");

            migrationBuilder.DropTable(
                name: "book_category");

            migrationBuilder.DropTable(
                name: "book_cover_cap");

            migrationBuilder.DropTable(
                name: "book_dimension");

            migrationBuilder.DropTable(
                name: "book_director");

            migrationBuilder.DropTable(
                name: "book_e_material_file");

            migrationBuilder.DropTable(
                name: "book_edition");

            migrationBuilder.DropTable(
                name: "book_editor");

            migrationBuilder.DropTable(
                name: "book_graphic_designer");

            migrationBuilder.DropTable(
                name: "book_graphic_director");

            migrationBuilder.DropTable(
                name: "book_image");

            migrationBuilder.DropTable(
                name: "book_interpreters");

            migrationBuilder.DropTable(
                name: "book_kit");

            migrationBuilder.DropTable(
                name: "book_other_people");

            migrationBuilder.DropTable(
                name: "book_redaction");

            migrationBuilder.DropTable(
                name: "book_reference");

            migrationBuilder.DropTable(
                name: "book_series_category");

            migrationBuilder.DropTable(
                name: "book_series_cover_cap");

            migrationBuilder.DropTable(
                name: "book_series_dimension");

            migrationBuilder.DropTable(
                name: "book_series_director");

            migrationBuilder.DropTable(
                name: "book_series_e_material_file");

            migrationBuilder.DropTable(
                name: "book_series_edition");

            migrationBuilder.DropTable(
                name: "book_series_editor");

            migrationBuilder.DropTable(
                name: "book_series_graphic_designer");

            migrationBuilder.DropTable(
                name: "book_series_graphic_director");

            migrationBuilder.DropTable(
                name: "book_series_image");

            migrationBuilder.DropTable(
                name: "book_series_interpreters");

            migrationBuilder.DropTable(
                name: "book_series_kit");

            migrationBuilder.DropTable(
                name: "book_series_other_people");

            migrationBuilder.DropTable(
                name: "book_series_redaction");

            migrationBuilder.DropTable(
                name: "book_series_technical_number");

            migrationBuilder.DropTable(
                name: "book_series_technical_placeholder");

            migrationBuilder.DropTable(
                name: "book_series_writer");

            migrationBuilder.DropTable(
                name: "book_technical_number");

            migrationBuilder.DropTable(
                name: "book_technical_placeholder");

            migrationBuilder.DropTable(
                name: "book_writer");

            migrationBuilder.DropTable(
                name: "cartographic_material_category");

            migrationBuilder.DropTable(
                name: "cartographic_material_dimension");

            migrationBuilder.DropTable(
                name: "cartographic_material_e_material_file");

            migrationBuilder.DropTable(
                name: "cartographic_material_image");

            migrationBuilder.DropTable(
                name: "cartographic_material_kit");

            migrationBuilder.DropTable(
                name: "cartographic_material_technical_placeholder");

            migrationBuilder.DropTable(
                name: "category_depiction");

            migrationBuilder.DropTable(
                name: "category_dissertation");

            migrationBuilder.DropTable(
                name: "category_electronics_resource");

            migrationBuilder.DropTable(
                name: "category_encyclopedia");

            migrationBuilder.DropTable(
                name: "category_graphical_image");

            migrationBuilder.DropTable(
                name: "category_kit");

            migrationBuilder.DropTable(
                name: "category_magazine");

            migrationBuilder.DropTable(
                name: "category_microform");

            migrationBuilder.DropTable(
                name: "category_musical_note");

            migrationBuilder.DropTable(
                name: "category_news_paper");

            migrationBuilder.DropTable(
                name: "category_object3d");

            migrationBuilder.DropTable(
                name: "category_painting");

            migrationBuilder.DropTable(
                name: "category_poster");

            migrationBuilder.DropTable(
                name: "category_thesis");

            migrationBuilder.DropTable(
                name: "composer_musical_note");

            migrationBuilder.DropTable(
                name: "cover_cap_encyclopedia");

            migrationBuilder.DropTable(
                name: "cover_cap_magazine");

            migrationBuilder.DropTable(
                name: "cover_cap_news_paper");

            migrationBuilder.DropTable(
                name: "depiction_dimension");

            migrationBuilder.DropTable(
                name: "depiction_e_material_file");

            migrationBuilder.DropTable(
                name: "depiction_kit");

            migrationBuilder.DropTable(
                name: "depiction_technical_placeholder");

            migrationBuilder.DropTable(
                name: "dimension_dissertation");

            migrationBuilder.DropTable(
                name: "dimension_electronics_resource");

            migrationBuilder.DropTable(
                name: "dimension_encyclopedia");

            migrationBuilder.DropTable(
                name: "dimension_graphical_image");

            migrationBuilder.DropTable(
                name: "dimension_magazine");

            migrationBuilder.DropTable(
                name: "dimension_microform");

            migrationBuilder.DropTable(
                name: "dimension_musical_note");

            migrationBuilder.DropTable(
                name: "dimension_news_paper");

            migrationBuilder.DropTable(
                name: "dimension_object3d");

            migrationBuilder.DropTable(
                name: "dimension_painting");

            migrationBuilder.DropTable(
                name: "dimension_poster");

            migrationBuilder.DropTable(
                name: "dimension_thesis");

            migrationBuilder.DropTable(
                name: "director_encyclopedia");

            migrationBuilder.DropTable(
                name: "director_magazine");

            migrationBuilder.DropTable(
                name: "director_news_paper");

            migrationBuilder.DropTable(
                name: "dissertation_e_material_file");

            migrationBuilder.DropTable(
                name: "dissertation_kit");

            migrationBuilder.DropTable(
                name: "dissertation_researcher");

            migrationBuilder.DropTable(
                name: "dissertation_technical_placeholder");

            migrationBuilder.DropTable(
                name: "dissertation_university");

            migrationBuilder.DropTable(
                name: "e_material_file_electronics_resource");

            migrationBuilder.DropTable(
                name: "e_material_file_encyclopedia");

            migrationBuilder.DropTable(
                name: "e_material_file_graphical_image");

            migrationBuilder.DropTable(
                name: "e_material_file_magazine");

            migrationBuilder.DropTable(
                name: "e_material_file_microform");

            migrationBuilder.DropTable(
                name: "e_material_file_musical_note");

            migrationBuilder.DropTable(
                name: "e_material_file_news_paper");

            migrationBuilder.DropTable(
                name: "e_material_file_object3d");

            migrationBuilder.DropTable(
                name: "e_material_file_painting");

            migrationBuilder.DropTable(
                name: "e_material_file_poster");

            migrationBuilder.DropTable(
                name: "e_material_file_thesis");

            migrationBuilder.DropTable(
                name: "edition_encyclopedia");

            migrationBuilder.DropTable(
                name: "edition_magazine");

            migrationBuilder.DropTable(
                name: "edition_news_paper");

            migrationBuilder.DropTable(
                name: "editor_encyclopedia");

            migrationBuilder.DropTable(
                name: "editor_magazine");

            migrationBuilder.DropTable(
                name: "editor_news_paper");

            migrationBuilder.DropTable(
                name: "electronics_resource_kit");

            migrationBuilder.DropTable(
                name: "electronics_resource_technical_placeholder");

            migrationBuilder.DropTable(
                name: "encyclopedia_graphic_designer");

            migrationBuilder.DropTable(
                name: "encyclopedia_graphic_director");

            migrationBuilder.DropTable(
                name: "encyclopedia_image");

            migrationBuilder.DropTable(
                name: "encyclopedia_interpreters");

            migrationBuilder.DropTable(
                name: "encyclopedia_kit");

            migrationBuilder.DropTable(
                name: "encyclopedia_other_people");

            migrationBuilder.DropTable(
                name: "encyclopedia_redaction");

            migrationBuilder.DropTable(
                name: "encyclopedia_technical_number");

            migrationBuilder.DropTable(
                name: "encyclopedia_technical_placeholder");

            migrationBuilder.DropTable(
                name: "encyclopedia_writer");

            migrationBuilder.DropTable(
                name: "graphic_designer_magazine");

            migrationBuilder.DropTable(
                name: "graphic_designer_news_paper");

            migrationBuilder.DropTable(
                name: "graphic_director_magazine");

            migrationBuilder.DropTable(
                name: "graphic_director_news_paper");

            migrationBuilder.DropTable(
                name: "graphical_image_kit");

            migrationBuilder.DropTable(
                name: "graphical_image_technical_placeholder");

            migrationBuilder.DropTable(
                name: "image_magazine");

            migrationBuilder.DropTable(
                name: "image_news_paper");

            migrationBuilder.DropTable(
                name: "image_object3d");

            migrationBuilder.DropTable(
                name: "image_poster");

            migrationBuilder.DropTable(
                name: "interpreters_magazine");

            migrationBuilder.DropTable(
                name: "interpreters_news_paper");

            migrationBuilder.DropTable(
                name: "kit_magazine");

            migrationBuilder.DropTable(
                name: "kit_microform");

            migrationBuilder.DropTable(
                name: "kit_musical_note");

            migrationBuilder.DropTable(
                name: "kit_news_paper");

            migrationBuilder.DropTable(
                name: "kit_object3d");

            migrationBuilder.DropTable(
                name: "kit_painting");

            migrationBuilder.DropTable(
                name: "kit_poster");

            migrationBuilder.DropTable(
                name: "kit_thesis");

            migrationBuilder.DropTable(
                name: "magazine_other_people");

            migrationBuilder.DropTable(
                name: "magazine_redaction");

            migrationBuilder.DropTable(
                name: "magazine_technical_number");

            migrationBuilder.DropTable(
                name: "magazine_technical_placeholder");

            migrationBuilder.DropTable(
                name: "magazine_writer");

            migrationBuilder.DropTable(
                name: "microform_technical_placeholder");

            migrationBuilder.DropTable(
                name: "musical_note_technical_placeholder");

            migrationBuilder.DropTable(
                name: "news_paper_other_people");

            migrationBuilder.DropTable(
                name: "news_paper_redaction");

            migrationBuilder.DropTable(
                name: "news_paper_technical_number");

            migrationBuilder.DropTable(
                name: "news_paper_technical_placeholder");

            migrationBuilder.DropTable(
                name: "news_paper_writer");

            migrationBuilder.DropTable(
                name: "object3d_technical_placeholder");

            migrationBuilder.DropTable(
                name: "painting_technical_placeholder");

            migrationBuilder.DropTable(
                name: "poster_technical_placeholder");

            migrationBuilder.DropTable(
                name: "technical_placeholder_thesis");

            migrationBuilder.DropTable(
                name: "academic_journals");

            migrationBuilder.DropTable(
                name: "audio_records");

            migrationBuilder.DropTable(
                name: "references");

            migrationBuilder.DropTable(
                name: "book_series");

            migrationBuilder.DropTable(
                name: "cartographic_materials");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "composers");

            migrationBuilder.DropTable(
                name: "cover_caps");

            migrationBuilder.DropTable(
                name: "depictions");

            migrationBuilder.DropTable(
                name: "dimensions");

            migrationBuilder.DropTable(
                name: "directors");

            migrationBuilder.DropTable(
                name: "researchers");

            migrationBuilder.DropTable(
                name: "dissertations");

            migrationBuilder.DropTable(
                name: "e_material_files");

            migrationBuilder.DropTable(
                name: "editions");

            migrationBuilder.DropTable(
                name: "editors");

            migrationBuilder.DropTable(
                name: "electronics_resources");

            migrationBuilder.DropTable(
                name: "encyclopedias");

            migrationBuilder.DropTable(
                name: "graphic_design");

            migrationBuilder.DropTable(
                name: "graphic_directors");

            migrationBuilder.DropTable(
                name: "graphical_images");

            migrationBuilder.DropTable(
                name: "interpreters");

            migrationBuilder.DropTable(
                name: "magazines");

            migrationBuilder.DropTable(
                name: "microforms");

            migrationBuilder.DropTable(
                name: "musical_notes");

            migrationBuilder.DropTable(
                name: "other_peoples");

            migrationBuilder.DropTable(
                name: "redactions");

            migrationBuilder.DropTable(
                name: "news_papers");

            migrationBuilder.DropTable(
                name: "writers");

            migrationBuilder.DropTable(
                name: "object3ds");

            migrationBuilder.DropTable(
                name: "paintings");

            migrationBuilder.DropTable(
                name: "posters");

            migrationBuilder.DropTable(
                name: "technical_placeholders");

            migrationBuilder.DropTable(
                name: "theses");

            migrationBuilder.DropTable(
                name: "technical_numbers");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "kits");

            migrationBuilder.DropTable(
                name: "libraries");

            migrationBuilder.DropTable(
                name: "consultants");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "universities");

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
