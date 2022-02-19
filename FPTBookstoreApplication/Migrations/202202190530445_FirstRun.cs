namespace FPTBookstoreApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstRun : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "Accounts_UserName" });
            DropColumn("dbo.Orders", "UserName");
            RenameColumn(table: "dbo.Orders", name: "Accounts_UserName", newName: "UserName");
            AddColumn("dbo.Accounts", "ConfirmPass", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "AddressDilivery", c => c.String());
            AlterColumn("dbo.Accounts", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "UserName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "UserName" });
            AlterColumn("dbo.Orders", "UserName", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "Email", c => c.String());
            AlterColumn("dbo.Accounts", "Address", c => c.String());
            AlterColumn("dbo.Accounts", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
            AlterColumn("dbo.Accounts", "FullName", c => c.String());
            DropColumn("dbo.Orders", "AddressDilivery");
            DropColumn("dbo.Accounts", "ConfirmPass");
            RenameColumn(table: "dbo.Orders", name: "UserName", newName: "Accounts_UserName");
            AddColumn("dbo.Orders", "UserName", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Accounts_UserName");
        }
    }
}
