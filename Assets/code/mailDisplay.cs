using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mailDisplay : MonoBehaviour {

    public mailData mail;

    public Text address;
    public Text subject;
    public Text boddy;
    public Button openMail;
    public Button closeMail;

    public RectTransform mailInfo;

    // Use this for initialization
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

            mailInfo.Translate(new Vector3(-513, 0,0));

            mailDisplay data = mailInfo.GetComponent<mailDisplay>();

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

    void Draw()
    {
        if (address != null)
        {
            address.text = mail.address;
        }

        if (subject != null)
        {
            subject.text = mail.subject;
        }
        if (boddy != null)
        {
            boddy.text = mail.boddy;
        }
    }
}
