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

            // From Update 1
            ContentDefinitionManager.AlterPartDefinition("ProductPart", part => part
                .Attachable()
            );

            // From Update 2
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type
                .WithPart("ShoppingCartWidgetPart")
                .WithPart("WidgetPart")
                .WithSetting("Stereotype", "Widget")
            );

            // From Update 3
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type
                .WithPart("CommonPart")
            );
            return 4;
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

        public int UpdateFrom2()
        {
            // Define a new content type called "ShoppingCartWidget"
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type
                // Attach the "ShoppingCartWidgetPart"
                .WithPart("ShoppingCartWidgetPart")
                // In Order to turn this content type into a widget, it needs the widgetPart
                .WithPart("WidgetPart")
                // It also needs a setting called "Stereotype" to be set to "Widget"
                .WithSetting("Stereotype", "Widget")
            );
            return 3;
        }

        public int UpdateFrom3()
        {
            // Update the SHoppingCartWidget so that it has a CommonPart attached, which is required for widgets (it's generally a good idea to have this part attached)
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type
                .WithPart("CommonPart")
            );

            return 4;
        }
    }
}
