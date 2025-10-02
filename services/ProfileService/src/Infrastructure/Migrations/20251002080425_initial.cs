using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone_contact = table.Column<string>(type: "text", nullable: false),
                    email_contact = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.id);
                    table.CheckConstraint("CK_email_contact_format", "email_contact ~ '^[^@]+@[^@]+\\.[^@]+$'");
                    table.CheckConstraint("CK_name_length", "LENGTH(name) >=3 AND LENGTH(name) <= 15");
                    table.CheckConstraint("CK_phone_contact_length", "LENGTH(phone_contact) = 11");
                    table.CheckConstraint("CK_phone_contact_text_digits", "phone_contact ~ '^[0-9]*$'");
                    table.CheckConstraint("CK_updatedat_more_createdat", "updated_at >= created_at");
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.CheckConstraint("CK_email_format", "email ~ '^[^@]+@[^@]+\\.[^@]+$'");
                    table.CheckConstraint("CK_login_length", "LENGTH(login) >=5 AND LENGTH(login) <= 20");
                    table.CheckConstraint("CK_phone_number_length", "LENGTH(phone_number) = 11");
                    table.CheckConstraint("CK_phone_number_text_digits", "phone_number ~ '^[0-9]*$'");
                    table.CheckConstraint("CK_updatedat_more_createdat", "updated_at >= created_at");
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.id);
                    table.ForeignKey(
                        name: "FK_admins_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rating = table.Column<double>(type: "numeric(2,1)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.CheckConstraint("CK_rating_range", "rating BETWEEN 0 AND 5");
                    table.ForeignKey(
                        name: "FK_customers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: false),
                    gender = table.Column<bool>(type: "boolean", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.id);
                    table.CheckConstraint("CK_age_range", "age BETWEEN 1 AND 100");
                    table.CheckConstraint("CK_name_length", "LENGTH(name) >=3 AND LENGTH(name) <= 15");
                    table.CheckConstraint("CK_patronymic_length", "LENGTH(patronymic) >=3 AND LENGTH(patronymic) <= 25");
                    table.CheckConstraint("CK_surname_length", "LENGTH(surname) >=3 AND LENGTH(surname) <= 25");
                    table.ForeignKey(
                        name: "FK_profiles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users_roles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_roles", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_users_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    shop_id = table.Column<Guid>(type: "uuid", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: true),
                    email_contact = table.Column<string>(type: "text", nullable: false),
                    phone_contact = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.id);
                    table.CheckConstraint("CK_email_contact_format", "email_contact ~ '^[^@]+@[^@]+\\.[^@]+$'");
                    table.CheckConstraint("CK_phone_contact_text_digits", "phone_contact ~ '^[0-9]*$'");
                    table.ForeignKey(
                        name: "FK_sellers_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sellers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    seller_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<double>(type: "numeric(2,1)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shops", x => x.id);
                    table.CheckConstraint("CK_description_length", "LENGTH(description) >=0 AND LENGTH(description) <= 300");
                    table.CheckConstraint("CK_name_length", "LENGTH(name) >=3 AND LENGTH(name) <= 30");
                    table.CheckConstraint("CK_rating_range", "rating BETWEEN 0 AND 5");
                    table.CheckConstraint("CK_updatedat_more_createdat", "updated_at >= created_at");
                    table.ForeignKey(
                        name: "FK_shops_sellers_seller_id",
                        column: x => x.seller_id,
                        principalTable: "sellers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admins_id",
                table: "admins",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_admins_user_id",
                table: "admins",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_id",
                table: "companies",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_id",
                table: "customers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_user_id",
                table: "customers",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_id",
                table: "profiles",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_user_id",
                table: "profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_id",
                table: "roles",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sellers_company_id",
                table: "sellers",
                column: "company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sellers_id",
                table: "sellers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sellers_shop_id",
                table: "sellers",
                column: "shop_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sellers_user_id",
                table: "sellers",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shops_id",
                table: "shops",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shops_seller_id",
                table: "shops",
                column: "seller_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_id",
                table: "users",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_login",
                table: "users",
                column: "login");

            migrationBuilder.CreateIndex(
                name: "IX_users_roles_role_id",
                table: "users_roles",
                column: "role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_roles_user_id",
                table: "users_roles",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_sellers_shops_shop_id",
                table: "sellers",
                column: "shop_id",
                principalTable: "shops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sellers_users_user_id",
                table: "sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_sellers_companies_company_id",
                table: "sellers");

            migrationBuilder.DropForeignKey(
                name: "FK_sellers_shops_shop_id",
                table: "sellers");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "users_roles");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "shops");

            migrationBuilder.DropTable(
                name: "sellers");
        }
    }
}
