using System.Globalization;

namespace AdventureCore.Models
{
  public class ProductBasic
  {
    public int IdProductID { get; set; }
    public string? ProductName { get; set; }
    public string? ProductNumber {  get; set; }
    public String? color {  get; set; }
    public decimal ListPrince { get; set; }
    public decimal StandartCost { get; set; }
    public String? Size {  get; set; }
    public DateTime ModifiedDate {  get; set; }

  }
}
