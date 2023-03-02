using ScintillaNet.Abstractions.UtilityClasses;

namespace AbstractionTests;

[TestClass]
public class ColorConvertTests
{
    [TestMethod]
    public void HtmlToColorToHtml1()
    {
        var color = "#0c6b91";
        var color1 = ColorHtmlConverter.HtmlColorToInt("#0c6b91");
        var color2 = ColorHtmlConverter.IntToHtmlColor(color1);
        Assert.AreEqual(color2, color);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void HtmlToColorToHtml2()
    {
        _ = ColorHtmlConverter.HtmlColorToInt("#0c6b9");
    }
}