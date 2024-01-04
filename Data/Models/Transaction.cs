using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models;

public class Transaction: SingleEntity
{
    // Own properties
    public DateTime TransactionDateTime { get; set; }
    
    public string Currency { get; set; }
    
    public decimal Amount { get; set; }
    
    
    
    // Foreign keys
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(Card))]
    public Guid CardId { get; set; }
    
    [ForeignKey(nameof(Destination))]
    public Guid DestinationId { get; set; }
    
    // Navigation properties
    public User User { get; set; }
    public Card Card { get; set; }
    public Destination Destination { get; set; }
}