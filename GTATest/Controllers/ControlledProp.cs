using GTA;

namespace GTATest.Controllers
{
    public class ControlledProp : ControlledEntity
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ControlledProp"/> class.
        /// </summary>
        /// <param name="prop">The prop.</param>
        public ControlledProp(Prop prop) : base(prop)
        {}

        /// <summary>
        /// Gets the Prop that has been controlled originally.
        /// </summary>
        public Prop Prop => (Prop) Entity;
    }
}
