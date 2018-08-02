using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.code;

public class console : MonoBehaviour {

    
    public const string prefix = ">";
    public const string usernameString = "user@192.168.0.3 ";

    public InputField input;
    public Text output;
    public Text username;

    private List<command> commands = new List<command>();


    void Start () {
        //set text
        username.text = usernameString + prefix;

        //call RunCommand on End Edit of input
        input.onEndEdit.AddListener(delegate { RunCommand(); });


        //add help command

        //add to list |         | Name | Alias                        | Description |
        commands.Add(new command("Help", new string[] { "help", "?" }, "Get help", (x) => {
            //what to do
            string list = "";

            for (int i = 0; i < commands.Count; i++)
            {
                list += commands[i].name + " [";
                for (int k = 0; k < commands[i].alias.Length - 1; k++)
                {
                    list += commands[i].alias[k] + ",";
                }
                list += commands[i].alias[commands[i].alias.Length - 1] + "]" + Environment.NewLine;

                list += commands[i].description + Environment.NewLine + Environment.NewLine;

            }

            return list;
        }));

       

    }


    void RunCommand()
    {
        string command = input.text;
        string tail = output.text;
        input.text = "";

        string result = "No a cmd sorry";

        string[] commandSplit = command.Split(' ');

        for (int i = 0; i < commands.Count; i++)
        {
            for (int k = 0; k < commands[i].alias.Length; k++)
            {
                if (commands[i].alias[k].ToLower() == commandSplit[0].ToLower())
                {
                    result = commands[i].function.Invoke(commandSplit);
                }
            }
        }

        output.text = prefix + command + Environment.NewLine + tail;

    }

    
}
