using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace VacationsTracker.Core.Infrastructure.Storage
{
    public class VacationVacationSecureStorage : IVacationSecureStorage
    {
        public async Task SetAsync(string key, string value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<string> GetAsync(string key)
        {
            try
            {
                return await SecureStorage.GetAsync(key);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public Task<bool> RemoveAsync(string key)
        {
            try
            {
                var taskCompletionSource = new TaskCompletionSource<bool>();
                Task.Run(() => { taskCompletionSource.SetResult(SecureStorage.Remove(key)); });
                return taskCompletionSource.Task;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public void RemoveAll()
        {
            try
            {
                SecureStorage.RemoveAll();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
