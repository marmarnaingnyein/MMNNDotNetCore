using Microsoft.AspNetCore.Mvc;
using MMNNDotNetCore.NLayerRestApi.Model;
using Newtonsoft.Json;

namespace MMNNDotNetCore.NLayerRestApi.Features.Zodic;

[Route("api/[controller]")]
[ApiController]
public class ZodicController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetZodicList()
    {
        var model = await GetDataAsync();
        return Ok(model.ZodiacSignsDetail);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var model = await GetDataAsync();
        var result = model.ZodiacSignsDetail.FirstOrDefault(x => x.Id == id);
        return Ok(result);
    }


    [HttpGet("GetByDay/{birthday}")]
    public async Task<IActionResult> SearchByBirthDate(string birthday)
    {
        string[] lstStr = birthday.Split("-");
        int day = Convert.ToInt32(lstStr[0]);
        int month = Convert.ToInt32(lstStr[1]);
        
        if (month <= 0 || month > 12)
        {
            return Ok($"Birthday is wrong. Sample date format is 21-10-1990");
        }

        if (day <= 0 || day > 31)
        {
            return Ok($"Birthday is wrong. Sample date format is 21-10-1990");
        }
        
        var model = await GetDataAsync();
        var zodiacId = GetZodicId(month, day);
        if (zodiacId == 0)
        {
            return Ok($"Birthday is wrong. Sample date format is 21-10-1990");
        }
        
        var result = model.ZodiacSignsDetail.FirstOrDefault(x => x.Id == zodiacId);
        if (result is null)
        {
            return NotFound("Result is not found.");
        }

        return Ok(result);
    }

    private int GetZodicId(int month, int day)
    {
        if ((month == 3 && day >= 21 && day <= 31) || (month == 4 && day >= 01 && day <= 19))
        {
            return 1;
        }
        
        if ((month == 4 && day >= 20 && day <= 30) || (month == 5 && day >= 01 && day <= 20))
        {
            return 2;
        }
        if ((month == 5 && day >= 21 && day <= 31) || (month == 6 && day >= 01 && day <= 20))
        {
            return 3;
        }
        if ((month == 6 && day >= 21 && day <= 30) || (month == 7 && day >= 01 && day <= 22))
        {
            return 4;
        }
        if ((month == 7 && day >= 23 && day <= 31) || (month == 8 && day >= 01 && day <= 22))
        {
            return 5;
        }
        if ((month == 8 && day >= 23 && day <= 31) ||
                 (month == 9 && day >= 01 && day <= 22))
        {
            return 6;
        }
        if ((month == 9 && day >= 23 && day <= 30) ||
                 (month == 10 && day >= 01 && day <= 22))
        {
            return 7;
        }
        if ((month == 10 && day >= 23 && day <= 31) ||
                 (month == 11 && day >= 01 && day <= 21))
        {
            return 8;
        }
        if ((month == 11 && day >= 22 && day <= 30) ||
                 (month == 12 && day >= 01 && day <= 21))
        {
            return 9;
        }
        if ((month == 12 && day >= 22 && day <= 31) ||
                 (month == 1 && day >= 01 && day <= 19))
        {
            return 10;
        }
        if ((month == 1 && day >= 20 && day <= 31) ||
                 (month == 2 && day >= 01 && day <= 18))
        {
            return 11;
        }
        if ((month == 2 && day >= 19 && day <= 29) ||
            (month == 3 && day >= 01 && day <= 20))
        {
            return 12;
        }
        
        return 0;
    }

    private async Task<ZodicModel> GetDataAsync()
    {
        string json = await System.IO.File.ReadAllTextAsync("Zodiac.json");
        var model = JsonConvert.DeserializeObject<ZodicModel>(json)!;
        return model;
    }
}