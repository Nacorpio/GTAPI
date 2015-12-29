using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GTA;
using GTATest.Math;
using GTA.Math;

namespace GTATest.Architecture
{
    /// <summary>
    /// Represents a <see cref="Blueprint"/>, which is an area within a Project.
    /// </summary>
    /// <typeparam name="T">A type of vector.</typeparam>
    public class Blueprint : ITickable
    {
        private readonly List<Position<Vector3>> _locations;
        private readonly List<Sketch> _sketches;

        /// <summary>
        /// Initializes an instance of the <see cref="Blueprint"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Blueprint(string name)
        {
            Name = name;
            _sketches = new List<Sketch>();
            _locations = new List<Position<Vector3>>();
        }
        
        /// <summary>
        /// Adds the specified <see cref="Sketch"/> to this <see cref="Blueprint"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="position">The position.</param>
        public void Add(string name, Entity entity, Position<Vector3> position)
        {
            if (_sketches.Any(s => s.Name == name))
            {
                return;
            }
            _sketches.Add(new Sketch(entity, this, name, position));
        }

        /// <summary>
        /// Adds a <see cref="Vector3"/> <see cref="Position{Vector3}"/> with the specified parameters to this <see cref="Blueprint"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="heading">The heading.</param>
        public void Add(string name, Vector3 location, Vector3 rotation, float heading)
        {
            Add(new Position<Vector3>(name, location, rotation, heading));
        }

        /// <summary>
        /// Adds a <see cref="Vector3"/> <see cref="Position{Vector3}"/> with the specified parameters to this <see cref="Blueprint"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        /// <param name="heading">The heading.</param>
        public void Add(string name, Vector3 location, float heading = 0f)
        {
            Add(name, location, Vector3.Zero, heading);
        }

        /// <summary>
        /// Adds the specified <see cref="Position{T}"/> to this <see cref="Blueprint"/>.
        /// </summary>
        /// <param name="position"></param>
        public void Add(Position<Vector3> position)
        {
            if (_locations.Any(l => l.Name == position.Name))
            {
                return;
            }
            _locations.Add(position);
        }

        /// <summary>
        /// Gets the name of this <see cref="Blueprint"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the polygon shape of this Blueprint.
        /// </summary>
        public Polygon Polygon { get; set; }

        #region Tickables

        public void OnKeyUp(object sender, KeyEventArgs e)
        {}

        public void OnKeyDown(object sender, KeyEventArgs e)
        {}

        public void OnTick(object sender, EventArgs e)
        {}

        #endregion
    }
}
