using System;
using UnityEngine;

namespace Assets.code
{
    class command
    {
        public string name;
        public Array alias;

        
        public virtual string runCommand()
        {
            Debug.Log("command not set");
            return "command not set";
        }

    }
}
