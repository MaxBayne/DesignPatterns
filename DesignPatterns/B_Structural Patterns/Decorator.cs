using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.B_Structure_Patterns
{

    public abstract class AbstractDecorator: SmsService
    {
        protected ISmsService _smsService;

        public void SetService(ISmsService service)
        {
            _smsService = service;
        }
        

        public override string SendSms(int userId, string mobile, string message)
        {
            return _smsService.SendSms(userId, mobile, message);
        }
       
    }

    public class SendSmsWithEmailDecorator: AbstractDecorator
    {
        private string _emailAddress;

        public SendSmsWithEmailDecorator(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        private string SendEmail(string email,string message)
        {
            return $"email sent to {email} with message {message}";
        }

        public override string SendSms(int userId, string mobile, string message)
        {
            var stringBuilder = new StringBuilder();

            //Send Sms
            stringBuilder.AppendLine(base.SendSms(userId, mobile, message));

            //Send Email
            stringBuilder.AppendLine(SendEmail(_emailAddress,message));

            return stringBuilder.ToString();
        }
    }
}
