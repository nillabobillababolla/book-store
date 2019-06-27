using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services
{
    public class ShopService : EFRepository<Shop>, IShopService
    {
        private BookDbContext _context;

        public ShopService(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public object PostShop(DtoShop model)
        {
            if(model == null)
            {
                return new DtoShop();
            }

            var checkShop = _context.Shop.Where(c => c.Name == model.ShopName).Any();

            if (checkShop)
            {
                return false;
            }

            Shop shop = new Shop();
            shop.Name = model.ShopName;
            shop.Location = model.Location;
            shop.StaffCount = model.StaffCount;

            this.Add(shop);
            this.Save();

            model.ShopId = shop.Id;

            return model;
        }

        public bool DeleteShop(Guid id)
        {
            if(id == null)
            {
                return false;
            }

            Shop shop = this.GetById(id);

            this.Delete(shop);
            this.Save();

            return true;
        }

        public DtoShop GetShop(Guid id)
        {
            if(id == null)
            {
                return new DtoShop();
            }

            var shop = this.GetById(id);

            DtoShop model = new DtoShop();
            model.ShopName = shop.Name;
            model.Location = shop.Location;
            model.StaffCount = shop.StaffCount;
            model.ShopId = shop.Id;

            return model;
        }

        public List<DtoShop> GetShops()
        {
            var shops = this.GetAll();

            if(shops == null || shops.Count() == 0)
            {
                return new List<DtoShop>();
            }

            var allShops = shops.Select(c => new DtoShop()
            {
                ShopId = c.Id,
                ShopName = c.Name,
                Location = c.Location,
                StaffCount = c.StaffCount
            }).ToList();

            return allShops;
        }

        public object UpdateShop(DtoShop model)
        {
            if(model == null)
            {
                return new DtoShop();
            }

            var checkShop = _context.Shop.Where(c => c.Name == model.ShopName).Any();

            if (checkShop)
            {
                return false;
            }

            Shop shop = this.GetById(model.ShopId);
            shop.Id = model.ShopId;
            shop.Name = model.ShopName;
            shop.Location = model.Location;
            shop.StaffCount = model.StaffCount;

            this.Update(shop);
            this.Save();

            return model;
        }
    }
}