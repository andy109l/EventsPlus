using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class Migrationsv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OrganizerContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OrganizerEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PosCitCou",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosCitCou", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRegEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRegEvent_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VenueAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerId = table.Column<int>(type: "int", nullable: false),
                    EventsStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventsStartEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfAttendies = table.Column<int>(type: "int", nullable: false),
                    PrivacySetting = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedOnly = table.Column<bool>(type: "bit", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    VenueAddressId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_VenueAddress_VenueAddressId",
                        column: x => x.VenueAddressId,
                        principalTable: "VenueAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestAttendee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAttendee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestAttendee_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestRegEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestAttendeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestRegEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestRegEvent_GuestAttendee_GuestAttendeeId",
                        column: x => x.GuestAttendeeId,
                        principalTable: "GuestAttendee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerId",
                table: "Event",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_VenueAddressId",
                table: "Event",
                column: "VenueAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAttendee_EventId",
                table: "GuestAttendee",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRegEvent_GuestAttendeeId",
                table: "GuestRegEvent",
                column: "GuestAttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegEvent_UserId",
                table: "UserRegEvent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestRegEvent");

            migrationBuilder.DropTable(
                name: "PosCitCou");

            migrationBuilder.DropTable(
                name: "UserRegEvent");

            migrationBuilder.DropTable(
                name: "GuestAttendee");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Organizer");

            migrationBuilder.DropTable(
                name: "VenueAddress");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
