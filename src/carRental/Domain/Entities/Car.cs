using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Car : Entity<Guid>
{
    public Guid ColorId { get; set; }
    public Guid ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }

    public virtual Color? Color { get; set; }
    public virtual Model? Model { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }

    public Car()
    {
        Rentals = new HashSet<Rental>();
    }

    public Car(
        Guid id,
        Guid colorId,
        Guid modelId,
        CarState carState,
        int kilometer,
        short modelYear,
        string plate
    )
        : this()
    {
        Id = id;
        ColorId = colorId;
        ModelId = modelId;
        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
    }
}
