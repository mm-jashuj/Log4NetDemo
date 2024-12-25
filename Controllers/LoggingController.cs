
using log4net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoggingController : ControllerBase
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(LoggingController));

    [HttpGet("test")]
    public IActionResult TestLogging()
    {
        _logger.Info("Info log message");
        _logger.Warn("Warning log message");
        _logger.Error("Error log message");
        _logger.Debug("Debug log message");
        _logger.Fatal("Fatal log message");

        return Ok(new { Message = "Logging test completed. Check the console and log files." });
    }

    [HttpGet("get")]
    public IActionResult GetSampleData()
    {
        _logger.Info("Sample data fetched successfully.");
        return Ok(new { Data = new[] { "Item1", "Item2", "Item3" } });
    }

    [HttpPost("post")]
    public IActionResult PostSampleData([FromBody] string data)
    {
        _logger.Info($"Data received: {data}");
        return Ok(new { Message = "Data posted successfully", ReceivedData = data });
    }

    [HttpPut("update")]
    public IActionResult UpdateSampleData([FromBody] string data)
    {
        _logger.Info($"Data updated: {data}");
        return Ok(new { Message = "Data updated successfully", UpdatedData = data });
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteSampleData(int id)
    {
        _logger.Warn($"Data with ID {id} has been deleted.");
        return Ok(new { Message = $"Data with ID {id} deleted successfully" });
    }
}
