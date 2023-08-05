// <copyright file="PortDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The Data Transfer Object corresponding to Port entity.
    /// </summary>
    public class PortDto
    {
        /// <summary>
        /// Gets or sets property LoCode.
        /// </summary>
        public string LoCode { get; set; }

        /// <summary>
        /// Gets or sets property LoCode.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets property LoCode.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets property LoCode.
        /// </summary>
        public string? Description { get; set; }
    }
}