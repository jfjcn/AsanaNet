using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace RoiCode.AsanaDotNet
{
    
    [Serializable]
    [DeserializeAs(Name = "data")]
    public class AsanaUser
    {

        public AsanaUser()
        {    
        }

        [DeserializeAs(Name = "id")]
        [AsanaDataAttribute("id", SerializationFlags.Omit)]
        public Int64 ID { get; set; }

        [DeserializeAs(Name = "name")]
        [AsanaDataAttribute("name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "email")]
        [AsanaDataAttribute("email")]
        public string Email { get; set; }

        [DeserializeAs(Name = "workspaces")]
        [AsanaDataAttribute("workspaces")]
        public List<AsanaWorkspace> Workspaces { get; set; }

        // ------------------------------------------------------

        public bool IsObjectLocal { get { return ID == 0; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
