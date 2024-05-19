using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LightScience.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        // GET: Contato
        public IActionResult Contato()
        {
            return View();
        }

        // POST: Contato/Enviar
        [HttpPost]
        public async Task<IActionResult> Enviar(string Nome, string Email, string Assunto, string Mensagem)
        {
            // Configuração do serviço de email
            var destinatario = "lucas.cgoncalves7@gmail.com"; // Substitua pelo seu endereço de email
            var corpoEmail = $"<h2>Formulário de Contato</h2><p><strong>Nome:</strong> {Nome}</p><p><strong>Email:</strong> {Email}</p><p><strong>Assunto:</strong> {Assunto}</p><p><strong>Mensagem:</strong> {Mensagem}</p>";

            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(destinatario));
                message.From = new MailAddress("no-reply@lightscience.com"); // Endereço do remetente
                message.Subject = Assunto;
                message.Body = corpoEmail;
                message.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient("smtp.gmail.com")) // Configure seu servidor SMTP
                {
                    smtpClient.Port = 587; // Configure a porta SMTP
                    smtpClient.Credentials = new System.Net.NetworkCredential("lightscense@gmail.com", "xzyi qdlj ffac zwwa"); // Configure as credenciais SMTP
                    smtpClient.EnableSsl = true; // Ative SSL se necessário
                    await smtpClient.SendMailAsync(message);
                }

                ViewBag.Message = "Mensagem enviada com sucesso!";
            }
            catch (System.Exception ex)
            {
                ViewBag.Message = $"Erro ao enviar a mensagem: {ex.Message}";
            }

            return View("Index");
        }
    }
}

