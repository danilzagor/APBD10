using APBD10.Models;

namespace APBD10.ResponseModel;

public class GetAccountResponseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public List<GetCartModel> Cart { get; set; }
}