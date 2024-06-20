namespace KolosTest2.DTOs;

public class ResponseAddItemsToBackpackCharacterDTO
{
    public IEnumerable<BackpackClientDTO> Backpack { get; set; }
}

public class BackpackClientDTO
{
    public int Amount { get; set; }
    public int ItemId { get; set; }
    public int CharacterId { get; set; }
}