// <copyright file="Event.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// Represents a single Formula 1 Grand Prix.
    /// </summary>
    public class Event : UserTrace
    {
        /// <summary>
        /// Gets or sets the event id.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the event description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the event location id.
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or sets the event location.
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the event takes place outside the European Union.
        /// </summary>
        [Required]
        public bool ExtraEu { get; set; }

        /// <summary>
        /// Gets or sets the event alias.
        /// </summary>
        public string? Alias { get; set; }

        /// <summary>
        /// Gets or sets the event progressive number.
        /// </summary>
        public int? EventNumber { get; set; }

        /// <summary>
        /// Gets or sets the event starting date.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Gets or sets the event ending date.
        /// </summary>
        public DateTime? End { get; set; }
    }
}
