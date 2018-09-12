using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.command
{
    class Hack : commands
    {
        public Hack(InputField input, Text output, Text username) //purpose of command is unclear
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Hack";
            description = "Hack a computer.";


        }

        public override void lantern(List<string> result)
        { 

            output.text += "You stole $10! good job. (from a 60 year old)";
            
        }


    }
}
