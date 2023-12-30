using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.B_Structure_Patterns
{
    /* Decorator Pattern
     * ----------------
     * - the ability to add functionality to class without editing it mean not break princible (Open For Extend Closed For Modification) by using Decorator
     */

    #region SmsSenderService Decorator

    #region Old Class

    public interface ISmsSenderService
    {
        void SendSms(int userId, string mobile, string message);
    }

    public class SmsSenderService : ISmsSenderService
    {
        public void SendSms(int userId, string mobile, string message)
        {
            Console.WriteLine($"(SmsSenderService) => Sending Sms message ({message}) to number #{mobile} by user #{userId}");
        }
    }

    #endregion

    #region New Class Decorators 

    //we add new funcationality to class SmsService without editing SmsService Class just by using Decorator Pattern

    //Adding Email Feature To SmsSenderService without alter SmsSenderService Class
    public class SmsSenderServiceEmailingDecorator : ISmsSenderService
    {
        private readonly ISmsSenderService _smsSenderService;

        public SmsSenderServiceEmailingDecorator(ISmsSenderService smsSenderService)
        {
            _smsSenderService = smsSenderService;
        }

        public void SendSms(int userId, string mobile, string message)
        {
            //use old / original logic
            _smsSenderService.SendSms(userId, mobile, message);

            //add some logic
            Console.WriteLine("(SmsServiceEmailingDecorator) => we send email for sms message");
        }
    }

    //Adding Excetion Handeling Feature to SmsSenderService without Alter SmsSenderService class
    public class SmsSenderServiceExceptionHandelDecorator : ISmsSenderService
    {
        private readonly ISmsSenderService _smsSenderService;

        public SmsSenderServiceExceptionHandelDecorator(ISmsSenderService smsSenderService)
        {
            _smsSenderService = smsSenderService;
        }

        public void SendSms(int userId, string mobile, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(mobile))
                    throw new Exception("Mobile Number Required");

                //use old / original logic
                _smsSenderService.SendSms(userId, mobile, message);
            }
            catch (Exception ex)
            {
                //Hanel Exception Here
                Console.WriteLine($"(SmsSenderServiceExceptionHandelDecorator) => Handel Exception with Message ({ex.Message})");
            }
        }
    }

    #endregion



    #endregion
}
