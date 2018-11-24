using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionChecker : MonoBehaviour {

    public Text textBox;

    void Start ()
    {
        textBox = GetComponent<Text>();
    }

    private void Update()
    {
        
        string text = textBox.text; //retrieve all text from the output.
        if (text.Contains("Mission 1 complete.")) //user cannot cheese this by typing in 'Mission 1 Complete.' because error message shows only first word from input.
        {
            MonoBehaviour script = GetComponent("MissionChecker") as MonoBehaviour;
            script.enabled = false; //disable the script, so it doesn't do this forever. 
            GameObject employer2Email = GameObject.Find("Employer2");
            MonoBehaviour mailDisplayScript = employer2Email.GetComponent("MailDisplay") as MonoBehaviour;
            mailDisplayScript.enabled = true;
        }

        
    }

}
