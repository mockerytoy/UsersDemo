using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model.Contracts;

namespace Users.Model
{
    public abstract class DataModel : IDeletable, IAuditable
    {
        public bool IsDeleted { get; set ; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
