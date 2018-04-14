using System;
using System.Collections.Generic;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YYP.ComLib.Configuration;

namespace YYP.ComLib.Services
{
    /// <summary>
    /// 短信发送类
    /// </summary>
    public class AliyunSendSmsService : ISendSmsService
    {
        private readonly IOptions<AliyunSetting> _aliyunSetting;
        private readonly ILogger _logger;
        public AliyunSendSmsService(IOptions<AliyunSetting> aliyunSetting, ILogger<AliyunSendSmsService> logger)
        {
            _aliyunSetting = aliyunSetting;
            _logger = logger;
        }

        public SendSmsServiceResult SendMessage(string paramstr, string phones, string userid, string tmpCode, string signname)
        {
            var result = new SendSmsServiceResult();
            IClientProfile profile = DefaultProfile.GetProfile(_aliyunSetting.Value.RegionIdForPop, _aliyunSetting.Value.AppKey, _aliyunSetting.Value.AppSecret);
            //DefaultProfile.AddEndpoint(_aliyunSetting.Value.RegionIdForPop, _aliyunSetting.Value.RegionIdForPop, _aliyunSetting.Value.ProductName, _aliyunSetting.Value.Domain);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", "Dysmsapi", "dysmsapi.aliyuncs.com");
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = phones;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = signname;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = tmpCode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = paramstr;
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "";
                //请求失败这里会抛ClientException异常
                var sendSmsResponse = acsClient.GetAcsResponse(request);

                result.Code = sendSmsResponse.Code;
            }
            catch (ServerException e)
            {
                _logger.LogError(e.ErrorMessage);
                result.RuleViolations.Add(new RuleViolation("SendSms", e.ErrorMessage));
            }
            catch (ClientException e)
            {
                _logger.LogError(e.ErrorMessage);
                result.RuleViolations.Add(new RuleViolation("SendSms", e.ErrorMessage));
            }
            return result;
        }
    }

    public interface ISendSmsService
    {
        SendSmsServiceResult SendMessage(string paramstr, string phones, string userid, string tmpCode, string signname);
    }
    
    public class SendSmsServiceResult : ServiceResultBase
    {
        public SendSmsServiceResult() : this(new List<RuleViolation>())
        {
        }

        public SendSmsServiceResult(string code)
            : this()
        {
            this.Code = code;
        }

        public SendSmsServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        {
        }

        public string Code
        {
            get;
            set;
        }
    }
}
