﻿namespace KRM_Events_API.Dtos.Account
{
    public class UpdateProfileDTO
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
