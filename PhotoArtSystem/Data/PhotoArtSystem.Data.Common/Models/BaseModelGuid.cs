namespace PhotoArtSystem.Data.Common.Models
{
    using System;

    public abstract class BaseModelGuid : BaseModel<Guid>, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public BaseModelGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
