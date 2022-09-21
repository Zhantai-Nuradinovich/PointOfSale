using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PointOfSale.Interfaces;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointOfSaleController : ControllerBase
    {
        private readonly IPointOfSaleTerminalService _terminal;

        public PointOfSaleController(IPointOfSaleTerminalService terminal)
        {
            _terminal = terminal;
        }

        [HttpGet(nameof(Shopping))]
        public IActionResult Shopping()
        {
            var purchaseId = _terminal.StartShopping();
            var response = new PurchaseInfo()
            {
                PurchaseId = purchaseId,
                Href = HttpContext.Request.Path,
                RouteName = nameof(Shopping),
                Method = Link.GetMethod,
                Scan = new Link()
                {
                    Method = Link.GetMethod,
                    Href = HttpContext.Request.PathBase + "/api/PointOfSale/" + nameof(Scan) + "/" + purchaseId + "/productCode", 
                    RouteName = nameof(Scan)
                }
            };
            return Ok(response);
        }

        //made method "HttpGet" to make it possible to execute from the browser
        [HttpGet(nameof(Scan) + "/{purchaseId}/{productCode}")]
        public IActionResult Scan(int purchaseId, string productCode)
        {
            _terminal.StartShopping(purchaseId);
            _terminal.Scan(productCode);
            var response = new ScanInfo()
            {
                Href = HttpContext.Request.Path,
                RouteName = nameof(Scan),
                RouteValues = new { purchaseId, productCode },
                Method = Link.PostMethod,
                TotalPrice = new Link()
                {
                    Method = Link.PostMethod,
                    Href = HttpContext.Request.PathBase + "/api/PointOfSale/" + nameof(TotalPrice),
                    RouteName = nameof(TotalPrice),
                    RouteValues = new TotalPriceRequest() { PurchaseId = purchaseId } 
                }
            };
            return Ok(response);
        }

        [HttpPost(nameof(TotalPrice))]
        public IActionResult TotalPrice([FromBody] TotalPriceRequest totalPriceRequest)
        {
            _terminal.SetPricing(totalPriceRequest.Prices);
            _terminal.StartShopping(totalPriceRequest.PurchaseId);
            var totalPrice = _terminal.CalculateTotal();
            var response = new TotalPriceInfo()
            {
                TotalPrice = totalPrice,
                Href = HttpContext.Request.Path,
                RouteName = nameof(TotalPrice),
                RouteValues = totalPriceRequest,
                Method = Link.GetMethod
            };
            return Ok(response);
        }
    }
}
