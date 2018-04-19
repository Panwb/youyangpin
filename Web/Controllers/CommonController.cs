using Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YYP.ComLib;

namespace YYP.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 获取图形验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetImgCode()
        {
            ImageIdentifyCodeHelper helper = new ImageIdentifyCodeHelper();
            helper.CreateImage();
            Session[SessionKey.ImageIdentifyCode] = helper.Text;
            byte[] bytes = ByteConvertHelper.Bitmap2Bytes(helper.Image);
            return File(bytes, "image/jpeg");
        }
    }
}
