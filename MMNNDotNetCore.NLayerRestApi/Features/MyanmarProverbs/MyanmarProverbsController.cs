using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MMNNDotNetCore.NLayerRestApi.Features.MyanmarProverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetTitleList()
    {
        MyanmarProverbsModel model = await GetApiData();
        return Ok(model.Tbl_MMProverbsTitle);
    }

    [HttpGet("{titleName}")]
    public async Task<IActionResult> GetByTitleName(string titleName)
    {
        MyanmarProverbsModel model = await GetApiData();
        MMProverbsTitle? title = model.Tbl_MMProverbsTitle.FirstOrDefault(w => w.TitleName == titleName);
        if (title is null)
        {
            return Ok("Title is not found!");
        }
        
        MMProverbsDetail? detail = model.Tbl_MMProverbs.FirstOrDefault(w => w.TitleId == title.TitleId);
        if (detail is null)
        {
            return Ok("Detail is not found!");
        }
        return Ok(detail);
    }

    public async Task<IActionResult> Get(int titleId, int proverbId)
    {
        MyanmarProverbsModel model = await GetApiData();
        MMProverbsDetail? detail = model.Tbl_MMProverbs
            .FirstOrDefault(x => x.TitleId == titleId
                                 && x.ProverbId == proverbId);
        if (detail is null)
        {
            return Ok("Data is nt found!");
        }

        return Ok(detail);
    }

    private async Task<MyanmarProverbsModel> GetApiData()
    {
        MyanmarProverbsModel model = new MyanmarProverbsModel();
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
        if (response.IsSuccessStatusCode)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<MyanmarProverbsModel>(jsonStr)!;
        }

        return model;
    }
}