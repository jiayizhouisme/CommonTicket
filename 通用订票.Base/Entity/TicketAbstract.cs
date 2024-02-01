namespace 通用订票.Base.Entity;

/// <summary>
/// 门票
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class TicketAbstract
{
    /// <summary>
    /// 票号
    /// </summary>
    public string ticketNumber { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime startTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime endTime { get; set; }

    /// <summary>
    /// 门票状态
    /// </summary>
    public TicketStatus stauts { get; set; }

}
public enum TicketStatus
{
    未使用 = 0,
    已使用 = 1,
    未激活 = 2,
    已冻结 = 3
}
