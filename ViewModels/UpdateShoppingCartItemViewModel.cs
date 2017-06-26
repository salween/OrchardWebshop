namespace Orchard.Webshop.ViewModels
{
    public class UpdateShoppingCartItemViewModel
    {
        public decimal ProductId { get; set; }
        public bool IsRemoved { get; set; }
        public int Quantity { get; set; }
    }
}
