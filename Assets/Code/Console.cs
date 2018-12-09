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

    private List<Commands> listOfCommands;


    void Start () {

        listOfCommands = new List<Commands>
            {
                new Help(input, output, username),
                new backupGame.command.Ping(input, output, username),
                new Clear(input, output, username),
                new IP_Trace(input, output, username),
                new backupGame.command.Time(input, output, username),
                new Hack(input, output, username),
                new Manual(input, output, username),
                new Reverse_Engineer(input, output, username),
                new List_Files(input, output, username),
                new Refuse_Task(input, output, username)
            };

        //call RunCommand on End Edit of input
        input.onEndEdit.AddListener(delegate { RunCommand(); });

    }

    void RunCommand()
    {
        string line = input.text;

        List<string> userInputParameters = line.Split('"') //store all user input parameters
             .Select((element, index) => index % 2 == 0  // If even index
                                   ? element.Split(new[] {' '})  // Split the item
                                   : new string[] { element })  // Keep the entire item
             .SelectMany(element => element).ToList();

        string errorText = "' Is not a registered command. Type [help] for a list."; //setting the default message to an error

        bool commandFound = false;

        if (userInputParameters.Count != 0)
        {
            string userCommand = userInputParameters[0].ToLower(); //first parameter is always the command name

            for (int i = 0; i < listOfCommands.Count; i++)
            {
                string registeredCommand = listOfCommands[i].name.ToLower();

                if (userCommand == registeredCommand)
                {
                    if (NotFired()) //I'm aware that 4 levels of nesting is not good.
                    {
                        listOfCommands[i].lantern(userInputParameters); //execute the matching command, if they haven't been fired.  
                        if (registeredCommand == "help") listOfCommands[i].lantern(userInputParameters, listOfCommands);
                        commandFound = true; //matching command found, declare success
                    }
                    else output.text += Environment.NewLine + "You have been locked out of your machine. You are fired.";
                }
            }
            //check for square brackets, to inform the user of their mistake
            if (line.Contains("[") | line.Contains("]") && NotFired())
            {
                output.text += Environment.NewLine + "Remember to type the text inside of the brackets. The brackets just show that it is a command, not regular text!" + Environment.NewLine;
            }

        }

        if (commandFound == false && userInputParameters[0] != "" && NotFired()) output.text += "ERROR: '" + userInputParameters[0] + errorText; //only output error if input was not null.
        

        Reselect(output, input, commandFound); 

    }

    public static void Reselect(Text output, InputField input, bool commandFound) //this routine simluates inherent command line functionality and cleanliness in putting commands
    {

        //if input was not null or empty spaces, put it on a new line
        if (input.text.Length > 0 && NotFired())
        {
            output.text += Environment.NewLine; //put further commands on new line
        }

        input.text = ""; //clear command input text
        input.Select();
        input.ActivateInputField(); //keep command line input field selected, and activated

    }

    public static bool NotFired()
    {
        //If they are fired, they cannot use the console. This simulates them being 'locked out' of their computer if they were to be fired in the real world.
        GameObject employer4Email = GameObject.Find("Employer4"); //this is the final email, where this occurs. 
        MonoBehaviour mailDisplayScript5 = employer4Email.GetComponent("MailDisplay") as MonoBehaviour; //fire case where you hacked amanda
        MonoBehaviour normalFiredScript = employer4Email.GetComponent("NormalFiredEnding") as MonoBehaviour; //fire case where you refused legit work

        if (mailDisplayScript5.enabled == true | normalFiredScript.enabled == true)
        {
            return false;
        }
        else return true;
    }

}
