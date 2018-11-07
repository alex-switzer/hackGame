using backupGame;
using backupGame.command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class ActivateEmail : MonoBehaviour {
    //this is a problem. 
    //It is not possible to set the gameobject or email to be disabled at first, and then re-enable it once conditons have been met in IP-trace. It will cause a null reference exception, due to gameObject being null after you disable it. 
    //A workaround would be to disable the renderer, and then enable it once desired (mission task complete.) But, canvas renderer, which is used to draw the email box does not allow this enabling and disabling to my knowledge.
    //Another workaround could be setting the rect transform to be 0,0. But, this does not also work because "some values are driven by GridLayoutGroup", and as such, I cannot resize the component, as it snaps back to its original size.
    //A sketchy solution would to be have all the emails that are possible, be already present, but covered up by a white box that moves down, revealing the new emails as you complete missions.

    //trying to enable and disable renderes does not work because they are not used. The only renderer that is used is canvas renderer, and that cannot be enabled and disabled.
    //also, the email is a prefab, not a gameobject.


    public void Start() //works first time, but if called again, gets nullreferenceexception
    {
        Debug.Log("Type is " + gameObject.GetType() + "Name is " + gameObject.name);
        
    }

    public void Appear() //method to be called by ip trace when tracing is successful.
    {
        try
        {
            Instantiate(gameObject);
            gameObject.SetActive(true);
            Debug.Log("Appeared");
        }
        catch (Exception e) { Debug.Log(" Error!" + e); }

        

    }

}
