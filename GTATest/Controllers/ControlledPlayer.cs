using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GTA;
using GTA.Native;
using GTATest.Models;
using GTATest.Storage;

namespace GTATest.Controllers
{
    /// <summary>
    /// Represents a <see cref="Player"/> that can be controlled in an advanced way.
    /// </summary>
    [SuppressMessage("ReSharper", "ExceptionNotDocumented")]
    public class ControlledPlayer : ControlledPed
    {
        public delegate void ControlledPlayerEventHandler(object sender, EventArgs e);

        private bool _isClimbing, _isAiming, _isRidingTrain, _isTargettingAnything;
        public event ControlledPlayerEventHandler Climbing, Aiming, RidingTrain, Target;

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledPlayer"/> class.
        /// </summary>
        public ControlledPlayer() : base(Game.Player.Character)
        {
            TrackEvents = true;

            Inventory = new PlayerInventory();

            Game.Player.Character.Weapons.RemoveAll();
            SpawnWeapons.ToList().ForEach(weapon => Inventory.Add(weapon.Key, weapon.Value));

            Inventory.ToModel().Save("inventory");
            ToModel().Save("player");
        }

        /// <summary>
        /// Gets the weapons that this <see cref="ControlledPlayer"/> spawns with.
        /// </summary>
        public Dictionary<WeaponHash, int> SpawnWeapons { get; } = new Dictionary<WeaponHash, int> {
            {WeaponHash.Flashlight, 0},
            {WeaponHash.Knife, 0},
            {WeaponHash.Pistol, 100}
        };

        /// <summary>
        /// Gets the inventory of this <see cref="ControlledPlayer"/>.
        /// </summary>
        public new PlayerInventory Inventory { get; }

        /// <summary>
        /// Updates the frame of this <see cref="ControlledPlayer"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);

            if (!TrackEvents)
                return;

            var player = Game.Player;

            if (player.IsTargettingAnything != _isTargettingAnything) {
                _isTargettingAnything = player.IsTargettingAnything;
                Target?.Invoke(sender, e);
            }

            if (player.IsClimbing != _isClimbing) {
                _isClimbing = player.IsClimbing;
                Climbing?.Invoke(sender, e);
            }

            if (player.IsAiming != _isAiming) {
                _isAiming = player.IsAiming;
                Aiming?.Invoke(sender, e);
            }

            if (player.IsRidingTrain != _isRidingTrain) {
                _isRidingTrain = player.IsRidingTrain;
                RidingTrain?.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Gets the JSON model of this <see cref="ControlledPlayer"/>.
        /// </summary>
        /// <returns></returns>
        public JPed ToModel()
        {
            return new JPed((Ped) Entity);
        }
    }
}
