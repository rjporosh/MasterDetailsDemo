using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterDetailsDemo.Models;

namespace MasterDetailsDemo.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        OnlineShopEntities _db = new OnlineShopEntities();

        public ActionResult Index()
        {
            var orderAndCustomerList = _db.Customers.ToList();
            return View(orderAndCustomerList);
        }
        public ActionResult SaveOrder(string name, String address, Order[] order)
        {
            var result = "Error! Order Is Not Complete!";
            if (name == null || address == null || order == null) return Json(result, JsonRequestBehavior.AllowGet);
            var customerId = Guid.NewGuid();
            var model = new Customer
            {
                CustomerId = customerId, Name = name, Address = address, OrderDate = DateTime.Now
            };
            _db.Customers.Add(model);

            foreach (var item in order)
            {
                var orderId = Guid.NewGuid();
                var o = new Order
                {
                    OrderId = orderId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Amount = item.Amount,
                    CustomerId = customerId
                };
                _db.Orders.Add(o);
            }
            _db.SaveChanges();
            result = "Success! Order Is Complete!";
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}