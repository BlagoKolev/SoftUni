namespace FoodShortage.Intefaces
{
   public interface IBuyer
    {
        string Name { get; }
        int Food { get; }
        int BuyFood();

    }
}
