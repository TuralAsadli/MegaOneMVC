namespace MegaOneMvc.Models.Entities
{
    public class Booking : BaseItem
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
    }
}
