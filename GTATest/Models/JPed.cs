using GTA;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Ped"/>.
    /// </summary>
    public class JPed : JEntity
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
        }

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
