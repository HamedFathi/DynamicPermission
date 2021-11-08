using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace DynamicPermission.TagHelpers
{

    //public class ApplicationRole : IdentityRole
    //{
    //    public string Access { get; set; }
    //}

    [HtmlTargetElement("restricted-area")]
    public class RestrictedAreaTagHelper : TagHelper
    {
        private readonly IdentityDbContext _identityDbContext;

        public RestrictedAreaTagHelper(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        [HtmlAttributeName("asp-area")]
        public string Area { get; set; } = "";

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; } = "";

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; } = "";

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var user = ViewContext.HttpContext.User;

            if (user.Identity != null && !user.Identity.IsAuthenticated)
            {
                output.SuppressOutput();
                return;
            }
            
            var roles = await (
                from usr in _identityDbContext.Users
                join userRole in _identityDbContext.UserRoles on usr.Id equals userRole.UserId
                join role in _identityDbContext.Roles on userRole.RoleId equals role.Id
                where usr.UserName == user.Identity.Name
                select role
            ).ToListAsync();

            var actionId = $"{Area}:{Controller}:{Action}";

            foreach (var role in roles)
            {
                // var accessList = JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                // if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                // return;
            }

            output.SuppressOutput();
        }
    }
}
