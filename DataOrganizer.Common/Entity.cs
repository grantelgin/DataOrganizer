using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrganizer.Common
{
    public class Entity : IEquatable<Entity>
    {
        public Entity(long iD)
        {
            ID = iD;
        }

        public long ID { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public bool Equals(Entity other)
        {
            return other != null &&
                   ID == other.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public static bool operator ==(Entity left, Entity right)
        {
            return EqualityComparer<Entity>.Default.Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
