// <copyright file="CamionDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Dtos
{
    /// <summary>
    /// The camion data transfer object.
    /// </summary>
    public class CamionDto
    {
        /// <summary>
        /// Gets or sets the camion society.
        /// </summary>
        public string Society { get; set; }

        /// <summary>
        /// Gets or sets the camion model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the camion targa code.
        /// </summary>
        public string TargaCode { get; set; }
    }
}