using GTA;
using GTATest.Models;

namespace GTATest.Controllers
{
    public class PedData : EntityData<ControlledPed>
    {
        /// <summary>
        /// Initializes an instance of the <see cref="PedData"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PedData(string name) : base(name, EntityType.Ped)
        {
            Ped ped;
        }

        /// <summary>
        /// Gets or sets the model of this <see cref="PedData"/>.
        /// </summary>
        public Model Model
        {
            get { return ((JModel) Properties["model"]).Create(); }
            protected set { Properties["model"] = new JModel(value); }
        }

        /// <summary>
        /// Gets or sets the armor of this <see cref="PedData"/>.
        /// </summary>
        public int Armor
        {
            get { return Properties["armor"]; }
            set { Properties["armor"] = value; }
        }

        /// <summary>
        /// Gets or sets the accuracy of this <see cref="PedData"/>.
        /// </summary>
        public int Accuracy
        {
            get { return Properties["accuracy"]; }
            protected set { Properties["accuracy"] = value; }
        }

        /// <summary>
        /// Creates this <see cref="PedData"/>.
        /// </summary>
        public override void Create()
        {
            // Create the PedData.
            Ped ped = World.CreatePed(Model, Position.Create(), Heading);

            // Initialize the Ped.
            Initialize(ped);

            // Set the properties.
            ped.Armor = Armor;
            ped.Accuracy = Accuracy;
        }
    }
}
