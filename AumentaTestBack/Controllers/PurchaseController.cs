using AumentaTestBack.Contracts;
using AumentaTestBack.DTO;
using AumentaTestBack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AumentaTestBack.Controllers
{
    [ApiController]
    //[Route("Product")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private IRepositoryWrapper _repository;

        public ProductController(ILogger<ProductController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //See Products List
        [Route("GetAllProducts")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            List<Product> products = _repository.Product.GetAllProducts().ToList();
            return Ok(products);
        }

        //See cart
        [Route("GetLastPurchase")] 
        [HttpGet]
        public IActionResult GetLastPurchase()
        {
            Purchase? purchase = _repository.Purchase.GetLastPurchase();
            if (purchase == null)
            {
                return BadRequest("A purchase object was not found in the DB");
            }
            return Ok(purchase);
        }

        //Add Product To Cart
        [Route("AddProductToCart")]
        [HttpPost]
        public IActionResult CreatePurchaseProduct(PurchaseProductForCreation purchaseProductForCreation)
        {
            //Check if last purchase exist and if it is finished
            Purchase purchase;
            Purchase? lastPurchase = _repository.Purchase.GetLastPurchase();
            if (lastPurchase == null || lastPurchase.Finished)
            {
                Purchase newPurchase = new Purchase() { Finished = false };
                _repository.Purchase.CreatePurchase(newPurchase);
                _repository.Save();
                purchase = newPurchase;
            }
            else
            {
                purchase = lastPurchase;
            }

            PurchaseProduct newPurchaseProduct = new PurchaseProduct()
            {
                PurchaseId = purchase.Id,
                ProductId = purchaseProductForCreation.ProductId,
                Amount = purchaseProductForCreation.Amount,
            };
            _repository.PurchaseProduct.CreatePurchaseProduct(newPurchaseProduct);
            _repository.Save();

            return Ok();
        }

        //Create Ticket
        [Route("FinishPurchase")]
        [HttpPut]
        public IActionResult FinishPurchase()
        {
            Purchase? lastPurchase = _repository.Purchase.GetLastPurchaseWithPurchaseProducts();
            if (lastPurchase == null)
            {
                return BadRequest("A purchase object was not found in the DB");
            }

            lastPurchase.Finished = true;
            _repository.Purchase.UpdatePurchase(lastPurchase);
            _repository.Save();

            List<PurchaseProductDTO> products = new List<PurchaseProductDTO>();
            foreach (var item in lastPurchase.PurchaseProducts)
            {
                ProductDTO product = item.Product.IsTaxesFree ? new TaxesFreeProductDTO() : new BasicProductDTO();

                product.Name = item.Product.Name;
                product.Price = item.Product.Price;
                product.FinalPrice = product.Price + product.GetTaxes();
                      
                products.Add(
                    new PurchaseProductDTO()
                    {
                        Amount = item.Amount,
                        Product = product
                    }
                );
            }

            TicketDTO ticket = new TicketDTO()
            {
                Total = products.Sum(p => p.GetFinalPrice()),
                Taxes = products.Sum(p => p.GetTaxes()),
                PurchaseProducts = products
            };

            return Ok(ticket);

        }
    }
}
