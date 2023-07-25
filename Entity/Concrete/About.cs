namespace Entity.Concrete;

public class About
{
    public Guid Id { get; set; }
    
    public string Details1 { get; set; }=string.Empty;
    
    public string Details2 { get; set; }=string.Empty;

    public string ImageUrl1 { get; set; }=string.Empty;
    
    public string ImageUrl2 { get; set; }=string.Empty;

    public string MapLocation { get; set; }=string.Empty;
    
    public bool Status { get; set; }
}