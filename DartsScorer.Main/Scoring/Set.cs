using DartsScorer.Main.Match;

namespace DartsScorer.Main.Scoring
{
    /// <summary>
    /// Represents a set in a darts match, which is a collection of legs.
    /// In darts, a set consists of multiple legs, and players typically need to win a certain number of legs to win a set.
    /// </summary>
    public class Set
    {
        /// <summary>
        /// Gets the private collection of legs in this set.
        /// </summary>
        private ICollection<CommonLeg> Legs { get; } = new List<CommonLeg>();

        /// <summary>
        /// Gets an array of all legs in this set.
        /// </summary>
        public CommonLeg[] SetLegs => Legs.ToArray();

        /// <summary>
        /// Adds a leg to this set.
        /// </summary>
        /// <param name="leg">The leg to add to this set</param>
        public void AddLeg(Leg leg)
        {
            Legs.Add(leg);
        }
    }
}