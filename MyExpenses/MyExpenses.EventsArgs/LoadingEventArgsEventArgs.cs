using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.EventsArgs {
    /// <summary>
    ///  SaveEventArgs
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class LoadingEventArgs : EventArgs {
        public bool IsLoading { get; set; } = false;
    }
}
