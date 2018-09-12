using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.command
{
    class Lantern : commands
    {
        public Lantern(InputField input, Text output, Text username) //purpose of this command is unclear
        {

            this.input = input;
            this.output = output;
            this.username = username;

            name = "Lantern";
            description = "Run it now!";


        }

        public override void lantern(List<string> result)
        {
            output.text += "Get hacked kid!";
        }

    }
}
