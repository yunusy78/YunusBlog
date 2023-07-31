using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete;

public class Message2
{
    [Key]
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    
    public Guid ReceiverId { get; set; }
    
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
    
    public Writer SenderWriter { get; set; }
    public Writer ReceiverWriter { get; set; }
    
    
}