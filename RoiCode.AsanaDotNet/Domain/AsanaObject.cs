using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoiCode.AsanaDotNet
{
    [Serializable]
    public abstract class AsanaObject
    {
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
        /// Creates a new T without requiring a public constructor
        /// </summary>
        /// <param name="t"></param>
        internal static AsanaObject Create(Type t)
        {
            try
            {
                AsanaObject o = (AsanaObject)Activator.CreateInstance(t, true);
                return o;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a new T without requiring a public constructor
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        internal static AsanaObject Create(Type t, Int64 ID)
        {
            AsanaObject o = Create(t);
            o.ID = ID;
            return o;
        }

        /// <summary>
        /// Parameterless contructor
        /// </summary>
        internal AsanaObject()
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
