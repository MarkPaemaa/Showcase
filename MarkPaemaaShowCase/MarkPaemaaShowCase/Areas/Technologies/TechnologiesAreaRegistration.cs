using System.Web.Mvc;

namespace MarkPaemaaShowCase.Areas.Technologies
{
    public class TechnologiesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Technologies";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Technologies_default",
                "Technologies/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}