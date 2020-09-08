using System;

namespace GeometryLib.Models
{
    public abstract class BaseClass : IDisposable
    {
        // To detect redundant calls
        private bool _disposed = false;
		
		// Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                OnDisposing();
            }

            _disposed = true;
        }

        protected abstract void OnDisposing();
    }
}
