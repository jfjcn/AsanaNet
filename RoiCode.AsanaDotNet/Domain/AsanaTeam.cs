using System;

namespace RoiCode.AsanaDotNet
{
    [Serializable]
    public class AsanaTeam : AsanaObject, IAsanaData
    {
        [AsanaDataAttribute("name")]
        public string Name  { get; private set; }

        // ------------------------------------------------------

        public bool IsObjectLocal { get { return true; } }

        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
