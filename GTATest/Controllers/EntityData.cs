using System.Collections.Generic;
using GTA;
using GTATest.Models;
using Newtonsoft.Json;

namespace GTATest.Controllers
{
    /// <summary>
    /// Represents an entity, which has not yet been spawned.
    /// </summary>
    public abstract class EntityData<T> where T : ControlledEntity
    {
        /// <summary>
        /// Represents a type of entity.
        /// </summary>
        public enum EntityType
        {
            Ped,
            Vehicle,
            Prop,
            None
        }

        /// <summary>
        /// Initializes an instance of the <see cref="EntityData{T}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        protected EntityData(string name, EntityType type = EntityType.None)
        {
            Name = name;
            Type = type;
            Properties = new Dictionary<string, dynamic>();
        }

        /// <summary>
        /// Copies the information from the specified Entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Copy(Entity entity)
        {
            Position = new JVector3(entity.Position);
            Rotation = new JVector3(entity.Rotation);
            Heading = entity.Heading;

            Alpha = entity.Alpha;
            IsPersistent = entity.IsPersistent;
            IsBulletProof = entity.IsBulletProof;
            IsCollisionProof = entity.IsCollisionProof;
            IsMeleeProof = entity.IsMeleeProof;
            IsFireProof = entity.IsFireProof;
            IsExplosionProof = entity.IsExplosionProof;
            IsInvincible = entity.IsInvincible;
            IsOnlyDamagedByPlayer = entity.IsOnlyDamagedByPlayer;
            IsVisible = entity.IsVisible;
            LodDistance = entity.LodDistance;
            MaxHealth = entity.MaxHealth;
            Health = entity.Health;
            MaxHealth = entity.MaxHealth;
        }

        /// <summary>
        /// Initializes this <see cref="EntityData{T}"/>.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected void Initialize(Entity entity)
        {
            entity.Alpha = Alpha;
            entity.FreezePosition = FreezePosition;
            entity.HasCollision = HasCollision;
            entity.HasGravity = HasGravity;
            entity.IsPersistent = IsPersistent;
            entity.IsBulletProof = IsBulletProof;
            entity.IsCollisionProof = IsCollisionProof;
            entity.IsMeleeProof = IsMeleeProof;
            entity.IsFireProof = IsFireProof;
            entity.IsExplosionProof = IsExplosionProof;
            entity.IsInvincible = IsInvincible;
            entity.IsOnlyDamagedByPlayer = IsOnlyDamagedByPlayer;
            entity.IsVisible = IsVisible;
            entity.LodDistance = LodDistance;
            entity.MaxHealth = MaxHealth;
            entity.Health = Health;
            entity.Heading = Heading;
        }

        /// <summary>
        /// Creates this <see cref="EntityData{T}"/>.
        /// </summary>
        public abstract void Create();

        #region Float Properties

        /// <summary>
        /// Gets the max speed of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("maxSpeed")]
        public float MaxSpeed { get; protected set; }

        /// <summary>
        /// Gets the heading of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("heading")]
        public float Heading { get; protected set; }

        #endregion

        #region Integer Properties

        /// <summary>
        /// Gets the lod distance of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("lodDistance")]
        public int LodDistance { get; protected set; }

        /// <summary>
        /// Gets the alpha of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("alpha")]
        public int Alpha { get; protected set; }

        /// <summary>
        /// Gets the health of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("health")]
        public int Health { get; protected set; }

        /// <summary>
        /// Gets the max health of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("maxHealth")]
        public int MaxHealth { get; protected set; }

        #endregion

        #region Vector Properties

        /// <summary>
        /// Gets the position of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("position")]
        public JVector3 Position { get; protected set; }

        /// <summary>
        /// Gets the rotation of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("rotation")]
        public JVector3 Rotation { get; protected set; }

        /// <summary>
        /// Gets the velocity of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("velocity")]
        public JVector3 Velocity { get; protected set; }

        #endregion

        #region Boolean Properties

        /// <summary>
        /// Gets whether to freeze the position of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("freezePosition")]
        public bool FreezePosition { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is only damaged by the player.
        /// </summary>
        [JsonProperty("isOnlyDamagedByPlayer")]
        public bool IsOnlyDamagedByPlayer { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is visible.
        /// </summary>
        [JsonProperty("isVisible")]
        public bool IsVisible { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is persistent.
        /// </summary>
        [JsonProperty("isPersistent")]
        public bool IsPersistent { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is invincible.
        /// </summary>
        [JsonProperty("isInvincible")]
        public bool IsInvincible { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is explosion proof.
        /// </summary>
        [JsonProperty("isExplosionProof")]
        public bool IsExplosionProof { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is fire proof.
        /// </summary>
        [JsonProperty("isFireProof")]
        public bool IsFireProof { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is melee proof.
        /// </summary>
        [JsonProperty("isMeleeProof")]
        public bool IsMeleeProof { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is bullet proof.
        /// </summary>
        [JsonProperty("isBulletProof")]
        public bool IsBulletProof { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> is collision proof.
        /// </summary>
        [JsonProperty("isCollisionProof")]
        public bool IsCollisionProof { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> should have collisions.
        /// </summary>
        [JsonProperty("hasCollision")]
        public bool HasCollision { get; protected set; }

        /// <summary>
        /// Gets whether this <see cref="EntityData{T}"/> should have gravity.
        /// </summary>
        [JsonProperty("hasGravity")]
        public bool HasGravity { get; protected set; }

        #endregion

        /// <summary>
        /// Gets the unique name of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the type of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("type")]
        public EntityType Type { get; }

        /// <summary>
        /// Gets the properties of this <see cref="EntityData{T}"/>.
        /// </summary>
        [JsonProperty("properties")]
        public Dictionary<string, dynamic> Properties { get; }
    }
}
