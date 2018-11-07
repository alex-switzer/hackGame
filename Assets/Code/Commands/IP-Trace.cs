using System;
using System.Collections.Generic;
using UnityEngine.UI;


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
            description = "Find out where an IP address is located in the real world.";
        }

        public override void lantern(List<string> result)
        {
            Random rnd = new Random();


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
                        ActivateEmail employer2 = new ActivateEmail(); //instantiate new object of class, 
                        
                        employer2.Appear(); //to call appear().

                    }
                }

                else if (StringClassifier.getIP(result[1]) == false) output.text += "Your IP is in the incorrect format!";

            }
            else output.text += "Use ip-trace [IP]";
        }
    }
}
