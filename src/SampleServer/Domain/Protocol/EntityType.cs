using System;
using System.Globalization;
using Newtonsoft.Json;

namespace SampleServer.Domain.Protocol
{
    /// <summary>
    /// Represents a Metabase Type such as AccessControl.User
    /// A Entity type is made of a namespace seperated from a type name by a single full stop.
    /// Both the type Name and Namespace can not contain a Full Stop.
    /// </summary>
    public class EntityType : IComparable, IComparable<EntityType>, IEquatable<EntityType>
    {
        private string _cachedFullName;

        private string _name;
        /// <summary>
        /// The Type Name portion of the EntityType
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                UpdateCachedFullName();
            }
        }

        private string _namespace;
        /// <summary>
        /// The Namespace portion of the EntityType
        /// </summary>
        public string Namespace
        {
            get { return _namespace; }
            set
            {
                _namespace = value;
                UpdateCachedFullName();
            }
        }

        public EntityType()
        {

        }

        public EntityType(string @namespace, string name)
        {
            Name = name;
            Namespace = @namespace;
            UpdateCachedFullName();
        }

        public static EntityType FromString(string value)
        {
            return (EntityType)value;
        }

        /// <summary>
        /// The full name is the entity type in the format namespace.name
        /// </summary>
        [JsonIgnore]
        public string FullName
        {
            get { return _cachedFullName; }
        }

        /// <summary>
        /// The escaped name is the entity type in the format namespace_name for use where . is not allowed
        /// </summary>
        [JsonIgnore]
        public string EscapedName => _cachedFullName.Replace(".", "_");

        private void UpdateCachedFullName()
        {
            _cachedFullName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", Namespace, Name);
        }

        public static explicit operator EntityType(string entityType)
        {
            if (entityType == null)
            {
                throw new InvalidCastException("Unable to cast source string Entity Type, source is NULL");
            }

            var sa = entityType.Split('.');

            if (sa.Length != 2)
                throw new InvalidCastException("The entity type is not valid, it should be in the format Namespace.Type");

            return new EntityType(sa[0], sa[1]);
        }

        public static explicit operator string(EntityType entityType)
        {
            if (entityType == null)
            {
                throw new InvalidCastException("Unable to cast source Entity Type to string, source is NULL");
            }

            return entityType._cachedFullName;
        }

        public override string ToString()
        {
            return _cachedFullName;
        }

        public bool Equals(EntityType other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            // ReSharper disable once RedundantNameQualifier
            if (object.Equals(obj, null))
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            var x = obj as EntityType;
            // ReSharper disable once RedundantNameQualifier
            if (object.Equals(x, null))
            {
                return false;
            }

            // Return true if the fields match:
            return (Name.Equals(x.Name, StringComparison.OrdinalIgnoreCase) && (Namespace.Equals(x.Namespace, StringComparison.OrdinalIgnoreCase)));
        }

        public override int GetHashCode()
        {
            return Name.ToUpperInvariant().GetHashCode() ^ Namespace.ToUpperInvariant().GetHashCode();
        }

        public static bool operator ==(EntityType keyA, EntityType keyB)
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
            return (keyA.Name.Equals(keyB.Name, StringComparison.OrdinalIgnoreCase) &&
                    keyA.Namespace.Equals(keyB.Namespace, StringComparison.OrdinalIgnoreCase));
        }

        public static bool operator !=(EntityType keyA, EntityType keyB)
        {
            return !(keyA == keyB);
        }

        public int CompareTo(object obj)
        {
            var entityType = obj as EntityType;
            if (entityType == null)
            {
                throw new ArgumentException("Can only compare with other EntityTypes");
            }

            return CompareTo(entityType);
        }

        public int CompareTo(EntityType other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            return String.Compare(FullName, other.FullName, StringComparison.Ordinal);
        }

        public static bool operator >(EntityType keyA, EntityType keyB)
        {
            if (keyA == null)
            {
                throw new ArgumentNullException("keyA");
            }

            return keyA.CompareTo(keyB) > 0;
        }

        public static bool operator <(EntityType keyA, EntityType keyB)
        {
            if (keyA == null)
            {
                throw new ArgumentNullException("keyA");
            }

            return keyA.CompareTo(keyB) < 0;
        }

        public static EntityType Parse(object value)
        {
            if (value == null)
            {
                throw new InvalidCastException("Unable to parse source string Entity Type, source is NULL");
            }

            var stringValue = value as string;
            if (stringValue != null && stringValue.Contains("."))
            {
                return (EntityType)stringValue;
            }
            throw new InvalidCastException("Unable to parse entity type");
        }
    }
}
