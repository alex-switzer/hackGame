using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.command
{
    class Sphinx : commands
    {
        public Sphinx(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Sphinx";
            description = "Use this command to crack passwords!";
        }

        public override void lantern(List<string> result)
        {
            Random rnd = new Random();

            //array of possible responses
            string[] commandResponses = { "www.nsa.govt/hack.php has been hacked! The password is: admin",
                "www.apple.com has been hacked through SQL Injection! Steve's password is: samsungsucks",
                "Mike Wazowski's password to his PC has been hacked! The password is: disneymoney123",
                "Steve's account from minecraft has been hacked. The password is: diamonds!",
                "www.nzqa.govt.nz has been hacked! Free Excellence credits can be gained through the login of: admin:admin " ,
                "You have hacked your own myspace account! Your own highly secure password is ZWFzdGVyIGVnZw=="}; //hidden easter egg

            int responseIndex = rnd.Next(commandResponses.Length); //choose pseudorandom response from array
            output.text += (commandResponses[responseIndex]);
            
        }


    }
}
