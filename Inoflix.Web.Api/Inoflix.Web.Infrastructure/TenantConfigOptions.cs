﻿namespace Inoflix.Web.Infrastructure
{
    public class TenantConfigOptions
    {
        public const string Tenants = "Tenants";

        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
