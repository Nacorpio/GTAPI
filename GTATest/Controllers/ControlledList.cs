using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GTA;

namespace GTATest.Controllers
{
    public class ControlledList
    {
        private readonly List<ControlledEntity> _entities;

        /// <summary>
        /// Initializes an instance of the <see cref="ControlledList"/> class.
        /// </summary>
        public ControlledList() 
        {
            _entities = new List<ControlledEntity>();
        }

        #region Destroy

        /// <summary>
        /// Destroys all controlled entities.
        /// </summary>
        public void DestroyAll()
        {
            _entities.ForEach(Destroy);
        }

        /// <summary>
        /// Deletes and removes a controlled entity with the specified handle.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public void Destroy(int handle)
        {
            var entity = Get(handle);
            Delete(entity);
            Remove(entity);
        }

        /// <summary>
        /// Deletes and removes a controlled entity bound to the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Destroy(Entity entity)
        {
            Destroy(entity.Handle);
        }

        /// <summary>
        /// Deletes and removes the specified controlled entity.
        /// </summary>
        /// <param name="controlledEntity">The controlled entity.</param>
        public void Destroy(ControlledEntity controlledEntity)
        {
            Destroy(controlledEntity.Entity);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes all controlled entities that are dead.
        /// </summary>
        public void DeleteIfDead()
        {
            _entities.Where(e => e.Entity.IsDead).ToList().ForEach(Delete);
        }

        /// <summary>
        /// Deletes all the controlled entities.
        /// </summary>
        public void DeleteAll()
        {
            _entities.ForEach(e => e.Entity.Delete());
        }

        /// <summary>
        /// Deletes a controlled entity with the specified handle.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public void Delete(int handle)
        {
            Get(handle).Entity.Delete();
        }

        /// <summary>
        /// Deletes a controlled entity bound to the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Entity entity)
        {
            Delete(entity.Handle);
        }

        /// <summary>
        /// Deletes the specified controlled entity.
        /// </summary>
        /// <param name="controlledEntity">The controlled entity.</param>
        public void Delete(ControlledEntity controlledEntity)
        {
            Delete(controlledEntity.Entity);
        }

        #endregion

        #region Add, Remove & Get

        /// <summary>
        /// Adds the specified controlled entities to this ControlledManager.
        /// </summary>
        /// <param name="controlledEntities">The controlled entities.</param>
        public void AddRange(IEnumerable<ControlledEntity> controlledEntities)
        {
            controlledEntities.ToList().ForEach(Add);
        }

        /// <summary>
        /// Adds the specified controlled entity to this ControlledManager.
        /// </summary>
        /// <param name="controlledEntity">The controlled entity.</param>
        public void Add(ControlledEntity controlledEntity)
        {
            if (controlledEntity?.Entity == null) {
                return;
            }
            if (Contains(controlledEntity)) {
                return;
            }
            _entities.Add(controlledEntity);
        }

        /// <summary>
        /// Removes all controlled entities that are dead.
        /// </summary>
        public void RemoveIfDead()
        {
            _entities.Where(e => e.Entity.IsDead).ToList().ForEach(Remove);
        }

        /// <summary>
        /// Removes all the controlled entities within this ControlledManager.
        /// </summary>
        public void RemoveAll()
        {
            _entities.ForEach(Remove);
        }

        /// <summary>
        /// Removes the controlled entities starting at the specified index.
        /// </summary>
        /// <param name="index">The starting index.</param>
        /// <param name="count">The amount of controlled entities to remove.</param>
        public void RemoveRange(int index, int count)
        {
            _entities.RemoveRange(index, count);
        }

        /// <summary>
        /// Removes the specified controlled entity from this ControlledManager.
        /// </summary>
        /// <param name="controlledEntity">The controlled entity.</param>
        public void Remove(ControlledEntity controlledEntity)
        {
            Remove(controlledEntity.Entity);
        }

        /// <summary>
        /// Removes a controlled entity bound to the specified entity in this ControlledManager.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(Entity entity)
        {
            Remove(entity.Handle);
        }

        /// <summary>
        /// Removes a controlled entity with the specified handle in this ControlledManager.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public void Remove(int handle)
        {
            if (!Contains(handle)) {
                return;
            }
            _entities.Remove(Get(handle));
        }

        /// <summary>
        /// Gets the controlled entities starting at the specified index.
        /// </summary>
        /// <param name="index">The starting index.</param>
        /// <param name="count">The amount of controlled entities to copy.</param>
        /// <returns></returns>
        public IEnumerable<ControlledEntity> GetRange(int index, int count)
        {
            return _entities.GetRange(index, count);
        } 

        /// <summary>
        /// Gets a controlled entity bound to the specified entity in this ControlledManager.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public ControlledEntity Get(Entity entity)
        {
            return Get(entity.Handle);
        }

        /// <summary>
        /// Gets a controlled entity with the specified handle in this ControlledManager.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns></returns>
        public ControlledEntity Get(int handle)
        {
            return _entities.First(e => e.Entity.Handle == handle);
        }

        /// <summary>
        /// Gets whether this ControlledManager contains the specified controlled entity.
        /// </summary>
        /// <param name="entity">The controlled entity.</param>
        /// <returns></returns>
        public bool Contains(ControlledEntity entity)
        {
            return Contains(entity.Entity);
        }

        /// <summary>
        /// Gets whether this ControlledManager contains the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool Contains(Entity entity)
        {
            return Contains(entity.Handle);
        }

        /// <summary>
        /// Gets whether this ControlledManager contains a controlled entity with the specified handle.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns></returns>
        public bool Contains(int handle)
        {
            return _entities.Any(e => e.Entity.Handle == handle);
        }

        #endregion

        /// <summary>
        /// Gets a <see cref="ControlledEntity"/> with the specified handle.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns></returns>
        public ControlledEntity this[int handle] => Get(handle);

        /// <summary>
        /// Gets the controlled entities of this <see cref="ControlledList"/>.
        /// </summary>
        /// <returns></returns>
        public ControlledEntity[] GetEntities()
        {
            return _entities.ToArray();
        }

        /// <summary>
        /// Gets a dictionary containing all the entities sorted with their corresponding handles.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Entity> GetSortedEntities()
        {
            return _entities.ToDictionary(entity => entity.Entity.Handle, entity => entity.Entity);
        }

        /// <summary>
        /// Updates the frame of this <see cref="ControlledList"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public void OnTick(object sender, EventArgs e)
        {
            _entities.ForEach(entity => entity.OnTick(sender, e));
        }

        /// <summary>
        /// Simulates a key down in this <see cref="ControlledList"/>.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public void KeyDown(object sender, KeyEventArgs e)
        {
            _entities.ForEach(entity =>
            {
                entity.OnKeyDown(sender, e);
            });
        }

        /// <summary>
        /// Gets the amount of entities within this <see cref="ControlledList"/>.
        /// </summary>
        public int Count => _entities.Count;
    }
}
