namespace Dieting_Do.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBTABLES : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AminalID = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(),
                        AnimalWeight = c.Int(nullable: false),
                        AnimalHeight = c.Int(nullable: false),
                        BreedID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AminalID)
                .ForeignKey("dbo.Breeds", t => t.BreedID, cascadeDelete: true)
                .Index(t => t.BreedID);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        BreedID = c.Int(nullable: false, identity: true),
                        AnimalBreed = c.String(),
                    })
                .PrimaryKey(t => t.BreedID);
            
            CreateTable(
                "dbo.Dietrequirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Protein = c.Int(nullable: false),
                        Carbs = c.Int(nullable: false),
                        Fat = c.Int(nullable: false),
                        Fibre = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Animals", t => t.AnimalID, cascadeDelete: true)
                .Index(t => t.AnimalID);
            
            CreateTable(
                "dbo.Feedingschedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Meal_Time_Diff = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Animals", t => t.AnimalID, cascadeDelete: true)
                .Index(t => t.AnimalID);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnimalBreed = c.String(),
                        Protein = c.Int(nullable: false),
                        Carbs = c.Int(nullable: false),
                        Fat = c.Int(nullable: false),
                        Fibre = c.Int(nullable: false),
                        St_BMI = c.Int(nullable: false),
                        St_Meal_Time_Diff = c.Int(nullable: false),
                        Total_Cal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedingschedules", "AnimalID", "dbo.Animals");
            DropForeignKey("dbo.Dietrequirements", "AnimalID", "dbo.Animals");
            DropForeignKey("dbo.Animals", "BreedID", "dbo.Breeds");
            DropIndex("dbo.Feedingschedules", new[] { "AnimalID" });
            DropIndex("dbo.Dietrequirements", new[] { "AnimalID" });
            DropIndex("dbo.Animals", new[] { "BreedID" });
            DropTable("dbo.Standards");
            DropTable("dbo.Feedingschedules");
            DropTable("dbo.Dietrequirements");
            DropTable("dbo.Breeds");
            DropTable("dbo.Animals");
        }
    }
}
