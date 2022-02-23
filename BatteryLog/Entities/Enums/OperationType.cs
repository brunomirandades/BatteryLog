using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    enum OperationType : int
    {
        SetInput = 0,
        ReadInput = 1,
        LockInput = 2,
        UnlockInput = 3,
        ReadOutput = 4,
        ActivateOutput = 5,
        DeactivateOutput = 6
    }
}
