namespace 通用订票.Web.Entry.Model
{
    
    public class SimpleRet
    {
        static string addSucceed => "添加成功";
        static string updateSucceed => "修改成功";
        static string deleteSucceed => "删除成功";
        static string addFailed => "添加失败";
        static string updateFailed => "修改失败";
        static string deleteFailed => "删除失败";

        public retValue code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static SimpleRet AddSuccessed(object data = null)
        {
            return new SimpleRet() { code = retValue.succeed, message = addSucceed,data = data};
        }

        public static SimpleRet UpdateSuccessed(object data = null)
        {
            return new SimpleRet() { code = retValue.succeed, message = updateSucceed, data = data };
        }

        public static SimpleRet DeleteSuccessed(object data = null)
        {
            return new SimpleRet() { code = retValue.succeed, message = deleteFailed, data = data };
        }

        public static SimpleRet AddFailed(object data = null)
        {
            return new SimpleRet { code = retValue.fail, message = addFailed };
        }

        public static SimpleRet UpdateFailed(object data = null)
        {
            return new SimpleRet { code = retValue.fail, message = updateFailed };
        }
        public static SimpleRet DeleteFailed(object data = null)
        {
            return new SimpleRet { code = retValue.fail, message = deleteFailed };
        }
    }

    public enum retValue
    {
        fail,
        succeed
    }

    
}
