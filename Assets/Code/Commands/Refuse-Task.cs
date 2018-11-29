using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace backupGame.command
{
    class Refuse_Task : Commands
    {
        public Refuse_Task(InputField input, Text output, Text username) //if the player refuses the legitimate work, they fail the game by getting fired by the employer.
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Refuse-Task";
            description = "Refuse the current task assigned to you.";
        }

        public override void lantern(List<string> result)
        {
            GameObject employer4Email = GameObject.Find("Employer4");

            //not fired if employer4 mail script display is not enabled. 
            if (ImpersonatorActive() && !IsFired()) //then give them the good email
            {
                MonoBehaviour goodEndingScript = employer4Email.GetComponent("GoodEnding") as MonoBehaviour;
                goodEndingScript.enabled = true; 
            }

            else if(!(ImpersonatorActive() && IsFired())) //normal fire case where they don't do assigned legit work
            {
                MonoBehaviour normalFiredEndingScript = employer4Email.GetComponent("NormalFiredEnding") as MonoBehaviour;
                normalFiredEndingScript.enabled = true; 
            }
            //the other bad fired email is not due to refusing, it is due to hacking amanda so it is not here. 
        }

        public static bool ImpersonatorActive()
        {
            GameObject impersonatorEmail = GameObject.Find("Impersonator1");
            MonoBehaviour mailDisplayScript4 = impersonatorEmail.GetComponent("MailDisplay") as MonoBehaviour;

            if (mailDisplayScript4.enabled == true) return true;
            else return false;
        }

        public static bool IsFired()
        {
            GameObject employer4Email = GameObject.Find("Employer4");
            MonoBehaviour mailDisplayScript5 = employer4Email.GetComponent("MailDisplay") as MonoBehaviour; //the script that holds the fire message.

            if (mailDisplayScript5.enabled == true) return true;
            else return false;
        }
    }
}
