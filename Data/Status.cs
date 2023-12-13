namespace FoodStore.Data
{
    enum Status
    {
        New = 1,
        Payment_received,
        Payment_failed,
        In_Progress,
        Completed,
        Closed,
        Canceled
    }
}