using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDotNetCoreApp.Migrations
{
    public partial class VersionAndModifiedDateForFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER trVersionAndModifiedDateForFiles\r\n  " +
                                 "on Files\r\n\r\n  " +
                                 "AFTER UPDATE\r\n  " +
                                 "AS \r\n  " +
                                 "BEGIN\r\n\t  " +
                                 "UPDATE Files SET Version = Version + 1,\r\n\t  " +
                                 "ModifiedDate = GETDATE()\r\n\t  " +
                                 "WHERE Id IN (SELECT Id FROM inserted)\r\n  " +
                                 "END\r\n  " +
                                 "GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trVersionAndModifiedDateForFiles");
        }
    }
}
