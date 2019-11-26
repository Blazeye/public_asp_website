using System;
using System.Web.Mvc;

namespace SkuApplication.Abstract
{
    public interface IUserController
    {
        ActionResult EditLastLogout(int userid, DateTime last_logout);
    }
}
