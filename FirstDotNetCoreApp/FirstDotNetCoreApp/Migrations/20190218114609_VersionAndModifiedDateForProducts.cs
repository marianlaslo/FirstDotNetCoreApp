using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDotNetCoreApp.Migrations
{
    public partial class VersionAndModifiedDateForProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER trVersionAndModifiedDateForProducts\r\n  " +
                                 "on Products\r\n\r\n  " +
                                 "AFTER UPDATE\r\n  " +
                                 "AS \r\n  " +
                                 "BEGIN\r\n\t  " +
                                 "UPDATE Products SET Version = Version + 1,\r\n\t  " +
                                 "ModifiedDate = GETDATE()\r\n\t  " +
                                 "WHERE Id IN (SELECT Id FROM inserted)\r\n  " +
                                 "END\r\n  " +
                                 "GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trVersionAndModifiedDateForProducts");
        }
    }
}
