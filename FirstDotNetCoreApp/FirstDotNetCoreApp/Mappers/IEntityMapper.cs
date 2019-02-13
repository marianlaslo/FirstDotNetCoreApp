using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.Mappers
{
    public interface IEntityMapper<out TOutEntity, in TInEntity>
    {
        TOutEntity Convert(TInEntity model);
    }
}
