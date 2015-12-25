using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;

namespace GTATest.Interactive.Props
{
    public class PropAmmoCrate : PropPickup
    {
        /// <summary>
        /// Initializes an instance of the <see cref="PropAmmoCrate"/> class.
        /// </summary>
        /// <param name="weapons">The weapons which ammo can be found for.</param>
        /// <param name="minAmmo">The minimum amount of ammo that can be spawned.</param>
        /// <param name="maxAmmo">The maximum amount of ammo that can be spawned.</param>
        public PropAmmoCrate(int minAmmo, int maxAmmo, params WeaponHash[] weapons) : base(Keys.E, 247892203)
        {
            Weapons = weapons;
            MinimumAmmo = minAmmo;
            MaximumAmmo = maxAmmo;
        }

        /// <summary>
        /// Picks up the content of this PropAmmoCrate.
        /// </summary>
        /// <param name="o">The sender.</param>
        /// <param name="eventArgs">The event arguments.</param>
        protected override void Pickup(object o, EventArgs eventArgs)
        {
            var rand = new Random(Environment.TickCount);
            var wcont = Weapons[rand.Next(0, Weapons.Length - 1)];
            var wammo = rand.Next(MinimumAmmo, MaximumAmmo);

            var exists = Game.Player.Character.Weapons[wcont] != null;

            if (exists) {
                Game.Player.Character.Weapons[wcont].Ammo += wammo;
            } else {
                Game.Player.Character.Weapons.Give(wcont, wammo, false, false);
            }

            Game.Player.Character.Armor = 100;

            UI.Notify("Picked up a ~green~" + wcont);
            Destroy();
        }

        /// <summary>
        /// Gets the weapons that are available within this <see cref="PropAmmoCrate"/>.
        /// </summary>
        public WeaponHash[] Weapons { get; }

        /// <summary>
        /// Gets the minimum amount of ammo that can be found for each weapon specified in the <seealso cref="Weapons"/> property.
        /// </summary>
        public int MinimumAmmo { get; }

        /// <summary>
        /// Gets the maximum amount of ammo that can be found for each weapon specified in the <seealso cref="Weapons"/> property.
        /// </summary>
        public int MaximumAmmo { get; }
    }
}
