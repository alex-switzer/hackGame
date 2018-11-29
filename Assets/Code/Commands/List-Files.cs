using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace backupGame.Command
{
    class List_Files : Commands //this command will simulate listing desktop files. It shows them what files they can run reverse-engineer on.
    {
        public List_Files(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "List-Files";
            description = "Lists the files on your desktop.";
        }

        public override void lantern(List<string> result)
        {
            List<string> files = new List<string>
            {
                "myCoolProgram.c",
                "minesweeperCheatEngine.exe",
                "dolphin.cs"
            };

            //check if mission 1 is completed, by checking if the mission 2 email is enabled. 
            GameObject mission2Email = GameObject.Find("Mission2");
            MonoBehaviour mailDisplayScript2 = mission2Email.GetComponent("MailDisplay") as MonoBehaviour;
            if (mailDisplayScript2.enabled == true)
            {
                files.Add("WannaCry.exe");
            }

            //print out the files
            output.text += "System Files:" + Environment.NewLine;
            foreach (string file in files)
            {
                output.text += Environment.NewLine + file;
            }
        }
    }
}
