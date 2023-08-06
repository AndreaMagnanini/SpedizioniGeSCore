// <copyright file="Item.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using FancyWebApp.Models.Common;

    /// <summary>
    /// Represent a single and generic movable shipment unity.
    /// </summary>
    public abstract class Item : UserTrace
    {
        /// <summary>
        /// Gets or sets the Item id.
        /// </summary>
        [Key]
        [Required]
        public Guid Id { set; get; }

        /// <summary>
        /// Gets or sets the Item description.
        /// </summary>
        [Required]
        public string Description { set; get; }

        /// <summary>
        /// Gets or sets the Item height.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the Item width.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the Item depth.
        /// </summary>
        public int? Depth { get; set; }

        /// <summary>
        /// Gets or sets the Item weight.
        /// </summary>
        public float? Weight { get; set; }

        /// <summary>
        /// Gets or sets the Item tare.
        /// </summary>
        public float? Tare { get; set; }

        /// <summary>
        /// Gets or sets the Item type.
        /// </summary>
        [Required]
        public ItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the Item availability.
        /// </summary>
        [Required]
        public int Availability { get; set; }

        /// <summary>
        /// Gets or sets the Item quantity.
        /// </summary>
        [Required]
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Enum representing all possible item types.
    /// </summary>
#pragma warning disable SA1201 // Elements should appear in the correct order
    public enum ItemType
#pragma warning restore SA1201 // Elements should appear in the correct order
    {
        /// <summary>
        /// Item as single object, only can be contained.
        /// </summary>
        Object,

        /// <summary>
        /// Item as boxes, can both contain other boxes or object, or be stored inside other boxes or containers / pallets.
        /// </summary>
        Box,

        /// <summary>
        /// Item as a whole container, only can contain boxes or objects.
        /// </summary>
        Pallet,
    }
}