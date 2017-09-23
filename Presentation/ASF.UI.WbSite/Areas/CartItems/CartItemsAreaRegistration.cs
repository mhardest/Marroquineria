using System.Web.Mvc;

namespace ASF.UI.WbSite.Areas.CartItems
{
    public class CartItemsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CartItems";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CartItems_default",
                "CartItems/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}