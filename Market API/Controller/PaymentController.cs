using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Market_API.Interface;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Market_API.Dto;
using Market_API.Models;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace Market_API.Controllers
{
    [Route("api/[payment]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Payment>))]
        public IActionResult GetPayments()
        {
            var payments = _mapper.Map<List<PaymentDto>>(_paymentRepository.GetPayments());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(payments);
        }

        [HttpGet("{paymentId}")]
        [ProducesResponseType(200, Type = typeof(Payment))]
        [ProducesResponseType(400)]
        public IActionResult GetPayment(int paymentId)
        {
            if (!_paymentRepository.PaymentExists(paymentId))
                return NotFound();

            var payment = _mapper.Map<PaymentDto>(_paymentRepository.GetPayment(paymentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(payment);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePayment([FromBody] PaymentDto paymentCreate)
        {
            if (paymentCreate == null)
                return BadRequest(ModelState);

            var payment = _paymentRepository.GetPayments().FirstOrDefault();

            if (payment != null)
            {
                ModelState.AddModelError("", "Payment already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentMap = _mapper.Map<Payment>(paymentCreate);

            if (!_paymentRepository.CreatePayment(paymentMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{paymentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePayment(int paymentId, [FromBody] PaymentDto updatedPayment)
        {
            if (updatedPayment == null)
                return BadRequest(ModelState);

            if (paymentId != updatedPayment.PaymentId)
                return BadRequest(ModelState);

            if (!_paymentRepository.PaymentExists(paymentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var paymentMap = _mapper.Map<Payment>(updatedPayment);

            if (!_paymentRepository.UpdatePayment(paymentMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{paymentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePayment(int paymentId)
        {
            if (!_paymentRepository.PaymentExists(paymentId))
            {
                return NotFound();
            }

            var paymentToDelete = _paymentRepository.GetPayment(paymentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_paymentRepository.DeletePayment(paymentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
