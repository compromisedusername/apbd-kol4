using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolosTest2.Models;
[Table("character_titles")]
[PrimaryKey(nameof(TitleId),nameof(CharactedId))]
public class CharacterTitle
{
    
    public int TitleId { get; set; }
    public int CharactedId { get; set; }

    [ForeignKey(nameof(CharactedId))]
    public Character Character { get; set; }  
    
    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; } 
    
    [DataType(DataType.DateTime)]
    public DateTime AcquiredAt { get; set; }
}