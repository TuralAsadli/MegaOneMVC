﻿namespace MegaOneMvc.Models.Entities
{
    public class Deal : BaseItem
    {
        public string DealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgPath { get; set; }
    }
}
