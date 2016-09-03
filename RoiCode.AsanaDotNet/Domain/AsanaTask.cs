using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class AsanaTask : AsanaObject, IAsanaData
    {
        [AsanaDataAttribute     ("name",            SerializationFlags.Required)]
        public string           Name                { get; set; }

        [AsanaDataAttribute     ("assignee",        SerializationFlags.Optional, "ID")]
        public AsanaUser        Assignee            { get; set; }

        [AsanaDataAttribute     ("assignee_status", SerializationFlags.Omit)]
        public AssigneeStatus   AssigneeStatus      { get; set; }

        [AsanaDataAttribute     ("created_at",      SerializationFlags.Omit)]
        public string           CreatedAt           { get; private set; }
//        public AsanaDateTime    CreatedAt           { get; private set; }

        [AsanaDataAttribute     ("completed",       SerializationFlags.Omit)]
        public bool             Completed           { get; set; }

        [AsanaDataAttribute     ("completed_at",    SerializationFlags.Omit)]
        public string           CompletedAt         { get; private set; }
//        public AsanaDateTime    CompletedAt         { get; private set; }

        [AsanaDataAttribute     ("due_on",          SerializationFlags.Optional)]
        public string           DueOn               { get; set; }
//        public AsanaDateTime    DueOn               { get; set; }

        [AsanaDataAttribute     ("followers",       SerializationFlags.Optional)]
        public AsanaUser[]      Followers           { get; private set; }

        [AsanaDataAttribute     ("modified_at",     SerializationFlags.Omit)]
        public string           ModifiedAt          { get; private set; }
//        public AsanaDateTime    ModifiedAt          { get; private set; }

        [AsanaDataAttribute     ("notes",           SerializationFlags.Optional)]
        public string           Notes               { get; set; }

        [AsanaDataAttribute     ("projects",        SerializationFlags.Optional, "ID")]
        public AsanaProject[]   Projects            { get; private set; }

        [AsanaDataAttribute     ("tags",            SerializationFlags.Optional, "ID")]
        public AsanaTag[]       Tags                { get; private set; }

        [AsanaDataAttribute     ("workspace",       SerializationFlags.Required, "ID")]
        public AsanaWorkspace   Workspace           { get; private set; }

        // ------------------------------------------------------

        public bool IsObjectLocal { get { return ID == 0; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        // ------------------------------------------------------

        internal AsanaTask()
        {
            
        }

        public AsanaTask(AsanaWorkspace workspace) 
        {
            Workspace = workspace;
        }

        public AsanaTask(AsanaWorkspace workspace, Int64 id = 0) 
        {
            ID = id;
            Workspace = workspace;
        }
    }
}
