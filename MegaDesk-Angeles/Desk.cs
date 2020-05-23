namespace MegaDesk_Wood
{
    public enum DeskMaterial
    {
        Laminate,
        Oak,
        Pine,
        Rosewood,
        Veneer
    };
    public class Desk
    {
        //getters and setters
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public int SurfaceArea { get { return Width * Depth; } }
        public int Rush { get; set; }
        public string Material { get; set; }

        //constraints
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;
        public const int MINDRAWERS = 0;
        public const int MAXDRAWERS = 7;
    }
}
