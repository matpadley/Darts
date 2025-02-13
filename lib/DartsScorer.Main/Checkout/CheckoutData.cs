using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Checkout;

public static class CheckoutData
{
    public static readonly Dictionary<int, ThrowScore[]> Scores = new()
    {
        {
            170, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            ]
        },
        {
            167, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            ]
        },
        {
            164, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            ]
        },
        {
            161, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
            ]
        },
        {
            160, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            158, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            ]
        },
        {
            157, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            156, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            155, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            ]
        },
        {
            154, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            153, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            152, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            151, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            150, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            149, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            148, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            147, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            146, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            145, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            144, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            143, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            142, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            141, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            140, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            139, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            138, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            137, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            136, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            135, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            134, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            133, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            132, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            131, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            130, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Five)
            ]
        },
        {
            129, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Six)
            ]
        },
        {
            128, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Four)
            ]
        },
        {
            127, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            126, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Six)
            ]
        },
        {
            125, [
                new ThrowScore(Multiplier.Double, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            ]
        },
        {
            124, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            123, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nine)
            ]
        },
        {
            122, [
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Four)
            ]
        },
        {
            121, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            120, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            119, [
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            118, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            117, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            116, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            115, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            114, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            113, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            112, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            111, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            110, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            109, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            108, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            107, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            106, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            105, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            104, [
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            103, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Single, BoardScore.Eleven),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            102, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty), new ThrowScore(Multiplier.Single, BoardScore.Ten),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            101, [
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            100, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            99, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.Ten),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            98, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            ]
        },
        {
            97, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            96, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            95, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
            ]
        },
        {
            94, [
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            93, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            92, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            91, [
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            90, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Fifteen)
            ]
        },
        {
            89, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            88, [
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            87, [
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            86, [
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            85, [
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            84, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            83, [
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            82, [
                new ThrowScore(Multiplier.Double, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Single, BoardScore.Four),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            81, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            80, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty), new ThrowScore(Multiplier.Double, BoardScore.Ten)
            ]
        },
        {
            79, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eleven)
            ]
        },
        {
            78, [
                new ThrowScore(Multiplier.Treble, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            77, [
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            76, [
                new ThrowScore(Multiplier.Treble, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            75, [
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            74, [
                new ThrowScore(Multiplier.Treble, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            73, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            72, [
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            71, [
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            70, [
                new ThrowScore(Multiplier.Single, BoardScore.Ten),
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            69, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Six)
            ]
        },
        {
            68, [
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen), new ThrowScore(Multiplier.Double, BoardScore.Ten)
            ]
        },
        {
            67, [
                new ThrowScore(Multiplier.Treble, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            66, [
                new ThrowScore(Multiplier.Treble, BoardScore.Ten),
                new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
            ]
        },
        {
            65, [
                new ThrowScore(Multiplier.Treble, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Four)
            ]
        },
        {
            64, [
                new ThrowScore(Multiplier.Treble, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            63, [
                new ThrowScore(Multiplier.Treble, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twelve)
            ]
        },
        {
            62, [
                new ThrowScore(Multiplier.Treble, BoardScore.Ten), new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            61, [
                new ThrowScore(Multiplier.Treble, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        {
            60, [
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            59, [
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            58, [
                new ThrowScore(Multiplier.Single, BoardScore.Eighteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            57, [
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            56, [
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            55, [
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            54, [
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            53, [
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Twenty)
            ]
        },
        {
            52, [
                new ThrowScore(Multiplier.Single, BoardScore.Twenty),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            51, [
                new ThrowScore(Multiplier.Single, BoardScore.Nineteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        { 50, [new ThrowScore(Multiplier.Single, BoardScore.BullsEye)] },
        {
            49, [
                new ThrowScore(Multiplier.Single, BoardScore.Seventeen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            48, [
                new ThrowScore(Multiplier.Single, BoardScore.Sixteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            47, [
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            46, [
                new ThrowScore(Multiplier.Single, BoardScore.Fourteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            45, [
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            44, [
                new ThrowScore(Multiplier.Single, BoardScore.Twelve),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            43, [
                new ThrowScore(Multiplier.Single, BoardScore.Eleven),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            42, [
                new ThrowScore(Multiplier.Single, BoardScore.Ten), new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        {
            41, [
                new ThrowScore(Multiplier.Single, BoardScore.Nine),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        { 40, [new ThrowScore(Multiplier.Double, BoardScore.Twenty)] },
        {
            39, [
                new ThrowScore(Multiplier.Single, BoardScore.Seven),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        { 38, [new ThrowScore(Multiplier.Double, BoardScore.Nineteen)] },
        {
            37, [
                new ThrowScore(Multiplier.Single, BoardScore.Five),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        { 36, [new ThrowScore(Multiplier.Double, BoardScore.Eighteen)] },
        {
            35, [
                new ThrowScore(Multiplier.Single, BoardScore.Three),
                new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        { 34, [new ThrowScore(Multiplier.Double, BoardScore.Seventeen)] },
        {
            33, [
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
            ]
        },
        { 32, [new ThrowScore(Multiplier.Double, BoardScore.Sixteen)] },
        {
            31, [
                new ThrowScore(Multiplier.Single, BoardScore.Fifteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 30, [new ThrowScore(Multiplier.Double, BoardScore.Fifteen)] },
        {
            29, [
                new ThrowScore(Multiplier.Single, BoardScore.Thirteen),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 28, [new ThrowScore(Multiplier.Double, BoardScore.Fourteen)] },
        {
            27, [
                new ThrowScore(Multiplier.Single, BoardScore.Eleven),
                new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 26, [new ThrowScore(Multiplier.Double, BoardScore.Thirteen)] },
        {
            25, [
                new ThrowScore(Multiplier.Single, BoardScore.Nine), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 24, [new ThrowScore(Multiplier.Double, BoardScore.Twelve)] },
        {
            23, [
                new ThrowScore(Multiplier.Single, BoardScore.Seven), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 22, [new ThrowScore(Multiplier.Double, BoardScore.Eleven)] },
        {
            21, [
                new ThrowScore(Multiplier.Single, BoardScore.Five), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 20, [new ThrowScore(Multiplier.Double, BoardScore.Ten)] },
        {
            19, [
                new ThrowScore(Multiplier.Single, BoardScore.Three), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 18, [new ThrowScore(Multiplier.Double, BoardScore.Nine)] },
        {
            17, [
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Eight)
            ]
        },
        { 16, [new ThrowScore(Multiplier.Double, BoardScore.Eight)] },
        {
            15, [
                new ThrowScore(Multiplier.Single, BoardScore.Seven), new ThrowScore(Multiplier.Double, BoardScore.Four)
            ]
        },
        { 14, [new ThrowScore(Multiplier.Double, BoardScore.Seven)] },
        {
            13, [
                new ThrowScore(Multiplier.Single, BoardScore.Five), new ThrowScore(Multiplier.Double, BoardScore.Four)
            ]
        },
        { 12, [new ThrowScore(Multiplier.Double, BoardScore.Six)] },
        {
            11, [
                new ThrowScore(Multiplier.Single, BoardScore.Three), new ThrowScore(Multiplier.Double, BoardScore.Four)
            ]
        },
        { 10, [new ThrowScore(Multiplier.Double, BoardScore.Five)] },
        {
            9, [
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Four)
            ]
        },
        { 8, [new ThrowScore(Multiplier.Double, BoardScore.Four)] },
        {
            7, [
                new ThrowScore(Multiplier.Single, BoardScore.Three), new ThrowScore(Multiplier.Double, BoardScore.Two)
            ]
        },
        { 6, [new ThrowScore(Multiplier.Double, BoardScore.Three)] },
        {
            5, [
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.Two)
            ]
        },
        { 4, [new ThrowScore(Multiplier.Double, BoardScore.Two)] },
        {
            3, [
                new ThrowScore(Multiplier.Single, BoardScore.One), new ThrowScore(Multiplier.Double, BoardScore.One)
            ]
        },
        { 2, [new ThrowScore(Multiplier.Double, BoardScore.One)] },

    };
}