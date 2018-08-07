using System;

namespace Assets.Code.Commands
{
    class Ping : Command
    {
        public Ping()
        {
            name = "Ping";

            alias = new string[] { "ping" };
            description = "Pings a IP.";
        }

        public override string function(string[] x, CommandData data)
        {
            if (x.Length <= 1)
            {
                return "Use ping [IP] to ping an IP" + Environment.NewLine + data.tail;
            }

            //TODO:
            //add ping code

            return "Done ping" + Environment.NewLine + data.tail;
        }

    }
}
