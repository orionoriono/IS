using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MusicEShop.Domain.DomainModels;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;

public class PaymentController : Controller
{
    private readonly StripeSettings _stripeSettings;

    public PaymentController(IOptions<StripeSettings> stripeSettings)
    {
        _stripeSettings = stripeSettings.Value;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        ViewBag.PublishableKey = _stripeSettings.PublishableKey;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCheckoutSession()
    {
        if (TempData["CheckoutOptions"] != null)
        {
            var options = JsonConvert.DeserializeObject<SessionCreateOptions>(TempData["CheckoutOptions"].ToString());

         options.SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme);
        options.CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme);

        try
        {
            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return Json(new { id = session.Id });
        }
        catch (StripeException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
        return BadRequest("Checkout options are missing.");

    }
    public IActionResult Success()
    {
        return View();
    }

    public IActionResult Cancel()
    {
        return View();
    }
}