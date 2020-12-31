using MimeKit;
using MailKit.Net.Smtp;

namespace _0_Framework.Application.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("حیدریة النجف الاشرف", "emamzadeha@aol.com");
            message.From.Add(from);

            var to = new MailboxAddress("User", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<body style=\"margin: 0; padding: 0;\"><div class=\"main_container\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" bgcolor=\"#f98550\" background=\"img/hero_gradient.jpg\" style=\"height:450px; background-image: url('img/hero_gradient.jpg'); background-size: cover; -webkit-background-size: cover; -moz-background-size: cover -o-background-size: cover; background-position: 50% 50%; background-repeat: no-repeat;\">  <tr>   <td>   <table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\">   <tbody>   <tr>   <td width=\"100%\" height=\"40\"></td>   </tr>   <tr>   <td>   <!--  Logo  -->   <table border=\"0\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\">   <tbody>   <tr>   <td>   <a href=\"#\"><img src=\"img/logo.png\" alt=\"Holu\" border=\"0\" style=\"display: block;\"/> </a>   </td>   </tr>   </tbody>   </table>   </td>   </tr>   <tr>   <td height=\"169\"></td>   </tr>   <tr>   <td style=\"text-align:center; color: #fff; font-family: 'Droid Arabic Kufi', tahoma; font-weight:600; font-size: 36px; text-transform:uppercase; letter-spacing:3px;\">مراسم حیدریة النجف الاشرف</td>   </tr>   <tr>   <td height=\"133\"></td>   </tr>   <tr>   <td>   <table width=\"24\" align=\"center\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\">   <tr>   <td><img  width=\"24\" height=\"63\" src=\"img/mouse.png\" alt=\"Scroll Down\" border=\"0\" style=\"display:block;\"/></td>   </tr>   </table>   </td>   </tr>   </tbody>   </table>   </td>  </tr> </table><!--  features  --><table width=\"600\" align=\"center\" cellpadding=\"0\" border=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><!--  sppace  --><tr><td width=\"100%\" height=\"100\"></td></tr><!--  feature1  --><tr><td><table width=\"280\" align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"240\"><img src=\"img/feature1.png\" alt=\"\" border=\"0\" style=\"display: block;\"/></td></tr></tbody></table><!--  space  --><table width=\"40\" align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"40\"></td></tr></tbody></table><!--  feature2  --><table width=\"280\" align=\"right\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" ><tbody><tr><td  style=\"color: #555; font-family: 'Droid Arabic Kufi', tahoma; font-weight:600; font-size: 20px; text-transform:uppercase; line-height:28px;\">" +
                $"{messageBody}" +
                $"</tr></tbody></table></td></tr><!--  space  --><tr><td width=\"100%\" height=\"120\"></td></tr></tbody></table><!--  footer  --><table width=\"100%\" bgcolor=\"#f9823a\" cellpadding=\"0\" border=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td><table width=\"600\" align=\"center\" cellpadding=\"0\" border=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"40px\"></td></tr><tr><td><!--  footer logo  --><table  align=\"left\" cellpadding=\"0\" border=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td><img src=\"img/footer_logo.png\" alt=\"\" border=\"0\"/></td><td width=\"20\"></td><td><table cellpadding=\"0\" border=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tr><td width=\"100%\" height=\"16\"></td></tr><tr><td style=\"color: #fff; font-family: 'Droid Arabic Kufi'; font-size: 12px;\">© تمام حقوق محفوظ است</td></tr></table></td></tr></tbody></table><!--  footer social media  --><table align=\"right\" cellpadding=\"0\" border=\"0\" cellspacing=\"0\" style=\"border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;\"><tbody><tr><td width=\"100%\" height=\"8\"></td></tr><tr><td><a href=\"#\"><img src=\"img/facebook.png\" alt=\"facebook\" border=\"0\"/></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\"><img src=\"img/twitter.png\" alt=\"twitter\" border=\"0\"/></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\"><img src=\"img/google+.png\" alt=\"google+\" border=\"0\"/></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"#\"><img src=\"img/dribbble.png\" alt=\"dribbble\" border=\"0\"/></a></td></tr></tbody></table></td></tr><tr><td width=\"100%\" height=\"40px\"></td></tr></tbody></table></td></tr></tbody></table></div><p style=\"text-align:center; margin: 50px 0; color: #6B6B6B; font-size:13px; font-family: 'Droid Arabic Kufi', tahoma; font-weight:600;\">پوسته فارسی ایمیل توسط <a href=\"http://persianscript.ir\" style=\"color:#3f3f3f; text-decoration:none;\">حیدریة النجف الاشرف</a></p></body>",
            };

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            client.Connect("smtp.aol.com", 25, false);
            client.Authenticate("emamzadeha@aol.com", "hani3205");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}