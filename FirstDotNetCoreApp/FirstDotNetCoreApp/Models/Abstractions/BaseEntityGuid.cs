using System;

namespace FirstDotNetCoreApp.Models.Abstractions
{
    public class BaseEntityGuid : BaseEntityAbstraction<Guid>
    {
        public BaseEntityGuid() : base()
        {
            Id = Guid.NewGuid();
        }
    }
}
