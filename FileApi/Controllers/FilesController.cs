using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet(Name = "DownloadFile")]
        public IActionResult DownloadFile(string filename)
        {
           
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", filename);
            var stream = new FileStream(path, FileMode.Open);
           
            return File(stream, "application/octet-streama", filename);
        }
        [HttpGet("IP")]
        public IActionResult YourIP6()
        {
            string hostName = Dns.GetHostName(); // Retrieve the Name of HOST
            // Get the IP
            IPAddress[] addresses = Dns.GetHostEntry(hostName).AddressList;
            string myIP = addresses.Length > 0 ? addresses[0].ToString() : "No IP address found.";
            return Content(myIP);
        }


    }
}
