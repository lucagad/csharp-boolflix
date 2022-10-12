public class MediaInfo
{
    public int Id { get; set; }
    public string Year { get; set; }
    public bool IsNew { get; set; }
    
    public int? TVSeriesId { get; set; }
    public TVSeries? Serie { get; set; }
    
    public int? FilmId { get; set; }
    public Film? Film { get; set; }
    
    public List<Actor> Cast { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Feature> Features { get; set; }


}