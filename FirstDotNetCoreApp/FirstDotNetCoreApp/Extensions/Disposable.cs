using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.Extensions
{
    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>
        (
            Func<TDisposable> factory,
            Func<TDisposable, TResult> fn)
            where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return fn(disposable);
            }
        }

        public static void Using<TDisposable>
        (
            Func<TDisposable> factory,
            Action<TDisposable> fn)
            where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                fn(disposable);
            }
        }
    }
}
