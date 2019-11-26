using log4net;
using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using SkuApplication.Abstract;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace SkuApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4.config.xml"));
            LOG.InfoFormat("Application started at {0}", DateTime.Now);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_End(Object sender, EventArgs e)
        {

            var timeNow = DateTime.Now;
            int id = Convert.ToInt32(Session["id"]);

            var repository = (IUserController)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserController));

            repository.EditLastLogout(id, timeNow);
        }
    }
}
