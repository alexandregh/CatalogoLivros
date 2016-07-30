using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using CatalogoLivros.Domain.Entity;

namespace CatalogoLivros.Util.Email
{
    public class Email
    {
        #region Propriedades

        public static string Remetente { get { return "Catálogo de Livros Online."; } }
        public static string EmailRemetente { get { return "catalogolivrosonline@catalogolivrosonline.com.br"; } }
        public static string Destinatario { get; set; }
        public static string Assunto { get; set; }
        public static string Mensagem { get; set; }

        private static readonly string conta = "cotiexemplo@gmail.com";
        private static readonly string senha = "@coticoti@";
        private static readonly string smtp = "smtp.gmail.com";
        private static readonly int porta = 587;

        #endregion


        #region Métodos

        public static void SendEmail(Usuario usuario)
        {
            try
            {
                Destinatario = usuario.Email;
                Assunto = "Recuperação do Login.";
                Mensagem = "Olá <strong>" + usuario.Nome + "</strong>.<br />" +
                           "Recebemos uma solicitação de envio de seu Login. " +
                           "Segue-se abaixo a resposta de sua solicitação.<br /><br />" +
                           "Seu Login é: <strong>" + usuario.Login + "</strong>." +
                           "<br /><br /> Agradecemos seu contato para conosco." +
                           "<br /><br /> Atenciosamente, <br /> <strong>Catálogo de Livros Online</strong>";

                MailMessage msg = new MailMessage(conta, Destinatario);
                msg.Subject = Assunto;
                msg.Body = Mensagem;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;

                //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
                msg.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                msg.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //Passo 2) Enviar a mensagem..
                SmtpClient smtpClient = new SmtpClient(smtp, porta);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(conta, senha);
                //autenticação..

                //enviar o email..
                smtpClient.Send(msg);
                msg.Dispose();
            }
            catch (ObjectDisposedException ex)
            {
                throw new ObjectDisposedException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                throw new SmtpFailedRecipientsException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (SmtpException ex)
            {
                throw new SmtpException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
        }

        //_______________________________________________________________________

        public static void SendEmail(Usuario usuario, string[] dadosNovaSenha)
        {
            try
            {
                Destinatario = usuario.Email;
                Assunto = "Recuperação da Senha.";
                Mensagem = "Olá <strong>" + usuario.Nome + "</strong>.<br />" +
                           "Recebemos uma solicitação de envio de sua Nova Senha. " +
                           "Segue-se abaixo a resposta de sua solicitação.<br /><br />" +
                           "Sua Nova Senha é: <strong>" + dadosNovaSenha[0] + "</strong>.<br />" +
                           "Sua Criptografia da Senha é: <strong>" + dadosNovaSenha[1] + "</strong>." +
                           "<br /><br /> Agradecemos seu contato para conosco." +
                           "<br /><br /> Atenciosamente, <br /> <strong>Catálogo de Livros Online</strong>";

                MailMessage msg = new MailMessage(conta, Destinatario);
                msg.Subject = Assunto;
                msg.Body = Mensagem;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;

                //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
                msg.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                msg.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //Passo 2) Enviar a mensagem..
                SmtpClient smtpClient = new SmtpClient(smtp, porta);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(conta, senha);
                //autenticação..

                //enviar o email..
                smtpClient.Send(msg);
                msg.Dispose();
            }
            catch (ObjectDisposedException ex)
            {
                throw new ObjectDisposedException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                throw new SmtpFailedRecipientsException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (SmtpException ex)
            {
                throw new SmtpException("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu o seguinte erro no envio do email: " + ex.Message);
            }
        }

        #endregion
    }
}