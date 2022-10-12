using csharp_boolflix.Models;

namespace csharp_boolflix.Models
{
    public class MediaContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RunningTime { get; set; }
        public string Description { get; set; }
        public int VisualizationCount { get; set; }
    }
}

public class TVSeries : MediaContent
{
    public int NumberOfSeasons { get; set; }
    public int NumberOfEpisodes { get; set; }
    public MediaInfo MediaInfo { get; set; }
    public List<Episode> Episodes { get; set; }
}
public class Film : MediaContent
{
    public MediaInfo MediaInfo { get; set; }

}
public class Episode : MediaContent
{
    public int SeasonNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public int TVSeriesId { get; set; }
    public TVSeries TVSerie { get; set; }
}