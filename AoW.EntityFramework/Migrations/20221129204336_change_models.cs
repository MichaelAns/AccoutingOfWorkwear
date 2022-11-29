using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AoW.EntityFramework.Migrations
{
    public partial class change_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraditionInfo_Staff_StaffID",
                table: "ExtraditionInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraditionInfo_WorkWear_WorkWearID",
                table: "ExtraditionInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptInfo_Provider_ProviderID",
                table: "ReceiptInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptInfo_WorkWear_WorkWearID",
                table: "ReceiptInfo");

            migrationBuilder.RenameColumn(
                name: "WorkWearID",
                table: "ReceiptInfo",
                newName: "WorkWearId");

            migrationBuilder.RenameColumn(
                name: "ProviderID",
                table: "ReceiptInfo",
                newName: "ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptInfo_WorkWearID",
                table: "ReceiptInfo",
                newName: "IX_ReceiptInfo_WorkWearId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptInfo_ProviderID",
                table: "ReceiptInfo",
                newName: "IX_ReceiptInfo_ProviderId");

            migrationBuilder.RenameColumn(
                name: "WorkWearID",
                table: "ExtraditionInfo",
                newName: "WorkWearId");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "ExtraditionInfo",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraditionInfo_WorkWearID",
                table: "ExtraditionInfo",
                newName: "IX_ExtraditionInfo_WorkWearId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraditionInfo_StaffID",
                table: "ExtraditionInfo",
                newName: "IX_ExtraditionInfo_StaffId");

            migrationBuilder.AddColumn<int>(
                name: "Remains",
                table: "ReceiptInfo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraditionInfo_Staff_StaffId",
                table: "ExtraditionInfo",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraditionInfo_WorkWear_WorkWearId",
                table: "ExtraditionInfo",
                column: "WorkWearId",
                principalTable: "WorkWear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptInfo_Provider_ProviderId",
                table: "ReceiptInfo",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptInfo_WorkWear_WorkWearId",
                table: "ReceiptInfo",
                column: "WorkWearId",
                principalTable: "WorkWear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraditionInfo_Staff_StaffId",
                table: "ExtraditionInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraditionInfo_WorkWear_WorkWearId",
                table: "ExtraditionInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptInfo_Provider_ProviderId",
                table: "ReceiptInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptInfo_WorkWear_WorkWearId",
                table: "ReceiptInfo");

            migrationBuilder.DropColumn(
                name: "Remains",
                table: "ReceiptInfo");

            migrationBuilder.RenameColumn(
                name: "WorkWearId",
                table: "ReceiptInfo",
                newName: "WorkWearID");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "ReceiptInfo",
                newName: "ProviderID");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptInfo_WorkWearId",
                table: "ReceiptInfo",
                newName: "IX_ReceiptInfo_WorkWearID");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptInfo_ProviderId",
                table: "ReceiptInfo",
                newName: "IX_ReceiptInfo_ProviderID");

            migrationBuilder.RenameColumn(
                name: "WorkWearId",
                table: "ExtraditionInfo",
                newName: "WorkWearID");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "ExtraditionInfo",
                newName: "StaffID");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraditionInfo_WorkWearId",
                table: "ExtraditionInfo",
                newName: "IX_ExtraditionInfo_WorkWearID");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraditionInfo_StaffId",
                table: "ExtraditionInfo",
                newName: "IX_ExtraditionInfo_StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraditionInfo_Staff_StaffID",
                table: "ExtraditionInfo",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraditionInfo_WorkWear_WorkWearID",
                table: "ExtraditionInfo",
                column: "WorkWearID",
                principalTable: "WorkWear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptInfo_Provider_ProviderID",
                table: "ReceiptInfo",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptInfo_WorkWear_WorkWearID",
                table: "ReceiptInfo",
                column: "WorkWearID",
                principalTable: "WorkWear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
