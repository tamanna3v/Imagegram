using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Imagegram
{
  public  class Comments: FullAuditedEntity<long>
    {
        public string Content { get; set; }
        public virtual long PostId { get; set; }
    }
}
