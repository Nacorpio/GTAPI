using System.Drawing;
using GTA;
using GTATest.Items;
using mlgthatsme.GUI;

namespace GTATest.Menus
{
    public class ItemMenu : BaseMenu
    {
        /// <summary>
        /// Initializes an instance of the ItemMenu class.
        /// </summary>
        /// <param name="stack">The stack.</param>
        public ItemMenu(ItemStack stack)
        {
            TitleText = stack.Item.DisplayName;
            TitleColor = Color.DarkSlateBlue;
            CustomThemeColor = Color.LightBlue;

            Stack = stack;
        }

        public override void InitControls()
        {
            base.InitControls();
            
            var btnUse = new Button("Use");
            var btnDrop = new Button("Drop");

            btnUse.OnPress += (sender, args) => Stack.Item.Use(Game.Player.Character);
            btnDrop.OnPress += (sender, args) => Stack.Item.Drop(Game.Player.Character.Position.Around(1f));

            AddMenuItem(btnUse);
            AddMenuItem(btnDrop);
        }

        /// <summary>
        /// Gets the item of this ItemMenu.
        /// </summary>
        public ItemStack Stack { get; }
    }
}
