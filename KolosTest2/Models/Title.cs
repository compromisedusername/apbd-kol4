using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace KolosTest2.Models;

[Table("titles")]
public class Title
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();
}