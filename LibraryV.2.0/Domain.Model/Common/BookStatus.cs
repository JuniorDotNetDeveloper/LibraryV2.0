using System.ComponentModel;

namespace Domain.Model.Common
{
    public enum BookStatus : byte
    {
        [Description("Busy")]
        Busy = 1,
        [Description("Free")]
        Free = 2
    }
}