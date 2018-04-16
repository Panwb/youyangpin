using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYP.Dto
{
    public class RegisterDto
    {
        public string TelPhone { get; set; }
        public string Password { get; set; }
        public string StudioHostName { get; set; }
        public string IdentifyCode { get; set; }
        public string SmsIdentifyCode { get; set; }
    }
}
