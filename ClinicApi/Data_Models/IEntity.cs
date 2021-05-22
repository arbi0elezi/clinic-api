using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApi.Data_Models
{
    public class IEntity
    { 
       public Guid Id { get; set; } = Guid.NewGuid();
    }
}
