using System.Security.Claims;
using BlogWeb.Models;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Entity.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
    private readonly IEmailSender _emailSender;
    
    
    public MembershipController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager, Context context, IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _context = context;
        _membershipManager = new MembershipManager(new EfMembershipRepository(_context));
        _orderManager = new OrderManager(new EfOrderRepository(_context));
        _emailSender = emailSender;
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
                    string emailContent = GenerateEmailContent(order);
                    await _emailSender.SendEmailAsync(order.User.Email, "New Order - YunusBlog", emailContent);
                   
                }
            }
            
            
            return View(id);
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }
        
        
         public string GenerateEmailContent(Order order)
{
    string emailContent = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Order Confirmation - YunusBlog</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            margin: 0;
            padding: 0;
        }}
        
        .container {{
            max-width: 600px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }}
        
        h1 {{
            margin-top: 0;
        }}
        
        p {{
            margin-bottom: 20px;
            line-height: 1.6;
        }}
        
        .cta-button {{
            display: inline-block;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            text-decoration: none;
            border-radius: 5px;
        }}
        
        .cta-button:hover {{
            background-color: #0056b3; 
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <h1>Order Confirmation - YunusBlog</h1>
        <p>Dear {order.User!.FirstName} {order.User.LastName},</p>
        <p>Your order with Order Number {order.Id} has been successfully placed. Thank you for choosing YunusBlog for your purchase.</p>
        <p>Order Details:</p>
        <ul>
            <li>Order ID: {order.Id}</li>
            <li>Customer: {order.User.FirstName} {order.User.LastName}</li>
            <li>Total Amount: {order.Price}</li>
            <!-- ... more order details ... -->
        </ul>
        <p>You can track the status of your order by logging into your account on our website.</p>
        <p>If you have any questions or need assistance, please don't hesitate to contact our customer support team at [].</p>
        <p>Thank you for shopping with us!</p>
        <a class=""cta-button"" href=""[https://localhost:7030/Blog/Index/]"">Visit Our Website</a>
    </div>
</body>
</html>";
    return emailContent;
}
      

        
        
}