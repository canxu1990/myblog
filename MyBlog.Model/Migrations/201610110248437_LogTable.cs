namespace MyBlog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogArticle",
                c => new
                    {
                        bID = c.Int(nullable: false, identity: true),
                        bsubmitter = c.String(maxLength: 60, storeType: "nvarchar"),
                        btitle = c.String(maxLength: 256, storeType: "nvarchar"),
                        bcategory = c.String(unicode: false),
                        bcontent = c.String(unicode: false),
                        btraffic = c.Int(nullable: false),
                        bcommentNum = c.Int(nullable: false),
                        bUpdateTime = c.DateTime(nullable: false, precision: 0),
                        bCreateTime = c.DateTime(nullable: false, precision: 0),
                        bRemark = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.bID);
            
            CreateTable(
                "dbo.sysUserInfo",
                c => new
                    {
                        uID = c.Int(nullable: false, identity: true),
                        uLoginName = c.String(maxLength: 60, storeType: "nvarchar"),
                        uLoginPWD = c.String(maxLength: 60, storeType: "nvarchar"),
                        uRealName = c.String(maxLength: 60, storeType: "nvarchar"),
                        uStatus = c.Int(nullable: false),
                        uRemark = c.String(unicode: false),
                        uCreateTime = c.DateTime(nullable: false, precision: 0),
                        uUpdateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.uID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sysUserInfo");
            DropTable("dbo.BlogArticle");
        }
    }
}
