using System.ComponentModel.DataAnnotations;

namespace Data.Models.Base;

/// <summary>
/// Bundle Entity should always have combined primary key that consists of foreign keys
/// </summary>
public class BundleEntity :IEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
}