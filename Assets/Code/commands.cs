using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace backupGame
{   
    class commands
    {

        public InputField input;
        public Text output;
        public Text username;

        public string name;
        public string description;

        public virtual void lantern(List<string> result)
        {
 
        }
        public virtual void lantern(List<string> result, List<commands> listOfCommands)
        {

        }

    }
}
