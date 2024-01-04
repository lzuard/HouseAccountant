using System.ComponentModel.DataAnnotations;

namespace Data.Models.Base;

public class SingleEntity: IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
}