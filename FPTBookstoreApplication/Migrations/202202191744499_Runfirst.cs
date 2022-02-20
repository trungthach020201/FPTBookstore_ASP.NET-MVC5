namespace FPTBookstoreApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Runfirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        StatusCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        UserName = c.String(maxLength: 128),
                        Addressdilivery = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Accounts", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Orderdetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Img = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        DateAdd = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orderdetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orderdetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Orders", "UserName", "dbo.Accounts");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Orderdetails", new[] { "OrderId" });
            DropIndex("dbo.Orderdetails", new[] { "BookId" });
            DropIndex("dbo.Orders", new[] { "UserName" });
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.Orderdetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Accounts");
        }
    }
}
