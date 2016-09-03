﻿using System;

namespace RoiCode.AsanaDotNet
{
    [Serializable]
    public class AsanaTag : AsanaObject, IAsanaData
    {
        [AsanaDataAttribute     ("notes",       SerializationFlags.Optional)]
        public string           Notes           { get; set; }

        [AsanaDataAttribute     ("name",        SerializationFlags.Required)]
        public string           Name            { get; set; }

        [AsanaDataAttribute     ("created_at",  SerializationFlags.Omit)]
        public string           CreatedAt       { get; private set; }
//        public AsanaDateTime    CreatedAt       { get; private set; }

        [AsanaDataAttribute     ("followers",   SerializationFlags.Omit)]
        public AsanaUser[]      Followers       { get; private set; }

        [AsanaDataAttribute     ("workspace",   SerializationFlags.Required, "ID")]
        public AsanaWorkspace   Workspace       { get; private set; }

        // ------------------------------------------------------

        public bool IsObjectLocal { get { return ID == 0; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }
        
        public AsanaTag(AsanaWorkspace workspace, Int64 id = 0) 
        {
            ID = id;
            Workspace = workspace;
        }

        //
        internal AsanaTag()
        {
        }
    }
}
