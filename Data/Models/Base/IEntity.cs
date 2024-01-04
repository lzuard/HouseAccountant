using System.ComponentModel.DataAnnotations;

namespace Data.Models.Base;

public interface IEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
}