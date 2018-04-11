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

namespace Kingston.KCMS.Modules.OrderGood.Controllers
{   
    [Admin, Themed, ValidateInput(false)]
    [AdminAuthorization, Authorization(Permission = PermissionKey.ViewOrderGood)]
    public class OrderGoodController : Controller
    {
        #region Construction
        public Localizer T { get; set; }
        
        private readonly IOrderGoodService _orderGoodService;
        private readonly IWorkContext _workContext;
        private readonly INotifier _notifer;
        
        public OrderGoodController(IOrderGoodService orderGoodService,IWorkContext workContext, INotifier notifier)
        {
            T = NullLocalizer.Instance;
            
            this._orderGoodService = orderGoodService;
            this._workContext= workContext;
            this._notifer = notifier;
        }

        #endregion

        #region Inquiry

        #region Action
 
        public ActionResult Index()
        {
            var model = new OrderGoodSearchViewModel();
            return View(model);
        }
        #endregion

        #region Inquiry Function
        public JsonResult GetPagedOrderGood(FlexGridFetchOptions fetchOptions, OrderGoodSearchViewModel model)
        {
            model.StoreQueryCriteria(fetchOptions);
            
            int recordCount;
            int? pageIndex = fetchOptions.page;
            var itemsPerPage = fetchOptions.rp;

            var entities = _orderGoodService.GetPagedOrderGood(
                pageIndex, itemsPerPage, fetchOptions.sortname, fetchOptions.sortorder, out recordCount);

            var pagedResult = new FlexGridData<OrderGood>(
                entities, fetchOptions.page, recordCount, x =>x.OrderGoodsId,
                y =>
                    {
						y.Add(z => z.OrderGoodsId);
						y.Add(z => z.OrderId);
						y.Add(z => z.GoodsId);
                    });

            return Json(pagedResult);
        }

        #endregion

        #endregion

        #region Create & Edit        
 
        public ActionResult Create()
        {
            var model = new OrderGoodViewModel { Action = EntityAction.New };
            return View("Form", model);
        }
		 	
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Create(OrderGoodViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		 
        public ActionResult Edit(int id)
        {
		    var entity=_orderGoodService.GetById(id).OrderGood;
            if(entity==null){
                _notifer.Error(T("This OrderGood node does not exist in current system."));
                return RedirectToAction("Index");
            }
            var model=new OrderGoodViewModel(entity){
                Action=EntityAction.Updated
            };
		 
        	return View("Form", model);
        }
		
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Edit(OrderGoodViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		
        #endregion

        #region Post.Save
  
        private ActionResult Save(OrderGoodViewModel model, CodeTable.Operation operation)
        {
            if (operation != CodeTable.Operation.Cancel)
            {
                if (!ModelState.IsValid)
                {
                    _notifer.Error(T("Data validation failed"));
                    return View("Form", model);
                }
				var entity=model.ToEntity();
                var result = _orderGoodService.Save(entity);
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




