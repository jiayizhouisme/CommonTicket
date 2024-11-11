namespace 通用订票.Application.System.Models
{
    public class AppointmentsAdd
    {
        /// <summary>
        /// 展馆id
        /// </summary>
        [Required(ErrorMessage = "请选择展馆")]
        public Guid exhibitionID { get; set; }
        /// <summary>
        /// 从今天算起，第几天开始
        /// </summary>
        public int dayStart { get; set; }
        /// <summary>
        /// 总天数
        /// </summary>
        public int totalDay { get; set; }
        public TimeSpans[] timeSpans { get; set; }
    }

    public class AppointmentAdd
    {
        /// <summary>
        /// 展馆id
        /// </summary>
        [Required(ErrorMessage = "请选择展馆")]
        public Guid exhibitionID { get; set; }
        /// <summary>
        /// 从今天算起，第几天开始
        /// </summary>
        public int day { get; set; }

        public TimeSpans[] timeSpans { get; set; }
    }

    public struct TimeSpans {
        /// <summary>
        /// 开始时间段比如1:00-2:00
        /// </summary>
        public TimeSpan timeStart { get; set; }
        /// <summary>
        /// 结束时间段
        /// </summary>
        public TimeSpan timeEnd { get; set; }
    }

}
