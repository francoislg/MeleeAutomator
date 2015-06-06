using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator {
    public interface MeleeState {
        Task reset();
    }
}
