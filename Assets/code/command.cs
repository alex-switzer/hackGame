using System;
using System.Collections;
using UnityEngine;

namespace Assets.code
{
    public class command
    {
        public string name;
        public string[] alias;

        public string description;

        public Func<string, string> action;

        public command(string name, string[] alias, string description, Func<string, string> action)
        {
            this.name = name;
            this.alias = alias;

            this.description = description;

            this.action = action;
        }

    }
}
