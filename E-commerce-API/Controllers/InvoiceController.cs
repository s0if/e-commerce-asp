using E_commerce_API.HelperFunctions;
using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }
        [HttpPost("create")]
        public async Task<IActionResult> createInvoice()
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token Is Missing");
            int? userId = ExtractClaims.ExtractUserId(token);
            string createInvoice = await invoiceRepository.CreateInvoiceAsync(((int)userId));
            if (createInvoice is  null) 
            {
                return BadRequest("no item in the cart to create invoices");
            }
            return Ok(createInvoice);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> getInvoice(int invoiceId)
        {    if (ModelState.IsValid) 
            {
            
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token Is Missing");
            int? userId = ExtractClaims.ExtractUserId(token);
            InvoiceReceiptDTOs receipt = await invoiceRepository.GetInvoiceReceiptAsync(((int)userId), invoiceId);
            if (receipt is not null) { 
                return Ok(receipt);
            }
            return BadRequest(receipt);
            }
        return NotFound();

        }

    }
}
