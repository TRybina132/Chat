using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0f146d60-892b-496f-beda-e8d3e564b368", "AQAAAAEAACcQAAAAEI2nnGblCMj212Tg4+TMuzpmsUspXCudDS21B+0ejMh7ghu3OZ9NvOBpt+grRToqgA==", "38687ef7-92f7-4a72-92fe-f0e2e56673ba", "6_Ikaren" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "649255c3-ecfd-4a78-9075-e41d264f8bdd", "AQAAAAEAACcQAAAAEC0NWVZs6e52VRbcOpRw7SAOQpVZQY3QWINDvSz1xZ2uivX1Y6fH7uEPNqYLzDXmbw==", "8bdc662b-31d6-4e1a-a241-04e69f676264", "nancy_2200" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a8aa4c0c-1c47-4cda-aa54-f3ffde6a3254", "AQAAAAEAACcQAAAAEKY+/a1GV0FglqNXP8KmB7TggLW5YbL4P7O9i0Jfs8LutoEXOpWulF/lOuuMykNQbw==", "791e45cb-1b03-4dfe-8a3b-6136cb37f74f", "coolJony222" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "Username");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Username" },
                values: new object[] { "218074fa-d167-493d-b0a2-a9778d2f55c3", "AQAAAAEAACcQAAAAECx5k/g/yt7DLhWwbCj+6/IGkWShfsTDhUYN7GZBc4QNTpGLQOxLAp6Qxu0pM8eQIQ==", "42c5cc94-0f43-4d34-ba96-3b61d71ddfb7", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Username" },
                values: new object[] { "cb04bf39-a462-4c8d-abd1-1aa3102978c5", "AQAAAAEAACcQAAAAEPS1ikSaVpm4eS5jDdoDGa3SD3kY9KEf0z5mCb6H38ungE1GWR4VVCKhb790xlLIcw==", "06aec8fd-5191-4624-8b5a-15c5708e81da", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Username" },
                values: new object[] { "aa2d13a1-9e51-45b8-b46e-47dcf90081ae", "AQAAAAEAACcQAAAAEPY5+seq7NtH0jc233LMsbYIGG9vlbD/dy8kVDP4Mcw7Ip0ocPVHuswpNSh1V+/NEA==", "722f857d-7e56-4727-a1ee-f6866e0a306a", null });
        }
    }
}
