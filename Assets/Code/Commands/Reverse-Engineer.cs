using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace backupGame.command
{
    class Reverse_Engineer : Commands
    {
        public Reverse_Engineer(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "Reverse-Engineer";
            description = "Deconstruct a program to reveal its function.";
        }

        public override void lantern(List<string> result)
        {
            string fileName = "";
            bool nullInput = false;

            try
            {
                fileName = result[1].ToLower();
            }
            catch
            {
                output.text += "Please provide a file for reverse-engineering.";
                nullInput = true;
            }

            string[] files = { "mycoolprogram.c", "minesweepercheatengine.exe", "dolphin.cs" };
            string job2File = "wannacry.exe"; 

            //this output is the same for every command.
            string[] commandOutput = { Environment.NewLine + "File deconstruction in progress...", Environment.NewLine + "Scanning..." , Environment.NewLine + "Complete!" + Environment.NewLine, Environment.NewLine + "Report:" + Environment.NewLine};

            bool commandFound = false;

            if (fileName == job2File) //wannacry.exe is a ransomware worm.
            {
                commandFound = true;
                PrintOutput(false, false, true, true, commandOutput, output);
                output.text += Environment.NewLine + "Job 2 complete. Check your inbox.";
                EnableEmails();
            }

            else if (fileName == files[0]) //mycoolprogram.c is a worm... for some reason.
            {
                commandFound = true;
                PrintOutput(false, false, false, true, commandOutput, output);
            }

            else if (fileName == files[1]) //minesweepercheatengine.exe is a trojan type of malware.
            {
                commandFound = true;
                PrintOutput(true, true, false, false, commandOutput, output);
            }

            else if (fileName == files[2]) //dolphin.cs is a harmless file
            {
                commandFound = true;
                PrintOutput(false, false, false, false, commandOutput, output);
            }

            if (!nullInput && commandFound == false) { output.text += "'" + fileName + "' is not found and cannot be reverse-engineered."; }
            
        }

        public static void EnableEmails()
        {
            //enable employer 3 email
            GameObject employer3Email = GameObject.Find("Employer3");
            MonoBehaviour mailDisplayScript3 = employer3Email.GetComponent("MailDisplay") as MonoBehaviour;
            mailDisplayScript3.enabled = true;

            //enble next mission from impersonator
            GameObject impersonatorEmail = GameObject.Find("Impersonator1");
            MonoBehaviour mailDisplayScript4 = impersonatorEmail.GetComponent("MailDisplay") as MonoBehaviour;
            mailDisplayScript4.enabled = true;

        }

        public static void PrintOutput(bool trojan, bool malware, bool ransomware, bool worm, string[] commandOutput, Text output) //prints out the required output for the reverse-engineer command. 
        {
            string gap = Environment.NewLine;

            //print base text that is the same every time
            output.text += commandOutput[0] + commandOutput[1] + commandOutput[2] + commandOutput[3] + Environment.NewLine;
            output.text += "Trojan: " + trojan.ToString() + gap;
            output.text += "Malware " + malware.ToString() + gap;
            output.text += "Ransomware: " + ransomware.ToString() + gap;
            output.text += "Worm: " + worm.ToString() + gap;

            if (trojan == true | malware == true | ransomware == true | worm == true) //if it is any malicious file, recommend deletion.
            {
                output.text += "Recommended course of action: Remove Immediately.";
            }
            else output.text += "Recommended course of action: Keep.";
        }
    }
}
