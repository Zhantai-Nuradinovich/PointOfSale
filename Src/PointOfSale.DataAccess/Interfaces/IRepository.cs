using PointOfSale.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}
