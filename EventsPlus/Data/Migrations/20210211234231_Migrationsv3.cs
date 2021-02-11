using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsPlus.Data.Migrations
{
    public partial class Migrationsv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PosCitCou_PosCitCouId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Organizer_OrganizerID1",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestAttendee_PosCitCou_PosCitCouID",
                table: "GuestAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRegEvent_Event_EventID",
                table: "GuestRegEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRegEvent_GuestAttendee_GuestAttendeeGuestAttendyId",
                table: "GuestRegEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizer_PosCitCou_PosCitCouId1",
                table: "Organizer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRegEvent_Event_EventID",
                table: "UserRegEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_VenueAddress_PosCitCou_PosCitCouId",
                table: "VenueAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PosCitCou",
                table: "PosCitCou");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer");

            migrationBuilder.DropIndex(
                name: "IX_Organizer_PosCitCouId1",
                table: "Organizer");

            migrationBuilder.DropIndex(
                name: "IX_GuestRegEvent_GuestAttendeeGuestAttendyId",
                table: "GuestRegEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestAttendee",
                table: "GuestAttendee");

            migrationBuilder.DropIndex(
                name: "IX_Event_OrganizerID1",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "VenPosCitCouID",
                table: "VenueAddress");

            migrationBuilder.DropColumn(
                name: "Event1ID",
                table: "UserRegEvent");

            migrationBuilder.DropColumn(
                name: "User1ID",
                table: "UserRegEvent");

            migrationBuilder.DropColumn(
                name: "PosCitCouId1",
                table: "Organizer");

            migrationBuilder.DropColumn(
                name: "Event1ID",
                table: "GuestRegEvent");

            migrationBuilder.DropColumn(
                name: "GuestAttendeeGuestAttendyId",
                table: "GuestRegEvent");

            migrationBuilder.DropColumn(
                name: "OrganizerID1",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "PosCitCouPostcode",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "VenueAddress",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "UserRegEvent",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserRegEvent",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserRegEvent_EventID",
                table: "UserRegEvent",
                newName: "IX_UserRegEvent_EventId");

            migrationBuilder.RenameColumn(
                name: "PosCitCouId",
                table: "PosCitCou",
                newName: "VenueAddressId");

            migrationBuilder.RenameColumn(
                name: "OrganizerID",
                table: "Organizer",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "GuestRegEvent",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "GuestRegEvent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GeuestAttendee1ID",
                table: "GuestRegEvent",
                newName: "GuestAttendeeId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestRegEvent_EventID",
                table: "GuestRegEvent",
                newName: "IX_GuestRegEvent_EventId");

            migrationBuilder.RenameColumn(
                name: "PosCitCouID",
                table: "GuestAttendee",
                newName: "PosCitCouId");

            migrationBuilder.RenameColumn(
                name: "GuestAttendyId",
                table: "GuestAttendee",
                newName: "GuestRegEventId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestAttendee_PosCitCouID",
                table: "GuestAttendee",
                newName: "IX_GuestAttendee_PosCitCouId");

            migrationBuilder.RenameColumn(
                name: "OrganizerID",
                table: "Event",
                newName: "OrganizerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Event",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "PosCitCouId",
                table: "VenueAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserRegEvent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "UserRegEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VenueAddressId",
                table: "PosCitCou",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PosCitCou",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GuestAttendeeId",
                table: "PosCitCou",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizerId",
                table: "PosCitCou",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PosCitCou",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PosCitCouId",
                table: "Organizer",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Organizer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Organizer",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "GuestRegEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuestRegEventId",
                table: "GuestAttendee",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GuestAttendee",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerId",
                table: "Event",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "GuestRegEvent",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRegEvent",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRegEventId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosCitCou",
                table: "PosCitCou",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestAttendee",
                table: "GuestAttendee",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_PosCitCouId",
                table: "Organizer",
                column: "PosCitCouId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRegEvent_GuestAttendeeId",
                table: "GuestRegEvent",
                column: "GuestAttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerId",
                table: "Event",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PosCitCou_PosCitCouId",
                table: "AspNetUsers",
                column: "PosCitCouId",
                principalTable: "PosCitCou",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Organizer_OrganizerId",
                table: "Event",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestAttendee_PosCitCou_PosCitCouId",
                table: "GuestAttendee",
                column: "PosCitCouId",
                principalTable: "PosCitCou",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRegEvent_Event_EventId",
                table: "GuestRegEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRegEvent_GuestAttendee_GuestAttendeeId",
                table: "GuestRegEvent",
                column: "GuestAttendeeId",
                principalTable: "GuestAttendee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizer_PosCitCou_PosCitCouId",
                table: "Organizer",
                column: "PosCitCouId",
                principalTable: "PosCitCou",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegEvent_Event_EventId",
                table: "UserRegEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VenueAddress_PosCitCou_PosCitCouId",
                table: "VenueAddress",
                column: "PosCitCouId",
                principalTable: "PosCitCou",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PosCitCou_PosCitCouId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Organizer_OrganizerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestAttendee_PosCitCou_PosCitCouId",
                table: "GuestAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRegEvent_Event_EventId",
                table: "GuestRegEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestRegEvent_GuestAttendee_GuestAttendeeId",
                table: "GuestRegEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizer_PosCitCou_PosCitCouId",
                table: "Organizer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRegEvent_Event_EventId",
                table: "UserRegEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_VenueAddress_PosCitCou_PosCitCouId",
                table: "VenueAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PosCitCou",
                table: "PosCitCou");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer");

            migrationBuilder.DropIndex(
                name: "IX_Organizer_PosCitCouId",
                table: "Organizer");

            migrationBuilder.DropIndex(
                name: "IX_GuestRegEvent_GuestAttendeeId",
                table: "GuestRegEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestAttendee",
                table: "GuestAttendee");

            migrationBuilder.DropIndex(
                name: "IX_Event_OrganizerId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PosCitCou");

            migrationBuilder.DropColumn(
                name: "GuestAttendeeId",
                table: "PosCitCou");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "PosCitCou");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PosCitCou");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Organizer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GuestAttendee");

            migrationBuilder.DropColumn(
                name: "GuestRegEvent",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UserRegEvent",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UserRegEventId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VenueAddress",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "UserRegEvent",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserRegEvent",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRegEvent_EventId",
                table: "UserRegEvent",
                newName: "IX_UserRegEvent_EventID");

            migrationBuilder.RenameColumn(
                name: "VenueAddressId",
                table: "PosCitCou",
                newName: "PosCitCouId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Organizer",
                newName: "OrganizerID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "GuestRegEvent",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GuestRegEvent",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GuestAttendeeId",
                table: "GuestRegEvent",
                newName: "GeuestAttendee1ID");

            migrationBuilder.RenameIndex(
                name: "IX_GuestRegEvent_EventId",
                table: "GuestRegEvent",
                newName: "IX_GuestRegEvent_EventID");

            migrationBuilder.RenameColumn(
                name: "PosCitCouId",
                table: "GuestAttendee",
                newName: "PosCitCouID");

            migrationBuilder.RenameColumn(
                name: "GuestRegEventId",
                table: "GuestAttendee",
                newName: "GuestAttendyId");

            migrationBuilder.RenameIndex(
                name: "IX_GuestAttendee_PosCitCouId",
                table: "GuestAttendee",
                newName: "IX_GuestAttendee_PosCitCouID");

            migrationBuilder.RenameColumn(
                name: "OrganizerId",
                table: "Event",
                newName: "OrganizerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Event",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "PosCitCouId",
                table: "VenueAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VenPosCitCouID",
                table: "VenueAddress",
                type: "int",
                maxLength: 15,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserRegEvent",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "UserRegEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Event1ID",
                table: "UserRegEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User1ID",
                table: "UserRegEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PosCitCouId",
                table: "PosCitCou",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "PosCitCouId",
                table: "Organizer",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerID",
                table: "Organizer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PosCitCouId1",
                table: "Organizer",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "GuestRegEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Event1ID",
                table: "GuestRegEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuestAttendeeGuestAttendyId",
                table: "GuestRegEvent",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuestAttendyId",
                table: "GuestAttendee",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerID",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrganizerID1",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosCitCouPostcode",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosCitCou",
                table: "PosCitCou",
                column: "PosCitCouId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer",
                column: "OrganizerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestAttendee",
                table: "GuestAttendee",
                column: "GuestAttendyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizer_PosCitCouId1",
                table: "Organizer",
                column: "PosCitCouId1");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRegEvent_GuestAttendeeGuestAttendyId",
                table: "GuestRegEvent",
                column: "GuestAttendeeGuestAttendyId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerID1",
                table: "Event",
                column: "OrganizerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PosCitCou_PosCitCouId",
                table: "AspNetUsers",
                column: "PosCitCouId",
                principalTable: "PosCitCou",
                principalColumn: "PosCitCouId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Organizer_OrganizerID1",
                table: "Event",
                column: "OrganizerID1",
                principalTable: "Organizer",
                principalColumn: "OrganizerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestAttendee_PosCitCou_PosCitCouID",
                table: "GuestAttendee",
                column: "PosCitCouID",
                principalTable: "PosCitCou",
                principalColumn: "PosCitCouId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRegEvent_Event_EventID",
                table: "GuestRegEvent",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRegEvent_GuestAttendee_GuestAttendeeGuestAttendyId",
                table: "GuestRegEvent",
                column: "GuestAttendeeGuestAttendyId",
                principalTable: "GuestAttendee",
                principalColumn: "GuestAttendyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizer_PosCitCou_PosCitCouId1",
                table: "Organizer",
                column: "PosCitCouId1",
                principalTable: "PosCitCou",
                principalColumn: "PosCitCouId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegEvent_Event_EventID",
                table: "UserRegEvent",
                column: "EventID",
                principalTable: "Event",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VenueAddress_PosCitCou_PosCitCouId",
                table: "VenueAddress",
                column: "PosCitCouId",
                principalTable: "PosCitCou",
                principalColumn: "PosCitCouId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
