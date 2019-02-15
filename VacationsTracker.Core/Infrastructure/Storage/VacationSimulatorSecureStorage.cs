using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace VacationsTracker.Core.Infrastructure.Storage
{
    public class VacationSimulatorSecureStorage : IVacationSecureStorage
    {
        private static readonly ConcurrentDictionary<string, string> _dictionarySessionStorage;

        static VacationSimulatorSecureStorage()
        {
            _dictionarySessionStorage = new ConcurrentDictionary<string, string>();
        }

        public async Task<string> GetAsync(string key)
        {
            try
            {
                _dictionarySessionStorage.TryGetValue(key, out string value);
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public bool Remove(string key)
        {
            try
            {
                return _dictionarySessionStorage.TryRemove(key, out string value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task SetAsync(string key, string value)
        {
            try
            {
                _dictionarySessionStorage.TryAdd(key, value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
