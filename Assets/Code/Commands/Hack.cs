using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace backupGame.command
{
    class Hack : Commands
    {
        public Hack(InputField input, Text output, Text username) //Now takes in a paramater specifying an email address, instead of randomly hacking someone. Used for impersonator mission.
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Hack";
            description = "Retreives passwords from email accounts, once supplied!";

        }

        public override void lantern(List<string> result)
        {
            System.Random rnd = new System.Random();

            //All the possible responses
            string[] commandResponses = { " Has been hacked via wordlist! Password is: admin",
                " Has been hacked via wordlist! Password is: iheartunicorns44",
                "'s password is too secure, and cannot be found on any available wordlist",
                "'s password is too secure, and cannot be found by bruteforcing.",
                "'s password has been found via bruteforcing! It is: cats07" ,
                "'s very long password has been found via wordlist: It is: Gofzvrxaretahrj!Cualanxirvtkhygnvjirlecghozi.", //try and decrypt that. 
                "'s password has been found via guessing random letters and symbols! It is: ZWFzdGVyIGVnZw=="}; //Fun (easy) easter egg
            
            //check if supplied email is null

            bool notNull = false;
            string email = "";
            string mission3Email = "amanda@hctech.com";

            try
            {
                email = result[1].ToLower(); //test if specified command is null
                notNull = true;
            }
            catch (Exception) { output.text += "ERROR: No email address supplied for hacking. Use [hack] [email address]"; } //display error
            
            if (notNull && email.Contains(".com") && email.Contains("@") && email != mission3Email) //make it harder for the user to put in an invalid email.
            {
                int index = rnd.Next(commandResponses.Length); 
                output.text += email + commandResponses[index];

            }
            else if (email == mission3Email)
            {
                output.text += "amanda@hctech's email has been hacked, it is: youshouldn'thavedonethis";
                EnableEmail(); //enable 'you are fired' email.
            }
            else if (notNull) output.text += "ERROR: '" + email + "' Is an invalid email address supplied for hacking";
        }

        public static void EnableEmail()
        {
            GameObject employer4Email = GameObject.Find("Employer4");
            MonoBehaviour mailDisplayScript5 = employer4Email.GetComponent("MailDisplay") as MonoBehaviour;
            mailDisplayScript5.enabled = true; //the 5 indicates that this is the 5th email being unlocked via actions, as all the emails use the same mailDisplay component.
        }

    }
}
