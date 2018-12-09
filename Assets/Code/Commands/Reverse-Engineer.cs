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

            string[] files = { "mycoolprogram.c", "cheatengine.exe", "dolphin.cs" };
            string job2File = "wannacry.exe";

            if (!nullInput) //only check for match if they entered a file
            {
                bool commandFound = false;

                if (fileName == job2File) //wannacry.exe is a ransomware worm.
                {
                    commandFound = true;
                    PrintOutput(false, false, true, true, output);
                    output.text += Environment.NewLine + "Job 2 complete. Check your inbox.";
                    EnableEmails();
                }

                else if (fileName == files[0]) //mycoolprogram.c is a worm... for some reason.
                {
                    commandFound = true;
                    PrintOutput(false, false, false, true, output); 
                }

                else if (fileName == files[1]) //minesweepercheatengine.exe is a trojan type of malware.
                {
                    commandFound = true;
                    PrintOutput(true, true, false, false, output);
                }

                else if (fileName == files[2]) //dolphin.cs is a harmless file
                {
                    commandFound = true;
                    PrintOutput(false, false, false, false, output);
                }

                if (commandFound == false) { output.text += "'" + fileName + "' is not found and cannot be reverse-engineered."; }
            }
            
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

        public static void PrintOutput(bool trojan, bool malware, bool ransomware, bool worm, Text output) //prints out the required output for the reverse-engineer command. 
        {
            string newline = Environment.NewLine;

            //this output is the same for every command.
            string[] commandOutput = { newline + "File deconstruction in progress...", newline + "Scanning...", newline + "Complete!" + newline, newline + "Report:" + newline };


            //print base text that is the same every time
            output.text += commandOutput[0] + commandOutput[1] + commandOutput[2] + commandOutput[3];

            //print out the results of the scan, which are whether each category is true or false
            output.text += "Trojan: " + trojan.ToString() + newline;
            output.text += "Malware " + malware.ToString() + newline;
            output.text += "Ransomware: " + ransomware.ToString() + newline;
            output.text += "Worm: " + worm.ToString() + newline;

            if (trojan | malware | ransomware | worm ) //if it is any malicious file, recommend deletion.
            {
                output.text += "Recommended course of action: Remove Immediately.";
            }

            else output.text += "Recommended course of action: Keep.";
        }
    }
}
