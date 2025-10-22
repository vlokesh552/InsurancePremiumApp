namespace InsuranceApp.Models
{
    public class Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RatingId { get; set; }
        public OccupationRating Rating { get; set; }
    }
}
