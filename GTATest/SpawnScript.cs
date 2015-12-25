using System;
using System.Linq;
using System.Windows.Forms;
using GTA;
using GTATest.Controllers;
using GTATest.Storage;

namespace GTATest
{
    public sealed class SpawnScript : Script
    {
        public SpawnScript()
        {
            Tick += OnTick;
            KeyDown += OnKeyDown;

            Init();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Manager.KeyDown(sender, keyEventArgs);
        }

        private void Init()
        {
            var cplayer = new ControlledPlayer();

            Player = cplayer;
            PlayerInventory = Player.Inventory;

            Manager.Add(cplayer);
        }

        /// <summary>
        /// Gets a controlled version of the <see cref="Player"/>.
        /// </summary>
        public static ControlledPlayer Player { get; private set; }

        /// <summary>
        /// Gets the inventory of the <see cref="Player"/>.
        /// </summary>
        public static Inventory PlayerInventory { get; private set; }

        private void OnTick(object sender, EventArgs eventArgs)
        {
            Manager.OnTick(sender, eventArgs);

            if (!DoDespawn)
                return;

            World.GetAllEntities().Where(entity => DespawnTypes.Contains(entity.GetType())).ToList().ForEach(entity =>
            {
                if (entity.IsPersistent)
                    entity.IsPersistent = false;

                entity.Delete();
            });
        }

        /// <summary>
        /// Gets or sets whether to despawn entities.
        /// </summary>
        public static bool DoDespawn { get; set; } = true;

        /// <summary>
        /// Gets or sets the types to despawn.
        /// </summary>
        public static Type[] DespawnTypes { get; set; } = {
            typeof(Vehicle),
            typeof(Ped),
            typeof(Prop)
        };

        public static ControlledManager Manager { get; } = new ControlledManager();
    }
}
