using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Services;
using PaymentGateway.Shared;
using PaymentGateway.Shared.DTOs.Requests;

namespace PaymentGateway.Controllers
{

    [ApiController]
    [Route("api")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("payment")]
        public async Task<IActionResult> Pay([FromBody] PaymentRequest request)
        {
            if (request.Amount <= 0) return BadRequest("Amount must be > 0");

            var res = await _service.ProcessPaymentAsync(request);
            if (res.Status == PaymentStages.SUCCESS.ToString()) return Ok(res);
            return BadRequest(res);
        }

        [Authorize]
        [HttpPost("refund")]
        public async Task<IActionResult> Refund([FromBody] RefundRequest request)
        {
            var res = await _service.ProcessRefundAsync(request);
            if (res.Status == PaymentStages.SUCCESS.ToString()) return Ok(res);
            return BadRequest(res);
        }

        [Authorize]
        [HttpGet("status/{transactionId}")]
        public async Task<IActionResult> Status(string transactionId)
        {
            var res = await _service.GetStatusAsync(transactionId);
            if (res == null) return NotFound();
            return Ok(res);
        }
    }
}