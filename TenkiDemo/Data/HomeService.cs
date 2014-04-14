using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

	namespace TenkiDemo.Data {

    /// <summary>
    /// Default IService implementation
    /// - uses a fake sleep, to emulate network interaction
    /// </summary>
		public class HomeService : IHomeService {

        private const int Sleep = 1000;

		public Task<bool> HomeAsync (string cityCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew (() => {
#if NETFX_CORE
                new System.Threading.ManualResetEvent(false).WaitOne(Sleep);
#else
                Thread.Sleep (Sleep);
#endif

                return true;
            }, cancellationToken);
        }
    }
}