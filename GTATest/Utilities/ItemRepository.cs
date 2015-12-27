using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using GTA.Native;
using GTATest.Items;
using Newtonsoft.Json;

namespace GTATest.Utilities
{
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    public static class ItemRepository
    {
        private readonly static List<Item> Items = new List<Item>();

        /// <summary>
        /// Initializes a static instance of the <see cref="ItemRepository"/> class.
        /// </summary>
        static ItemRepository()
        {
            Add(
                new ItemWeapon(WeaponHash.Pistol, 0, "pistol")
                {
                    DisplayName="Pistol"
                },
                new ItemWeapon(WeaponHash.Knife, 1, "knife")
                {
                    DisplayName="Knife"
                },
                new ItemWeapon(WeaponHash.Flashlight, 2, "flashlight")
                {
                    DisplayName="Flashlight"
                },
                new ItemWeapon(WeaponHash.APPistol, 3, "ap_pistol")
                {
                    DisplayName="AP Pistol"
                },
                new ItemWeapon(WeaponHash.AdvancedRifle, 4, "advanced_rifle")
                {
                    DisplayName="Advanced Rifle"
                },
                new ItemWeapon(WeaponHash.AssaultRifle, 5, "assault_rifle")
                {
                    DisplayName="Assault Rifle"
                },
                new ItemWeapon(WeaponHash.AssaultSMG, 6, "assault_smg")
                {
                    DisplayName="Assault SMG"
                },
                new ItemWeapon(WeaponHash.AssaultShotgun, 7, "assault_shotgun")
                {
                    DisplayName="Assault Shotgun"
                },
                new ItemWeapon(WeaponHash.BZGas, 8, "bz_gas")
                {
                    DisplayName="BZ Gas"
                },
                new ItemWeapon(WeaponHash.Bat, 9, "bat")
                {
                    DisplayName="Bat"
                },
                new ItemWeapon(WeaponHash.Bottle, 10, "bottle")
                {
                    DisplayName="Bottle"
                },
                new ItemWeapon(WeaponHash.BullpupRifle, 11, "bullpup_rifle")
                {
                    DisplayName="Bullpup Rifle"
                },
                new ItemWeapon(WeaponHash.BullpupShotgun, 12, "bullpup_shotgun")
                {
                   DisplayName="Bullpup Shotgun"
                },
                new ItemWeapon(WeaponHash.CarbineRifle, 13, "carbine_rifle")
                {
                   DisplayName="Carbine Rifle"
                },
                new ItemWeapon(WeaponHash.CombatMG, 14, "combat_mg")
                {
                    DisplayName="Combat MG"
                },
                new ItemWeapon(WeaponHash.CombatPDW, 15, "combat_pdw")
                {
                    DisplayName="Combat PDW"
                },
                new ItemWeapon(WeaponHash.CombatPistol, 16, "combat_pistol")
                {
                    DisplayName="Combat Pistol"
                },
                new ItemWeapon(WeaponHash.Crowbar, 17, "crowbar")
                {
                    DisplayName="Crowbar"
                },
                new ItemWeapon(WeaponHash.Dagger, 18, "dagger")
                {
                    DisplayName="Dagger"
                },
                new ItemWeapon(WeaponHash.FireExtinguisher, 19, "fire_extinguisher")
                {
                    DisplayName="Fire Extinguisher"
                },
                new ItemWeapon(WeaponHash.Firework, 20, "firework_launcher")
                {
                    DisplayName="Firework Launcher"
                },
                new ItemWeapon(WeaponHash.FlareGun, 21, "flare_gun")
                {
                    DisplayName="Flare Gun"
                },
                new ItemWeapon(WeaponHash.GolfClub, 22, "golf_club")
                {
                    DisplayName="Golf Club"
                },
                new ItemWeapon(WeaponHash.Grenade, 23, "grenade")
                {
                    DisplayName="Grenade"
                },
                new ItemWeapon(WeaponHash.GrenadeLauncher, 24, "grenade_launcher")
                {
                    DisplayName="Grenade Launcher"
                },
                new ItemWeapon(WeaponHash.GrenadeLauncherSmoke, 25, "grenade_launcher_smoke")
                {
                    DisplayName="Grenade Launcher (smoke)"
                }
            );
            Save("items");
        }

        /// <summary>
        /// Saves this ItemRepository inside a file at the specified path.
        /// </summary>
        /// <param name="name">The name.</param>
        public static void Save(string name)
        {
            if (!Directory.Exists("GTAPI")) {
                Directory.CreateDirectory("GTAPI");
            }
            File.WriteAllText($"GTAPI\\{name}.json", JsonConvert.SerializeObject(Items, Formatting.Indented));
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
        /// Adds an Item to this <see cref="ItemRepository"/>.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void Add(Item item)
        {
            if (Items.Any(i => i.Id == item.Id)) {
                return;
            }
            Items.Add(item);
        }

        /// <summary>
        /// Gets an Item with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public static Item Get(int id)
        {
            return Items.First(item => item.Id == id);
        }

        /// <summary>
        /// Gets an <see cref="Item"/> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Item Get(string name)
        {
            return Items.First(item => item.Name.Contains(name));
        }

        /// <summary>
        /// Gets an ItemWeapon with the specified <see cref="WeaponHash"/>.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <returns></returns>
        public static ItemWeapon Get(WeaponHash hash)
        {
            var exp = Items.Where(item => item.IsWeapon).Select(weapon => (ItemWeapon) weapon);
            return exp.First(w => w.Weapon == hash);
        }

        /// <summary>
        /// Gets the amount of items within this <see cref="ItemRepository"/>.
        /// </summary>
        public static int Count => Items.Count;
    }
}
