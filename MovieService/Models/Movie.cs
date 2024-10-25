namespace MovieService.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string Language { get; set; }
        public string PosterUrl { get; set; }

        // Foreign key to Cast
        // List of Cast IDs associated with this movie
        public List<int> CastIds { get; set; } = new List<int>();
    }
}
