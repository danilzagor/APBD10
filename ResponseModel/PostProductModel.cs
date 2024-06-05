using System.ComponentModel.DataAnnotations;
using APBD10.Models;

namespace APBD10.ResponseModel;

public class PostProductModel
{
    [MaxLength(100)]
    public string ProductName { get; set; }
    [Range(typeof(decimal), "0.00", "999.99", ErrorMessage = "Value must be a decimal with up to 3 digits before and 2 digits after the decimal point.")]
    public decimal Weight { get; set; }
    [Range(typeof(decimal), "0.00", "999.99", ErrorMessage = "Value must be a decimal with up to 3 digits before and 2 digits after the decimal point.")]
    public decimal Width { get; set; }
    [Range(typeof(decimal), "0.00", "999.99", ErrorMessage = "Value must be a decimal with up to 3 digits before and 2 digits after the decimal point.")]
    public decimal Height { get; set; }
    [Range(typeof(decimal), "0.00", "999.99", ErrorMessage = "Value must be a decimal with up to 3 digits before and 2 digits after the decimal point.")]
    public decimal Depth { get; set; }
    public List<int> ProductCategories { get; set; }
}