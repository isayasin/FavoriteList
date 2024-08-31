using FavoriteList.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteList.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class FavListController(FavListService favListService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var response = await favListService.GetAllAsync(cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string contentType, string name, byte star, CancellationToken cancellationToken = default)
    {
        await favListService.CreateAsync(contentType, name, star, cancellationToken);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateByID(Guid id, string contentType, string name, byte star, CancellationToken cancellationToken = default)
    {
        await favListService.UpdateAsync(id, contentType, name, star, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken = default)
    {
        await favListService.DeleteById(id, cancellationToken);
        return Ok();
    }
}