using DartsScorer.Main.Scoring;
using DartsScorer.Main.Scoring.x01;

namespace DartsScorer.Main.Models
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