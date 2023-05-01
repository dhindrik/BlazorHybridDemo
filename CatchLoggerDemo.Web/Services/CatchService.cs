using System.Reflection;
using CatchLoggerDemo.Web.Entities;
using LiteDB;

namespace CatchLoggerDemo.Web.Services;

[GenerateAutoInterface]
public class CatchService : ICatchService
{
    public CatchService()
    {
    }

    public Task Save(CatchModel @catch)
    {
        var item = new Catch()
        {
            Id = @catch.Id,
            Created = DateTime.Now,
            Fish = @catch.Fish,
            Weight = @catch.Weight,
            Length = @catch.Length,
            Note = @catch.Note,
            Photos = @catch.Photos.Select(x => x.Id).ToList()
        };

        var collection = DB.GetCollection<Catch>("Catches");
        collection.Insert(item);

        foreach (var photo in @catch.Photos)
        {
            DB.FileStorage.Upload(photo.Id, photo.Filename, new MemoryStream(photo.Bytes));
        }

        return Task.CompletedTask;
    }

    public Task<List<CatchModel>> GetCatches()
    {
        var collection = DB.GetCollection<Catch>("Catches");
        var items = collection.Query().ToList();

        var result = items.Select(x => new CatchModel()
        {
            Id = x.Id,
            Fish = x.Fish,
            Created = x.Created,
            Length = x.Length,
            Weight = x.Weight,
            Photos = x.Photos.Select(y => new PhotoModel()
            {
                Id = y,
                Bytes = null!,
                Filename = null!
            }).ToList()
        }).ToList();

        foreach (var @catch in result.Where(x => x.Photos.Count > 0))
        {
            foreach (var photo in @catch.Photos)
            {

                using var stream = new MemoryStream();
                var info = DB.FileStorage.Download(photo.Id, stream);
                stream.Position = 0;

                photo.Bytes = stream.ToArray();
                photo.Filename = info.Filename;
            }
        }

        return Task.FromResult(result);
    }

    private static LiteDatabase? database;

    protected LiteDatabase DB => GetDatabase();

    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
    private LiteDatabase GetDatabase()
    {
        semaphoreSlim.Wait();

        if (database == null)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "catchlog.db");

            database = new LiteDatabase(path);
        }

        semaphoreSlim.Release();

        return database;
    }
}

