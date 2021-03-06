﻿using System.Threading.Tasks;

namespace VacationsTracker.Core.Infrastructure.Storage
{
    public interface IVacationSecureStorage
    {
        Task SetAsync(string key, string value);

        Task<string> GetAsync(string key);

        bool Remove(string key);
    }
}
