//using AutoSpare.Persistence.Contexts;
//using Microsoft.AspNetCore.Authorization;



//namespace AutoSpare.Persistence.Authorization;
//public class SuperAdminOrAdminAndCompanyHandler : AuthorizationHandler<SuperAdminOrAdminAndCompanyRequirement>
//{

//    private readonly AutoSpareDbContext _context;

//    public SuperAdminOrAdminAndCompanyHandler(AutoSpareDbContext context)
//    {
//        _context = context;
//    }

//    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, SuperAdminOrAdminAndCompanyRequirement requirement)
//    {
//        if (context.User == null || !context.User.Identity.IsAuthenticated)
//        {
//            context.Fail();
//            return;
//        }

//        // Check if the user has the superadmin role
//        if (context.User.IsInRole("superadmin"))
//        {
//            context.Succeed(requirement);
//            return;
//        }

//        // Check if the user has the admin role and if the company ID exists
//        if (context.User.IsInRole("admin"))
//        {
//            var companyId = context.User.FindFirst("companyId")?.Value;
//            if (!string.IsNullOrEmpty(companyId))
//            {
//                // Check if the company ID exists in the database
//                var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
//                if (company != null)
//                {
//                    context.Succeed(requirement);
//                    return;
//                }
//            }
//        }

//        // User does not meet the requirements
//        context.Fail();
//    }
//}