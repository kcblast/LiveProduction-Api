using AutoMapper.Configuration;
using LiveProduction_Api.Core.InterfaceServices;
using LiveProduction_Api.Core.Models;
using LiveProduction_Api.Core.ViewModels;
using LiveProduction_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveProduction_Api.Core.Models.Utility;

namespace LiveProduction_Api.Domain
{
    public class AdminManager : IAdminManager
    {
        private readonly LiveProductionDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public AdminManager(LiveProductionDbContext context, IConfiguration configuration, IEmailService emailService, ILogger logger)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Tuple<string, object>> ApproveProduct(int productCode)
        {

            var update = await _context.Products.Where(x => x.ProductCode == productCode).FirstOrDefaultAsync();
            if (update == null)
            {
                return new Tuple<string, object>(StatusMessage.NOT_FOUND, null);
            }
            else
            {
                if (update.Status == Utility.ProductStatus.Pending)
                {
                    update.Status = ProductStatus.Approved;

                    string emailFor = "ApprovedProduct";


                    var save = await _context.SaveChangesAsync();
                    if (save > 0)
                    {
                        _emailService.ProductMessage(update, emailFor);
                    }
                    return new Tuple<string, object>(StatusMessage.Ok, update);
                }
            }
            return new Tuple<string, object>(StatusMessage.PROCESS_FAILED, null);
        }

        public async Task<Tuple<string, object>> DisapproveProduct(int productCode)
        {
            var update = await _context.Products.Where(x => x.ProductCode == productCode).FirstOrDefaultAsync();

            if (update == null)
            {
                return new Tuple<string, object>(StatusMessage.NOT_FOUND, null);
            }
            else
            {
                string emailFor = "DisapprovedProduct";

                _context.Products.Remove(update);
                var save = await _context.SaveChangesAsync();
                if (save > 0)
                {
                    _emailService.ProductMessage(update, emailFor);
                }
                return new Tuple<string, object>(StatusMessage.Ok, update);
            }

        }


        public async Task<Tuple<string, object>> DeleteProduct(Guid id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return new Tuple<string, object>(StatusMessage.NOT_FOUND, null);
            }
            else
            {
                var save = await _context.SaveChangesAsync();
                if (save > 0)
                {
                    return new Tuple<string, object>(StatusMessage.Ok, product);
                }
                return new Tuple<string, object>(StatusMessage.PROCESS_FAILED, null);
            }
        }



        //public async Task<Tuple<string, object>> GetBuyerAsync(Guid UserId)
        //{
            
        //}

        public Task<Tuple<string, ProductDTO>> GetProduct()
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<string, object>> GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<string, object>> GetProductByName(string Productname)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<string, object>> GetRequsts()
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<string, object>> GetSellerAsync(Guid UserId)
        {
            try
            {
                var seller = await _context.Sellers.Where(x => x.UserId == UserId).Include(x =>
                x.User).FirstOrDefaultAsync();

                SellerDTO newObj = new SellerDTO
                {

                    FirstName = seller.FirstName,
                    LastName = seller.LastName,
                    PhoneNumber = seller.PhoneNumber,
                    Email = seller.Email,
                    ShopAddress = seller.Address,
                    CompanyName = seller.CompanyName
                };
                
                if (newObj == null)
                {
                    return new Tuple<string, object>(StatusMessage.NOT_FOUND, null);
                }
                return new Tuple<string, object>(StatusMessage.Ok, newObj);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
   
}
