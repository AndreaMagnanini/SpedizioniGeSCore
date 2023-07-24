// <copyright file="Content.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The content table entity.
    /// </summary>
    public class Content
    {
        /// <summary>
        /// Gets or sets the content id field.
        /// </summary>
        [Key]
        [Required]
        public Guid ContentId { get; set; }

        /// <summary>
        /// Gets or sets the item id field.
        /// </summary>
        [Required]
        public Guid ItemId { get; set; }

        /// <summary>
        /// Gets or sets the item field.
        /// </summary>
        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        /// <summary>
        /// Gets or sets the quantity field.
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the sigil id field.
        /// </summary>
        public Guid? SigilId { get; set; }

        /// <summary>
        /// Gets or sets the sigil field.
        /// </summary>
        [ForeignKey("SigilId")]
        public Sigil Sigil { get; set; }

        /// <summary>
        /// Gets or sets the shipment id field.
        /// </summary>
        [Required]
        public Guid ShipmentId { get; set; }

        /// <summary>
        /// Gets or sets the shipment field.
        /// </summary>
        [ForeignKey("ShipmentId")]
        public Shipment Shipment { get; set; }

        /// <summary>
        /// Gets or sets the container id field.
        /// </summary>
        public Guid? ContainerId { get; set; }
    }

    /// <summary>
    /// Possible values for content type field.
    /// </summary>
#pragma warning disable SA1201 // Elements should appear in the correct order
    public enum ContentType
    {
        /// <summary>
        /// An item which only has content and is not placed in any container.
        /// </summary>
        Root,   // has ContainerId = null

        /// <summary>
        /// An item which has content and is also placed into a container.
        /// </summary>
        Middle, // has both ContainerId != null and Contents.Count > 0

        /// <summary>
        /// An item which is placed inside a container but has no further content inside itself.
        /// </summary>
        Leaf, // has Contents.Count = 0
    }
#pragma warning restore SA1201 // Elements should appear in the correct order
}