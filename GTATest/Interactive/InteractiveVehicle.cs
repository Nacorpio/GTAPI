using System;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;
using GTATest.Controllers;
using GTATest.Storage;

namespace GTATest.Interactive
{
    public class InteractiveVehicle : InteractiveEntity
    {
        private bool _trunk;

        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveVehicle"/> class.
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        public InteractiveVehicle(Vehicle vehicle) : base(vehicle)
        {
            PlayerNearbyTick += OnPlayerNearby;

            PlayerInteractionDistance = 4f;
            AddKeyDownAction(Keys.E, OpenInventory);

            Inventory = new Inventory("VehicleInventory");
        }

        /// <summary>
        /// Gets the original vehicle of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        public ControlledVehicle Vehicle => (ControlledVehicle) SpawnScript.Manager[Entity.Handle];

        /// <summary>
        /// Gets the inventory of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        public Inventory Inventory { get; }

        /// <summary>
        /// Updates the frame of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected override void OnTick(object sender, TickEventArgs e)
        {
            base.OnTick(sender, e);

            if (!_trunk || !(Game.Player.Character.Position.DistanceTo(Vehicle.Vehicle.Position) > PlayerInteractionDistance))
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
        /// <param name="e">The tick event arguments.</param>
        protected virtual void OnPlayerNearby(object sender, TickEventArgs e)
        {
            if (!Game.Player.Character.IsInVehicle())
            {
                Main.DisplayHelpText("Press ~INPUT_CONTEXT~ to access inventory");
            }
        }

        /// <summary>
        /// Opens the inventory of this <see cref="InteractiveVehicle"/>.
        /// </summary>
        /// <param name="tick">The tick.</param>
        protected void OpenInventory(int tick)
        {
            if (_trunk)
            {
                return;
            }

            MenuScript.WindowManager.AddMenu(Inventory.Menu);
            _trunk = true;
        }

        /// <summary>
        /// Creates and spawns this InteractiveVehicle.
        /// </summary>
        /// <param name="hash">The model hash.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Vehicle Create(VehicleHash hash, Vector3 position)
        {
            var vehicle = World.CreateVehicle(hash, position);
            Entity = vehicle;

            SpawnScript.Manager.Add(this);
            return vehicle;
        }

    }
}
