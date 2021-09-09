namespace visualtrees
{
    public class Connection
    {
        public Coord StartNode { get; set; }
        public Coord EndNode { get; set; }

        public Connection(Coord start, Coord end)
        {
            StartNode = start;
            EndNode = end;
        }
    }

}
