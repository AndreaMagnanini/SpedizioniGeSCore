// <copyright file="FerryShipment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The ferry shipment table entity.
    /// </summary>
    public class FerryShipment : Shipment
    {
        /// <summary>
        /// Gets or sets the origin port id field.
        /// </summary>
        [Required]
        public Guid OriginPortId { get; set; }

        /// <summary>
        /// Gets or sets the origin port field.
        /// </summary>
        [ForeignKey("OriginPortId")]
        public Port OriginPort { get; set; }

        /// <summary>
        /// Gets or sets the destination port id field.
        /// </summary>
        [Required]
        public Guid DestinationPortId { get; set; }

        /// <summary>
        /// Gets or sets the destination port id field.
        /// </summary>
        [ForeignKey("DestinationPortId")]
        public Port DestinationPort { get; set; }
    }
}