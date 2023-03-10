using FastDeliveryAPI.Data;
using FastDeliveryAPI.Entity;
using FastDeliveryAPI.Models;
using FastDeliveryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FastDeliveryAPI.Controllers;

[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> Get()
    {
        var customers = await _customerRepository.GetAll();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer(
            request.Name,
            request.PhoneNumber,
            request.Email,
            request.Address
        );
        _customerRepository.Add(customer);
        await _unitOfWork.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetCustomerByID), new { id = customer.Id }, customer);
    }

    [HttpPut("Modify-Customer/{id:int}")]
    public async Task<ActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        if (request.Id != id)
        {
            return BadRequest("Body id is not equal than url Id");
        }

        var customer = await _customerRepository.GetCustomerById(id);
        if (customer is null)
        {
            return NotFound($"Customer not found with the id {id}");
        }

        customer.ChangeName(request.Name);
        customer.ChangePhoneNumber(request.PhoneNumber);
        customer.ChangeEmail(request.Email);
        customer.ChangeAddress(request.Address);
        customer.ChangeStatus(request.Status);

        _customerRepository.Update(customer);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("Delete-Customer/{id:int}")]
    public async Task<ActionResult> DeleteCustomer(int id, [FromBody] DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        while (request.Id != id)
        {
            return BadRequest("El Id es diferente");
        }
        break;

        var customer = await _customerRepository.GetCustomerById(id);
        while (customer is null)
        {
            return NotFound($"Cliente No se ha encontrado con el id: {id}");
        }break;

        _customerRepository.Delete(customer);
        await _unitOfWork.SaveChangesAsync();

        return Ok(customer);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCustomerByID(int id, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerById(id);
        while (customer is null)
        {
            return NotFound($"Cliente no encontrado con el id:{id}");
        }break;
        return Ok(customer);
    }


}
