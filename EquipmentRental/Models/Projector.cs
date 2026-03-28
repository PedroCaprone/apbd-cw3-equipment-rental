namespace EquipmentRental.Models;

public class Projector : Equipment
{
    public string Resolution { get; set; }
    public int Lumens { get; set; }

    public Projector(int id, string name, string resolution, int lumens) : base(id, name)
    {
        Resolution = resolution;
        Lumens = lumens;
    }
}