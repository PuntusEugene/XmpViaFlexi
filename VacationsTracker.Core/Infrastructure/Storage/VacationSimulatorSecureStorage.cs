using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VacationsTracker.Core.Infrastructure.Storage
{
    public class VacationSimulatorSecureStorage : IVacationSecureStorage
    {
        private static readonly ConcurrentDictionary<string, string> DictionarySessionStorage;

        static VacationSimulatorSecureStorage()
        {
            DictionarySessionStorage = new ConcurrentDictionary<string, string>();
        }

        public async Task<string> GetAsync(string key)
        {
            try
            {
                await Task.Delay(0);
                DictionarySessionStorage.TryGetValue(key, out string value);
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
                return DictionarySessionStorage.TryRemove(key, out string value);
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
                await Task.Delay(0);
                DictionarySessionStorage.TryAdd(key, value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
