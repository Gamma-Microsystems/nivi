using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace NiVi.Builtin
{
    public class poweroff : Command
    {
        public poweroff(String name) : base(name) { }

        public override String execute(String[] args)
        {
            Cosmos.System.Power.Shutdown();
            return "";
        }
    }
}