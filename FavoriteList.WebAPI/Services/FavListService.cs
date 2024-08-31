using FavoriteList.WebAPI.Repositories;
using FavortieList.WebAPI.Models;

namespace FavoriteList.WebAPI.Services;

public sealed class FavListService(FavListRepository favListRepository)
{
    public async Task<List<FavList>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await favListRepository.GetAllAsnyc(cancellationToken);
        return response.OrderByDescending(f => f.Star).ToList();
    }

    public async Task CreateAsync(string contentType, string name, byte star, CancellationToken cancellationToken = default)
    {
        FavList favList = new()
        {
            ContentType = contentType,
            Name = name,
            Star = star
        };
        await favListRepository.CreateAsync(favList, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, string contentType, string name, byte star, CancellationToken cancellationToken = default)
    {

        FavList? favList = await favListRepository.GetByIdAsync(id, cancellationToken);

        if (favList == null)
        {
            throw new ArgumentNullException("Liste boş");
        }

        favList.ContentType = contentType;
        favList.Name = name;
        favList.Star = star;

        await favListRepository.UpdateAsync(favList, cancellationToken);
    }

    public async Task DeleteById(Guid id, CancellationToken cancellationToken = default)
    {
        FavList? favList = await favListRepository.GetByIdAsync(id, cancellationToken);

        if (favList == null)
        {
            throw new ArgumentNullException("Liste boş");
        }

        await favListRepository.DeleteByIdAsync(favList, cancellationToken);
    }
}