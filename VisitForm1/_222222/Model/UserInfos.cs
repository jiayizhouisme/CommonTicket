using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitForm1._222222.Model
{
    public class UserInfos
    {
        public long Id { get; set; }

        public long? UserId { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(50, ErrorMessage = "姓名不能超过50个字符")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "手机号不能为空")]
        [StringLength(11, ErrorMessage = "手机号必须是11位", MinimumLength = 11)] 
        [RegularExpression(@"^1[3-9]\d{9}$", ErrorMessage = "手机号格式不正确")] 
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "身份证号不能为空")]
        [StringLength(18, ErrorMessage = "身份证号必须是18位", MinimumLength = 15)] 
        public string? IdCard { get; set; }
        

    }
}
