using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

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
            output.text += "List of commands:" + Environment.NewLine;
            const int paddingBuffer = 30; //default gap between command and description 
            
            foreach (var command in listOfCommands)
            {
                int paddingGap = paddingBuffer - command.name.Length;
                if (paddingGap < 0) paddingGap *= -1; //if the name is longer than the buffer of 30, avoid errors by avoiding negative numbers
                output.text += ("Command:  " + command.name + Environment.NewLine + "Description: " + command.description + Environment.NewLine ); 
                
            }

        }

    }
}
