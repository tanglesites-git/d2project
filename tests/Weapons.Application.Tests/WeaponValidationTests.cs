namespace Weapons.Application.Tests;

public class WeaponValidationTests
{
    [Fact]
    public void Should_Check_If_Url_Is_Jpg_Image()
    {
        var url = "420f8b4de34a98ff1d8d8d992359eb6a.jpg";
        var split = url.Split(".").Last();
        Assert.True(split is "png" or "jpg");
    }
    
    [Fact]
    public void Should_Check_If_Url_Is_Png_Image()
    {
        var url = "420f8b4de34a98ff1d8d8d992359eb6a.png";
        var split = url.Split(".").Last();
        Assert.True(split is "png" or "jpg");
    }
}