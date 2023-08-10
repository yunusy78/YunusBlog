using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWeb.Areas.Admin.Models;

public class NotificationAdminTypeModel
{
    public string Details { get; set; }
    public string Symbol { get; set; }
    public string Color { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    public string Type { get; set; }
    public List<SelectListItem> NotificationSymbol { get; set; }
    public List<SelectListItem> NotificationTypes { get; set; }
    public List<SelectListItem> ColorOptions { get; set; }
    
    public NotificationAdminTypeModel()
    {
        NotificationSymbol = new List<SelectListItem>
        {
            new SelectListItem { Value = "fa fa-upload fa-fw", Text = "Upload" },
            new SelectListItem { Value = "fa fa-twitter fa-fw", Text = "Twitter" },
            new SelectListItem { Value = "fa fa-envelope fa-fw", Text = "Email" },
            new SelectListItem { Value = "fa fa-calendar", Text = "Calendar" },
            new SelectListItem { Value = "fa fa-cogs", Text = "Settings" },
            new SelectListItem { Value = "fa fa-link", Text = "Link Variant" },
            new SelectListItem { Value = "fa fa-power-off", Text = "Power" },
            new SelectListItem { Value = "fa fa-align-justify", Text = "Format Line Spacing" },
            new SelectListItem { Value = "fa fa-bars", Text = "Menu" },
        };
        
        ColorOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "red", Text = "Red" },
            new SelectListItem { Value = "blue", Text = "Blue" },
            new SelectListItem { Value = "green", Text = "Green" },
            new SelectListItem { Value = "yellow", Text = "Yellow" },
            new SelectListItem { Value = "orange", Text = "Orange" },
            new SelectListItem { Value = "purple", Text = "Purple" },
            new SelectListItem { Value = "pink", Text = "Pink" },
            new SelectListItem { Value = "brown", Text = "Brown" },
            new SelectListItem { Value = "gray", Text = "Gray" },
            new SelectListItem { Value = "black", Text = "Black" }
        };
        
        NotificationTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "Meeting", Text = "Meeting" },
            new SelectListItem { Value = "Maintenance", Text = "Maintenance" },
            new SelectListItem { Value = "Message", Text = "Message" },
            new SelectListItem { Value = "Event", Text = "Event" },
            new SelectListItem { Value = "Settings", Text = "Settings" },
            new SelectListItem { Value = "Link", Text = "Link" },
            new SelectListItem { Value = "Power", Text = "Power" },
            new SelectListItem { Value = "Formatting", Text = "Formatting" },
            new SelectListItem { Value = "Menu", Text = "Menu" },
        };
    }
    
}