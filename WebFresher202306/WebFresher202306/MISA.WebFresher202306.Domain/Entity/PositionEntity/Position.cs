namespace WebFresher202306.Domain
{
    /// <summary>
    /// thực thể chức danh
    /// author: Trương Mạnh Quang (9/8/2023)
    /// </summary>
    public class Position : BaseAuditEntity, IEntity<Guid>
    {
        /// <summary>
        /// id chức danh
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// mã chức danh
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// tên chức danh
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// mô tả chức danh
        /// </summary>
        public string Description { get; set; }

        public Guid GetId()
        {
            return PositionId;
        }

        public void SetId(Guid id)
        {
            PositionId = id;
        }
    }
}
