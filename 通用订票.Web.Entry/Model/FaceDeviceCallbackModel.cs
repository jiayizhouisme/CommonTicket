namespace 通用订票.Web.Entry.Model
{
    public class FaceDeviceCallbackModel
    {
        public int type { get; set; }
        public string data { get; set; }
        public string extra { get; set;}
        public long time { get; set; }
        public string deviceSn { get; set; }
    }
    public class FaceDeviceVerifyResultReturn
    {
        public int code { get; set; }
        public int cmd { get; set; }
        public string message { get; set; }
        public string voiceData { get; set; }
    }
}
