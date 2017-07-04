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
    public class ParamErrorEventArgs : EventArgs {
        public string Message { get; set; }
    }
}
