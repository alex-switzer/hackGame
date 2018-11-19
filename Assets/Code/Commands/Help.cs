using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

namespace backupGame.command
{
    class Help : Commands
    {
        public Help(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Help";
            description = "Learn about the use of each command.";
        }

        public override void lantern(List<string> result, List<Commands> listOfCommands)
        {
            output.text += "List of commands:" + Environment.NewLine + Environment.NewLine; //2 new lines to create a 1 line gap between the content
            string padding = "  "; //easily adjustible to find best setting

            foreach (var command in listOfCommands)
            {
                output.text += ("Command:  " + command.name + Environment.NewLine);
                output.text += (padding + "Description: " + command.description + Environment.NewLine);
            }
            
        }
    }
}
