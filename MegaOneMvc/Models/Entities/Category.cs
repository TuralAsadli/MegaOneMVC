namespace MegaOneMvc.Models.Entities
{
    public class Category : BaseItem
    {
        public string CategoryName { get; set; }
        
        public string IconName { get; set; }

        public IEnumerable<Food> Foods { get; set; }
    }
}
