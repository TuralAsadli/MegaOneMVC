﻿using AutoMapper;
using MegaOneMvc.Models.Commands.Categories;
using MegaOneMvc.Models.Commands.Deals;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.ViewModels.Category;
using MegaOneMvc.ViewModels.Deal;
using MegaOneMvc.ViewModels.Food;

namespace MegaOneMvc.Utilites.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetCategoryVM, Category>();
            CreateMap<CreateCategoryVM, Category>();
            CreateMap<Category, CreateCategoryVM>();
            CreateMap<Category, GetCategoryVM>();

            CreateMap<CreateDealVM, Deal>();
            CreateMap<GetDealVM, Deal>();
            CreateMap<Deal, GetDealVM>();
            CreateMap<Deal, CreateDealVM>();

            CreateMap<CreateFoodVM, Food>();
            CreateMap<GetFoodVM, Food>();
            CreateMap<Food, GetFoodVM>();
            CreateMap<Food, CreateFoodVM>();

            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<CreateDealCommand, Deal>();
            CreateMap<UpdateDealCommand, Deal>();
        }
    }
}