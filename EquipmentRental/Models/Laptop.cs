namespace EquipmentRental.Models;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public string Processor { get; set; }

    public Laptop(int id, string name, int ramGb, string processor) : base(id, name)
    {
        RamGb = ramGb;
        Processor = processor;
    }
}