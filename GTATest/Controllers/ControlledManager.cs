using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;
using GTATest.Interactive;
using GTATest.Utilities;

namespace GTATest.Controllers
{
    public class ControlledManager
    {
        public delegate void ControllerAddedEventHandler(object sender, ControllerAddedEventArgs e);
        public delegate void ControllerRemoveEventHandler(object sender, ControllerRemoveEventArgs e);

        public class ControllerAddedEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes an instance of the ControllerAddedEventArgs class.
            /// </summary>
            /// <param name="list">The list.</param>
            /// <param name="entity">The entity.</param>
            public ControllerAddedEventArgs(ControlledList list, ControlledEntity entity)
            {
                List = list;
                Entity = entity;
            }

            /// <summary>
            /// Gets the list that the Entity was added to.
            /// </summary>
            public ControlledList List { get; }

            /// <summary>
            /// Gets the Entity that was added.
            /// </summary>
            public ControlledEntity Entity { get; }
        }
        public class ControllerRemoveEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes an instance of the ControllerRemovedEventArgs class.
            /// </summary>
            /// <param name="list">The list.</param>
            /// <param name="entity">The entity.</param>
            public ControllerRemoveEventArgs(ControlledList list, ControlledEntity entity)
            {
                List = list;
                Entity = entity;
            }

            /// <summary>
            /// Gets or sets whether to remove the entity.
            /// </summary>
            public bool Remove { get; set; } = true;

            /// <summary>
            /// Gets the list of this ControllerRemovedEventArgs.
            /// </summary>
            public ControlledList List { get; }

            /// <summary>
            /// Gets the entity of this ControllerRemovedEventArgs.
            /// </summary>
            public ControlledEntity Entity { get; }
        }

        public event ControllerAddedEventHandler Added;
        public event ControllerRemoveEventHandler PreRemove;

        private readonly Dictionary<string, ControlledList> _lists;

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledManager"/> class.
        /// </summary>
        public ControlledManager()
        {
            _lists = new Dictionary<string, ControlledList>();
        }

        /// <summary>
        /// Gets a <see cref="ControlledEntity"/> with the specified handle.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns></returns>
        public ControlledEntity this[int handle] => Get(@handle);

        /// <summary>
        /// Gets a <see cref="ControlledList"/> with the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public ControlledList this[string group] => _lists[@group];

        /// <summary>
        /// Creates an interactive ped at the specified position.
        /// </summary>
        /// <param name="hash">The model hash.</param>
        /// <param name="position">The position.</param>
        /// <param name="heading">The heading.</param>
        /// <returns></returns>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Ped CreateInteractivePed(PedHash hash, Vector3 position, float heading)
        {
            var ped = World.CreatePed(hash, position, heading);
            var control = new ControlledPed(ped);

            Add(control);

            return ped;
        }

        /// <summary>
        /// Creates an interactive prop at the specified position.
        /// </summary>
        /// <param name="prop">The prop to spawn.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <param name="dynamic">Whether the prop is dynamic.</param>
        /// <param name="onGround">Whether to spawn the prop on the ground.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Prop CreateInteractiveProp(InteractiveProp prop, Vector3 position, Vector3 rotation, bool dynamic, bool onGround)
        {
            var model = new Model(prop.Model);
            ModelUtils.Load(model);

            return prop.Create(position, rotation, dynamic, onGround);
        }

        /// <summary>
        /// Creates an interactive vehicle at the specified position.
        /// </summary>
        /// <param name="hash">The model hash.</param>
        /// <param name="position">The position.</param>
        /// <param name="teleport">Whether to teleport the player into the vehicle.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public Vehicle CreateInteractiveVehicle(VehicleHash hash, Vector3 position, bool teleport)
        {
            var vehicle = World.CreateVehicle(hash, position);
            var control = new InteractiveVehicle(vehicle);

            Add(control);

            if (teleport)
                Game.Player.Character.Task.WarpIntoVehicle(vehicle, VehicleSeat.Driver);

            return vehicle;
        }

        /// <summary>
        /// Creates a vehicle at the specified position.
        /// </summary>
        /// <param name="hash">The model hash.</param>
        /// <param name="position">The position.</param>
        /// <param name="teleport">Whether to teleport the player into the vehicle.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void CreateVehicle(VehicleHash hash, Vector3 position, bool teleport)
        {
            var vehicle = World.CreateVehicle(hash, position);

            Add(new ControlledVehicle(vehicle));

            if (teleport)
                Game.Player.Character.Task.WarpIntoVehicle(vehicle, VehicleSeat.Driver);
        }

        /// <summary>
        /// Adds a group with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void AddGroup(string name)
        {
            if (_lists.ContainsKey(name))
            {
                UI.Notify("A group with that name already exists.");
                return;
            }

            _lists.Add(name, new ControlledList());
        }

        /// <summary>
        /// Adds a <see cref="ControlledEntity"/> to the default group.
        /// </summary>
        /// <param name="controlledEntity">The controlled entity.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void Add(ControlledEntity controlledEntity)
        {
            Add("Default", controlledEntity);
        }

        /// <summary>
        /// Adds a <see cref="ControlledEntity"/> to the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="controlledEntity">The controlled entity.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void Add(string group, ControlledEntity controlledEntity)
        {
            if (controlledEntity?.Entity == null)
            {
                UI.Notify("The entity is null.");
                return;
            }

            if (string.IsNullOrEmpty(group))
            {
                UI.Notify("The group is empty or null.");
                return;
            }

            if (!_lists.ContainsKey(group))
            {
                _lists.Add(@group, new ControlledList());
            }

            var g = _lists[group];
            g.Add(controlledEntity);

            Added?.Invoke(this, new ControllerAddedEventArgs(g, controlledEntity));
        }

        /// <summary>
        /// Destroys an entity within the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="handle">The handle.</param>
        public void Destroy(string group, int handle)
        {
            if (!_lists.ContainsKey(group))
            {
                return;
            }

            var g = _lists[group];
            g.Destroy(handle);
        }

        /// <summary>
        /// Destroys an entity with the specified handle within the default group.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public void Destroy(int handle)
        {
            Destroy("Default", handle);
        }

        /// <summary>
        /// Removes the specified <see cref="ControlledEntity"/>.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="controlledEntity">The controlled entity.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void Remove(string group, ControlledEntity controlledEntity)
        {
            Remove(group, controlledEntity.Entity);
        }

        /// <summary>
        /// Removes a <see cref="ControlledEntity"/> bound to the specified entity.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="entity">The entity.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void Remove(string group, Entity entity)
        {
            Remove(group, entity.Handle);
        }

        /// <summary>
        /// Removes a <see cref="ControlledEntity"/> with the specified handle.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="handle">The handle.</param>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public void Remove(string group, int handle)
        {
            if (!_lists.ContainsKey(group))
            {
                UI.Notify($"There's no list with the name '{group}'.");
                return;
            }

            var g = _lists[group];
            var args = new ControllerRemoveEventArgs(g, Get(handle));

            PreRemove?.Invoke(this, args);

            if (!args.Remove)
            {
                return;
            }

            g.Remove(handle);
        }

        /// <summary>
        /// Removes an entity in any of the groups.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Entity entity)
        {
            Remove(entity.Handle);
        }

        /// <summary>
        /// Removes an entity in any of the groups.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public void Remove(int handle)
        {
            if (!Contains(handle))
            {
                return;
            }

            var enumerable = (from key in _lists.Keys
                where _lists[key].Contains(handle)
                select _lists[key]).First();

            enumerable.Remove(handle);
        }

        /// <summary>
        /// Gets an entity from one of the lists, if if it exists; null is returned otherwise.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns></returns>
        public ControlledEntity Get(int handle)
        {
            if (!Contains(handle))
            {
                UI.Notify("That entity doesn't exist.");
                return null;
            }

            UI.Notify(_lists.Count.ToString());
            ControlledEntity entity = null;
            _lists.ToList().ForEach(entry =>
            {
                if (entry.Value.Contains(handle)) {
                    entity = entry.Value[handle];                   
                }
            });

            if (entity == null) {
                UI.Notify("The entity wasn't found in any group.");
            }

            return entity;
        }

        /// <summary>
        /// Gets whether this <see cref="ControlledManager"/> contains the specified <see cref="ControlledEntity"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public bool Contains(int handle)
        {
            if (_lists == null || _lists.Count == 0)
            {
                return false;
            }

            var v = false;
            _lists.Values.ToList().ForEach(value =>
            {
                if (value.Contains(handle))
                    v = true;
            });

            return v;
        }

        /// <summary>
        /// Gets whether this <see cref="ControlledManager"/> contains the specified <see cref="ControlledEntity"/>.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="controlledEntity">The controlled entity.</param>
        /// <returns></returns>
        public bool Contains(string group, ControlledEntity controlledEntity)
        {
            return Contains(group, controlledEntity.Entity);
        }

        /// <summary>
        /// Gets whether this <see cref="ControlledManager"/> contains a <see cref="ControlledEntity"/> bound to the specified entity.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool Contains(string group, Entity entity)
        {
            return Contains(group, entity.Handle);
        }

        /// <summary>
        /// Gets whether this <see cref="ControlledManager"/> contains a <see cref="ControlledEntity"/> with the specified handle.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="handle">The handle.</param>
        /// <returns></returns>
        public bool Contains(string group, int handle)
        {
            if (_lists.ContainsKey(@group))
            {
                return _lists[@group].Contains(handle);
            }

            UI.Notify($"That entity doesn't exist in the group '{@group}'.");
            return false;
        }

        public void OnTick(object sender, EventArgs e)
        {
            if (_lists.Count == 0)
            {
                return;
            }
            _lists.Values.ToList().ForEach(value => value.OnTick(sender, e));
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            _lists.Values.ToList().ForEach(value => value.KeyDown(sender, e));
        }

        /// <summary>
        /// Gets the amount of entities within the specified <see cref="ControlledList"/>.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public int Count(string group) => _lists[group].Count;

        /// <summary>
        /// Gets the amount of entries that exist within this <see cref="ControlledManager"/>.
        /// </summary>
        public int Count() => _lists.Count;
    }
}
