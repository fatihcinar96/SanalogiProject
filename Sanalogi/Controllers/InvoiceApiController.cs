using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sanalogi.Models;
using Sanalogi.Models.Data;

namespace Sanalogi.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceApiController : ControllerBase
    {
        [HttpPost]
        public string AddInvoice(InvoiceCreateModel model)
        {
            if (ModelState.IsValid)
            {
                InvoiceModel invoice = new InvoiceModel();

                try
                {
                    invoice.Name = model.Name;
                    invoice.Surname = model.Surname;
                    invoice.Email = model.Email;
                    invoice.Phone = model.Phone;
                    invoice.Address = model.Address;
                    invoice.InvoiceDate = model.InvoiceDate;
                    invoice.InvoiceNo = model.InvoiceNo;
                    invoice.Products = model.Products;
                    decimal totalPrice = 0;
                    foreach (var item in model.Products)
                    {
                        totalPrice += item.UnitPrice * item.Piece;
                    }
                    invoice.TotalPrice = totalPrice;
                    using (var db = new SanalogiDbContext())
                    {
                        db.Invoices.Add(invoice);
                        db.SaveChanges();
                    }
                    return "Kayıt başarılı!";

                }
                catch (Exception ex)
                {
                    return "Kayıt başarısız:" + ex.Message;
                }

            }
            return "Hatalı bilgi girdiniz.";
        }

    }
}