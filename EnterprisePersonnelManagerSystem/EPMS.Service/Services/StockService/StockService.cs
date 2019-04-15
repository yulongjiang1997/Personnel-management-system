using AutoMapper;
using EPMS.Model.Dto;
using EPMS.Model.Dto.Stocks;
using EPMS.Model.Enums;
using EPMS.Model.Model;
using EPMSEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.StockService
{
    public class StockService : IStockService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public StockService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnData<bool>> CreateAsync(AddStockDto model)
        {
            var result = new ReturnData<bool>();
            var stock = await _context.Stocks.FirstOrDefaultAsync(i => i.PrductId == model.ProductId);
            if (stock != null)
            {
                result.Message = "已存在库存请进行出入库操作";
                result.Result = false;
                return result;
            }
            stock = new Model.Model.Stock()
            {
                PrductId = model.ProductId,
                Number = model.Number
            };
            _context.Stocks.Add(stock);
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public Task<ReturnData<bool>> CreateStockAccessAsync(AddStockAccessDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(i => i.Id == id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReturnData<bool>> EditAsync(int id, EditStockDto model)
        {
            var result = new ReturnData<bool>();
            var stock = await _context.Stocks.FirstOrDefaultAsync(i => i.Id == id);
            if (stock != null)
            {
                if (model.InOrOut == InAndOutStockType.In)
                {
                    stock.Number += model.Number;
                    _context.InAndOutStockDetaileds.Add(new InAndOutStockDetailed
                    {
                        InAndOutStockType = Model.Enums.InAndOutStockType.In,
                        Number = model.Number,
                        StockId = stock.Id,
                        SurplusStock = stock.Number
                    });
                }
                if (model.InOrOut == InAndOutStockType.Out)
                {
                    if (stock.Number - model.Number < 0)
                    {
                        result.Message = "库存不足，操作失败";
                        result.Result = false;
                        return result;
                    }
                    stock.Number -= model.Number;
                    _context.InAndOutStockDetaileds.Add(new InAndOutStockDetailed
                    {
                        InAndOutStockType = Model.Enums.InAndOutStockType.Out,
                        Number = model.Number,
                        StockId = stock.Id,
                        SurplusStock = stock.Number
                    });
                }
            }

            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<ReturnPagin<List<ReturnStockAccessDto>>> QueryPaginStockRecordAsync(SelectStockAccessDto model)
        {
            var result = new ReturnPagin<List<ReturnStockAccessDto>>();
            var stockAccess = _context.InAndOutStockDetaileds.Include(i => i.Stock.Product).AsNoTracking();
            if (model.StockId.HasValue)
            {
                stockAccess = stockAccess.Where(i => i.StockId == model.StockId);
            }
            result.Page = model.Page;
            result.Number = model.Number;
            result.Count = await stockAccess.CountAsync();
            result.Items = await stockAccess.Select(i => new ReturnStockAccessDto
            {
                InAndOutStockType = i.InAndOutStockType,
                Number = i.Number,
                StockProductName = i.Stock.Product.Name,
                SurplusStock = i.SurplusStock,
                CreateTime = i.CreateTime
            }).ToListAsync();
            return result;
        }

        public async Task<ReturnPagin<List<ReturnStockDto>>> QueryPaginStockAsync(SelectStockDto model)
        {
            var result = new ReturnPagin<List<ReturnStockDto>>();
            var stocks = _context.Stocks.Include(i => i.Product).AsNoTracking();
            if (model.ProductId.HasValue)
            {
                stocks = stocks.Where(i => i.PrductId == model.ProductId);
            }
            result.Count = await stocks.CountAsync();
            result.Number = model.Number;
            result.Page = model.Page;
            result.Items = _mapper.Map<List<ReturnStockDto>>(await stocks.Pagin(model).ToListAsync());
            return result;

        }
    }

}
