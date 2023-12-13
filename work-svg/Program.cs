using Svg;
using System;

public static class Program
{
    public static void Main(string[] args)
    {
        string pathFile = "C:\\Users\\wesley.alves\\Downloads\\files\\img.svg";
        SvgDocument svgDocument = SvgDocument.Open(pathFile);
        SvgElement areaContainer = svgDocument.GetElementById("area-container");

        List<DrawnAreas> areaList = new();

        areaList = areaContainer.Children.Select(area => new DrawnAreas
        {
            content = RemoveHeaderXML(area.GetXML())
        }).ToList();

        areaContainer.Children.Clear();
        areaContainer.Content = "{{area}}";

        AddressMap addressMap = new()
        {
            template = RemoveHeaderXML(svgDocument.GetXML()),
            drawnAreaList = areaList
        };

        Console.WriteLine("Objeto estruturado.");
    }

    private static string RemoveHeaderXML(string scriptXML)
    {
        var formaterArray = scriptXML.Split("<?xml version=\"1.0\" encoding=\"utf-16\"?>");
        return formaterArray.Last();
    }
}

public class AddressMap
{
    public int id { get; set; }
    public string template { get; set; }    
    public List<DrawnAreas> drawnAreaList { get; set; }
}

public class DrawnAreas
{
    public long addressMapId { get; set; }
    public string content { get; set; }
}