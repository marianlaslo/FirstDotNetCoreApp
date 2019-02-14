using System;
using System.ComponentModel.DataAnnotations;

namespace FirstDotNetCoreApp.Models.Abstractions
{
    public interface IEntity<T> : IEntity
    {
        [Key]
        T Id { get; set; }
    }

    public interface IEntity
    {
        DateTime CreateDate { get; set; }

        DateTime? ModifiedDate { get; set; }

        int Version { get; set; }
    }
}
