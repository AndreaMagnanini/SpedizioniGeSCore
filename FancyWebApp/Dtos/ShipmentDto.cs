// <copyright file="ShipmentDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    using FancyWebApp.Models;

    /// <summary>
    /// The shipment data transfer object.
    /// </summary>
    public class ShipmentDto
    {
        /// <summary>
        /// Gets or sets the shipment code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the shipment description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the shipment event.
        /// </summary>
        public EventDto Event { get; set; }

        /// <summary>
        /// Gets or sets the shipment place of origin.
        /// </summary>
        public LocationDto Origin { get; set; }

        /// <summary>
        /// Gets or sets the shipment airport of origin.
        /// </summary>
        public AirportDto? OriginAirport { get; set; }

        /// <summary>
        /// Gets or sets the shipment airport of destination.
        /// </summary>
        public AirportDto? DestinationAirport { get; set; }

        /// <summary>
        /// Gets or sets the shipment port of origin.
        /// </summary>
        public PortDto? OriginPort { get; set; }

        /// <summary>
        /// Gets or sets the shipment port of destination.
        /// </summary>
        public PortDto? DestinationPort { get; set; }

        /// <summary>
        /// Gets or sets the shipment place of destination.
        /// </summary>
        public LocationDto Destination { get; set; }

        /// <summary>
        /// Gets or sets the shipment departure date.
        /// </summary>
        public DateTime Departure { get; set; }

        /// <summary>
        /// Gets or sets the shipment arrive date.
        /// </summary>
        public DateTime Arrive { get; set; }

        /// <summary>
        /// Gets or sets the shipment content list.
        /// </summary>
        public List<ContentDto> Contents { get; set; } // roots of the tree

        // public List<Object> FloatingObjects { get; set; }
        // public List<Box> Boxes { get; set; }
        // public List<Pallet> Pallets { get; set; }

        /// <summary>
        /// Gets or sets the shipment type.
        /// </summary>
        public ShipmentType Type { get; set; }

        /// <summary>
        /// Gets or sets the shipment status.
        /// </summary>
        public ShipmentStatus Status { get; set; }
    }
}