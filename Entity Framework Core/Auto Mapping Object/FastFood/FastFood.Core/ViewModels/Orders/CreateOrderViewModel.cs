namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<CreateOrderEmployeeViewModel> Employees { get; set; }
        public List<CreateOrderItemViewModel> Items { get; set; }
    }
}
