using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addChatEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => new { x.UserId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_UserChats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "218074fa-d167-493d-b0a2-a9778d2f55c3", "AQAAAAEAACcQAAAAECx5k/g/yt7DLhWwbCj+6/IGkWShfsTDhUYN7GZBc4QNTpGLQOxLAp6Qxu0pM8eQIQ==", "42c5cc94-0f43-4d34-ba96-3b61d71ddfb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb04bf39-a462-4c8d-abd1-1aa3102978c5", "AQAAAAEAACcQAAAAEPS1ikSaVpm4eS5jDdoDGa3SD3kY9KEf0z5mCb6H38ungE1GWR4VVCKhb790xlLIcw==", "06aec8fd-5191-4624-8b5a-15c5708e81da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa2d13a1-9e51-45b8-b46e-47dcf90081ae", "AQAAAAEAACcQAAAAEPY5+seq7NtH0jc233LMsbYIGG9vlbD/dy8kVDP4Mcw7Ip0ocPVHuswpNSh1V+/NEA==", "722f857d-7e56-4727-a1ee-f6866e0a306a" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChats",
                column: "ChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91541bfb-98c0-41fe-a629-bc83f3308ef5", "AQAAAAEAACcQAAAAEDMRr7uj/4r7npqusa9lJyJtk8qVfuvYICS4HrDBrNqc78rSaFOxLQSd548kFUBiKw==", "5c58d44d-2a13-4ab9-9bc8-ea42cca8d8cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1de0a9d0-6f18-4208-bd3a-1cfd9214ab4b", "AQAAAAEAACcQAAAAEDIMxJjsI2PNzhAEnU52CS6CYTpFRIKVrUXHQBek9Ri+Sv+yTaWmEeYnUUnDAo+Cyg==", "a4673413-5598-4506-bd4b-e0af1a2add2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42ad3f4d-d792-49da-8a5c-f643fe23fac8", "AQAAAAEAACcQAAAAEGbnWbkPoHERIqrSnGg6e/fDlaF1p7/RFVSEcv15lHDh/oQhJqjFdB4UbQZ12gHVaQ==", "ad1a76ff-8afe-4f98-9e83-8aa498834407" });
        }
    }
}
