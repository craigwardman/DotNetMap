namespace DotNetMap.MapZoomInformation.ZoomLevelCalculator
{
    internal interface IZoomLevelCalculator
    {
        int GetZoomLevel(BoundingBox boundingBox, int viewingWidthPx);
    }
}