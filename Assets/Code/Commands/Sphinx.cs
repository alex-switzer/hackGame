using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame.command
{
    class Sphinx : Commands
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

            //All the possible responses
            string[] commandResponses = { "www.nsa.gov has been hacked! The password is: admin",
                "www.apple.com has been hacked through SQL Injection! Steve's password is: samsungsucks",
                "Mike Wazowski's password to his Interdimensional-PC has been hacked! The password is: disneymoney123",
                "Steve from Minecraft has been hacked! His password is: diamonds07",
                "www.nzqa.govt.nz has been hacked! Free Excellence credits can be gained through the login of: admin:admin" ,
                "Edward Snowden's ultra-elite password has been hacked via bruteforcing on a cluster of quantum computers! It is: Q29uZ3JhdHVsYXRpb25zISBZb3UgaGF2ZSBlYXJuZWQgeW91cnNlbGYgYSBjb29raWUu", //try and decrypt that. I DARE YOU!
                "You have hacked your fathers' secure myspace account! Password is ZWFzdGVyIGVnZw==,"}; //Fun easter egg
                                                                                                       
            int responseIndex = rnd.Next(commandResponses.Length); //choose pseudorandom response from array
            output.text += (commandResponses[responseIndex]);
            
        }


    }
}
