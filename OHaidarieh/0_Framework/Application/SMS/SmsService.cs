using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Nest;
//using SmsIrRestful;

namespace _0_Framework.Application.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Send(string reciver, string message)
        {
            var sender = "1000596446";
            var Receptor = reciver;
            var Message = message;
            var api = new Kavenegar.KavenegarApi("50414532787376704463362B32575133554D7975442B3471504E6533646477426A6F5A484A61396435346F3D");
            api.Send(sender, Receptor, Message);

        }
    }
}