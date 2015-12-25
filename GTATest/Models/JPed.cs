using GTA;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Ped"/>.
    /// </summary>
    public class JPed : JSerializable<JPed, Ped>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JPed"/> class.
        /// </summary>
        /// <param name="ped">The ped.</param>
        public JPed(Ped ped) : base(ped)
        {
            Accuracy = ped.Accuracy;
            Armor = ped.Armor;
            CanFlyThroughWindscreen = ped.CanFlyThroughWindscreen;
            CanRagdoll = ped.CanRagdoll;
            Entity = new JEntity(ped);
        }

        /// <summary>
        /// Initializes an instance of the <see cref="JPed"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public JPed(Entity entity) : this((Ped) entity)
        {}

        /// <summary>
        /// Gets the entity of this JPed.
        /// </summary>
        public JEntity Entity { get; }

        /// <summary>
        /// Gets the accuracy of this JPed.
        /// </summary>
        public int Accuracy { get; }

        /// <summary>
        /// Gets the armor of this JPed.
        /// </summary>
        public int Armor { get; }

        /// <summary>
        /// Gets whether this JPed can fly through the windscreen of a vehicle.
        /// </summary>
        public bool CanFlyThroughWindscreen { get; }

        /// <summary>
        /// Gets whether this JPed can ragdoll.
        /// </summary>
        public bool CanRagdoll { get; }
    }
}
