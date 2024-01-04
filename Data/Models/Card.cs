using Data.Enums;
using Data.Models.Base;

namespace Data.Models;

public class Card: SingleEntity
{
    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public CardTypesEnum Type { get; set; }
}