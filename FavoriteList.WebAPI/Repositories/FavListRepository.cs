using FavortieList.WebAPI.Context;
using FavortieList.WebAPI.Models;

namespace FavoriteList.WebAPI.Repositories;

public sealed class FavListRepository : Repository<FavList>
{
    public FavListRepository(ApplicationDbContext context) : base(context)
    {
    }
}
