namespace WebFresher202306.Domain
{
    public class Department : BaseAuditEntity, IEntity<Guid>
    {
        /// <summary>
        /// id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// mô tả phòng ban
        /// </summary>
        public string Description { get; set; }

        public Guid GetId()
        {
            return DepartmentId;
        }

        public void SetId(Guid id)
        {
            DepartmentId = id;
        }
    }
}
