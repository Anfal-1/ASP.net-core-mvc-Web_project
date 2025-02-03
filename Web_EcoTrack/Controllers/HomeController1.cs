using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_EcoTrack.Controllers
{
    public class AIController : Controller
    {
        private readonly HttpClient _httpClient;

        public AIController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> AnalyzeImage()
        {
            var file = Request.Form.Files[0];

            if (file != null && file.Length > 0)
            {
                // حفظ الصورة مؤقتًا في المجلد wwwroot/uploads
                var filePath = Path.Combine("wwwroot/uploads", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // إرسال الصورة إلى خادم YOLOv8 لمعالجتها
                var formData = new MultipartFormDataContent();
                formData.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(filePath)), "file", file.FileName);

                var response = await _httpClient.PostAsync("http://localhost:5000/predict", formData);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Json(new { processed_image_url = $"/uploads/{file.FileName}", objects_detected = result });
                }

                return BadRequest("خطأ في معالجة الصورة بواسطة الذكاء الاصطناعي.");
            }

            return BadRequest("لم يتم تحميل أي صورة.");
        }
    }
}