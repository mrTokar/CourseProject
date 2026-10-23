using NpgsqlTypes;

namespace PcShop.Models
{
    public enum ProductStatus
    {
        [PgName("free")]
        Free,
        [PgName("reserved")]
        Reserved,
        [PgName("paid")]
        Paid,
        [PgName("sold")]
        Sold,
        [PgName("written-off")]
        WrittenOff
    }

    public enum OrderStatus
    {
        [PgName("Собирается")]
        Collecting,
        [PgName("Собран")]
        Collected,
        [PgName("В пути")]
        InTransit,
        [PgName("Приехал в пункт выдачи")]
        ArrivedAtPickupPoint,
        [PgName("Завершен")]
        Completed,
        [PgName("Отменен")]
        Cancelled
    }

    public enum PaymentType
    {
        [PgName("Онлайн оплата")]
        Online,
        [PgName("Наличными")]
        Cash,
        [PgName("Картой при получении")]
        CardOnDelivery
    }

    public enum UserRole
    {
        [PgName("client")]
        Client,
        [PgName("manager")]
        Manager,
        [PgName("seller")]
        Seller
    }
}
