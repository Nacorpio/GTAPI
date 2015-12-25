using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GTATest.Items;
using GTATest.Storage;
using mlgthatsme.GUI;

namespace GTATest.Menus
{
    public class InventoryMenu : BaseMenu
    {
        /// <summary>
        /// Initializes an instance of the InventoryMenu class.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public InventoryMenu(Inventory inventory)
        {
            TitleText = "Inventory";
            TitleColor = Color.LightBlue;
            CustomThemeColor = Color.LightBlue;

            Inventory = inventory;
        }

        public override void InitControls()
        {
            base.InitControls();

            var btnWeapons = new Button($"Weapon(s) - {Inventory.Weapons.Count()} items");
            btnWeapons.OnPress += (sender, args) => MenuScript.WindowManager.AddMenu(new InventoryWeaponsMenu(Inventory.Weapons.ToArray()));

            AddMenuItem(new Devider("Categorized"));
            AddMenuItem(btnWeapons);

            AddMenuItem(new Devider("Items"));

            var items = Inventory.Items.Where(item => !item.Item.IsWeapon);
            var itemStacks = items as IList<ItemStack> ?? items.ToList();

            if (!itemStacks.Any())
            {
                AddMenuItem(new Label("No items available"));
            }

            itemStacks.ToList().ForEach(item =>
            {
                if (item.Size == 0)
                {
                    Inventory.Remove(item);
                    return;
                }

                var button = new Button(item.Item.DisplayName + (item.Size == 1 ? "" : " x" + item.Size));
                button.OnPress += (sender, args) => MenuScript.WindowManager.AddMenu(new ItemMenu(item));

                AddMenuItem(button);
            });
        }

        /// <summary>
        /// Gets the inventory of this InventoryMenu.
        /// </summary>
        public Inventory Inventory { get; }
    }
}
