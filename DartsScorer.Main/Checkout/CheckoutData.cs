using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Checkout;

/// <summary>
/// Contains pre-computed optimal checkout patterns for scores from 2-170 in X01 games.
/// This class provides a lookup table of the best ways to finish a game from various scores.
/// </summary>
public static class CheckoutData
{
    /// <summary>
    /// A dictionary mapping remaining scores to arrays of optimal throws to checkout.
    /// Keys are scores from 2-170, and values are arrays of ThrowScore objects representing
    /// the sequence of throws to achieve the checkout.
    /// </summary>
    public static readonly Dictionary<int, ThrowScore[]> Scores = new()
    {
        {
            170, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            }
        },
        {
            167, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            }
        },
        {
            164, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            }
        },
        {
            161, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            }
        },
        {
            160, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            158, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            }
        },
        {
            157, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            156, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            155, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            }
        },
        {
            154, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            153, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            152, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            151, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            150, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            149, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            148, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            147, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            146, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            145, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            144, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            143, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            142, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            141, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            140, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            139, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            138, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            137, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            136, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            135, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            134, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            133, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            132, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            131, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            130, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Five)
            }
        },
        {
            129, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Six)
            }
        },
        {
            128, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Four)
            }
        },
        {
            127, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            126, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Six)
            }
        },
        {
            125, new[]
            {
                new ThrowScore(Multiplier.Double, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            }
        },
        {
            124, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            123, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nine)
            }
        },
        {
            122, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Four)
            }
        },
        {
            121, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            120, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            119, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            118, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            117, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            116, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            115, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            114, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            113, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            112, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            111, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            110, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            109, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            108, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            107, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            106, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            105, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            104, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            103, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Eleven),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            102, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty), new ThrowScore(Multiplier.Single, BoardScore.Ten),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            101, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            100, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            99, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.Ten),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            98, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            }
        },
        {
            97, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            96, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            95, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            }
        },
        {
            94, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            93, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            92, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            91, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            90, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Fifteen)
            }
        },
        {
            89, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            88, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            87, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            86, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            85, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            84, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            83, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            82, new[]
            {
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.Four),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            81, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            80, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty), new ThrowScore(Multiplier.Double, BoardScore.Ten)
            }
        },
        {
            79, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eleven)
            }
        },
        {
            78, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            77, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            76, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            75, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            74, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            73, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            72, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            71, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            70, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Ten),
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            69, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Six)
            }
        },
        {
            68, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen), new ThrowScore(Multiplier.Double, BoardScore.Ten)
            }
        },
        {
            67, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            66, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Ten),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            }
        },
        {
            65, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Four)
            }
        },
        {
            64, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            63, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            }
        },
        {
            62, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Ten), new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            61, new[]
            {
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        {
            60, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            59, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            58, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            57, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            56, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            55, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            54, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            53, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            }
        },
        {
            52, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            51, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        { 50, new[] { new ThrowScore(Multiplier.Single, BoardScore.BullsEye) } },
        {
            49, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            48, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            47, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            46, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            45, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            44, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Twelve),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            43, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Eleven),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            42, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Ten), new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        {
            41, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Nine),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        { 40, new[] { new ThrowScore(Multiplier.Double, BoardScore.Twenty) } },
        {
            39, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Seven),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        { 38, new[] { new ThrowScore(Multiplier.Double, BoardScore.Nineteen) } },
        {
            37, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Five),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        { 36, new[] { new ThrowScore(Multiplier.Double, BoardScore.Eighteen) } },
        {
            35, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Three),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        { 34, new[] { new ThrowScore(Multiplier.Double, BoardScore.Seventeen) } },
        {
            33, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            }
        },
        { 32, new[] { new ThrowScore(Multiplier.Double, BoardScore.Sixteen) } },
        {
            31, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 30, new[] { new ThrowScore(Multiplier.Double, BoardScore.Fifteen) } },
        {
            29, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 28, new[] { new ThrowScore(Multiplier.Double, BoardScore.Fourteen) } },
        {
            27, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Eleven),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 26, new[] { new ThrowScore(Multiplier.Double, BoardScore.Thirteen) } },
        {
            25, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Nine), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 24, new[] { new ThrowScore(Multiplier.Double, BoardScore.Twelve) } },
        {
            23, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Seven), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 22, new[] { new ThrowScore(Multiplier.Double, BoardScore.Eleven) } },
        {
            21, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Five), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 20, new[] { new ThrowScore(Multiplier.Double, BoardScore.Ten) } },
        {
            19, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Three), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 18, new[] { new ThrowScore(Multiplier.Double, BoardScore.Nine) } },
        {
            17, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            }
        },
        { 16, new[] { new ThrowScore(Multiplier.Double, BoardScore.Eight) } },
        {
            15, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Seven), new ThrowScore(Multiplier.Double, BoardScore.Four)
            }
        },
        { 14, new[] { new ThrowScore(Multiplier.Double, BoardScore.Seven) } },
        {
            13, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Five), new ThrowScore(Multiplier.Double, BoardScore.Four)
            }
        },
        { 12, new[] { new ThrowScore(Multiplier.Double, BoardScore.Six) } },
        {
            11, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Three), new ThrowScore(Multiplier.Double, BoardScore.Four)
            }
        },
        { 10, new[] { new ThrowScore(Multiplier.Double, BoardScore.Five) } },
        {
            9, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Four)
            }
        },
        { 8, new[] { new ThrowScore(Multiplier.Double, BoardScore.Four) } },
        {
            7, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.Three), new ThrowScore(Multiplier.Double, BoardScore.Two)
            }
        },
        { 6, new[] { new ThrowScore(Multiplier.Double, BoardScore.Three) } },
        {
            5, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Two)
            }
        },
        { 4, new[] { new ThrowScore(Multiplier.Double, BoardScore.Two) } },
        {
            3, new[]
            {
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.One)
            }
        },
        { 2, new[] { new ThrowScore(Multiplier.Double, BoardScore.One) } },

    };
}