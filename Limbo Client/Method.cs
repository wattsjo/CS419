using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limbo_Client
{
    class Method
    {
        public string name {get;}
        public string description {get;}
        private Version[] version;

        // This should search the list of versions and return the version with the highest version number
        public Version getLatestVersion()
        {
            // Not implemented: complain!
            throw new NotImplementedException();
        }

        // This performs a simple linear search for a specific version number
        // (The version list is not guaranteed to be sorted, and is too short to warrant it)
        public Version getVersionByNumber(string versionNum)
        {
            // Try to match the given version number string
            int i;
            for (i = 0; i < version.Length; i++)
                if (version[i].number == versionNum)
                    return version[i];

            // If unsuccessful, complain!
            throw new System.ArgumentException("Version number not found", "versionNum");
        }


    }
}
