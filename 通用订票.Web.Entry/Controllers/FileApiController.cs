using Core.User.Entity;
using Furion;
using Furion.DynamicApiController;
using Furion.LinqBuilder;
using Furion.RemoteRequest.Extensions;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Diagnostics.CodeAnalysis;


namespace 设备物联.Web.Entry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileApiController : IDynamicApiController
    {
        [HttpPost(Name = "UploadFile")]
        [RequestSizeLimit(100_000_000)]
        [NonUnify]
        //[Authorize]
        public async Task<object> UploadFileAsync(IFormFile file)
        {
            // 如：保存到网站根目录下的 uploads 目录
            var savePath = Path.Combine(App.HostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

            //// 这里还可以获取文件的信息
            // var size = file.Length / 1024.0;  // 文件大小 KB
            // var clientFileName = file.FileName; // 客户端上传的文件名
            // var contentType = file.ContentType; // 获取文件 ContentType 或解析 MIME 类型

            // 避免文件名重复，采用 GUID 生成
            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(savePath, fileName);

            // 保存到指定路径
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            

            // 返回文件名（这里可以自由返回更多信息）
            return new { filePath = "/uploads/" + fileName };
        }

        [HttpPost(Name = "UploadFiles")]
        [RequestSizeLimit(100_000_000)]
        [NonUnify]
        //[Authorize]
        public async Task<object> UploadFilesAsync(List<IFormFile> files)    // 可改为 IFormFileCollection files
        {
            // 保存到网站根目录下的 uploads 目录
            var savePath = Path.Combine(App.HostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

            // 总上传大小
            long size = files.Sum(f => f.Length);
            string[] paths = new string[files.Count];
            int i = 0;
            // 遍历所有文件逐一上传
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // 避免文件名重复，采用 GUID 生成
                    var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
                    var filePath = Path.Combine(savePath, fileName);

                    // 保存到指定路径
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    paths[i++] = "/uploads/" + fileName;
                }
            }

            // 这里可自行返回更多信息
            return new { count = files.Count, filepaths = paths };
        }

        [HttpPost("DownloadImgsByUrls")]
        //[Authorize]
        public async Task<string[]> DownloadImgsByUrls([FromBody]string[] urls)
        {
            string[] result = new string[urls.Length]; 
            var savePath = Path.Combine(App.HostEnvironment.ContentRootPath, "uploads");
            int i = 0;
            foreach (var url in urls)
            {
                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(url);
                var filePath = Path.Combine(savePath, fileName);

                var str = await url.GetAsStreamAsync();
                var bytes = await str.Response.Content.ReadAsByteArrayAsync();
                var filestream = File.Create(filePath);
                await filestream.WriteAsync(bytes,0,bytes.Length);
                result[i++] = "/uploads/" + fileName;
                filestream.Close();
                str.Stream.Close();
            }
            return result;
        }
    }
    
}
