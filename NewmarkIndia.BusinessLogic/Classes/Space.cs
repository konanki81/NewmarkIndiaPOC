namespace NewmarkIndia.BusinessLogic.Classes
{
    public class Space
    {
        public string? SpaceId { get; set; }
        public string? SpaceName { get; set; }
        public IEnumerable< Rentroll>? RentRoll { get; set; }
    }
}
