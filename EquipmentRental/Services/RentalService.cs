using EquipmentRental.Models;
using EquipmentRental.Enums;

namespace EquipmentRental.Services;

public class RentalService
{
    private List<Rental> rentals = new();

    private const int StudentLimit = 2;
    private const int EmployeeLimit = 5;

    public void RentEquipment(User user, Equipment equipment, DateTime rentDate, DateTime dueDate)
    {
        if (equipment.Status != EquipmentStatus.Available)
            throw new Exception("Equipment is not available");

        int activeRentalsCount = GetUserRentals(user).Count;
        int userLimit = GetUserLimit(user);

        if (activeRentalsCount >= userLimit)
            throw new Exception("User has reached the rental limit");

        var rental = new Rental(rentals.Count + 1, user, equipment, rentDate, dueDate);
        rentals.Add(rental);

        equipment.Status = EquipmentStatus.Rented;
    }

    public void ReturnEquipment(Rental rental, DateTime returnDate)
    {
        rental.ReturnDate = returnDate;
        rental.Equipment.Status = EquipmentStatus.Available;
    }

    public List<Rental> GetUserRentals(User user)
    {
        return rentals.Where(r => r.User == user && r.ReturnDate == null).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return rentals.Where(r => r.ReturnDate == null && r.DueDate < DateTime.Now).ToList();
    }

    private int GetUserLimit(User user)
    {
        if (user is Student)
            return StudentLimit;

        if (user is Employee)
            return EmployeeLimit;

        throw new Exception("Unknown user type");
    }
}