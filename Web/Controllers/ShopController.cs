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

namespace Kingston.KCMS.Modules.Shop.Controllers
{   
    [Admin, Themed, ValidateInput(false)]
    [AdminAuthorization, Authorization(Permission = PermissionKey.ViewShop)]
    public class ShopController : Controller
    {
        #region Construction
        public Localizer T { get; set; }
        
        private readonly IShopService _shopService;
        private readonly IWorkContext _workContext;
        private readonly INotifier _notifer;
        
        public ShopController(IShopService shopService,IWorkContext workContext, INotifier notifier)
        {
            T = NullLocalizer.Instance;
            
            this._shopService = shopService;
            this._workContext= workContext;
            this._notifer = notifier;
        }

        #endregion

        #region Inquiry

        #region Action
 
        public ActionResult Index()
        {
            var model = new ShopSearchViewModel();
            return View(model);
        }
        #endregion

        #region Inquiry Function
        public JsonResult GetPagedShop(FlexGridFetchOptions fetchOptions, ShopSearchViewModel model)
        {
            model.StoreQueryCriteria(fetchOptions);
            
            int recordCount;
            int? pageIndex = fetchOptions.page;
            var itemsPerPage = fetchOptions.rp;

            var entities = _shopService.GetPagedShop(
                pageIndex, itemsPerPage, fetchOptions.sortname, fetchOptions.sortorder, out recordCount);

            var pagedResult = new FlexGridData<Shop>(
                entities, fetchOptions.page, recordCount, x =>x.ShopId,
                y =>
                    {
						y.Add(z => z.ShopId);
						y.Add(z => z.UserId);
						y.Add(z => z.ShopType);
						y.Add(z => z.ShopName);
						y.Add(z => z.VerticalFieldCode);
						y.Add(z => z.ShopURL);
						y.Add(z => z.WangWangNo);
						y.Add(z => z.ShopAddress);
						y.Add(z => z.DescriptionMatch);
						y.Add(z => z.ServiceAttitude);
						y.Add(z => z.LogisticsService);
						y.Add(z => z.CheckStatus);
						y.Add(z => z.DeleteMark);
                    });

            return Json(pagedResult);
        }

        #endregion

        #endregion

        #region Create & Edit        
 
        public ActionResult Create()
        {
            var model = new ShopViewModel { Action = EntityAction.New };
            return View("Form", model);
        }
		 	
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Create(ShopViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		 
        public ActionResult Edit(int id)
        {
		    var entity=_shopService.GetById(id).Shop;
            if(entity==null){
                _notifer.Error(T("This Shop node does not exist in current system."));
                return RedirectToAction("Index");
            }
            var model=new ShopViewModel(entity){
                Action=EntityAction.Updated
            };
		 
        	return View("Form", model);
        }
		
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Edit(ShopViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		
        #endregion

        #region Post.Save
  
        private ActionResult Save(ShopViewModel model, CodeTable.Operation operation)
        {
            if (operation != CodeTable.Operation.Cancel)
            {
                if (!ModelState.IsValid)
                {
                    _notifer.Error(T("Data validation failed"));
                    return View("Form", model);
                }
				var entity=model.ToEntity();
                var result = _shopService.Save(entity);
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




