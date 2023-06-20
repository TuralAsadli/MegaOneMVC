using MegaOneMvc.Models.Commands.Bookings;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Deal;

namespace MegaOneMvc.ViewModels.Food
{
    public class IndexPageVm
    {
        public List<GetFoodVM> Foods { get; set; }  
        public IEnumerable<GetCategoryVM> Categories { get; set; }

        public IEnumerable<GetDealVM> Deals { get; set; }

        public CreateBookingCommand? Booking { get; set; }
    }
}
