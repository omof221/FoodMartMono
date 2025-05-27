using FoodMartMono.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp; 
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace FoodMartMono.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {

            if (string.IsNullOrWhiteSpace(mailRequest.ReceiverMail))
            {
                ModelState.AddModelError("ReceiverMail", "E-posta adresi boş olamaz.");
                return RedirectToAction("Index", "Default");
            }


            var mimeMessage = new MimeMessage();





            var mailboxAddressFrom = new MailboxAddress("FoodmartAdminFirst","omeryasar921@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);   //kullanıcıya mail sana bak buradan geliyor demek için kullanılır bu kısım
             
         var mailboxAddressTo=new MailboxAddress(mailRequest.Name, mailRequest.ReceiverMail);    
           mimeMessage.To.Add(mailboxAddressTo); //mail gidicek kullanıcı adresi ve adı 

            mimeMessage.Subject = "Tebrikler %90 indirim kazandınız";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
<div style='font-family: Arial, Helvetica, sans-serif; background-color: #f8f9fa; padding: 20px; border-radius: 10px; color: #212529;'>
    <h2 style='color: #007bff;'>Merhaba {mailRequest.Name}, sizi mutlu edecek bir haberimiz var!</h2>
    <p>FoodMart ailesi olarak size özel <strong>%25 hoş geldin indirimi</strong> tanımladık.</p>
    <p>İlk siparişinizde bu kuponu kullanarak tasarruf etmeye hemen başlayabilirsiniz.</p>
    <div style='margin: 20px 0; padding: 10px 20px; background-color: #fff3cd; border-left: 5px solid #ffc107; display: inline-block;'>
        <strong style='font-size: 20px;'>KUPON KODUNUZ: <span style='color: #dc3545;'>FOOD25</span></strong>
    </div>
    <p>Alışverişe başlamak için hemen <a href='https://foodmart.com' style='color: #28a745; text-decoration: underline;'>web sitemizi</a> ziyaret edin ve fırsatları kaçırmayın!</p>
    <hr style='margin: 20px 0; border: none; border-top: 1px solid #dee2e6;' />
    <p style='font-size: 14px;'>Bu kampanya yalnızca sınırlı bir süre için geçerlidir.</p>
    <p>Sevgilerimizle,<br><strong>FoodMart Ekibi</strong></p>
</div>";







            mimeMessage.Body = bodyBuilder.ToMessageBody(); //body kısmı mailin içeriği
            using var SmtpClient = new SmtpClient(); //smtp ayarları
            SmtpClient.Connect("smtp.gmail.com",587, MailKit.Security.SecureSocketOptions.StartTls);
            SmtpClient.Authenticate("omeryasar921@gmail.com", "16harflibağlantısifresi");
            SmtpClient.Send(mimeMessage); //maili gönderme işlemi
            SmtpClient.Disconnect(true); //bağlantıyı kesme işlemi  

            TempData["Success"] = "Mail başarıyla gönderildi!"; //mail gönderildiğinde kullanıcıya mesaj gösterme   
            return RedirectToAction("Index","Default"); //mail gönderildikten sonra tekrar index sayfasına yönlendirme işlemi 
        }
    }
}
