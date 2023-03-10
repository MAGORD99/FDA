namespace FastDeliveryAPI.Exceptions;

public class EmailException : ApplicationException
{
    public EmailException(string customerName) : base($"El correo de {customerName} No es Valido")
    {

    }


}