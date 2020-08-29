using System;

namespace Feev.DesktopGL.Debug
{
    public class FunctionTimer : IDisposable
    {
        private string _name;
        private DateTime _start;
        private bool _disposed = false;
        private long _ms;

        public FunctionTimer(string name)
        {
            _name = name;
            _start = DateTime.Now;
        }
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!_disposed)
            {
                if (disposing)
                {
                    DateTime end = DateTime.Now;

                    _ms = (end.Ticks - _start.Ticks) / TimeSpan.TicksPerMillisecond;
                    Log.Info($"({_name}) {_ms} ms");
                }
                _disposed = true;
            }
        }

        public long GetMilliseconds()
        {
            return _ms;
        }
    }
}
