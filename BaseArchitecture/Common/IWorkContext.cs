using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using WebAPI.Entities;

namespace WebAPI.Common
{
    public interface IWorkContext
    {
        User CurrentUser { get; set; }
        HttpContext HttpContext { get; set; }
    }
}
