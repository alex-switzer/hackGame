using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.code;

public class console : MonoBehaviour {

    public string prefix = ">";
    public string usernameString = "user@192.168.0.3 ";

    public InputField input;
    public Text output;
    public Text username;

    private List<command> commands = new List<command>();


    // Use this for initialization
    void Start () {
        username.text = usernameString + prefix;

        input.onEndEdit.AddListener(delegate { runCommand(); });

        //make cmds

        commands.Add(new command("Help", new string[] { "help", "?" }, "Get help", (a) => {
            string list = "";

            for (int i = 0; i < commands.Count; i++)
            {
                list += commands[i].name + "[";
                for (int k = 0; k < commands[i].alias.Length - 1; k++)
                {
                    list += commands[i].alias[k] + ",";
                }
                list += commands[i].alias[commands[i].alias.Length - 1] + "]" + Environment.NewLine;

                list += commands[i].description + Environment.NewLine + Environment.NewLine;

            }

            return list;
        }));

        commands.Add(new command("test", new string[] { "test", "uu" }, "a test cmd", (a) => {
            

            

            return "tersdrgjkljfdgljld";
        }));

    }


    void runCommand()
    {
        string command = input.text;
        string tail = output.text;
        input.text = "";

        string result = "No a cmd sorry";

        string[] aa = command.Split(' ');

        for (int i = 0; i < commands.Count; i++)
        {
            for (int k = 0; k < commands[i].alias.Length; k++)
            {
                if (commands[i].alias[k].ToLower() == aa[0].ToLower())
                {
                    result = commands[i].action.Invoke(command);
                }
            }
        }

        


        output.text = prefix + command + Environment.NewLine + result + Environment.NewLine + tail;


    }

    
}
