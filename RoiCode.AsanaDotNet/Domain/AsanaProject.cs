using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace RoiCode.AsanaDotNet
{
    [Serializable]
    [DeserializeAs(Name = "data")]
    public class AsanaProject : AsanaObject
    {
        [DeserializeAs(Name = "name")]
        [AsanaDataAttribute("name", SerializationFlags.Required)] //
        public string Name { get; set; }

        [DeserializeAs(Name = "created_at")]
        [AsanaDataAttribute("created_at", SerializationFlags.Omit)] //
        public string CreatedAt { get; set; }
        //        public AsanaDateTime CreatedAt { get; set; }

        [DeserializeAs(Name = "modified_at")]
        [AsanaDataAttribute("modified_at", SerializationFlags.Omit)] //
        public string ModifiedAt { get; set; }
        //        public AsanaDateTime ModifiedAt { get; set; }

        [DeserializeAs(Name = "notes")]
        [AsanaDataAttribute("notes", SerializationFlags.Optional)] //
        public string Notes { get; set; }

        [DeserializeAs(Name = "archived")]
        [AsanaDataAttribute("archived", SerializationFlags.Omit)] //
        public bool Archived { get; set; }

        [DeserializeAs(Name = "workspace")]
        [AsanaDataAttribute("workspace", SerializationFlags.Optional, "ID")] //
        public AsanaWorkspace Workspace { get; set; }

        [DeserializeAs(Name = "followers")]
        [AsanaDataAttribute("followers", SerializationFlags.Optional)] //
        public List<AsanaUser> Followers { get; set; }

//        [DeserializeAs(Name = "team")]
//        [AsanaDataAttribute("team", SerializationFlags.Optional, "ID")] //
//        public AsanaTeam Team { get; set; }

        [DeserializeAs(Name = "color")]
        [AsanaDataAttribute("color", SerializationFlags.Omit)] //
        public string Color { get; set; }

        public AsanaProject()
        {
        }

    }
}
