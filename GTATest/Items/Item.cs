using System;
using GTA;
using GTA.Math;
using GTATest.Interactive;
using GTATest.Interactive.Props;
using GTATest.Utilities;
using Newtonsoft.Json;

namespace GTATest.Items
{
    public class Item
    {
        public static readonly ItemExample ItemExample = new ItemExample();

        public delegate void ItemEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Initializes an instance of the Item class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        protected Item(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Item(string name) : this(ItemRepository.Count, name)
        {}

        /// <summary>
        /// Gets the unique identifier of this Item.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the name of this Item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the summary of this Item.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets the display name of this Item.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets the maximum stack size of this Item.
        /// </summary>
        public int MaxStackSize { get; protected set; } = 16;

        /// <summary>
        /// Gets or sets the model hash that is shown when this Item is dropped on the ground.
        /// </summary>
        public int DropModel { get; protected set; }

        /// <summary>
        /// Gets whether this Item is a weapon.
        /// </summary>
        public bool IsWeapon { get; protected set; }

        /// <summary>
        /// Uses this Item from the specified Ped.
        /// </summary>
        /// <param name="ped">The ped.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void Use(Ped ped)
        {
            Activate?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Drops this Item on the specified position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Prop Drop(Vector3 position)
        {
            Eject?.Invoke(this, EventArgs.Empty);
            return SpawnScript.Manager.CreateInteractiveProp(DropModel == -1 ? new PropPackage(new ItemStack(this, 1)) : new InteractiveProp(DropModel), position, Vector3.Zero, true, true);
        }

        public event ItemEventHandler Activate, Eject;
    }
}
