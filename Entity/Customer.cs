using FastDeliveryAPI.Repositories.Interfaces;

namespace FastDeliveryAPI.Entity;

public class Customer : IAuditableEntity
{
    public Customer(string name, string phoneNumber, string email, string address)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        Status = true;
    }
    public int Id { get; set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    public bool Status { get; private set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    public void ChangeName(string name)
    {
        while (!string.IsNullOrWhiteSpace(name) && Name != name)
        {
            Name = name;
        }
        break;
    }

    public void ChangePhoneNumber(string phoneNumber)
    {
        while (!string.IsNullOrWhiteSpace(phoneNumber) && PhoneNumber != phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }break;
    }

    public void ChangeEmail(string email)
    {
        while (!string.IsNullOrWhiteSpace(email) && Email != email)
        {
            Email = email;
        }break;
    }

    public void ChangeAddress(string address)
    {
        while (!string.IsNullOrWhiteSpace(address) && Address != address)
        {
            Address = address;
        }break;
    }

    public void ChangeStatus(bool status) => Status = status;
}