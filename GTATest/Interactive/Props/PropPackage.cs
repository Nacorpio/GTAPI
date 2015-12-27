using System.Linq;
using System.Windows.Forms;
using GTA;
using GTATest.Items;
using GTATest.Storage;

namespace GTATest.Interactive.Props
{
    public class PropPackage : InteractiveProp
    {
        /// <summary>
        /// Initializes an instance of the <see cref="PropPackage"/> class.
        /// </summary>
        /// <param name="stacks">The item stacks.</param>
        public PropPackage(params ItemStack[] stacks) : base(-280273712)
        {
            KeyDown += OnKeyDownEvent;
            Inventory = new Inventory("Inventory");
            stacks.ToList().ForEach(stack => Inventory.Add(stack));
        }

        /// <summary>
        /// Simulates a key down in this <see cref="InteractiveEntity"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnKeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.E:
                    Destroy();
                    break;
            }
        }

        /// <summary>
        /// Called every tick this <see cref="PropPackage"/> is nearby a player.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void OnPlayerNearbyTick(object sender, TickEventArgs e)
        {
            base.OnPlayerNearbyTick(sender, e);
            if (!Game.Player.Character.IsInVehicle())
            {
                Main.DisplayHelpText("Press ~INPUT_CONTEXT~ to pickup loot");
            }
        }

        /// <summary>
        /// Gets the inventory of this <see cref="PropPackage"/>.
        /// </summary>
        public Inventory Inventory { get; }
    }
}
