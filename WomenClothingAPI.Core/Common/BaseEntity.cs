using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenClothingAPI.Core.Common;


public abstract class BaseEntity<TKey> : AuditableEntity, IHasKey<TKey>
{
    [Key]
    public TKey Id { get; set; }

}