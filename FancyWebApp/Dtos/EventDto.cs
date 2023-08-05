// <copyright file="EventDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The event data transfer object.
    /// </summary>
    public class EventDto
    {
        /// <summary>
        /// Gets or sets the event description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the event location.
        /// </summary>
        public LocationDto? Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the events take place outside the European Union.
        /// </summary>
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