namespace EquipmentRental.Models;

public class Camera : Equipment
{
    public int Megapixels { get; set; }
    public string LensType { get; set; }

    public Camera(int id, string name, int megapixels, string lensType) : base(id, name)
    {
        Megapixels = megapixels;
        LensType = lensType;
    }
}