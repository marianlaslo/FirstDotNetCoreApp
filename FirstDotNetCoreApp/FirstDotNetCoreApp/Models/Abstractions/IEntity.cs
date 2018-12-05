using System;
using System.ComponentModel.DataAnnotations;

namespace FirstDotNetCoreApp.Models.Abstractions
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }

        DateTime CreateDate { get; set; }

        DateTime? ModifiedDate { get; set; }

        int Version { get; set; }
    }
}
