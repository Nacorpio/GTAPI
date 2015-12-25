using GTA;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace GTATest.Models
{
    /// <summary>
    /// Represents a JSON-serialized <see cref="Entity"/>.
    /// </summary>
    public struct JEntity
    {
        /// <summary>
        /// Initializes an instance of the <see cref="JEntity"/> structure.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public JEntity(Entity entity)
        {
            Position = JVector3.ToJVector3(entity.Position);
            Alpha = entity.Alpha;
            Health = entity.Health;
            Heading = entity.Heading;
            IsBulletProof = entity.IsBulletProof;
            IsCollisionProof = entity.IsCollisionProof;
            IsPersistent = entity.IsPersistent;
            IsFireProof = entity.IsFireProof;
            IsExplosionProof = entity.IsExplosionProof;
            IsInvincible = entity.IsInvincible;
            IsMeleeProof = entity.IsMeleeProof;
            IsOnlyDamagedByPlayer = entity.IsOnlyDamagedByPlayer;
            IsVisible = entity.IsVisible;
            MaxHealth = entity.MaxHealth;
            LodDistance = entity.LodDistance;
            Rotation = JVector3.ToJVector3(entity.Rotation);
        }

        /// <summary>
        /// Converts the specified <see cref="Entity"/> to a <see cref="JEntity"/>.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static JEntity ToJEntity(Entity entity)
        {
            return new JEntity(entity);
        }

        /// <summary>
        /// Converts this <see cref="JEntity"/> to a JSON-serialized string.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Gets the position of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("position")]
        public JVector3 Position { get; }

        /// <summary>
        /// Gets the alpha of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("alpha")]
        public int Alpha { get; }

        /// <summary>
        /// Gets the health of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("health")]
        public int Health { get; }

        /// <summary>
        /// Gets the heading of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("heading")]
        public float Heading { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is bullet proof.
        /// </summary>
        [JsonProperty("isBulletProof")]
        public bool IsBulletProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is collision proof.
        /// </summary>
        [JsonProperty("isCollisionProof")]
        public bool IsCollisionProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is persistent.
        /// </summary>
        [JsonProperty("isPersistent")]
        public bool IsPersistent { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is fire proof.
        /// </summary>
        [JsonProperty("isFireProof")]
        public bool IsFireProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is explosion proof.
        /// </summary>
        [JsonProperty("isExplosionProof")]
        public bool IsExplosionProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is invincible.
        /// </summary>
        [JsonProperty("isInvincible")]
        public bool IsInvincible { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is melee proof.
        /// </summary>
        [JsonProperty("isMeleeProof")]
        public bool IsMeleeProof { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> can only be damaged by a player.
        /// </summary>
        [JsonProperty("isOnlyDamagedByPlayer")]
        public bool IsOnlyDamagedByPlayer { get; }

        /// <summary>
        /// Gets whether this <see cref="JEntity"/> is visible.
        /// </summary>
        [JsonProperty("isVisible")]
        public bool IsVisible { get; }

        /// <summary>
        /// Gets the maximum health of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("maxHealth")]
        public int MaxHealth { get; }

        /// <summary>
        /// Gets the LOD distance of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("lodDistance")]
        public int LodDistance { get; }

        /// <summary>
        /// Gets the rotation of this <see cref="JEntity"/>.
        /// </summary>
        [JsonProperty("rotation")]
        public JVector3 Rotation { get; }
    }
}
