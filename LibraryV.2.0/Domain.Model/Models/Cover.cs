using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class Cover : Entity
    {
        public virtual IList<Book> Books{ get; set; }

        [Obsolete]
        protected Cover() {}
    }
}
