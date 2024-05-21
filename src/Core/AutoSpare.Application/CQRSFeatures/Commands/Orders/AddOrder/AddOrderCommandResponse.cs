namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder
{
    public class AddOrderCommandResponse
    {

    }
    public class AddOrderCommandSuccessResponse : AddOrderCommandResponse
    {
        public bool Success { get; set; }
    }
    public class AddOrderCommandErrorResponse : AddOrderCommandResponse
    {
        public string Message { get; set; }
    }


}
