using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class Command
    {
        public string name;
        public string[] alias;

        public string description;

        public Command() { }

        public virtual string function(string[] x, CommandData data)
        {
            return "CMD not setup" + Environment.NewLine + data.tail;
        }

    }
}
