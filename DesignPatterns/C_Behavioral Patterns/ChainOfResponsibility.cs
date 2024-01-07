namespace DesignPatterns.C_Behavioral_Patterns
{
    /*
     * Chain Of Responsibility
     * -----------------------
     * its use case for request that will move over chain of handlers and only one handler can process this request depend on some rules
     * Middleware is example of Chain of Responsibility
     */

    #region Vacation Request Chain Of Responsibility

    #region Request

    public enum RequestType
    {
        TeamLeader,
        TechnicalLeader,
        CTO,
        CEO
    }

    public interface IRequest
    {
        RequestType RequestType { get; }
    }

    public abstract class Request : IRequest
    {
        public RequestType RequestType { get; private set; }

        public Request(RequestType requestType)
        {
            RequestType = requestType;
        }
    }



    public class VacationRequest : Request
    {
        public string EmployeeName { get; private set; }
        public int VacationDays { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public VacationRequest(RequestType requestType,string employeeName,DateTime startDate,int days):base(requestType)
        {
            EmployeeName = employeeName;
            VacationDays = days;
            StartDate = startDate;
            EndDate = startDate.AddDays(days);
        }
    }


    #endregion

    #region Handler

    public interface IHandler
    {
        void SetNextHandler(IHandler nextHandler);

        void ProcessRequest(IRequest request);
    }

    public abstract class Handler : IHandler
    {
        protected IHandler? _nextHandler;

        public void SetNextHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void ProcessRequest(IRequest request);
        
    }


    

    public class TeamLeaderHandler : Handler
    {
        public override void ProcessRequest(IRequest request)
        {
            if (request.RequestType == RequestType.TeamLeader)
            {
                Console.WriteLine("TeamLeader handel the Vacation Request");
                
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler?.ProcessRequest(request);
                }
                else
                {
                    Console.WriteLine("No Handler Found For Vacation Request");
                }
                
            }
        }
    }

    public class TechnicalLeadHandler : Handler
    {
        public override void ProcessRequest(IRequest request)
        {
            if (request.RequestType == RequestType.TechnicalLeader)
            {
                Console.WriteLine("TechnicalLeader handel the Vacation Request");

            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler?.ProcessRequest(request);
                }
                else
                {
                    Console.WriteLine("No Handler Found For Vacation Request");
                }
            }
        }
    }

    public class CtoHandler : Handler
    {
        public override void ProcessRequest(IRequest request)
        {
            if (request.RequestType == RequestType.CTO)
            {
                Console.WriteLine("Cto handel the Vacation Request");
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler?.ProcessRequest(request);
                }
                else
                {
                    Console.WriteLine("No Handler Found For Vacation Request");
                }
            }
        }
    }

    public class CeoHandler : Handler
    {
        public override void ProcessRequest(IRequest request)
        {
            if (request.RequestType == RequestType.CEO)
            {
                Console.WriteLine("CEO handel the Vacation Request");
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler?.ProcessRequest(request);
                }
                else
                {
                    Console.WriteLine("No Handler Found For Vacation Request");
                }
            }
        }
    }
     
    #endregion

    #endregion

}