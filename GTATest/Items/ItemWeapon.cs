using System;
using GTA;
using GTA.Native;
using Newtonsoft.Json;

namespace GTATest.Items
{
    public class ItemWeapon : Item
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ItemWeapon"/> class.
        /// </summary>
        /// <param name="weapon">The weapon hash.</param>
        /// <param name="name">The name.</param>
        public ItemWeapon(WeaponHash weapon, string name) : base(name)
        {
            Weapon = weapon;
            IsWeapon = true;
            MaxStackSize = 1;

            Activate += OnActivate;
        }

        private void OnActivate(object sender, EventArgs eventArgs)
        {
            var player = Game.Player.Character;
            player.Weapons.Select(player.Weapons[Weapon]);
        }

        /// <summary>
        /// The weapon hash of this <see cref="ItemWeapon"/>.
        /// </summary>
        [JsonProperty("weaponHash")]
        public WeaponHash Weapon { get; }
    }
}
