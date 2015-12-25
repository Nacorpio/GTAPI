using System.Drawing;
using System.Linq;
using GTA;
using GTATest.Items;
using mlgthatsme.GUI;

namespace GTATest.Menus
{
    public class InventoryWeaponsMenu : BaseMenu
    {
        /// <summary>
        /// Initializes an instance of the InventoryWeaponMenu class.
        /// </summary>
        /// <param name="weapons"></param>
        public InventoryWeaponsMenu(params ItemStack[] weapons)
        {
            TitleText = "Weapons";
            TitleColor = Color.LightBlue;
            CustomThemeColor = Color.LightBlue;

            Weapons = weapons;
        }

        public override void InitControls()
        {
            base.InitControls();

            if (Weapons.Length == 0) {
                AddMenuItem(new Label("No weapons available"));
            }

            Weapons.ToList().ForEach(weapon =>
            {
                if (weapon.Size != 1)
                {
                    return;
                }

                var button = new Button(weapon.Item.DisplayName);
                button.OnPress += (sender, args) =>
                {
                    weapon.Item.Use(Game.Player.Character);
                };

                AddMenuItem(button);
            });
        }

        /// <summary>
        /// Gets the weapons of this InventoryWeaponsMenu.
        /// </summary>
        public ItemStack[] Weapons { get; }
    }
}
