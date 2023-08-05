// <copyright file="BoxDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The box data transfer object.
    /// </summary>
    public class BoxDto : ItemDto
    {
        /// <summary>
        /// Gets or sets the box number.
        /// </summary>
        public string BoxNumber { get; set; }
    }
}