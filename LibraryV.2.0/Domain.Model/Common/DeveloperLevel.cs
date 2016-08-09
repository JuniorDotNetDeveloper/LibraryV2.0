using System.ComponentModel;

namespace Domain.Model.Common
{
    public enum DeveloperLevel : byte
    {
        [Description("Beginner")]
        Beginner = 1,

        [Description("Inter")]
        Inter = 2,

        [Description("Advanced")]
        Advanced =3 
    }
}