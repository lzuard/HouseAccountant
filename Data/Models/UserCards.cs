using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public class UserCards: BundleEntity
{
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(Card))]
    public Guid CardId { get; set; }
    
    //Navigation properties
    public User User { get; set; }
    public Card Card { get; set; }
}