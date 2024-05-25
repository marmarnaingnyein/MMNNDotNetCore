namespace MMNNDotNetCore.Models;

public class MyanmarProverbsModel
{
    public MMProverbsTitle[] Tbl_MMProverbsTitle { get; set; }
    public MMProverbsDetail[] Tbl_MMProverbs { get; set; }
}

public class MMProverbsTitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class MMProverbsDetail
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}
