using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordTestBot.Tools
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CmdAttribute : Attribute
    {
        public string Command { get; }

        public CmdAttribute(string command)
        {
            Command = command;
        }
    }
}
