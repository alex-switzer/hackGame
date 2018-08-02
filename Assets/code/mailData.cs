using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New mail", menuName = "Mail")]
public class MailData : ScriptableObject{

    
    public string address;
    public string subject;
    [TextArea]
    public string boddy;
    
}
    