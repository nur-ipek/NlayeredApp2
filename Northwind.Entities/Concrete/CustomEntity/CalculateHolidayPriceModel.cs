using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete.CustomEntity
{
    public class CalculateHolidayPriceModel
    {
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool Gender { get; set; }

        public int EmployeeType { get; set; }
    }
}
