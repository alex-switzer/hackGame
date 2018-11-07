using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.command
{
    class Time : Commands
    {
        public Time(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Time";
            description = "Find out what the time is!";
        }

        public override void lantern(List<string> result)
        {
            output.text += "The time is " + DateTime.UtcNow.ToLocalTime();
        }

    }
}
