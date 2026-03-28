using EquipmentRental.Models;
using EquipmentRental.Enums;

namespace EquipmentRental.Services;

public class RentalService
{
    private List<Rental> rentals = new();

    public void RentEquipment(User user, Equipment equipment, DateTime rentDate, DateTime dueDate)
    {
        if (equipment.Status != EquipmentStatus.Available)
            throw new Exception("Equipment is not available");

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
}