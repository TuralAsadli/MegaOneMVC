namespace MegaOneMvc.ViewModels.Deal
{
    public class GetDealVM
    {
        public Guid Id { get; set; }
        public string DealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgPath { get; set; }
    }
}
