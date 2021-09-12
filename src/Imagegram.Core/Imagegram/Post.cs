using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram
{
   public class Post: FullAuditedEntity<long>
    {
        public string Caption { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
