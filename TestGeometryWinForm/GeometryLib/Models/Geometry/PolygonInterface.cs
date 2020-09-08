namespace GeometryLib.Models.Geometry
{
    // Interface segregation principle (SOLID)
    public interface PolygonInterface : PolygonAccessInterface, PolygonOperationInterface
    {
    }
}