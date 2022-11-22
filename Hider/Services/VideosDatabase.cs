

namespace Hider.Services;

public static class VideosDatabase
{
    static SQLiteAsyncConnection db;
    static async Task Init()
    {
        if (db != null)
            return;
        var path = Path.Combine(FileSystem.AppDataDirectory, "videos.db");
        db = new SQLiteAsyncConnection(path);
        await db.CreateTableAsync<Video>();
    }
    public static async Task AddVideo(Video video)
    {
        await Init();
        await db.InsertAsync(video);
    }
    public static async Task RemoveVideo(int id)
    {
        await Init();
        await db.DeleteAsync<Video>(id);
    }
    public static async Task<IEnumerable<Video>> GetVideosAsync()
    {
        await Init();
        var result = await db.Table<Video>().ToListAsync();
        return result;
    }
    public static async Task UpdateVideoAsync(Video video)
    {
        await Init();
        db.UpdateAsync(video);
    }
}
