﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class RemovedMainPictureUriFromItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPictureUri",
                table: "Items");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainPictureUri",
                table: "Items",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

           
        }
    }
}
