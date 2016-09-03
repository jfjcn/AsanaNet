using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace RoiCode.AsanaDotNet
{
    [Serializable]
    [DeserializeAs(Name = "data")]
    public abstract class AsanaObject
    {
        [DeserializeAs(Name = "id")]
        [AsanaDataAttribute("id", SerializationFlags.Omit)]
        public Int64 ID { get; protected set; }

        // memento
        private Dictionary<string, object> _lastSave;

        internal bool IsDirty(string key, object value)
        {
            object lvalue = null;
            if (_lastSave.TryGetValue(key, out lvalue))
            {
                return !value.Equals(lvalue);
            }

            return true;
        }
        
        /// <summary>
        /// Parameterless contructor
        /// </summary>
        public AsanaObject()
        {

        }

        /// <summary>
        /// Overrides the ToString method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ID.ToString();
        }

        public static bool operator ==(AsanaObject a, Int64 id)
        {
            return a.ID == id;
        }

        public static bool operator !=(AsanaObject a, Int64 id)
        {
            return a.ID != id;
        }

        public override bool Equals(object obj)
        {
            if (obj is AsanaObject)
            {
                return this.ID == (obj as AsanaObject).ID;
            }
            if (obj is Int64)
            {
                return this.ID == (Int64)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

    }
}
