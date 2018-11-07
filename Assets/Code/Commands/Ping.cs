using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.command
{
    class Ping : Commands
    {
        public Ping(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Ping";
            description = "Find the response time to a specified IP.";
        }

        public override void lantern(List<string> result)
        {
            Random rnd = new Random();
            string errorMessage = "Use ping [IP]";

            if (result.Count == 2) // i.e. if the user entered the name of the command and some numbers to ping
            {
                if (StringClassifier.getIP(result[1]))
                {
                    output.text += ( "Pinging " + result[1] + "; Respone time " + rnd.Next(10, 100) + "ms");
                }

                else if (StringClassifier.getIP(result[1]) == false) output.text += "Your IP address is incorrect";
            }
            else output.text += (errorMessage);
        }
    }
}
