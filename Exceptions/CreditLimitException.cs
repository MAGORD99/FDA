namespace FastDeliveryAPI.Exceptions;

public class CreditLimitException : ApplicationException
{
    public CreditLimitException(string customerName) : base($"{customerName} No se puede Incrementar mas limite")
    {

    }

}