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

        public Func<string[], string> function;

        public command(string name, string[] alias, string description, Func<string[], string> function)
        {
            this.name = name;
            this.alias = alias;

            this.description = description;

            this.function = function;
        }

    }
}
