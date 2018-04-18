using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YYP.ComLib
{
    public enum UserState
    {
        Deleted = 0,
        Enabled = 1,
        Disabled = 2
    }

    public enum SendSmsType
    {
        Register = 1,
        RetrievePassword = 2
    }
}
