namespace EquipmentRental.Models;

public class Rental
{
    public int Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }

    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Rental(int id, User user, Equipment equipment, DateTime rentDate, DateTime dueDate)
    {
        Id = id;
        User = user;
        Equipment = equipment;
        RentDate = rentDate;
        DueDate = dueDate;
    }
}