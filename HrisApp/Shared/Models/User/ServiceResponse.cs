﻿namespace HrisApp.Shared.Models.User
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
    }
}