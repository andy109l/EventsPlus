using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class VerificationMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactAddressLine1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactAddressLine2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactAddressLine3",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactAddressLine4",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "PosCitCouId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosCitCouPostcode",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PosCitCou",
                columns: table => new
                {
                    PosCitCouId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postcode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosCitCou", x => x.PosCitCouId);
                });

            migrationBuilder.CreateTable(
                name: "GuestAttendee",
                columns: table => new
                {
                    GuestAttendyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosCitCouID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAttendee", x => x.GuestAttendyId);
                    table.ForeignKey(
                        name: "FK_GuestAttendee_PosCitCou_PosCitCouID",
                        column: x => x.PosCitCouID,
                        principalTable: "PosCitCou",
                        principalColumn: "PosCitCouId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    OrganizerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OrganizerContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OrganizerEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosCitCouID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PosCitCouId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.OrganizerID);
                    table.ForeignKey(
                        name: "FK_Organizer_PosCitCou_PosCitCouId",
                        column: x => x.PosCitCouId,
                        principalTable: "PosCitCou",
                        principalColumn: "PosCitCouId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VenueAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddressLine4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosCitCouID = table.Column<int>(type: "int", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VenueAddress_PosCitCou_PosCitCouID",
                        column: x => x.PosCitCouID,
                        principalTable: "PosCitCou",
                        principalColumn: "PosCitCouId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizerID1 = table.Column<int>(type: "int", nullable: true),
                    EventsStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventsStartEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfAttendies = table.Column<int>(type: "int", nullable: false),
                    PrivacySetting = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedOnly = table.Column<bool>(type: "bit", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    VenueAddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Organizer_OrganizerID1",
                        column: x => x.OrganizerID1,
                        principalTable: "Organizer",
                        principalColumn: "OrganizerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_VenueAddress_VenueAddressID",
                        column: x => x.VenueAddressID,
                        principalTable: "VenueAddress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestRegEvent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventsID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    GeuestAttendyID = table.Column<int>(type: "int", nullable: false),
                    GuestAttendeeGuestAttendyId = table.Column<int>(type: "int", nullable: true),
                    RegistrationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestRegEvent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GuestRegEvent_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestRegEvent_GuestAttendee_GuestAttendeeGuestAttendyId",
                        column: x => x.GuestAttendeeGuestAttendyId,
                        principalTable: "GuestAttendee",
                        principalColumn: "GuestAttendyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRegEvent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegistrationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegEvent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRegEvent_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRegEvent_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PosCitCouId",
                table: "AspNetUsers",
                column: "PosCitCouId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerID1",
                table: "Event",
                column: "OrganizerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Event_VenueAddressID",
                table: "Event",
                column: "VenueAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAttendee_PosCitCouID",
                table: "GuestAttendee",
                column: "PosCitCouID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRegEvent_EventID",
                table: "GuestRegEvent",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRegEvent_GuestAttendeeGuestAttendyId",
                table: "GuestRegEvent",
                column: "GuestAttendeeGuestAttendyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_PosCitCouId",
                table: "Organizer",
                column: "PosCitCouId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegEvent_EventID",
                table: "UserRegEvent",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegEvent_UserId",
                table: "UserRegEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueAddress_PosCitCouID",
                table: "VenueAddress",
                column: "PosCitCouID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PosCitCou_PosCitCouId",
                table: "AspNetUsers",
                column: "PosCitCouId",
                principalTable: "PosCitCou",
                principalColumn: "PosCitCouId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PosCitCou_PosCitCouId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GuestRegEvent");

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

            migrationBuilder.DropTable(
                name: "PosCitCou");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PosCitCouId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactAddressLine1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactAddressLine2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactAddressLine3",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactAddressLine4",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PosCitCouId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PosCitCouPostcode",
                table: "AspNetUsers");
        }
    }
}
