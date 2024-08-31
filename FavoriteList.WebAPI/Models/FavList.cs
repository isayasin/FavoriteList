namespace FavortieList.WebAPI.Models;

public sealed class FavList
{
    public FavList()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }

    public string ContentType { get; set; } = default!;

    public string Name { get; set; } = default!;

    public byte Star { get; set; } = default;
}