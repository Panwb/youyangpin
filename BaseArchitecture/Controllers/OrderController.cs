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

namespace Kingston.KCMS.Modules.Order.Controllers
{   
    [Admin, Themed, ValidateInput(false)]
    [AdminAuthorization, Authorization(Permission = PermissionKey.ViewOrder)]
    public class OrderController : Controller
    {
        #region Construction
        public Localizer T { get; set; }
        
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly INotifier _notifer;
        
        public OrderController(IOrderService orderService,IWorkContext workContext, INotifier notifier)
        {
            T = NullLocalizer.Instance;
            
            this._orderService = orderService;
            this._workContext= workContext;
            this._notifer = notifier;
        }

        #endregion

        #region Inquiry

        #region Action
 
        public ActionResult Index()
        {
            var model = new OrderSearchViewModel();
            return View(model);
        }
        #endregion

        #region Inquiry Function
        public JsonResult GetPagedOrder(FlexGridFetchOptions fetchOptions, OrderSearchViewModel model)
        {
            model.StoreQueryCriteria(fetchOptions);
            
            int recordCount;
            int? pageIndex = fetchOptions.page;
            var itemsPerPage = fetchOptions.rp;

            var entities = _orderService.GetPagedOrder(
                pageIndex, itemsPerPage, fetchOptions.sortname, fetchOptions.sortorder, out recordCount);

            var pagedResult = new FlexGridData<Order>(
                entities, fetchOptions.page, recordCount, x =>x.OrderId,
                y =>
                    {
						y.Add(z => z.OrderId);
						y.Add(z => z.StudioHostUserId);
						y.Add(z => z.MerchantUserId);
						y.Add(z => z.ShopGuid);
						y.Add(z => z.CheckStatus);
						y.Add(z => z.OrderNo);
						y.Add(z => z.OrderStatus);
						y.Add(z => z.CreateTime);
						y.Add(z => z.FaHuoTime);
						y.Add(z => z.DaoHuoTime);
						y.Add(z => z.TuiHuoTime);
						y.Add(z => z.TuiFeiTime);
						y.Add(z => z.LogisticName);
						y.Add(z => z.LogisticNo);
						y.Add(z => z.TuiHuoLogisticName);
						y.Add(z => z.TuiHuoLogisticNo);
						y.Add(z => z.TuiHuoPostage);
						y.Add(z => z.MerchantToStudioHos);
						y.Add(z => z.MerchantGiveStudioHosStars);
						y.Add(z => z.StudioHosToMerchant);
						y.Add(z => z.StudioHosGiveMerchantStars);
						y.Add(z => z.BroadcastScheduling);
						y.Add(z => z.DirectionalPlanStatus);
						y.Add(z => z.PostageStatisticsMark);
                    });

            return Json(pagedResult);
        }

        #endregion

        #endregion

        #region Create & Edit        
 
        public ActionResult Create()
        {
            var model = new OrderViewModel { Action = EntityAction.New };
            return View("Form", model);
        }
		 	
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Create(OrderViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		 
        public ActionResult Edit(int id)
        {
		    var entity=_orderService.GetById(id).Order;
            if(entity==null){
                _notifer.Error(T("This Order node does not exist in current system."));
                return RedirectToAction("Index");
            }
            var model=new OrderViewModel(entity){
                Action=EntityAction.Updated
            };
		 
        	return View("Form", model);
        }
		
		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Edit(OrderViewModel model, CodeTable.Operation operation)
		{
			return Save(model, operation);
		}
		
        #endregion

        #region Post.Save
  
        private ActionResult Save(OrderViewModel model, CodeTable.Operation operation)
        {
            if (operation != CodeTable.Operation.Cancel)
            {
                if (!ModelState.IsValid)
                {
                    _notifer.Error(T("Data validation failed"));
                    return View("Form", model);
                }
				var entity=model.ToEntity();
                var result = _orderService.Save(entity);
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




