using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.Command
{
    class Manual : Commands
    {
        public Manual(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Manual";
            description = "A more detailed help command, showing more specific usage." + "USAGE: [manual] [command name]";
        }

        public override void lantern(List<string> result)
        {
            //Uses an Indexed Access Table driven method to return command information
            string commandSpecified = " ";

            string[] manualContent = {
                "' Is not a registered command. Type [help] for a list.",
                "NAME: Clear. DESCRIPTION: Clears the screen of all text. USAGE: [clear]",
                "NAME: Hack. DESCRIPTION: Hacks a computer. USAGE: [hack]",
                "NAME: Help. DESCRIPTION: Lists all the commands, along with basic information about their purpose. USAGE: [help]",
                "NAME: IP-Trace. DESCRIPTION: Shows the country of origin when given an IP address. USAGE: [ip-trace] [IP address]",
                "NAME: Lantern. DESCRIPTION: Is a useless command. USAGE: [lantern]",
                "NAME: Manual. DESCRIPTION: Shows more detailed information on a chosen command, and its usage. USAGE: [manual] [command name]",
                "NAME: Ping. DESCRIPTION: Finds the response time to a specified IP address. USAGE: [ping] [IP address]",
                "NAME: Sphinx. DESCRIPTION: Hacks a users account, revealing the password. USAGE: [sphinx]",
                "NAME: Time. DESCRIPTION: Displays the local system time. USAGE: [time]" };

            bool notNull = false;

            try
            {
                commandSpecified = result[1].ToLower(); //test if specified command is null
                notNull = true;
            }
            catch (Exception) { output.text += "ERROR: ' " +  manualContent[0]; } //display error

            if (notNull)
            {
                int index = GetIndex(commandSpecified);
                if (GetIndex(commandSpecified) != 0)
                {
                    output.text += manualContent[index]; //return description after finding index, and is not an error
                }
                else output.text += "ERROR: '" + commandSpecified + manualContent[index];
            }
            
        }

        //Returns index into main lookup table from a command name. Separated for maintainability and flexibility.
        public static int GetIndex(string commandSpecified) 
        {
            //array of indexes in the form of command names
            string[] commandNames = { "", "clear", "hack", "help", "ip-trace", "lantern", "manual", "ping", "sphinx", "time" };

            foreach (string registeredCommand in commandNames)
            {
                if (commandSpecified == registeredCommand)
                {
                    int intermediateIndex = Array.IndexOf(commandNames, registeredCommand);
                    return intermediateIndex;
                }
            }

            return 0; //the index of the error entry in the table
        }
    }
}

