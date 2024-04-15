using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenClothingAPI.Core.Common
{
    public interface IHasKey<T>
    {
        T Id { get; set; }
    }
    internal class IHasKey
    {
    }
}
