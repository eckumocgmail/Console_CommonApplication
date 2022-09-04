namespace DataEntities
{
    /// <summary>
    /// Тот кто осуществляет транспортировку,
    /// напр. сотрудник курьерской службы
    /// </summary>
    public class ProductTransport:BaseEntity
    {
        public override int ID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
