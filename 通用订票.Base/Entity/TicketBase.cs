﻿namespace 通用订票.Base.Entity;

public abstract class TicketBase<T> : TicketAbstract
{
    /// <summary>
    /// 门票持有人ID
    /// </summary>
    public T userID { get; set; }
    /// <summary>
    /// 门票关联字段
    /// </summary>
    public long objectId { get; set; }
}
