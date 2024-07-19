﻿using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Rental : Entity<Guid>
{
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }

    public virtual Car Car { get; set; }
    public virtual Customer Customer { get; set; }

    public Rental() { }

    public Rental(
        Guid id,
        Guid customerId,
        Guid carId,
        DateTime rentStartDate,
        DateTime rentEndDate,
        DateTime? returnDate,
        int rentStartKilometer,
        int rentEndKilometer
    )
        : this()
    {
        Id = id;
        CustomerId = customerId;
        CarId = carId;
        RentStartDate = rentStartDate;
        RentEndDate = rentEndDate;
        ReturnDate = returnDate;
        RentStartKilometer = rentStartKilometer;
        RentEndKilometer = rentEndKilometer;
    }
}
