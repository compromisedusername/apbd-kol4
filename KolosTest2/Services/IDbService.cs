using KolosTest2.DTOs;
using KolosTest2.Models;

namespace KolosTest2.Services;

public interface IDbService
{

 Task<ResponseGetCharacterDataDTO> GetCharacterData(int characterId);
 Task<Character> GetCharacter(int characterId);

 Task<ResponseAddItemsToBackpackCharacterDTO> AddItemsToBackpackCharacter(int characterId, List<int> itemsId);

}