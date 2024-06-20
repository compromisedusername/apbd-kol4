using System.Data;
using KolosTest2.Data;
using KolosTest2.DTOs;
using KolosTest2.Extensions;
using KolosTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace KolosTest2.Services;

public class DbService : IDbService
{
    private readonly ApplicationContext _applicationContext;

    public DbService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }


    public async Task<ResponseGetCharacterDataDTO> GetCharacterData(int characterId)
    {
        
        var character = await _applicationContext.Characters
            .Where(ch => ch.Id == characterId)
            .Include(e => e.Backpacks).ThenInclude(backpack => backpack.Item)
            .Include(e => e.CharacterTitles).ThenInclude(characterTitle => characterTitle.Title)
            .FirstOrDefaultAsync();
        
        if (character == null)
        {
            throw new DomainException()
            {
                Message = "Character not found!",
                StatusCode = 404
            };
        }

        Console.WriteLine(character.Backpacks.Count);
        Console.WriteLine(character.CharacterTitles.Count);
        return new ResponseGetCharacterDataDTO
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks.Select(e => new BackpackDTO
            {
                ItemName = e.Item.Name,
                ItemWeight = e.Item.Weight,
                Amount = e.Amount
            }).ToList(),
            Titles = character.CharacterTitles.Select(e => new TitleDTO
            {
                Title = e.Title.Name,
                AquiredAt = e.AcquiredAt
            }).ToList()
        };
    }

    public async Task<Character> GetCharacter(int characterId)
    {
        return await _applicationContext.Characters.FindAsync(characterId);
    }

    public async Task<ResponseAddItemsToBackpackCharacterDTO> AddItemsToBackpackCharacter(int characterId, List<int> itemsId)
    {
        var character = await GetCharacter(characterId);
        if (character == null)
        {
            throw new DomainException()
            {
                Message = "Charactyer does not exist",
                StatusCode = 404

            };
        }
        
        List<Item> items = new List<Item>();
        
        foreach (var x in itemsId)
        {
            var item = await GetItem(x);
            if (item == null)
            {
                throw new DomainException()
                {
                    Message = "Item does not exist!",
                    StatusCode = 404
                };
            }
            items.Add(item);
        }

        var itemsWeight = items.Sum(e => e.Weight);

        if (itemsWeight > (character.MaxWeight - character.CurrentWeight))
        {
            throw new DomainException()
            {
                Message = "Character dont have enough load capacity.",
                StatusCode = 400
            };
        }


        var backpacks = new List<Backpack>{};
        foreach (var item in items)
        {
            var addItem = await IfItemAlreadyInBackPackChangeAmountElseAddBackpack(characterId, item);
            backpacks.Add(addItem);
        }

        
        character.CurrentWeight += itemsWeight;
        
        _applicationContext.Characters.Update(character);

       await _applicationContext.SaveChangesAsync();
       
        return new ResponseAddItemsToBackpackCharacterDTO()
        {
            Backpack = backpacks.Select( e => new BackpackClientDTO()
            {
                Amount = e.Amount,
                CharacterId = e.CharacterId,
                ItemId = e.ItemId
            })
        };
    }

    private async Task<Item> GetItem(int itemId)
    {
        return await _applicationContext.Items.FirstOrDefaultAsync(e => e.Id == itemId);
    }

    private async Task<Backpack> IfItemAlreadyInBackPackChangeAmountElseAddBackpack(int characterId, Item item)
    {
        var existingBackpack = await _applicationContext.Backpacks.FirstOrDefaultAsync(e => e.CharacterId == characterId && e.ItemId == item.Id);
        if (existingBackpack is not null)
        {
            existingBackpack.Amount += 1;
            _applicationContext.Backpacks.Update(existingBackpack);
            return existingBackpack;
        }
        else{
            var newBackpack =  new Backpack()
            {
                Amount = 1,
                CharacterId = characterId,
                ItemId = item.Id
            };
            await _applicationContext.Backpacks.AddAsync(newBackpack);
            return newBackpack;
        }
    }
}


