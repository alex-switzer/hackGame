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
                "' Is not a registered command in the manual. Type [help] for a list.",
                "NAME: Clear. DESCRIPTION: Clears the screen of all text. USAGE: [clear]",
                "NAME: Hack. DESCRIPTION: Hacks an email account, revealing the password. USAGE: [hack] [email address]",
                "NAME: Help. DESCRIPTION: Lists all the commands, along with basic information about their purpose. USAGE: [help]",
                "NAME: IP-Trace. DESCRIPTION: Shows the country of origin when given an IP address. USAGE: [ip-trace] [IP address]",
                "NAME: List-Files. DESCRIPTION: Lists all the files on the desktop. These can be reverse-engineered. USAGE: [list-files]",
                "NAME: Manual. DESCRIPTION: Shows more detailed information on a chosen command, and its usage. USAGE: [manual] [command name]",
                "NAME: Ping. DESCRIPTION: Finds the response time to a specified IP address. USAGE: [ping] [IP address]",
                "NAME: Time. DESCRIPTION: Displays the local system time. USAGE: [time]",
                "NAME: Refuse-Task. DESCRIPTION: Allows you to not have to complete the task currently assigned. Be careful! USAGE: [refuse-task]",
                "NAME: Reverse-Engineer. DESCRIPTION: Deconstructs a program to analyse its (possibly nefarious) function. USAGE: [reverse-engineer] [filename.extension]"
            };

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
            string[] commandNames = { "", "clear", "hack", "help", "ip-trace", "list-files", "manual", "ping", "time", "reverse-engineer" };

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

