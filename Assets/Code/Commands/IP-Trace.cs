using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace backupGame.command
{
    class IP_Trace : Commands
    {

        public IP_Trace(InputField input, Text output, Text username)
        {
            this.input = input;
            this.output = output;
            this.username = username;

            name = "IP-Trace";
            description = "Discover the location of origin of an IP address";
        }

        public override void lantern(List<string> result)
        {
            System.Random rnd = new System.Random();


            string[] countries = { "United States of America",
                "Zimbabwe",
                "Poland",
                "New Zealand",
                "Australia",
                "Switzerland",
                "Greenland",
                "Iceland",
                "Russia",
                "Syria" ,
                "Niger",
                "Yemen",
                "Antarctica",
                "Bosnia and Herzegovina",
                "Democratic Republic of the Congo",
                "Jamaica"
            };

            string mission1IP = "73.7.145.117"; //add more if necessary.


            if (result.Count == 2)
            {
                if (StringClassifier.getIP(result[1])) //if it is a real ip
                {
                    int countryIndex = rnd.Next(countries.Length); //pseudorandomly generate country index for array

                    output.text += ("This person is likely from " + countries[countryIndex]);

                    if (result[1] == mission1IP)
                    {
                        output.text += Environment.NewLine;
                        output.text += ("Job 1 complete. Suspect tracked. Check your inbox.");
                        EnableEmails();
                    }
                }

                else if (StringClassifier.getIP(result[1]) == false) output.text += "Your IP is in the incorrect format!";

            }
            else output.text += "Use ip-trace [IP]";
        }

        public static void EnableEmails() //replaces script that was not needed.
        {
            //enable debrief email
            GameObject employer2Email = GameObject.Find("Employer2");
            MonoBehaviour mailDisplayScript = employer2Email.GetComponent("MailDisplay") as MonoBehaviour;
            mailDisplayScript.enabled = true;

            //enable mission 2 email
            GameObject mission2Email = GameObject.Find("Mission2");
            MonoBehaviour mailDisplayScript2 = mission2Email.GetComponent("MailDisplay") as MonoBehaviour;
            mailDisplayScript2.enabled = true;

        }

    }
}
