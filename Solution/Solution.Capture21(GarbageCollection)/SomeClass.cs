using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture21_GarbageCollection_
{
    public class SomeClass : IDisposable
    {
        private bool disposed = false;

        // реализация интерфейса IDisposable.
        public void Dispose()
        {
            // освобождаем неуправляемые ресурсы
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
            }
            // освобождаем неуправляемые объекты
            disposed = true;
        }

        // Деструктор
        ~SomeClass()
        {
            Dispose(false);
        }
    }
}
