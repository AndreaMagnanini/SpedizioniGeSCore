// <copyright file="AirShipment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The air shipment table entity.
    /// </summary>
    public class AirShipment : Shipment
    {
        /// <summary>
        /// Gets or sets the origin airport id field.
        /// </summary>
        [Required]
        public Guid OriginAirportId { get; set; }

        /// <summary>
        /// Gets or sets the origin airport field.
        /// </summary>
        [ForeignKey("OriginAirportId")]
        public Airport OriginAirport { get; set; }

        /// <summary>
        /// Gets or sets the destination airport id field.
        /// </summary>
        [Required]
        public Guid DestinationAirportId { get; set; }

        /// <summary>
        /// Gets or sets the destination airport field.
        /// </summary>
        [ForeignKey("DestinationAirportId")]
        public Airport DestinationAirport { get; set; }
    }
}