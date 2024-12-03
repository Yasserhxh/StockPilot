﻿namespace StockPilot.Api.Application.Models
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpirationMinutes { get; set; }
    }
}