using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

//this is the same code as the Maildisplay script, it just makes it able to have a prefab hold more possible emails. 
//Is used to hold the 3 different emails for the ending. That is the: normal fired (refused legit work), bad fired (hacked amanda, and good ending (refused to hack amanda).

public class NormalFiredEnding : MonoBehaviour {

    public MailData mail;
    public Text address;
    public Text subject;
    public Text body;
    public UnityEngine.UI.Button openMail;
    public UnityEngine.UI.Button closeMail;
    public RectTransform mailInfo;


    void Start()
    {
        if (openMail != null)
        {
            openMail.onClick.AddListener(OpenMail);
        }
        if (closeMail != null)
        {
            closeMail.onClick.AddListener(CloseMail);
        }
        Draw();
    }

    void OpenMail()
    {
        if (mailInfo != null)
        {

            mailInfo.Translate(new Vector3(-513, 0, 0));

            MailDisplay data = mailInfo.GetComponent<MailDisplay>();

            data.mail = mail;

            data.Draw(); 

        }
    }

    void CloseMail()
    {
        RectTransform pos = GetComponent<RectTransform>();

        if (pos != null)
        {
            pos.Translate(new Vector3(513, 0, 0));

        }
    }

    public void Draw()
    {
        if (address != null && mail != null)
        {
            address.text = mail.address;
        }

        if (subject != null && mail != null)
        {
            subject.text = mail.subject;
        }
        if (body != null && mail != null)
        {
            body.text = mail.body;
        }
    }

}
