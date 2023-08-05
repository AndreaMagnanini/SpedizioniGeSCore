// <copyright file="ContentDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    using FancyWebApp.Models;

    /// <summary>
    /// The Content data transfer object.
    /// </summary>
    public class ContentDto
    {
        /// <summary>
        /// Gets or sets the content item.
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Gets or sets the content sigil.
        /// </summary>
        public Sigil Sigil { get; set; }

        /// <summary>
        /// Gets or sets the content shipment id.
        /// </summary>
        public Guid ShipmentId { get; set; }

        /// <summary>
        /// Gets or sets the content container id.
        /// </summary>
        public Guid? ContainerId { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public ItemType ContentType { get; set; }

        /// <summary>
        /// Gets or sets the content list of contents.
        /// </summary>
        public List<ContentDto>? Contents { get; set; }
    }
}