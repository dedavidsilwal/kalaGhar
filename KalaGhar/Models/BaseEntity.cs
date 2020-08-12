using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGhar.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
