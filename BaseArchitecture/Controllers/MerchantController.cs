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

namespace Kingston.KCMS.Modules.Merchant.Controllers
{   
    [Admin, Themed, ValidateInput(false)]
    [AdminAuthorization, Authorization(Permission = PermissionKey.ViewMerchant)]
    public class MerchantController : Controller
    {
        #region Construction
        public Localizer T { get; set; }
        
        private readonly IMerchantService _merchantService;
        private readonly IWorkContext _workContext;
        private readonly INotifier _notifer;
        
        public MerchantController(IMerchantService merchantService,IWorkContext workContext, INotifier notifier)
        {
            T = NullLocalizer.Instance;
            
            this._merchantService = merchantService;
            this._workContext= workContext;
            this._notifer = notifier;
        }

        #endregion

        #region Inquiry

        #region Action
 
        public ActionResult Index()
        {
            var model = new MerchantSearchViewModel();
            return View(model);
        }
        #endregion

        #region Inquiry Function
        public JsonResult GetPagedMerchant(FlexGridFetchOptions fetchOptions, MerchantSearchViewModel model)
        {
            model.StoreQueryCriteria(fetchOptions);
            
            int recordCount;
            int? pageIndex = fetchOptions.page;
            var itemsPerPage = fetchOptions.rp;

            var entities = _merchantService.GetPagedMerchant(
                pageIndex, itemsPerPage, fetchOptions.sortname, fetchOptions.sortorder, out recordCount);

            var pagedResult = new FlexGridData<Merchant>(
                entities, fetchOptions.page, recordCount, x =>x.UserId,
                y =>
                    {
						y.Add(z => z.UserId);
						y.Add(z => z.LinkmanName);
						y.Add(z => z.LinkmanPhone);
						y.Add(z => z.WeChat);
						y.Add(z => z.QQ);
						y.Add(z => z.Email);
						y.Add(z => z.AccountBalance);
						y.Add(z => z.DeleteMark);
                    });

            return Json(pagedResult);
        }

        #endregion

        #endregion

        #region Create & Edit        
 
        public ActionResult Create()
        {
            var model = new MerchantViewModel { Action = EntityAction.New };
            return View("Form", model);
        }
		 	
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Create(MerchantViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		 
        public ActionResult Edit(int id)
        {
		    var entity=_merchantService.GetById(id).Merchant;
            if(entity==null){
                _notifer.Error(T("This Merchant node does not exist in current system."));
                return RedirectToAction("Index");
            }
            var model=new MerchantViewModel(entity){
                Action=EntityAction.Updated
            };
		 
        	return View("Form", model);
        }
		
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Edit(MerchantViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		
        #endregion

        #region Post.Save
  
        private ActionResult Save(MerchantViewModel model, CodeTable.Operation operation)
        {
            if (operation != CodeTable.Operation.Cancel)
            {
                if (!ModelState.IsValid)
                {
                    _notifer.Error(T("Data validation failed"));
                    return View("Form", model);
                }
				var entity=model.ToEntity();
                var result = _merchantService.Save(entity);
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




