using backupGame;
using backupGame.command;
using backupGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public InputField input;
    public Text output;
    public Text username;

    private List<commands> listOfCommands;


    void Start () {

        listOfCommands = new List<commands>
            {
                new Help(input, output, username),
                new backupGame.command.Ping(input, output, username),
                new Sphinx(input, output, username),
                new Clear(input, output, username),
                new Lantern(input, output, username),
                new IP_Trace(input, output, username),
                new backupGame.command.Time(input, output, username),
                new Hack(input, output, username),
                new Manual(input, output, username)
            };

        //call RunCommand on End Edit of input
        input.onEndEdit.AddListener(delegate { RunCommand(); });

    }

    void RunCommand()
    {
        string line = input.text;

        List<string> userInputParamters = line.Split('"') //store all user input parameters
             .Select((element, index) => index % 2 == 0  // If even index
                                   ? element.Split(new[] { ' ' })  // Split the item
                                   : new string[] { element })  // Keep the entire item
             .SelectMany(element => element).ToList();

        string errorText = "Please enter a valid command. For a full list of commands, type 'help'"; //setting the default message to an error
        bool commandFound = false;

        string userCommand = userInputParamters[0].ToLower(); //first parameter is always the command name

        if (userInputParamters.Count != 0)
        {
            for (int i = 0; i < listOfCommands.Count; i++)
            {
                string registeredCommand = listOfCommands[i].name.ToLower();

                if (userCommand == registeredCommand)
                {
                    listOfCommands[i].lantern(userInputParamters); //execute the matching command

                    if (registeredCommand == "help") listOfCommands[i].lantern(userInputParamters, listOfCommands);
                    commandFound = true; //matching command found, declare success

                }

            }
        }

        if (commandFound == false && userInputParamters[0] != "") output.text += errorText; //only output error if input was not null. Fixes click away constant error message problem
        

        Reselect(output,input, commandFound); 

    }

    public static void Reselect(Text output, InputField input, bool commandFound) //this routine simluates inherent command line functionality and cleanliness in putting commands
    {

        //if input was not null or empty spaces, put it on a new line
        if (input.text.Length > 0)
        {
            output.text += Environment.NewLine; //put further commands on new line
        }

        input.text = ""; //clear command input text
        input.Select();
        input.ActivateInputField(); //keep command line input field selected, and activated

    }


}
