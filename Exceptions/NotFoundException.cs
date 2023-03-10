using System.Runtime.Serialization;

namespace FastDeliveryAPI.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"El Nombre:{name} con el  id: {key} no se ha encontrado!")
    {

    }

}