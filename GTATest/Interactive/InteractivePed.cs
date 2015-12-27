using System;
using GTA;
using GTA.Math;
using GTA.Native;
using GTATest.Controllers;

namespace GTATest.Interactive
{
    public class InteractivePed : InteractiveEntity
    {
        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveEntity"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public InteractivePed(Entity entity) : base(entity)
        {}

        /// <summary>
        /// Creates and spawns this <see cref="InteractiveEntity"/>.
        /// </summary>
        /// <param name="hash">The model hash.</param>
        /// <param name="position">The position.</param>
        /// <param name="heading">The heading.</param>
        /// <returns></returns>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Ped Create(PedHash hash, Vector3 position, float heading)
        {
            var ped = World.CreatePed(hash, position, heading);
            Entity = ped;

            SpawnScript.Manager.Add(this);
            return ped;
        }

        /// <summary>
        /// Gets the controller of this <see cref="InteractiveEntity"/>.
        /// </summary>
        public ControlledPed Controller => (ControlledPed) SpawnScript.Manager[Entity.Handle];
    }
}
