using EquipmentRental.Models;
using EquipmentRental.Services;

namespace EquipmentRental;

class Program
{
    static void Main(string[] args)
    {
        var equipmentService = new EquipmentService();
        var rentalService = new RentalService();

        // sprzęt
        var laptop = new Laptop(1, "Dell XPS", 16, "Intel i7");
        var projector = new Projector(2, "Epson X", "FullHD", 3000);

        equipmentService.AddEquipment(laptop);
        equipmentService.AddEquipment(projector);

        // użytkownicy
        var student = new Student(1, "Jan", "Kowalski");

        // wypożyczenie
        rentalService.RentEquipment(student, laptop, DateTime.Now, DateTime.Now.AddDays(7));
        Console.WriteLine("Laptop rented");

        // próba przekroczenia limitu
        try
        {
            rentalService.RentEquipment(student, projector, DateTime.Now, DateTime.Now.AddDays(7));
            rentalService.RentEquipment(student, new Camera(3, "Canon", 24, "Zoom"), DateTime.Now, DateTime.Now.AddDays(7));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // zwrot
        var rentals = rentalService.GetUserRentals(student);
        var firstRental = rentals.First();

        rentalService.ReturnEquipment(firstRental, DateTime.Now);
        Console.WriteLine("Laptop returned");
    }
}