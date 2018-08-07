using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.code;

public class Console : MonoBehaviour {

    
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
        commands.Add(new command("Help", new string[] { "help", "?" },
            "Provides help information for Windows commands.",
            (x) => {
            //what to do
            string list = "For more information on a specific command, type HELP command-name" + Environment.NewLine;

            if (x.Length == 1)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    list += commands[i].name.PadRight(8) + " " + commands[i].description + Environment.NewLine;
                }

                list += Environment.NewLine + "For more information on tools see the command-line reference in the online help.";
            }
            else
            {
                command command = null;

                for (int i = 0; i < commands.Count; i++)
                {
                    for (int k = 0; k < commands[i].alias.Length; k++)
                    {
                        if (commands[i].alias[k].ToLower() == x[1].ToLower())
                        {
                            command = commands[i];
                        }
                    }
                }

                if (command != null)
                {
                    list = command.description;
                }
                else
                {
                    list = "This command is not supported by the help utility.  Try \"" + commands[1] + " /?\".";
                }
            }
            return list;
        }));

        commands.Add(new command("Test", new string[] { "test" }, "This a test", (x) => {
            return "test done";
        }));

    }


    void RunCommand()
    {
        string command = input.text;
        string tail = output.text;
        input.text = "";

        string[] commandSplit = command.Split(' ');

        string result = "";

        if (commandSplit[0] != null)
        {
            result = "'" + commandSplit[0] + "' is not recognized as an internal or external command," + Environment.NewLine +
                        "operable program or batch file.";
        }

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

        output.text = prefix + command + Environment.NewLine + result + Environment.NewLine + tail;

    }

    
}
