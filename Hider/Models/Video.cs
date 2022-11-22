
namespace Hider.Models;

public class Video
{
    [PrimaryKey,AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public string WebUrl { get; set; }
    public string Path { get; set; }
    public double DownloadeedPercentage { get; set; }
    public int Position { get; set; }
}
