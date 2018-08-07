using System;
using System.Collections.Generic;
using Assets.Code;

namespace Assets.Code.Commands
{
    class Help : Command
    {
        public Help()
        {
            name = "Help";

            alias =  new string[] { "help", "?" };
            description = "Provides help information for Windows commands.";
        }

        public override string function(string[] x, CommandData data)
        {
            string list = "For more information on a specific command, type HELP command-name" + Environment.NewLine;

            if (x.Length == 1)
            {
                for (int i = 0; i < data.commands.Count; i++)
                {
                    list += data.commands[i].name.PadRight(8) + " " + data.commands[i].description + Environment.NewLine;
                }

                list += Environment.NewLine + "For more information on tools see the command-line reference in the online help.";
            }
            else
            {
                Command command = null;

                for (int i = 0; i < data.commands.Count; i++)
                {
                    for (int k = 0; k < data.commands[i].alias.Length; k++)
                    {
                        if (data.commands[i].alias[k].ToLower() == x[1].ToLower())
                        {
                            command = data.commands[i];
                        }
                    }
                }

                if (command != null)
                {
                    list = command.description;
                }
                else
                {
                    list = "This command is not supported by the help utility.  Try \"" + data.commands[1] + " /?\".";
                }
            }
            return list + Environment.NewLine + data.tail;
        }

    }
}
