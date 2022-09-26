using Microsoft.AspNetCore.Mvc;
using Path = System.IO.Path;

namespace Airedale.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ImageServerController : ControllerBase {
    /// <summary>
    /// Uploads an image to the server
    /// Requires authentication
    /// </summary>
    /// <param name="file"></param>
    [HttpPut]
    public async Task<IActionResult> Upload(IFormFile file) {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", file.FileName);

        await using (var stream = new FileStream(filePath, FileMode.Create)) {
            await file.CopyToAsync(stream);
        }

        return Ok();
    }

    /// <summary>
    /// Deletes an image from the server
    /// Requires authentication
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult Delete(string fileName) {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);

        if (System.IO.File.Exists(filePath)) {
            System.IO.File.Delete(filePath);
        }

        return Ok();
    }

    /// <summary>
    /// Gets an image from the server
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get(string fileName) {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);

        if (!System.IO.File.Exists(filePath)) {
            return NotFound();
        }

        return PhysicalFile(filePath, "image/jpeg");
    }

    /// <summary>
    /// Lists all images on the server
    /// Requires authentication
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<string?> List() {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images");

        return Directory.GetFiles(filePath).Select(Path.GetFileName);
    }
}