namespace YourMoney.Web.Areas.Admin.Controllers.Base
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using YourMoney.Common;

    [Area(GlobalConstants.AdminRoleName)]
    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    public abstract class AdminBaseController : Controller
    {
        protected AdminBaseController() { }
    }
}