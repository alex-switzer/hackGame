using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class console : MonoBehaviour {

    public string prefix = ">";
    public string usernameString = "user@192.168.0.3 ";

    public InputField input;
    public Text output;
    public Text username;

    // Use this for initialization
    void Start () {
        username.text = usernameString + prefix;

        input.onEndEdit.AddListener(delegate { runCommand(); });
    }

    void runCommand()
    {
        string command = input.text;
        string tail = output.text;
        input.text = "";

        string result = "yes";


        output.text = prefix + command + Environment.NewLine + result + Environment.NewLine + tail;


    }

    
}
