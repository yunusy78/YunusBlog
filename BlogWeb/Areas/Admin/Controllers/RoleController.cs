using BlogWeb.Areas.Admin.Models;
using BlogWeb.Models;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")] 
[Authorize (Roles = "Admin")]
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    // GET 
    public RoleController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager )
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var result = _roleManager.Roles.ToList();
        
        return View(result);
    }
    
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(RoleViewModel role)
    {
        if (ModelState.IsValid)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = role.Name
            };

            IdentityResult result = await _roleManager.CreateAsync(identityRole);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            
        }
        return View(role);
    }


    public async Task<IActionResult> Delete(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        await _roleManager.DeleteAsync(role);
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Update(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        return View(role);
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(IdentityRole roleViewModel)
    {
        var role = await _roleManager.FindByIdAsync(roleViewModel.Id);
        role.Name = roleViewModel.Name;
        await _roleManager.UpdateAsync(role);
        return RedirectToAction("Index");
    }
    
    
    public IActionResult UserRoleList()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }
    
    public async Task<IActionResult> UserRoleAssign(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        var roles = _roleManager.Roles.ToList();
        TempData["UserId"] = user.Id;
        
        var userRoles = await _userManager.GetRolesAsync(user);
        List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
        foreach (var item in roles)
        {
            RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
            roleAssignViewModel.RoleId = item.Id;
            roleAssignViewModel.Name = item.Name;
            roleAssignViewModel.Exist = userRoles.Contains(item.Name);
            roleAssignViewModels.Add(roleAssignViewModel);
        }
        
        return View(roleAssignViewModels);
    }
    
    [HttpPost]
    public async Task<IActionResult> UserRoleAssign(List<RoleAssignViewModel> roleAssignViewModels)
    {
        var userId = TempData["UserId"].ToString();
        var user = await _userManager.FindByIdAsync(userId);
        foreach (var item in roleAssignViewModels)
        {
            if (item.Exist)
            {
                await _userManager.AddToRoleAsync(user, item.Name);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, item.Name);
            }
        }
        return RedirectToAction("UserRoleList");
    }
    
  
}