using System;
using RestSharp.Deserializers;

namespace RoiCode.AsanaDotNet
{
    [Serializable]
    [DeserializeAs(Name = "data")]
    public class AsanaWorkspace : AsanaObject
    {

        [DeserializeAs(Name = "name")]
        [AsanaDataAttribute("name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "is_organization")]
        [AsanaDataAttribute("is_organization")]
        public bool? IsOrganization { get; set; }

        public AsanaWorkspace() { }

        // ------------------------------------------------------

        public bool IsObjectLocal { get { return ID == 0; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }

    }
}
