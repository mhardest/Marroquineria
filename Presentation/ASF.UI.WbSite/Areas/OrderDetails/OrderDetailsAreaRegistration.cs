using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.OrderDetails
{
    public class OrderDetailsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OrderDetails";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OrderDetails_default",
                "OrderDetails/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}