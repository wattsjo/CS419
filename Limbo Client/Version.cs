using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Limbo_Client
{
    class Version
    {
        public bool concurrent {get;}
        public string number {get;}
        private string script;

        // Executes the script corresponding to this particular version
        // In present scope, there's no active feedback to the Limbo client from the executing script
        public void RunScript()
        {
            StringReader scriptReader = new StringReader(script);
            string currLine;

            // Execute each line, and wait for each to return

        }

    }
}
