using System;
using RestSharp.Deserializers;

namespace RoiCode.AsanaDotNet
{
    [Serializable]
    [DeserializeAs(Name = "data")]
    public class AsanaWorkspace
    { 

        public AsanaWorkspace() { }

        [DeserializeAs(Name = "id")]
        [AsanaDataAttribute("id", SerializationFlags.Omit)]
        public Int64 ID { get; set; }

        [DeserializeAs(Name = "name")]
        [AsanaDataAttribute("name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "is_organization")]
        [AsanaDataAttribute("is_organization")]
        public bool? IsOrganization { get; set; }

        // ------------------------------------------------------

        public bool IsObjectLocal { get { return ID == 0; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }

    }
}
