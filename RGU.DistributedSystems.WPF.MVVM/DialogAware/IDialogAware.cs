using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGU.DistributedSystems.WPF.MVVM.DialogAware
{
    public interface IDialogAware
    {
        bool ShowDialog(
            DialogAwareParameters dialogParameters);
    }
}
