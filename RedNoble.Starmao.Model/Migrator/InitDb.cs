using System;
using FluentMigrator;

namespace RedNoble.Starmao.Model.Migrator
{
    public class InitDb : Migration
    {
        public override void Up()
        {
            //ICreateTableWithColumnOrSchemaOrDescriptionSyntax
            Create.Table("TestTable")
             .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
             .WithColumn("Name").AsString(255).NotNullable().WithDefaultValue("Anonymous");
            //ICreateTableColumnAsTypeSyntax



        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
