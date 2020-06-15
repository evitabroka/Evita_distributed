using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Evita_distributed.JsonParser
{
    public class JsonParser
    {
        public class JSONParser<T> : IDisposable
        {
            bool disposed = false;
            SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);



            }



            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                    return;
                if (disposing)
                {
                    handle.Dispose();
                }



                disposed = true;
            }



            public T parseJson(string json)
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}
