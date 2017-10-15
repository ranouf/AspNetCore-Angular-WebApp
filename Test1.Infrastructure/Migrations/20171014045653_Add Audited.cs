using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Test1.Infrastructure.Migrations
{
  public partial class AddAudited : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "UserId",
          table: "MySamples");

      migrationBuilder.DropForeignKey(
                name: "FK_MySamples_AspNetUsers_UserId",
                table: "MySamples");

      migrationBuilder.DropIndex(
          name: "IX_MySamples_UserId",
          table: "MySamples");

      migrationBuilder.AddColumn<Guid>(
          name: "AuthorId",
          table: "MySamples",
          type: "uniqueidentifier",
          nullable: false,
          defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      migrationBuilder.AddColumn<DateTimeOffset>(
          name: "CreationTime",
          table: "MySamples",
          type: "datetimeoffset",
          nullable: true);

      migrationBuilder.AddColumn<Guid>(
          name: "LastEditorId",
          table: "MySamples",
          type: "uniqueidentifier",
          nullable: true);

      migrationBuilder.AddColumn<DateTimeOffset>(
          name: "LastModificationTime",
          table: "MySamples",
          type: "datetimeoffset",
          nullable: true);

      migrationBuilder.CreateIndex(
          name: "IX_MySamples_AuthorId",
          table: "MySamples",
          column: "AuthorId");

      migrationBuilder.CreateIndex(
          name: "IX_MySamples_LastEditorId",
          table: "MySamples",
          column: "LastEditorId");

      migrationBuilder.AddForeignKey(
          name: "FK_MySamples_AspNetUsers_AuthorId",
          table: "MySamples",
          column: "AuthorId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_MySamples_AspNetUsers_LastEditorId",
          table: "MySamples",
          column: "LastEditorId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<Guid>(
          name: "UserId",
          table: "MySamples",
          nullable: false,
          defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      migrationBuilder.DropForeignKey(
          name: "FK_MySamples_AspNetUsers_AuthorId",
          table: "MySamples");

      migrationBuilder.DropForeignKey(
          name: "FK_MySamples_AspNetUsers_LastEditorId",
          table: "MySamples");

      migrationBuilder.DropIndex(
          name: "IX_MySamples_AuthorId",
          table: "MySamples");

      migrationBuilder.DropIndex(
          name: "IX_MySamples_LastEditorId",
          table: "MySamples");

      migrationBuilder.DropColumn(
          name: "AuthorId",
          table: "MySamples");

      migrationBuilder.DropColumn(
          name: "CreationTime",
          table: "MySamples");

      migrationBuilder.DropColumn(
          name: "LastEditorId",
          table: "MySamples");

      migrationBuilder.DropColumn(
          name: "LastModificationTime",
          table: "MySamples");

      migrationBuilder.CreateIndex(
          name: "IX_MySamples_UserId",
          table: "MySamples",
          column: "UserId");

      migrationBuilder.AddForeignKey(
          name: "FK_MySamples_AspNetUsers_UserId",
          table: "MySamples",
          column: "UserId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }
  }
}