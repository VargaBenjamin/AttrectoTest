﻿namespace AttrectoTest.Models.DTOs
{
    public class UserSaveDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
