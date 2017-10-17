using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Test1.Infrastructure.Migrations
{
    public partial class AddSoftDeleteAndRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MySamples_AspNetUsers_AuthorId",
                table: "MySamples");

            migrationBuilder.DropForeignKey(
                name: "FK_MySamples_AspNetUsers_LastUpdaterId",
                table: "MySamples");

            migrationBuilder.DropIndex(
                name: "IX_MySamples_AuthorId",
                table: "MySamples");

            migrationBuilder.DropIndex(
                name: "IX_MySamples_LastUpdaterId",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "LastUpdaterId",
                table: "MySamples");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MySamples",
                type: "datetimeoffset",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "MySamples",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "MySamples",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedByUserId",
                table: "MySamples",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MySamples",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "MySamples",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedByUserId",
                table: "MySamples",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MySamples_CreatedByUserId",
                table: "MySamples",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MySamples_DeletedByUserId",
                table: "MySamples",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MySamples_ModifiedByUserId",
                table: "MySamples",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MySamples_AspNetUsers_CreatedByUserId",
                table: "MySamples",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MySamples_AspNetUsers_DeletedByUserId",
                table: "MySamples",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MySamples_AspNetUsers_ModifiedByUserId",
                table: "MySamples",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MySamples_AspNetUsers_CreatedByUserId",
                table: "MySamples");

            migrationBuilder.DropForeignKey(
                name: "FK_MySamples_AspNetUsers_DeletedByUserId",
                table: "MySamples");

            migrationBuilder.DropForeignKey(
                name: "FK_MySamples_AspNetUsers_ModifiedByUserId",
                table: "MySamples");

            migrationBuilder.DropIndex(
                name: "IX_MySamples_CreatedByUserId",
                table: "MySamples");

            migrationBuilder.DropIndex(
                name: "IX_MySamples_DeletedByUserId",
                table: "MySamples");

            migrationBuilder.DropIndex(
                name: "IX_MySamples_ModifiedByUserId",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "MySamples");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "MySamples");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "MySamples",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "MySamples",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModificationTime",
                table: "MySamples",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdaterId",
                table: "MySamples",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MySamples_AuthorId",
                table: "MySamples",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MySamples_LastUpdaterId",
                table: "MySamples",
                column: "LastUpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MySamples_AspNetUsers_AuthorId",
                table: "MySamples",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MySamples_AspNetUsers_LastUpdaterId",
                table: "MySamples",
                column: "LastUpdaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
