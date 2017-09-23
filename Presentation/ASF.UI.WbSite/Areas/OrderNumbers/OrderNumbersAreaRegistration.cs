using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.OrderNumbers
{
    public class OrderNumbersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OrderNumbers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OrderNumbers_default",
                "OrderNumbers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}