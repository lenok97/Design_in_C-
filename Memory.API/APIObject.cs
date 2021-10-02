using System;

namespace Memory.API
{
    public class APIObject : IDisposable
    {
        private int id;
        private bool isDisposed = false;

        public APIObject(int id)
        {
            this.id = id;
            MagicAPI.Allocate(id);
        }

        ~APIObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool calledFromDisposeMethod)
        {
            if (!isDisposed)
            {
                MagicAPI.Free(id);
                isDisposed = true;
            }
        }
    }
}