using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Kingston.ComLib;
using Kingston.ComLib.DomainModel;
using Kingston.ComLib.Localization;
using Kingston.ComLib.Themes;
using Kingston.ComLib.UI.Notify;
using Kingston.ComLib.UI.Admin;
using Kingston.ComLib.Web.Mvc;
using Kingston.ComLib.Web.Mvc.Model;
using Kingston.KCMS.ActionFilters;
using Kingston.KCMS.Common;
using WebAPI.Entities;
using WebAPI.Services;
using Kingston.KCMS.Web.Modules.Widget.ViewModels;

namespace Kingston.KCMS.Modules.StudioHost.Controllers
{   
    [Admin, Themed, ValidateInput(false)]
    [AdminAuthorization, Authorization(Permission = PermissionKey.ViewStudioHost)]
    public class StudioHostController : Controller
    {
        #region Construction
        public Localizer T { get; set; }
        
        private readonly IStudioHostService _studioHostService;
        private readonly IWorkContext _workContext;
        private readonly INotifier _notifer;
        
        public StudioHostController(IStudioHostService studioHostService,IWorkContext workContext, INotifier notifier)
        {
            T = NullLocalizer.Instance;
            
            this._studioHostService = studioHostService;
            this._workContext= workContext;
            this._notifer = notifier;
        }

        #endregion

        #region Inquiry

        #region Action
 
        public ActionResult Index()
        {
            var model = new StudioHostSearchViewModel();
            return View(model);
        }
        #endregion

        #region Inquiry Function
        public JsonResult GetPagedStudioHost(FlexGridFetchOptions fetchOptions, StudioHostSearchViewModel model)
        {
            model.StoreQueryCriteria(fetchOptions);
            
            int recordCount;
            int? pageIndex = fetchOptions.page;
            var itemsPerPage = fetchOptions.rp;

            var entities = _studioHostService.GetPagedStudioHost(
                pageIndex, itemsPerPage, fetchOptions.sortname, fetchOptions.sortorder, out recordCount);

            var pagedResult = new FlexGridData<StudioHost>(
                entities, fetchOptions.page, recordCount, x =>x.UserId,
                y =>
                    {
						y.Add(z => z.UserId);
						y.Add(z => z.StudioHostName);
						y.Add(z => z.TKName);
						y.Add(z => z.Height);
						y.Add(z => z.Weight);
						y.Add(z => z.ShoeSize);
						y.Add(z => z.ClothesSize);
						y.Add(z => z.Address);
						y.Add(z => z.LinkmanName);
						y.Add(z => z.LinkmanPhone);
						y.Add(z => z.WeChat);
						y.Add(z => z.QQ);
						y.Add(z => z.Email);
						y.Add(z => z.FansNum);
						y.Add(z => z.AverageDailyViews);
						y.Add(z => z.VerticalFieldCode);
						y.Add(z => z.MainPopActivityType);
						y.Add(z => z.PerCustomerTransactionHight);
						y.Add(z => z.PerCustomerTransactionLow);
						y.Add(z => z.AlipayAccount);
						y.Add(z => z.AccountBalance);
						y.Add(z => z.Margin);
						y.Add(z => z.CheckStatus);
						y.Add(z => z.Remark);
						y.Add(z => z.DailyBeginTime);
						y.Add(z => z.DailyEndTime);
						y.Add(z => z.DeleteMark);
                    });

            return Json(pagedResult);
        }

        #endregion

        #endregion

        #region Create & Edit        
 
        public ActionResult Create()
        {
            var model = new StudioHostViewModel { Action = EntityAction.New };
            return View("Form", model);
        }
		 	
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Create(StudioHostViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		 
        public ActionResult Edit(int id)
        {
		    var entity=_studioHostService.GetById(id).StudioHost;
            if(entity==null){
                _notifer.Error(T("This StudioHost node does not exist in current system."));
                return RedirectToAction("Index");
            }
            var model=new StudioHostViewModel(entity){
                Action=EntityAction.Updated
            };
		 
        	return View("Form", model);
        }
		
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Edit(StudioHostViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		
        #endregion

        #region Post.Save
  
        private ActionResult Save(StudioHostViewModel model, CodeTable.Operation operation)
        {
            if (operation != CodeTable.Operation.Cancel)
            {
                if (!ModelState.IsValid)
                {
                    _notifer.Error(T("Data validation failed"));
                    return View("Form", model);
                }
				var entity=model.ToEntity();
                var result = _studioHostService.Save(entity);
                if (result.HasViolation)
                {
                    ViewData.ModelState.Merge(result.RuleViolations);
                    return View("Form", model);
                }
                _notifer.Success(T("Successful")); 
				if (operation == CodeTable.Operation.SaveAndContinue)
					return RedirectToAction("Edit", new { ActionType = ContentContextActionType.Edit, content.Item.ContentItemID, model.CultureId });
            }
            return RedirectToAction("Index");
        }
		
        #endregion
 
    }
}




