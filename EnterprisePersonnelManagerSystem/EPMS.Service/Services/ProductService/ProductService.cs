using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto;
using EPMS.Model.Dto.Products;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public ProductService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(AddProductDto model)
        {
            var result = new ReturnData<bool>();
            var products = await _context.Products.FirstOrDefaultAsync(i => i.Number == model.Number);
            if (products != null)
            {
                result.Message = "存在相同商品，添加失败";
                result.Result = false;
                return result;
            }
            _context.Products.Add(new Model.Model.Product
            {
                Number = model.Number,
                Price = model.Price,
                Name = model.Name,
                CreateTime = DateTime.Now,
                LastUpTime = DateTime.Now
            });
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var products = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, EditProductDto model)
        {
            var result = new ReturnData<bool>();
            var check = await _context.Products.FirstOrDefaultAsync(i => i.Number == model.Number);
            if (check != null)
            {
                result.Message = "存在相同编码，修改失败";
                result.Result = false;
                return result;
            }
            var products = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (products != null)
            {
                var checktime = await CheckTimeOut.Check(products.LastUpTime, model.LastUpTime);
                if (!checktime.Success)
                {
                    return checktime;
                }
                products.Name = model.Name;
                products.LastUpTime = DateTime.Now;
                products.Price = model.Price;
                products.Number = model.Number;
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<ReturnPagin<List<ReturnProductDto>>> QueryPaginAsync(SelectProductDto model)
        {

            var result = new ReturnPagin<List<ReturnProductDto>>();

            var products = _context.Products.AsNoTracking();

            if (!string.IsNullOrEmpty(model.Name))
            {
                products = products.Where(i => i.Name.Contains(model.Name));
            }

            if (!string.IsNullOrEmpty(model.ProductNumber))
            {
                products = products.Where(i => i.Number.Contains(model.ProductNumber));
            }

            if (model.BeginPrice.HasValue)
            {
                products = products.Where(i => i.Price >= model.BeginPrice);
            }

            if (model.EndPrice.HasValue)
            {
                products = products.Where(i => i.Price <= model.BeginPrice);

            }

            if (model.BeginTime.HasValue)
            {
                products = products.Where(i => i.CreateTime >= model.BeginTime);
            }

            if (model.EndTime.HasValue)
            {
                products = products.Where(i => i.CreateTime <= model.EndTime);
            }

            result.Items = await products.OrderByDescending(i => i.CreateTime).Pagin(model).Select(i => new ReturnProductDto
            {
                Number = i.Number,
                Price = i.Price,
                LastUpTime = i.LastUpTime,
                Name = i.Name,
                Id = i.Id

            }).ToListAsync();
            result.Count = await products.CountAsync();
            result.Number = model.Number;
            result.Page = model.Page;
            return result;
        }
    }
}
