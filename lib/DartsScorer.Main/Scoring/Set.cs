using DartsScorer.Main.Match;

namespace DartsScorer.Main.Scoring
{
    public class Set
    {
        private ICollection<CommonLeg> Legs { get; } = new List<CommonLeg>();

        public CommonLeg[] SetLegs => Legs.ToArray();

        public void AddLeg(Leg leg)
        {
            Legs.Add(leg);
        }
    }
}