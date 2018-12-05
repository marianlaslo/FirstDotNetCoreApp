using System;
using System.ComponentModel.DataAnnotations;

namespace FirstDotNetCoreApp.Models.Abstractions
{
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
}
