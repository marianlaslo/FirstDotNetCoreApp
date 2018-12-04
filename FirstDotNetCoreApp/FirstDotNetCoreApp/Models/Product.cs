using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }

    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }

        DateTime CreateDate { get; set; }

        DateTime? ModifiedDate { get; set; }

        int Version { get; set; }
    }

    public class BaseEntityGuid : BaseEntityAbstraction<Guid>
    {
        public BaseEntityGuid() : base()
        {
            Id = Guid.NewGuid();
        }
    }

    public class BaseEntity : BaseEntityAbstraction<int>
    {
        
    }

    public abstract class BaseEntityAbstraction<T> : IEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Version { get; set; }

        protected BaseEntityAbstraction()
        {
            CreateDate = DateTime.Now;
        }
    }

    //Func<v1, v2, decimalSalariu>
    //{Marian, SlariuMiddle}
    //{Andrian, SalariuSenior}
    // decimalSalariu SlariuMiddle(decimal v1, decimal v2)
    // decimalSalariu SalariuSenior(decimal v1, decimal v2)

}
