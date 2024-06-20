using System.ComponentModel.DataAnnotations;
using KolosTest2.Models;

namespace KolosTest2.DTOs;

public class ResponseGetCharacterDataDTO
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public int CurrentWeight { get; set; }
    [Required]
    public int MaxWeight { get; set; }
    public IEnumerable<BackpackDTO> BackpackItems { get; set; }= new List<BackpackDTO>();
    public IEnumerable<TitleDTO> Titles { get; set; } = new List<TitleDTO>();
}

public class TitleDTO
{
    [Required]
    public string Title { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime AquiredAt { get; set; }
    
}

public class BackpackDTO
{
    [Required]
    public string ItemName { get; set; }
    [Required]
    public int ItemWeight { get; set; }
    [Required]
    public int Amount { get; set; }
}