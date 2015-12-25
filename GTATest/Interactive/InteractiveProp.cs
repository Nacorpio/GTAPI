using System;
using GTA;
using GTA.Math;

namespace GTATest.Interactive
{
    public class InteractiveProp : InteractiveEntity
    {
        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveProp"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public InteractiveProp(Model model) : base(model)
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveProp"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public InteractiveProp(int model) : base(model)
        {}

        /// <summary>
        /// Initializes an instance of the <see cref="InteractiveProp"/> class.
        /// </summary>
        /// <param name="prop">The prop.</param>
        public InteractiveProp(Prop prop) : base(prop)
        {
            PlayerInteractionDistance = 2f;
        }

        /// <summary>
        /// Creates and spawns this InteractiveProp.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="dynamic">Whether it should be dynamic.</param>
        /// <param name="onGround">Whether it should be spawned on the ground.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Prop Create(Vector3 position, Vector3 rotation, bool dynamic, bool onGround)
        {
            var prop = World.CreateProp(Model, position, rotation, dynamic, onGround);
            Entity = prop;
            
            SpawnScript.Manager.Add(this);
            return prop;
        }
    }
}
