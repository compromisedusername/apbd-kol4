using System.Transactions;
using KolosTest2.DTOs;
using KolosTest2.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KolosTest2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{

    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("/api/{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpackCharacter(int characterId, List<int> itemsId)
    {
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                var result = await _dbService.AddItemsToBackpackCharacter(characterId, itemsId);
                if (result is null)
                {
                    return BadRequest(new ExceptionDTO()
                    {
                        Message = "Character does not exist",
                        StatusCode = 404
                    });
                }
                scope.Complete();
                return Ok(result);

            }
            catch (DomainException de)
            {
                return BadRequest(new ExceptionDTO()
                {
                    Message = de.Message,
                    StatusCode = de.StatusCode
                });
            }

            
        }

        
    }
    


    [HttpGet("{characterId:int}")]
    public async Task<IActionResult> GetCharacterData(int characterId)
    {
        try
        {
            var res = await _dbService.GetCharacterData(characterId);
            return Ok(res);
        }
        catch (DomainException e)
        {
            return BadRequest(new ExceptionDTO()
            {
                StatusCode = e.StatusCode,
                Message = e.Message
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ExceptionDTO()
            {
                StatusCode = 500,
                Message = e.Message
            });
        }

        

    }
    
}