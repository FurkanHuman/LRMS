using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigCreateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "kit_id",
                table: "technical_placeholders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "kit_id",
                table: "e_material_files",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "kit_id",
                table: "dimensions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "kit_id",
                table: "categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "kits",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    academic_journals_id = table.Column<Guid>(type: "uuid", nullable: false),
                    audio_records_id = table.Column<Guid>(type: "uuid", nullable: false),
                    books_id = table.Column<Guid>(type: "uuid", nullable: false),
                    book_series_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cartographic_materials_id = table.Column<Guid>(type: "uuid", nullable: false),
                    depictions_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dissertations_id = table.Column<Guid>(type: "uuid", nullable: false),
                    electronics_resources_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encyclopedias_id = table.Column<Guid>(type: "uuid", nullable: false),
                    graphical_images_id = table.Column<Guid>(type: "uuid", nullable: false),
                    magazines_id = table.Column<Guid>(type: "uuid", nullable: false),
                    microforms_id = table.Column<Guid>(type: "uuid", nullable: false),
                    musical_notes_id = table.Column<Guid>(type: "uuid", nullable: false),
                    news_papers_id = table.Column<Guid>(type: "uuid", nullable: false),
                    object3ds_id = table.Column<Guid>(type: "uuid", nullable: false),
                    paintings_id = table.Column<Guid>(type: "uuid", nullable: false),
                    posters_id = table.Column<Guid>(type: "uuid", nullable: false),
                    theses_id = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "ix_technical_placeholders_kit_id",
                table: "technical_placeholders",
                column: "kit_id");

            migrationBuilder.CreateIndex(
                name: "ix_e_material_files_kit_id",
                table: "e_material_files",
                column: "kit_id");

            migrationBuilder.CreateIndex(
                name: "ix_dimensions_kit_id",
                table: "dimensions",
                column: "kit_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_kit_id",
                table: "categories",
                column: "kit_id");

            migrationBuilder.CreateIndex(
                name: "ix_academic_journal_kit_kits_id",
                table: "academic_journal_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_audio_record_kit_kits_id",
                table: "audio_record_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_kit_kits_id",
                table: "book_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_book_series_kit_kits_id",
                table: "book_series_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_cartographic_material_kit_kits_id",
                table: "cartographic_material_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_depiction_kit_kits_id",
                table: "depiction_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_dissertation_kit_kits_id",
                table: "dissertation_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_electronics_resource_kit_kits_id",
                table: "electronics_resource_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_encyclopedia_kit_kits_id",
                table: "encyclopedia_kit",
                column: "kits_id");

            migrationBuilder.CreateIndex(
                name: "ix_graphical_image_kit_kits_id",
                table: "graphical_image_kit",
                column: "kits_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_categories_kits_kit_id",
                table: "categories",
                column: "kit_id",
                principalTable: "kits",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_dimensions_kits_kit_id",
                table: "dimensions",
                column: "kit_id",
                principalTable: "kits",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_e_material_files_kits_kit_id",
                table: "e_material_files",
                column: "kit_id",
                principalTable: "kits",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_technical_placeholders_kits_kit_id",
                table: "technical_placeholders",
                column: "kit_id",
                principalTable: "kits",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categories_kits_kit_id",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "fk_dimensions_kits_kit_id",
                table: "dimensions");

            migrationBuilder.DropForeignKey(
                name: "fk_e_material_files_kits_kit_id",
                table: "e_material_files");

            migrationBuilder.DropForeignKey(
                name: "fk_technical_placeholders_kits_kit_id",
                table: "technical_placeholders");

            migrationBuilder.DropTable(
                name: "academic_journal_kit");

            migrationBuilder.DropTable(
                name: "audio_record_kit");

            migrationBuilder.DropTable(
                name: "book_kit");

            migrationBuilder.DropTable(
                name: "book_series_kit");

            migrationBuilder.DropTable(
                name: "cartographic_material_kit");

            migrationBuilder.DropTable(
                name: "depiction_kit");

            migrationBuilder.DropTable(
                name: "dissertation_kit");

            migrationBuilder.DropTable(
                name: "electronics_resource_kit");

            migrationBuilder.DropTable(
                name: "encyclopedia_kit");

            migrationBuilder.DropTable(
                name: "graphical_image_kit");

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
                name: "kits");

            migrationBuilder.DropIndex(
                name: "ix_technical_placeholders_kit_id",
                table: "technical_placeholders");

            migrationBuilder.DropIndex(
                name: "ix_e_material_files_kit_id",
                table: "e_material_files");

            migrationBuilder.DropIndex(
                name: "ix_dimensions_kit_id",
                table: "dimensions");

            migrationBuilder.DropIndex(
                name: "ix_categories_kit_id",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "kit_id",
                table: "technical_placeholders");

            migrationBuilder.DropColumn(
                name: "kit_id",
                table: "e_material_files");

            migrationBuilder.DropColumn(
                name: "kit_id",
                table: "dimensions");

            migrationBuilder.DropColumn(
                name: "kit_id",
                table: "categories");
        }
    }
}
