// <copyright file="ItemDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    using FancyWebApp.Models;

    /// <summary>
    /// The item data transfer object.
    /// </summary>
    public class ItemDto
    {
        /// <summary>
        /// Gets or sets the item description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the item height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the item width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the item depth.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the item weight.
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Gets or sets the item tare.
        /// </summary>
        public float? Tare { get; set; }

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public ItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the item availability.
        /// </summary>
        public int Availability { get; set; }

        /// <summary>
        /// Gets or sets the item quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}