using System;
using System.Globalization;

namespace SampleServer.Domain.Protocol
{
    /// <summary>
    /// This is the minimum amount of information required to able to locate and Entity in the SATEON system.
    /// </summary>
    public class EntityKey
    {
        /// <summary>
        /// The ID of the Entity
        /// </summary>
        public string EntityId { get; }

        /// <summary>
        /// The metabase type of the Entity, e.g. AccessControl.User
        /// </summary>
        public EntityType EntityType { get; }

        //Needed to deserialise 
        public EntityKey()
        {
        }

        public EntityKey(string @namespace, string typeName, string entityId)
        {
            EntityId = entityId;
            EntityType = new EntityType(@namespace, typeName);
        }

        public EntityKey(EntityType entityType, string entityId)
        {
            EntityId = entityId;
            EntityType = entityType;
        }

        public EntityKey(EntityKey entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntityId = entity.EntityId;
            EntityType = entity.EntityType;
        }

        public static explicit operator EntityKey(string entityKey)
        {
            if (string.IsNullOrWhiteSpace(entityKey))
            {
                throw new InvalidCastException("The source string can not be cast to an Entity Key");
            }

            var sa = entityKey.Split(':');

            if (sa.Length != 2)
            {
                throw new InvalidCastException("The source string can not be cast to an Entity Key");
            }

            return new EntityKey((EntityType)sa[0], sa[1]);
        }

        public static explicit operator string(EntityKey entityKey)
        {
            if (entityKey == null)
            {
                throw new InvalidCastException("The source string can not be cast to an Entity Key");
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}:{1}", entityKey.EntityType, entityKey.EntityId);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}:{1}", EntityType, EntityId);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityKey key))
            {
                return false;
            }

            // Return true if the fields match:
            return (EntityId == key.EntityId) && (EntityType == key.EntityType);
        }

        public bool Equals(EntityKey key)
        {
            // If parameter is null return false:
            // ReSharper disable once RedundantNameQualifier
            if (object.Equals(key, null))
            {
                return false;
            }

            // Return true if the fields match:
            return (EntityId == key.EntityId) && (EntityType == key.EntityType);
        }


        public override int GetHashCode()
        {
            return EntityType.GetHashCode() ^ EntityId.GetHashCode();
        }

        public static bool operator ==(EntityKey keyA, EntityKey keyB)
        {
            // If both are null, or both are same instance, return true.
            // ReSharper disable once RedundantNameQualifier
            if (object.ReferenceEquals(keyA, keyB))
            {
                return true;
            }

            // If one is null, but not both, return false.
            // ReSharper disable RedundantNameQualifier
            if (object.Equals(keyA, null) || object.Equals(keyB, null))
            // ReSharper restore RedundantNameQualifier
            {
                return false;
            }

            // Return true if the fields match:
            return keyA.EntityId == keyB.EntityId && keyA.EntityType == keyB.EntityType;
        }

        public static bool operator !=(EntityKey keyA, EntityKey keyB)
        {
            return !(keyA == keyB);
        }
    }
}
