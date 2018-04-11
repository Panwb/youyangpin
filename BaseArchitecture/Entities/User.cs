
using System;
using Infrastructure.DomainModel;

namespace WebAPI.Entities
{
	#region WebAPI.Entities

	/// <summary>
	/// User object mapped to table 'T_Sys_User'.
	/// </summary>
	public class User : EntityBase
	{
		#region Column names
		
		//public const string CN_GUID = "GUID";
		//public const string CN_ACCOUNT = "Account";
		//public const string CN_PWD = "Pwd";
		//public const string CN_USERSTATE = "UserState";
		//public const string CN_USERTYPE = "UserType";
		//public const string CN_TRUENAME = "TrueName";
		//public const string CN_DEPARTMENTGUID = "DepartmentGuid";
		//public const string CN_POSITIONGUID = "PositionGuid";
		//public const string CN_LASTLOGINTIME = "LastLoginTime";
		//public const string CN_LASTLOGINIP = "LastLoginIP";
		//public const string CN_LOGINTIMES = "LoginTimes";
		//public const string CN_LOGINERRORTIMES = "LoginErrorTimes";
		//public const string CN_CREATEPERSON = "CreatePerson";
		//public const string CN_CREATETIME = "CreateTime";
		//public const string CN_EXPIRATIONDATE = "ExpirationDate";
		//public const string CN_QQ = "QQ";
		//public const string CN_ISADMIN = "IsAdmin";
		//public const string CN_TELPHONE = "TelPhone";
		//public const string CN_QQGROUP = "QQGroup";
		//public const string CN_RETURNINFO = "ReturnInfo";
		//public const string CN_CITYNAME = "CityName";
		//public const string CN_PROVINCENAME = "ProvinceName";
		//public const string CN_EMAIL = "Email";
		//public const string CN_GENDER = "Gender";
		//public const string CN_ZFBACCOUNT = "ZFBAccount";
		//public const string CN_UPDATETIME = "UpdateTime";
		
		#endregion
		
		#region Constructors

		public  User() { }

		public  User( string gUID, string account, string pwd, byte userState, string userType, string trueName, string departmentGuid, string positionGuid, DateTime lastLoginTime, string lastLoginIP, int loginTimes, int loginErrorTimes, string createPerson, DateTime createTime, DateTime expirationDate, string qQ, bool isAdmin, string telPhone, string qQGroup, string returnInfo, string cityName, string provinceName, string email, string gender, string zFBAccount, DateTime updateTime )
		{
			this.GUID = gUID;
			this.Account = account;
			this.Pwd = pwd;
			this.UserState = userState;
			this.UserType = userType;
			this.TrueName = trueName;
			this.DepartmentGuid = departmentGuid;
			this.PositionGuid = positionGuid;
			this.LastLoginTime = lastLoginTime;
			this.LastLoginIP = lastLoginIP;
			this.LoginTimes = loginTimes;
			this.LoginErrorTimes = loginErrorTimes;
			this.CreatePerson = createPerson;
			this.CreateTime = createTime;
			this.ExpirationDate = expirationDate;
			this.QQ = qQ;
			this.IsAdmin = isAdmin;
			this.TelPhone = telPhone;
			this.QQGroup = qQGroup;
			this.ReturnInfo = returnInfo;
			this.CityName = cityName;
			this.ProvinceName = provinceName;
			this.Email = email;
			this.Gender = gender;
			this.ZFBAccount = zFBAccount;
			this.UpdateTime = updateTime;
		}
		
		#endregion

		#region Public Properties

		public string GUID { get; set; }
		public string Account { get; set; }
		public string Pwd { get; set; }
		public byte UserState { get; set; }
		public string UserType { get; set; }
		public string TrueName { get; set; }
		public string DepartmentGuid { get; set; }
		public string PositionGuid { get; set; }
		public DateTime LastLoginTime { get; set; }
		public string LastLoginIP { get; set; }
		public int LoginTimes { get; set; }
		public int LoginErrorTimes { get; set; }
		public string CreatePerson { get; set; }
		public DateTime CreateTime { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string QQ { get; set; }
		public bool IsAdmin { get; set; }
		public string TelPhone { get; set; }
		public string QQGroup { get; set; }
		public string ReturnInfo { get; set; }
		public string CityName { get; set; }
		public string ProvinceName { get; set; }
		public string Email { get; set; }
		public string Gender { get; set; }
		public string ZFBAccount { get; set; }
		public DateTime UpdateTime { get; set; }
        
		#endregion
	}
	#endregion
}