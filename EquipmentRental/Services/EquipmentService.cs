using EquipmentRental.Models;
using EquipmentRental.Enums;

namespace EquipmentRental.Services;

public class EquipmentService
{
    private List<Equipment> equipments = new();

    public void AddEquipment(Equipment equipment)
    {
        equipments.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return equipments;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return equipments.Where(e => e.Status == EquipmentStatus.Available).ToList();
    }

    public void MarkAsUnavailable(Equipment equipment)
    {
        equipment.Status = EquipmentStatus.Unavailable;
    }
}