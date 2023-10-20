namespace Treehoot.Domain.Models
{
    public class Player : IComparable<Player>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Scores { get; set; }

        //bigger number - better person
        public int CompareTo(Player other)
        {
            if (other == null)
            {
                return 1;
            }

            if(this.Scores.Sum() > other.Scores.Sum())
            {
                return 1;
            }

            if (this.Scores.Sum() == other.Scores.Sum())
            {
                return 0;
            }

            if (this.Scores.Sum() < other.Scores.Sum())
            {
                return -1;
            }

            //escaped all ifs somehow
            return -2;
        }
    }
}
