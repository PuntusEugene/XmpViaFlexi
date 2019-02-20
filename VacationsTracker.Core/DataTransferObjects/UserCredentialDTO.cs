using VacationsTracker.Core.DataTransferObjects.Interfaces;
// ReSharper disable All

namespace VacationsTracker.Core.DataTransferObjects
{
    public class UserCredentialDTO : IDataTransferObject
    {
        public string Login { get; private set; }

        public string Password { get; private set; }
    }
}
