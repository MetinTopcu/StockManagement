using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Shared.Interfaces
{
    public interface IEntity<TIDType> where TIDType : struct
    {
        TIDType Id { get; set; }
    }
}
