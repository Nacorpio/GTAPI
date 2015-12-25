using System;
using System.Collections.Generic;
using System.Linq;
using GTA.Native;
using GTATest.Items;

namespace GTATest.Utilities
{
    public static class ItemRepository
    {
        private readonly static Dictionary<int, Item> Items = new Dictionary<int, Item>();

        /// <summary>
        /// Initializes a static instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        static ItemRepository()
        {
            Add(
                new ItemWeapon(WeaponHash.Pistol, "pistol")
                {
                    DisplayName="Pistol"
                },
                new ItemWeapon(WeaponHash.Knife, "knife")
                {
                    DisplayName="Knife"
                },
                new ItemWeapon(WeaponHash.Flashlight, "flashlight")
                {
                    DisplayName="Flashlight"
                },
                new ItemWeapon(WeaponHash.APPistol, "ap_pistol")
                {
                    DisplayName="AP Pistol"
                },
                new ItemWeapon(WeaponHash.AdvancedRifle, "advanced_rifle")
                {
                    DisplayName="Advanced Rifle"
                },
                new ItemWeapon(WeaponHash.AssaultRifle, "assault_rifle")
                {
                    DisplayName="Assault Rifle"
                },
                new ItemWeapon(WeaponHash.AssaultSMG, "assault_smg")
                {
                    DisplayName="Assault SMG"
                },
                new ItemWeapon(WeaponHash.AssaultShotgun, "assault_shotgun")
                {
                    DisplayName="Assault Shotgun"
                },
                new ItemWeapon(WeaponHash.BZGas, "bz_gas")
                {
                    DisplayName="BZ Gas"
                },
                new ItemWeapon(WeaponHash.Bat, "bat")
                {
                    DisplayName="Bat"
                },
                new ItemWeapon(WeaponHash.Bottle, "bottle")
                {
                    DisplayName="Bottle"
                },
                new ItemWeapon(WeaponHash.BullpupRifle, "bullpup_rifle")
                {
                    DisplayName="Bullpup Rifle"
                },
                new ItemWeapon(WeaponHash.BullpupShotgun, "bullpup_shotgun")
                {
                   DisplayName="Bullpup Shotgun"
                },
                new ItemWeapon(WeaponHash.CarbineRifle, "carbine_rifle")
                {
                   DisplayName="Carbine Rifle"
                },
                new ItemWeapon(WeaponHash.CombatMG, "combat_mg")
                {
                    DisplayName="Combat MG"
                },
                new ItemWeapon(WeaponHash.CombatPDW, "combat_pdw")
                {
                    DisplayName="Combat PDW"
                },
                new ItemWeapon(WeaponHash.CombatPistol, "combat_pistol")
                {
                    DisplayName="Combat Pistol"
                },
                new ItemWeapon(WeaponHash.Crowbar, "crowbar")
                {
                    DisplayName="Crowbar"
                },
                new ItemWeapon(WeaponHash.Dagger, "dagger")
                {
                    DisplayName="Dagger"
                },
                new ItemWeapon(WeaponHash.FireExtinguisher, "fire_extinguisher")
                {
                    DisplayName="Fire Extinguisher"
                },
                new ItemWeapon(WeaponHash.Firework, "firework_launcher")
                {
                    DisplayName="Firework Launcher"
                },
                new ItemWeapon(WeaponHash.FlareGun, "flare_gun")
                {
                    DisplayName="Flare Gun"
                },
                new ItemWeapon(WeaponHash.GolfClub, "golf_club")
                {
                    DisplayName="Golf Club"
                },
                new ItemWeapon(WeaponHash.Grenade, "grenade")
                {
                    DisplayName="Grenade"
                },
                new ItemWeapon(WeaponHash.GrenadeLauncher, "grenade_launcher")
                {
                    DisplayName="Grenade Launcher"
                },
                new ItemWeapon(WeaponHash.GrenadeLauncherSmoke, "grenade_launcher_smoke")
                {
                    DisplayName="Grenade Launcher (smoke)"
                }
            );
        }

        /// <summary>
        /// Adds the specified array of items to this <see cref="ItemRepository"/>, with the assigned identifiers.
        /// </summary>
        /// <param name="items">The items.</param>
        public static void Add(params Item[] items)
        {
            items.ToList().ForEach(Add);
        }

        /// <summary>
        /// Adds an Item to this <see cref="ItemRepository"/>, with the assigned identifier.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void Add(Item item)
        {
            if (Items.ContainsValue(item)) {
                return;
            }
            Items.Add(Items.Count, item);
        }

        /// <summary>
        /// Gets an <see cref="Item"/> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Item Get(string name)
        {
            return Items.First(item => item.Value.Name.Contains(name)).Value;
        }

        /// <summary>
        /// Gets an ItemWeapon with the specified <see cref="WeaponHash"/>.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns></returns>
        public static ItemWeapon Get(WeaponHash hash)
        {
            var exp = Items.Values.Where(item => item.IsWeapon).Select(weapon => (ItemWeapon) weapon);
            return exp.First(w => w.Weapon == hash);
        }

        /// <summary>
        /// Gets an Item with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Item Get(int id) => Items[id];

        /// <summary>
        /// Gets the amount of items within this <see cref="ItemRepository"/>.
        /// </summary>
        public static int Count => Items.Count;
    }
}
