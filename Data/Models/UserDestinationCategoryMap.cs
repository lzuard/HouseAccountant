using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Base;

namespace Data.Models;

public class UserDestinationCategoryMap: BundleEntity
{
    // Foreign keys
    [Key]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    
    [Key]
    [ForeignKey(nameof(Destination))]
    public Guid DestinationId { get; set; }
    
    [Key]
    [ForeignKey(nameof(Category))]
    public Guid CategoryId { get; set; }
    
    // Navigation properties
    public User User { get; set; }
    public Destination Destination { get; set; }
    public Category Category { get; set; }
}