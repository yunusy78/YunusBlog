using System.Security.Claims;
using BlogWeb.Models;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Entity.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe.Checkout;

namespace BlogWeb.Controllers;
[Authorize]
public class MembershipController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;     
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly Context _context;
    private readonly MembershipManager _membershipManager;
    private readonly OrderManager _orderManager;
    
    
    public MembershipController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, Context context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _context = context;
        _membershipManager = new MembershipManager(new EfMembershipRepository(_context));
        _orderManager = new OrderManager(new EfOrderRepository(_context));
    }
    
    // GET
    public IActionResult Index()
    {
        
        var memberships = _membershipManager.GetAll();
        List<SelectListItem> valueStatus = (from x in memberships
            select new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        ViewBag.Memberships = valueStatus;
        
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        var user = _userManager.GetUserAsync(User).Result;
        ViewBag.User= user;
        return View();

    }
    
     [HttpPost]
        public IActionResult CheckoutPOST(PaymentViewModel model)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Order  order = new Order();
            if (model.MembershipId == new Guid("97262ff0-9a98-4a0b-8333-df2da92d6179"))
            {
                order.Price = 100;
            }
            else if (model.MembershipId == new Guid("941c74c4-f9da-44a6-9873-55c31a1ff760"))
            {
                order.Price = 1000;
            }
            
            order.UserId = user.Id;
            order.MembershipId = model.MembershipId;
            order.PaymentStatus = PaymentService.PaymentStatusPending;
            order.Status = StatusService.Pending;
            order.PaymentType = "Stripe";
            order.OrderDate = DateTime.Now;
            
          

            _orderManager.Add(order);
           

            
            var domain = "https://localhost:7030/";
            
            var options = new SessionCreateOptions
            {
                
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                
                LineItems = new List<SessionLineItemOptions>(),
                
                Mode = "payment",
                
                SuccessUrl = domain + $"Membership/OrderConfirmation?id={order.Id}",
                
                CancelUrl = domain + $"Membership/index",
                
            };
            
            
            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(order.Price * 100),
                    
                    Currency = "nok",
                    
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = order.User!.FirstName + " " + order.User.LastName,
                    },

                },
                Quantity = 1,
            };
            
            
            
            options.LineItems.Add(sessionLineItem);

            var service = new SessionService();
            
            Session session = service.Create(options);

            _orderManager.UpdateStripeSessionId(order.Id, session.Id);

            Response.Headers.Add("Location", session.Url);
            
            return new StatusCodeResult(303);
            
        }
        
        
        
        public async Task<IActionResult> OrderConfirmation(Guid id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _userManager.AddToRoleAsync(_userManager.FindByIdAsync(claim.Value).Result, "Member").Wait();

            var order = _orderManager.GetListWithUserAndMembershipWithId(id).FirstOrDefault();
            
            if (order.PaymentStatus != PaymentService.PaymentStatusDelayedPayment)
            {
                var service = new SessionService();
                Session session = service.Get(order.SessionId);

                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _orderManager.UpdateStripePaymentId(id, order.SessionId, session.PaymentIntentId);
                   
                }
            }
            
            
            return View(id);
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        
}