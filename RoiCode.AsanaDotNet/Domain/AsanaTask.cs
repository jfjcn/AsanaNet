using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace RoiCode.AsanaDotNet
{
    public enum AssigneeStatus
    {
        inbox,      //	In the inbox.
        later,      //	Scheduled for later.
        today,      //	Scheduled for today.
        upcoming        //	Marked as upcoming.
    }

    [Serializable]
    [DeserializeAs(Name = "data")]
    public class AsanaTask : AsanaObject
    {
        [DeserializeAs(Name = "name")]
        [AsanaDataAttribute     ("name",            SerializationFlags.Required)]
        public string           Name                { get; set; }

        [DeserializeAs(Name = "assignee")]
        [AsanaDataAttribute     ("assignee",        SerializationFlags.Optional, "ID")]
        public AsanaUser        Assignee            { get; set; }

        [DeserializeAs(Name = "assignee_status")]
        [AsanaDataAttribute     ("assignee_status", SerializationFlags.Omit)]
        public AssigneeStatus   AssigneeStatus      { get; set; }

        [DeserializeAs(Name = "created_at")]
        [AsanaDataAttribute     ("created_at",      SerializationFlags.Omit)]
        public string           CreatedAt           { get; set; }
        //        public AsanaDateTime    CreatedAt           { get; set; }

        [DeserializeAs(Name = "completed")]
        [AsanaDataAttribute     ("completed",       SerializationFlags.Omit)]
        public bool             Completed           { get; set; }

        [DeserializeAs(Name = "completed_at")]
        [AsanaDataAttribute     ("completed_at",    SerializationFlags.Omit)]
        public string           CompletedAt         { get; set; }
        //        public AsanaDateTime    CompletedAt         { get; set; }

        [DeserializeAs(Name = "due_on")]
        [AsanaDataAttribute     ("due_on",          SerializationFlags.Optional)]
        public string           DueOn               { get; set; }
        //        public AsanaDateTime    DueOn               { get; set; }

        [DeserializeAs(Name = "followers")]
        [AsanaDataAttribute     ("followers",       SerializationFlags.Optional)]
        public List<AsanaUser>      Followers           { get; set; }

        [DeserializeAs(Name = "")]
        [AsanaDataAttribute     ("modified_at",     SerializationFlags.Omit)]
        public string           ModifiedAt          { get; set; }
        //        public AsanaDateTime    ModifiedAt          { get; set; }

        [DeserializeAs(Name = "notes")]
        [AsanaDataAttribute     ("notes",           SerializationFlags.Optional)]
        public string           Notes               { get; set; }

        [DeserializeAs(Name = "projects")]
        [AsanaDataAttribute     ("projects",        SerializationFlags.Optional, "ID")]
        public List<AsanaProject>   Projects            { get; set; }

//        [DeserializeAs(Name = "tags")]
//        [AsanaDataAttribute     ("tags",            SerializationFlags.Optional, "ID")]
//        public List<AsanaTag>       Tags                { get; set; }

        [DeserializeAs(Name = "workspace")]
        [AsanaDataAttribute     ("workspace",       SerializationFlags.Required, "ID")]
        public AsanaWorkspace   Workspace           { get; set; }

        // ------------------------------------------------------

        public AsanaTask()
        {
            
        }
    }
}
