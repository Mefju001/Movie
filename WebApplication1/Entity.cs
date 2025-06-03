public class Movie
{
    public int Id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public Genre genre { get; set; }
    public Director director  { get; set; }
    public List<Review> reviews { get; set; }
}
public class Genre
{
    public int Id { get; set; }
    public string name { get; set; }
}
public class Director
{
    public int Id {  set; get; }
    public string name { get; set; }
    public string surname { get; set; }
}
public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; } // np. 1-10
    public string Comment { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }

   // public string UserId { get; set; }
    //public AppUser User { get; set; }
}