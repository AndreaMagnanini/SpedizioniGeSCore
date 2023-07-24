// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FancyWebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a user part of Ferrari GeS.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user name field.
        /// </summary>
        [Key]
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the hashed pwd field.
        /// </summary>
        [Required]
        public string HashedPassword { get; set; }

        /// <summary>
        /// Gets or sets the name field.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user surname field.
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the user hashing salt field.
        /// </summary>
        public byte[] Salt { get; set; }

        /// <summary>
        /// Gets or sets the user email field.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user issue field.
        /// </summary>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the user expiry field.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }
    }
}