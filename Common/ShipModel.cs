namespace SwapiApiChallenge.Common
{
    public class AllShipsModel
    {
        public int count { get; set; }
        public string next { get; set; }

        public string previous { get; set; }

        public ShipModel[] results { set; get; }

    }
   

    public class ShipModel
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string Model { get; set; }
        public string Consumables { get; set; }
        public  string MGLT { get; set; }

    }
}