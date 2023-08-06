// <copyright file="GroundShipment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The ground shipment table entity.
    /// </summary>
    public class GroundShipment : Shipment
    {
        /// <summary>
        /// Gets or sets the driver name field.
        /// </summary>
        [Required]
        public string DriverName { get; set; }
    }
}