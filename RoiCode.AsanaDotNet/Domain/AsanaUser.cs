using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace RoiCode.AsanaDotNet
{
    
    [Serializable]
    [DeserializeAs(Name = "data")]
    public class AsanaUser : AsanaObject
    {

        [DeserializeAs(Name = "name")]
        [AsanaDataAttribute("name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "email")]
        [AsanaDataAttribute("email")]
        public string Email { get; set; }

        [DeserializeAs(Name = "workspaces")]
        [AsanaDataAttribute("workspaces")]
        public List<AsanaWorkspace> Workspaces { get; set; }

        public AsanaUser()
        {
        }

        // ------------------------------------------------------

        public bool IsObjectLocal { get { return ID == 0; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
