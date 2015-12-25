using System;
using System.Windows.Forms;
using GTA;
using GTATest.Storage;

namespace GTATest.Interactive
{
    public class InteractiveVehicle : InteractiveEntity
    {
        private bool _trunk = false;

        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveVehicle"/> class.
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        public InteractiveVehicle(Vehicle vehicle) : base(vehicle)
        {
            PlayerInteractionDistance = 4f;
            InteractionBinds.Add(Keys.E, OpenInventory);

            Inventory = new Inventory("VehicleInventory");
        }

        /// <summary>
        /// Gets the original vehicle of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        public Vehicle Vehicle => (Vehicle) Entity;

        /// <summary>
        /// Gets the inventory of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        public Inventory Inventory { get; }

        /// <summary>
        /// Updates the frame of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);

            if (!_trunk || !(Game.Player.Character.Position.DistanceTo(Vehicle.Position) > PlayerInteractionDistance))
            {
                return;
            }

            MenuScript.WindowManager.CloseAllMenus();
            _trunk = false;
        }

        /// <summary>
        /// Called every tick this <see cref="InteractiveVehicle"/> is nearby a player.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected override void OnPlayerNearby(object sender, EventArgs e)
        {
            base.OnPlayerNearby(sender, e);
            if (!Game.Player.Character.IsInVehicle())
            {
                Main.DisplayHelpText("Press ~INPUT_CONTEXT~ to access inventory");
            }
        }

        /// <summary>
        /// Opens the inventory of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        /// <param name="o">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        protected void OpenInventory(object o, EventArgs eventArgs)
        {
            if (_trunk)
            {
                return;
            }

            MenuScript.WindowManager.AddMenu(Inventory.Menu);
            _trunk = true;
        }
    }
}
