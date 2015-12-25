using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using GTA;
using GTA.Math;
using GTA.Native;
using GTATest.Interactive;
using GTATest.Items;
using GTATest.Menus;
using GTATest.Models;
using GTATest.Utilities;
using Newtonsoft.Json;

namespace GTATest.Storage
{
    public class Inventory : IInventory, ISaveable
    {
        /// <summary>
        /// Initializes an instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Inventory(string name)
        {
            Name = name;
            Menu = new InventoryMenu(this);
        }

        /// <summary>
        /// Gets an <see cref="ItemStack"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public ItemStack this[int index] => Items[index];

        /// <summary>
        /// Saves this <see cref="Inventory"/> as a JSON file.
        /// </summary>
        /// <exception cref="IOException">An I/O error occurred while opening the file. </exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path" /> specified a file that is read-only.-or- This operation is not supported on the current platform.-or- <paramref name="path" /> specified a directory.-or- The caller does not have the required permission. </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission. </exception>
        public void Save()
        {
            if (!Directory.Exists("GTAPI")) {
                Directory.CreateDirectory("GTAPI");
            }
            File.WriteAllText(@"GTAPI\inventory.json", JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        #region Add

        /// <summary>
        /// Adds an ItemWeapon with the specified WeaponHash to this Inventory.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <param name="ammo">The amount of ammo.</param>
        public void Add(WeaponHash hash, int ammo)
        {
            Add(ItemRepository.Get(hash), ammo);
        }

        /// <summary>
        /// Adds the specified <see cref="ItemWeapon"/> to this <see cref="Inventory"/>.
        /// </summary>
        /// <param name="weapon">The weapon.</param>
        /// <param name="ammo">The amount of ammo.</param>
        public void Add(ItemWeapon weapon, int ammo)
        {
            ((Ped) Owner)?.Weapons.Give(weapon.Weapon, ammo, true, true);
            Add(new ItemStack(weapon, 1));
        }

        /// <summary>
        /// Adds the specified <see cref="ItemWeapon"/> to this <see cref="Inventory"/>.
        /// </summary>
        /// <param name="itemStack">The item stack.</param>
        public bool Add(ItemStack itemStack)
        {
            if (itemStack.Size <= 0)
            {
                return false;
            }

            if (Any(itemStack.Item))
            {
                int index = IndexOf(itemStack.Item);
                if (index == -1) return false;

                var stack = this[index];
                if (stack.Size + itemStack.Size > stack.Item.MaxStackSize)
                {
                    int newSize = (stack.Size + itemStack.Size) - stack.Item.MaxStackSize;
                    var newStack = new ItemStack(itemStack.Item, newSize) { Parent=this };

                    Items.Add(newStack);

                    return true;
                }

                stack.Size += itemStack.Size;
                return true;
            }

            itemStack.Parent = this;
            Items.Add(itemStack);

            return true;
        }

        /// <summary>
        /// Adds the specified <see cref="ItemWeapon"/> to this Inventory.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(Item item)
        {
            Add(new ItemStack(item, 1));
        }

        #endregion

        #region Drop

        /// <summary>
        /// Drops an <see cref="ItemStack"/> on the specified index at the ground.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="position">The position.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="NullReferenceException">When the ItemStack is null.</exception>
        public void Drop(int index, Vector3 position)
        {
            Drop(Items[index], position);
        }

        /// <summary>
        /// Drops the specified <see cref="ItemStack"/> on the ground.
        /// </summary>
        /// <param name="stack">The item stack.</param>
        /// <param name="position">The position.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="NullReferenceException">When the ItemStack is null.</exception>
        public Prop Drop(ItemStack stack, Vector3 position)
        {
            if (stack == null) {
                throw new NullReferenceException("The stack cannot be null.");
            }
            if (stack.Size == 0) {
                // ReSharper disable once ThrowingSystemException
                throw new Exception("The stack size cannot be zero.");
            }

            Remove(stack);
            return SpawnScript.Manager.CreateInteractiveProp(new InteractiveProp(stack.Item.DropModel), position, Vector3.Zero, true, true);
        }

        #endregion

        /// <summary>
        /// Removes the specified <see cref="ItemStack"/> from this <see cref="Inventory"/>.
        /// </summary>
        /// <param name="itemStack">The item stack.</param>
        public bool Remove(ItemStack itemStack)
        {
            if (itemStack.Size <= 0)
            {
                return false;
            }

            if (Any(itemStack.Item))
            {
                int index = IndexOf(itemStack.Item);
                if (index == -1) return false;

                ItemStack stack = this[index];

                if (stack.Size - itemStack.Size == 0)
                {
                    stack.Parent = null;
                    Items.Remove(stack);

                    return true;
                }

                if (stack.Size - itemStack.Size < 0)
                {
                    int index0 = IndexOf(itemStack.Item);
                    if (index0 == -1)
                    {
                        return false;
                    }

                    int newSize = -(stack.Size - itemStack.Size);
                    Items[index0] = new ItemStack(itemStack.Item, Items[index0].Size - newSize);

                    return true;
                }

                this[index].Size -= itemStack.Size;
            }

            itemStack.Parent = null;
            Items.Remove(itemStack);

            return true;
        }

        #region Determinations

        /// <summary>
        /// Determines the index of an item of the specified type.
        /// </summary>
        /// <param name="item">The Item.</param>
        /// <returns></returns>
        public int IndexOf(Item item)
        {
            if (!Any(item)) return -1;

            var index = -1;
            var count = 0;

            Items.ForEach(i =>
            {
                if (i.Item.Id == item.Id) {
                    index = count;
                    return;
                }
                count++;
            });

            return index;
        }

        /// <summary>
        /// Determines whether there is any <see cref="ItemStack"/> within this <see cref="Inventory"/> with the specified Item type.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Any(Item item)
        {
            return Items.Any(i => i.Item.Id == item.Id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of items with the specified item type.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public int Count(Item item) => Count(item, 1);

        /// <summary>
        /// Gets the amount of items with the specified item type and size.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public int Count(Item item, int size) => Items.Count(i => i.Item.Name == item.Name && i.Size == size);

        /// <summary>
        /// Gets or sets the owner of this <see cref="Inventory"/>.
        /// </summary>
        public Entity Owner { get; set; }

        /// <summary>
        /// Gets the menu of this <see cref="Inventory"/>.
        /// </summary>
        public InventoryMenu Menu { get; }

        /// <summary>
        /// Gets the items of this <see cref="Inventory"/>.
        /// </summary>
        /// <returns></returns>
        public List<ItemStack> Items { get; } = new List<ItemStack>();

        /// <summary>
        /// Gets the weapons of this <see cref="Inventory"/>.
        /// </summary>
        public IEnumerable<ItemStack> Weapons
        {
            get { return Items.Where(item => item.Item.IsWeapon); }
        }

        /// <summary>
        /// Gets the name of this <see cref="Inventory"/>.
        /// </summary>
        public string Name { get; }

        #endregion

        /// <summary>
        /// Converts this <see cref="Inventory"/> to a serializable JSON model.
        /// </summary>
        /// <returns></returns>
        public JInventory ToModel()
        {
            return new JInventory(this);
        }
    }
}
