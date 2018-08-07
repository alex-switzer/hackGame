using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code;

namespace Assets.Code.Commands
{
    class Clear : Command
    {
        public Clear()
        {
            name = "Clear";

            alias = new string[] { "clear", "cl", "clr" };
            description = "Clears the screen.";
        }

        public override string function(string[] x, CommandData data)
        {
            return "";
        }

    }
}
