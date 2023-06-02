namespace DesignPatterns.B_Structure_Patterns;

/// <summary>
/// Used To Access another Class and prevent access class directlly ,good for security and remote api
/// </summary>
public class Proxy
{
    private ISmsService _smsService;

    //cant access SendSms Directly Just use Proxy to access it
    public string SendSms(int userId, string mobile, string message)
    {
        if(_smsService==null) _smsService = new ConcreteSmsService();

        if(userId==1)
        {
            return _smsService.SendSms(userId,mobile,message);
        }
        else if (userId == 2)
        {
            return _smsService.SendSms(userId, mobile, message);
        }
        else
        {
            return "Sorry userId is Wrong , can not use this service";
        }
    }
}

public interface ISmsService
{
    abstract string SendSms(int userId,string mobile,string message);
}

public abstract class SmsService : ISmsService
{
    public abstract string SendSms(int userId, string mobile, string message);
}

public class ConcreteSmsService : SmsService
{
    public override string SendSms(int userId, string mobile, string message)
    {
        return $"UserId=({userId}) Send Sms Message ({message}) to Number ({mobile})";
    }
}