namespace GeometryLib.Models.Geometry
{
    public enum RelativePointPosition
    {
        LEFT,
        RIGHT,
        BEYOND, // defore begin of Edge
        BEHIND, // after end of Edge
        BETWEEN, // on Edge
        ORIGIN, // begin of Edge
        DESTINTION // end of Edge
    }
}
