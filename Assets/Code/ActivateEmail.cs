using backupGame;
using backupGame.command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateEmail : MonoBehaviour {
    //this is a problem. 
    //It is not possible to set the gameobject or email to be disabled at first, and then re-enable it once conditons have been met in IP-trace. It will cause a null reference exception, due to gameObject being null after you disable it. 
    //A workaround would be to disable the renderer, and then enable it once desired (mission task complete.) But, canvas renderer, which is used to draw the email box does not allow this enabling and disabling to my knowledge.
    //Another workaround could be setting the rect transform to be 0,0. But, this does not also work because "some values are driven by GridLayoutGroup", and as such, I cannot resize the component, as it snaps back to its original size.
    //A sketchy solution would to be have all the emails that are possible, be already present, but covered up by a white box that moves down, revealing the new emails as you complete missions.
    private void Start()
    {
        Equals(0, 0); //trying to resize rect transform.

    }

    public void Appear() //method to be called by ip trace when tracing is successful.
    {
        //reenable or make email appear somehow.

    }

}
