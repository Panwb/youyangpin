
using System;
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Kingston.KCMS.Data;
using WebAPI.Entities;

namespace WebAPI.Data
{
    /// <summary>
    /// Summary description for UserRepository.
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
	{
        private readonly IWorkContext _workContext;
		public UserRepository(IWorkContext workContext)
		{
            this._workContext = workContext;
		}

		#region CRUD
		public override int Add(User inUser)
		{						
			var obj= Database.StoredProcedure("[dbo].[Usp_T_Sys_User_Insert]")
                .AddInputParameter("@Account", DbType.String , inUser.Account)
                .AddInputParameter("@Pwd", DbType.AnsiString , inUser.Pwd)
                .AddInputParameter("@UserState", DbType.Byte , inUser.UserState)
                .AddInputParameter("@UserType", DbType.String , inUser.UserType)
                .AddInputParameter("@TrueName", DbType.String , inUser.TrueName)
                .AddInputParameter("@DepartmentGuid", DbType.AnsiString , inUser.DepartmentGuid)
                .AddInputParameter("@PositionGuid", DbType.AnsiString , inUser.PositionGuid)
                .AddInputParameter("@LastLoginTime", DbType.DateTime , inUser.LastLoginTime)
                .AddInputParameter("@LastLoginIP", DbType.AnsiString , inUser.LastLoginIP)
                .AddInputParameter("@LoginTimes", DbType.Int32 , inUser.LoginTimes)
                .AddInputParameter("@LoginErrorTimes", DbType.Int32 , inUser.LoginErrorTimes)
                .AddInputParameter("@CreatePerson", DbType.AnsiString , inUser.CreatePerson)
                .AddInputParameter("@CreateTime", DbType.DateTime , inUser.CreateTime)
                .AddInputParameter("@ExpirationDate", DbType.DateTime , inUser.ExpirationDate)
                .AddInputParameter("@QQ", DbType.AnsiString , inUser.QQ)
                .AddInputParameter("@IsAdmin", DbType.Boolean , inUser.IsAdmin)
                .AddInputParameter("@TelPhone", DbType.AnsiString , inUser.TelPhone)
                .AddInputParameter("@QQGroup", DbType.String , inUser.QQGroup)
                .AddInputParameter("@ReturnInfo", DbType.String , inUser.ReturnInfo)
                .AddInputParameter("@CityName", DbType.String , inUser.CityName)
                .AddInputParameter("@ProvinceName", DbType.String , inUser.ProvinceName)
                .AddInputParameter("@Email", DbType.AnsiString , inUser.Email)
                .AddInputParameter("@Gender", DbType.String , inUser.Gender)
                .AddInputParameter("@ZFBAccount", DbType.String , inUser.ZFBAccount)
                .AddInputParameter("@UpdateTime", DbType.DateTime , inUser.UpdateTime)
                .ToScalar();

            if (obj == null)
            {
                return 0;
            }
            int returnValue;
            if (int.TryParse(obj.ToString(), out returnValue))
            {
                inUser.GUID = returnValue;
            }
            return returnValue;
		}
				
		public override int Update(User inUser)
		{	
            return Database.StoredProcedure("[dbo].[Usp_T_Sys_User_Update]")			
                .AddInputParameter("@GUID", DbType.AnsiString , inUser.GUID)
                .AddInputParameter("@Account", DbType.String , inUser.Account)
                .AddInputParameter("@Pwd", DbType.AnsiString , inUser.Pwd)
                .AddInputParameter("@UserState", DbType.Byte , inUser.UserState)
                .AddInputParameter("@UserType", DbType.String , inUser.UserType)
                .AddInputParameter("@TrueName", DbType.String , inUser.TrueName)
                .AddInputParameter("@DepartmentGuid", DbType.AnsiString , inUser.DepartmentGuid)
                .AddInputParameter("@PositionGuid", DbType.AnsiString , inUser.PositionGuid)
                .AddInputParameter("@LastLoginTime", DbType.DateTime , inUser.LastLoginTime)
                .AddInputParameter("@LastLoginIP", DbType.AnsiString , inUser.LastLoginIP)
                .AddInputParameter("@LoginTimes", DbType.Int32 , inUser.LoginTimes)
                .AddInputParameter("@LoginErrorTimes", DbType.Int32 , inUser.LoginErrorTimes)
                .AddInputParameter("@CreatePerson", DbType.AnsiString , inUser.CreatePerson)
                .AddInputParameter("@CreateTime", DbType.DateTime , inUser.CreateTime)
                .AddInputParameter("@ExpirationDate", DbType.DateTime , inUser.ExpirationDate)
                .AddInputParameter("@QQ", DbType.AnsiString , inUser.QQ)
                .AddInputParameter("@IsAdmin", DbType.Boolean , inUser.IsAdmin)
                .AddInputParameter("@TelPhone", DbType.AnsiString , inUser.TelPhone)
                .AddInputParameter("@QQGroup", DbType.String , inUser.QQGroup)
                .AddInputParameter("@ReturnInfo", DbType.String , inUser.ReturnInfo)
                .AddInputParameter("@CityName", DbType.String , inUser.CityName)
                .AddInputParameter("@ProvinceName", DbType.String , inUser.ProvinceName)
                .AddInputParameter("@Email", DbType.AnsiString , inUser.Email)
                .AddInputParameter("@Gender", DbType.String , inUser.Gender)
                .AddInputParameter("@ZFBAccount", DbType.String , inUser.ZFBAccount)
                .AddInputParameter("@UpdateTime", DbType.DateTime , inUser.UpdateTime)
			    .ExecuteNonQuery();                
		}
				
		public override int Delete(int inGUID)
		{            
            return Database.StoredProcedure("[dbo].[Usp_T_Sys_User_Delete]")			
                .AddInputParameter("@GUID", DbType.Int32 , inGUID)
			    .ExecuteNonQuery(); 			
		}
		
		public override User GetById(int inGUID)
		{
            return Database.StoredProcedure("[dbo].[Usp_T_Sys_User_Select]")
                .AddInputParameter("@GUID", DbType.Int32, inGUID)
                .ToDataReader()
                .As<User>();
		}
		
		public override IEnumerable<User> GetAll()
		{
            return Database.StoredProcedure("[dbo].[Usp_T_Sys_User_SelectAll]")
                .ToDataReader()
                .AsList<User>();
		}	
		#endregion
        
        
        
        public IEnumerable<User> GetPagedUser(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            ListDictionary outValues;
            var dt = Database.StoredProcedure("[dbo].[Usp_T_Sys_User_Pagination]")
                .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
                .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
                .AddInputParameter("@SortField", DbType.String, sortField)
                .AddInputParameter("@Sort", DbType.String, sort)
                .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
                .ToDataTable(out outValues);

            var myUser = new List<User>();
            Converter<,>.DataTableToEntityCollection(dt, myUser);
            recordCount = (int)outValues["RecordCount"];
            return myUser;
        }
        
        public DataTable GetHistoryByColumns(int inGUID)
        {
            return Database.StoredProcedure("[dbo].[Usp_T_Sys_User_SelectHistoryColumns]")
                .AddInputParameter("@GUID", DbType.Int32, inGUID)
                .ToDataTable();
        }
	}
}

