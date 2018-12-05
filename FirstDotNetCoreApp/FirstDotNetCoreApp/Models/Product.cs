using FirstDotNetCoreApp.Models.Abstractions;

namespace FirstDotNetCoreApp.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }

    //Func<v1, v2, decimalSalariu>
    //{Marian, SlariuMiddle}
    //{Andrian, SalariuSenior}
    // decimalSalariu SlariuMiddle(decimal v1, decimal v2)
    // decimalSalariu SalariuSenior(decimal v1, decimal v2)
}
