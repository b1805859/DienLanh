﻿using DienLanh_BackEnd.Models;
using JLPT_API.Common;
using Microsoft.AspNetCore.Mvc;
using WebAPI_JWT_NET6_Base.Services;

namespace DienLanh_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly S_Product _IProduct;

        public ProductController(S_Product IProduct)
        {
            _IProduct = IProduct;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                IEnumerable<Product> products = await Task.FromResult(_IProduct.GetProducts());

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = products });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }


        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var products = await Task.FromResult(_IProduct.GetProductDetails(id));

                if (products != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = products });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { ResultCode = C_Message.INF00003, Message = C_Message.getMessageByID(C_Message.INF00003) });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            try
            {
                bool result = await Task.FromResult(_IProduct.AddProduct(product));

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001), Data = product });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { ResultCode = C_Message.INF00003, Message = C_Message.getMessageByID(C_Message.INF00003) });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, Product product)
        {
            try
            {
                if (id != product.ProductID)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { ResultCode = C_Message.INF00003, Message = C_Message.getMessageByID(C_Message.INF00003) });
                }

                var result = await Task.FromResult(_IProduct.UpdateProduct(product));

                return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001) });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                bool result = await Task.FromResult(_IProduct.DeleteProduct(id));

                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new { ResultCode = C_Message.INF00001, Message = C_Message.getMessageByID(C_Message.INF00001) });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ResultCode = C_Message.ERR00007, Message = C_Message.getMessageByID(C_Message.ERR00007) });

            }
        }
    }
}
