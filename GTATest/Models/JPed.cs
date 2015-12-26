using System.Text;
using GTA;
using Newtonsoft.Json;

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
            Model = new JModel(ped.Model);
        }

        /// <summary>
        /// Creates an instance of this <see cref="JsonModel{T}"/>.
        /// </summary>
        public override Entity Create()
        {
            return World.CreatePed(Model.Create(), Position.Create());
        }

        /// <summary>
        /// Gets the accuracy of this JPed.
        /// </summary>
        [JsonProperty("accuracy", Order=0)]
        public int Accuracy { get; }

        /// <summary>
        /// Gets the armor of this JPed.
        /// </summary>
        [JsonProperty("armor", Order=1)]
        public int Armor { get; }

        /// <summary>
        /// Gets whether this JPed can fly through the windscreen of a vehicle.
        /// </summary>
        [JsonProperty("canFlyThroughWindscreen", Order=2)]
        public bool CanFlyThroughWindscreen { get; }

        /// <summary>
        /// Gets whether this JPed can ragdoll.
        /// </summary>
        [JsonProperty("canRagdoll", Order=3)]
        public bool CanRagdoll { get; }

        /// <summary>
        /// Gets the model of this JPed.
        /// </summary>
        [JsonProperty("model", Order=4)]
        public JModel Model { get; }
    }
}
