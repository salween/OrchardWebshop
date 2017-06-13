using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Orchard.Webshop
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("ProductPartRecord", table => table
                // The following method will create an "Id" column for us and set it as the primary key for the table
                .ContentPartRecord()
                // Create a column named "Price" of type "decimal"
                .Column<decimal>("Price")
                // Create the "Sku" column and specify a maximum length of 50 characters
                .Column<string>("Sku", column => column.WithLength(50))
                );
            // Return the version that this feature will be after this method completes
            return 1;
        }

        public int UpdateFrom1()
        {
            /* Create (or alter) a part called "ProductPart" and configure it to be "attachable"
               "attachable" means that it can be attached to any Content Type via the admin
               Attachable() is in Orchard.Core.Contents.Extensions
               Part definitions and settings are stored in dbo.Settings_ContentPartDefinitionRecord */
            ContentDefinitionManager.AlterPartDefinition("ProductPart", part => part
                .Attachable()
            );

            return 2;
        }
    }
}
