namespace MegaOneMvc.ViewModels.Deal
{
    public class CreateDealVM
    {
        public string DealName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImgFile { get; set; }

    }
}
