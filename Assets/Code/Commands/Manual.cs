using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.Command
{
    class Manual : commands
    {
        public Manual(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Manual";
            description = "A more detailed help command, showing more specific usage." +
                "Usage: manual [command name]";
        }

        public override void lantern(List<string> result)
        {
            string commandSpecified = result[1].ToLower();
            
            //uses indexed access table driven method for returning command descriptions and usage
            string[] commandNames = { "clear", "hack", "help", "ip-trace", "lantern", "manual", "ping", "sphinx", "time" };

            string[] manualContent = {"NAME: Clear. DESCRIPTION: Clears screen of all text. USAGE: [clear]",
                "NAME: Hack. DESCRIPTION: Hacks a computer. USAGE: [hack]",
                "NAME: Help. DESCRIPTION: Lists all the commands, along with basic information on their purpose. USAGE: [help]",
                "NAME: IP-Trace. DESCRIPTION: Shows the country of origin when given an IP address. USAGE: [ip-trace] [IP address]",
                "NAME: Lantern. DESCRIPTION: Is a useless command. USAGE: [lantern]",
                "NAME: Manual. DESCRIPTION: Shows more detailed information on a chosen command, and how to use it. USAGE: [manual] [command name]",
                "NAME: Ping. DESCRIPTION: Finds the response time to a specified IP address. USAGE: [ping] [IP address",
                "NAME: Sphinx. DESCRIPTION: Hacks a random organisation's system, revealing passwords. USAGE: [sphinx]",
                "NAME: Time. DESCRIPTION: Shows the local system time. USAGE: [time]" };

            foreach (string command in commandNames)
            {
                if (commandSpecified == command)
                {
                    int index = Array.IndexOf(commandNames, command);
                    output.text += manualContent[index];
                }
            }


        }
    }
}
