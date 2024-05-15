using NOS.Engineering.Challenge.Database;
using NOS.Engineering.Challenge.Models;

namespace NOS.Engineering.Challenge.Managers;

public class ContentsManager : IContentsManager
{
    private readonly IDatabase<Content?, ContentDto> _database;

    public ContentsManager(IDatabase<Content?, ContentDto> database)
    {
        _database = database;
    }

    public Task<IEnumerable<Content?>> GetManyContents()
    {
        return _database.ReadAll();
    }

    public Task<Content?> CreateContent(ContentDto content)
    {
        return _database.Create(content);
    }

    public Task<Content?> GetContent(Guid id)
    {
        return _database.Read(id);
    }

    public Task<Content?> UpdateContent(Guid id, ContentDto content)
    {
        return _database.Update(id, content);
    }

    public Task<Guid> DeleteContent(Guid id)
    {
        return _database.Delete(id);
    }

    public Task<Guid> AddGenres(Guid id, IEnumerable<string> genre)
    {
        ContentDto d = _database.Read(id);
        IEnumerable<string> aux = d.GenreList.get(genre);
        aux.add(genre);
        d.GenreList.set(genre);
        return _database.Update(id,d);
    }

    public Task<Guid> RemoveGenres(Guid id, IEnumerable<string> genre)
    {
        ContentDto d = _database.Read(id);
        IEnumerable<string> aux = d.GenreList.get(genre);
        aux.delete(genre);
        d.GenreList.set(genre);
        return _database.Update(id,d);
    }
}