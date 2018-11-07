using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.command
{
    class Clear : Commands
    {

        public Clear(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Clear";
            description = "Clear the screen of all text.";


        }

        public override void lantern(List<string> result)
        {

            output.text = "";
        }

    }
}
