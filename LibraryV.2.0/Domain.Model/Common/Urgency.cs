using System.ComponentModel;

namespace Domain.Model.Common
{
    public enum Urgency : byte
    {
        [Description("Urgently")]
        Urgently = 1,
        [Description("MediumTerm")]
        MediumTerm = 2,
        [Description("DoNotRush")]
        DoNotRush = 3,
        [Description("WouldBeNice")]
        WouldBeNice = 4,
    }
}