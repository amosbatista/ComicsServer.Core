
namespace AmosBatista.ComicsServer.Core.Data.Context
{
    public class Map
    {
        // Database fields
        public int mapID { get; set;}
        public int X {get;set;}
        public int Y { get; set;}
        public double Scale {get;set;}
        public int PageId { get; set; }
    }
}
