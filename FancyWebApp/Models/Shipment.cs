// <copyright file="Shipment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// Represents a view over the set of items that need to be shipped for a specific event to a specific location, in a specific way.
    /// </summary>
    public abstract class Shipment : UserTrace
    {
        /// <summary>
        /// Gets or sets the shipment id field.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the shipment code field.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the shipment description field.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the event id field.
        /// </summary>
        [Required]
        public Guid EventId { get; set; }

        /// <summary>
        /// Gets or sets the shipment event field.
        /// </summary>
        [ForeignKey("EventId")]
        public Event Event { get; set; }

        /// <summary>
        /// Gets or sets the origin location id field.
        /// </summary>
        [Required]
        public Guid OriginId { get; set; }

        /// <summary>
        /// Gets or sets the origin id field.
        /// </summary>
        [ForeignKey("OriginId")]
        public Location Origin { get; set; }

        /// <summary>
        /// Gets or sets the destination location id field.
        /// </summary>
        [Required]
        public Guid DestinationId { get; set; }

        /// <summary>
        /// Gets or sets the destination id field.
        /// </summary>
        [ForeignKey("DestinationId")]
        public Location Destination { get; set; }

        /// <summary>
        /// Gets or sets the departure date field.
        /// </summary>
        public DateTime? Departure { get; set; }

        /// <summary>
        /// Gets or sets the arrive date field.
        /// </summary>
        public DateTime? Arrive { get; set; }

        /// <summary>
        /// Gets or sets the shipment type field.
        /// </summary>
        [Required]
        public ShipmentType Type { get; set; }

        /// <summary>
        /// Gets or sets the shipment status field.
        /// </summary>
        [Required]
        public ShipmentStatus Status { get; set; }
    }

#pragma warning disable SA1201 // Elements should appear in the correct order

    /// <summary>
    /// The possible values for shipment types.
    /// </summary>
    public enum ShipmentType
    {
        /// <summary>
        /// Shipment traveling by plane.
        /// </summary>
        Air,

        /// <summary>
        /// Shipment traveling by ship.
        /// </summary>
        Ferry,

        /// <summary>
        /// Shipment traveling by tir.
        /// </summary>
        Ground,
    }

    /// <summary>
    /// The possible values for shipment status.
    /// </summary>
    public enum ShipmentStatus
    {
        /// <summary>
        /// Shipment created but still not departed.
        /// </summary>
        Scheduled,

        /// <summary>
        /// Shipment departed from origin but still not arrived.
        /// </summary>
        Departed,

        /// <summary>
        /// Shipment that has successfully reached destination.
        /// </summary>
        Arrived,
    }
#pragma warning restore SA1201 // Elements should appear in the correct order
}