using Microsoft.AspNetCore.Mvc;
using MMNNDotNetCore.NLayerRestApi.Model;
using Newtonsoft.Json;

namespace MMNNDotNetCore.NLayerRestApi.Features.LatHtaukBayDin;

[Route("api/[controller]")]
[ApiController]
public class LatHtaukBayDinController : ControllerBase
{
    [HttpGet("GetQuestions")]
    public async Task<IActionResult> Questions()
    {
        BayDinDataModel? model = await GetData();
        return Ok(model!.questions);
    }
    
    [HttpGet("GetNumbers")]
    public async Task<IActionResult> NumberList()
    {
        BayDinDataModel? model = await GetData();
        return Ok(model!.numberList);
    }

    [HttpGet("{questionNo}/{no}")]
    public async Task<IActionResult> Answer(int questionNo, int no)
    {
        BayDinDataModel? model = await GetData();
        return Ok(model!.answers.Where(w => w.questionNo == questionNo && w.answerNo == no));
    }

    private async Task<BayDinDataModel?> GetData()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
        BayDinDataModel? model = JsonConvert.DeserializeObject<BayDinDataModel>(jsonStr);
        return model;
    }
}