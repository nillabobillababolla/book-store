using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        #region ApiMethods

        [Route("api/PostShop")]
        [HttpPost]
        public object PostShop(DtoShop model)
        {
            return _shopService.AddShop(model);
        }

        [Route("api/GetShop")]
        [HttpGet]
        public object GetShop(Guid ID)
        {
            return _shopService.GetShop(ID);
        }

        [Route("api/GetAllShops")]
        [HttpGet]
        public List<DtoShop> GetAllShops()
        {

            return _shopService.GetShops();
        }

        [Route("api/UpdateShop")]
        [HttpPut]
        public object UpdateShop(DtoShop model)
        {
            return _shopService.UpdateShop(model);
        }

        [Route("api/DeleteShop/{id}")]
        [HttpDelete]
        public bool DeleteShop(Guid id)
        {
            return _shopService.DeleteShop(id);
        }

        #endregion

    }
}