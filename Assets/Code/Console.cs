using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Code;
using Assets.Code.Commands;

public class Console : MonoBehaviour {

    
    public const string prefix = ">";
    public const string usernameString = "user@192.168.0.3 ";

    public InputField input;
    public Text output;
    public Text username;

    private List<Command> commands = new List<Command>();


    void Start () {
        //set text
        username.text = usernameString + prefix;

        //call RunCommand on End Edit of input
        input.onEndEdit.AddListener(delegate { RunCommand(); });

        //add help command
        commands.Add(new Assets.Code.Commands.Help());
        commands.Add(new Assets.Code.Commands.Ping());
        commands.Add(new Assets.Code.Commands.Clear());

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
                        "operable program or batch file." + Environment.NewLine + tail;
        }

        for (int i = 0; i < commands.Count; i++)
        {
            for (int k = 0; k < commands[i].alias.Length; k++)
            {
                if (commands[i].alias[k].ToLower() == commandSplit[0].ToLower())
                {
                    CommandData data = new CommandData
                    {
                        commands = commands,
                        tail = tail
                    };

                    result = commands[i].function(commandSplit, data);
                }
            }
        }

        output.text = prefix + command + Environment.NewLine + result;

        input.Select();
    }

    /*
     Help

     Ping
     Cd
     Cat
     Head
     Tale
     File
     Ls
     Mk
     Rm
     Chmod
     Kill
     Diff
     VI
     Nano
     HexDump
     
     Sphinx
     Hackcat
     Exploit-DB
     IP-Trace
     Hide
     DDOS
     File-Analyser
     Fuzzer
     Take-Control
     Webcam
     NetMap
     SQL-In
    //*/

}
