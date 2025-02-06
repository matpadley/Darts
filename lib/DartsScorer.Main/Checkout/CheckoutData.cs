using DartsScorer.Main.Scoring;

namespace DartsScorer.Main.Checkout;

public class CheckoutData
{
    public readonly Dictionary<int, ThrowScore[]> Scores = new();

    public CheckoutData()
    {
Scores.Add(170, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
]);
Scores.Add(167, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
]);
Scores.Add(164, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
]);
Scores.Add(161, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
    ,    new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
]);
Scores.Add(160, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(158, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
]);
Scores.Add(157, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(156, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(155, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
]);
Scores.Add(154, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(153, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(152, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(151, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(150, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(149, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(148, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(147, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(146, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(145, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(144, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(143, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(142, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(141, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(140, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(139, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(138, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(137, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(136, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(135, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(134, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(133, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(132, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(131, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(130, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Five)
]);
Scores.Add(129, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Six)
]);
Scores.Add(128, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(127, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(126, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Six)
]);
Scores.Add(125, [
    new ThrowScore(Multiplier.Double, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
]);
Scores.Add(124, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(123, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Nine)
]);
Scores.Add(122, [
    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(121, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Triple, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(120, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(119, [
    new ThrowScore(Multiplier.Single, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
    
]);
Scores.Add(118, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(117, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(116, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(115, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(114, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(113, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(112, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(111, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(110, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(109, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(108, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(107, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Single, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(106, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(105, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(104, [
    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Single, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(103, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Eleven)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(102, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Single, BoardScore.Ten)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(101, [
    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Single, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(100, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(99, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Single, BoardScore.Ten)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(98, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
]);
Scores.Add(97, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(96, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(95, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
]);
Scores.Add(94, [
    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(93, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(92, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(91, [
    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(90, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Fifteen)
]);
Scores.Add(89, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(88, [
    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(87, [
    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(86, [
    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(85, [
    new ThrowScore(Multiplier.Triple, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(84, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(83, [
    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(82, [
     new ThrowScore(Multiplier.Double, BoardScore.Nineteen),
    new ThrowScore(Multiplier.Single, BoardScore.Four),
    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(81, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(80, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Ten)
]);
Scores.Add(79, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eleven)
]);
Scores.Add(78, [
    new ThrowScore(Multiplier.Triple, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(77, [
    new ThrowScore(Multiplier.Triple, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(76, [
    new ThrowScore(Multiplier.Triple, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(75, [
    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(74, [
    new ThrowScore(Multiplier.Triple, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(73, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(72, [
    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(71, [
    new ThrowScore(Multiplier.Triple, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(70, [
    new ThrowScore(Multiplier.Single, BoardScore.Ten),
    new ThrowScore(Multiplier.Single, BoardScore.Twenty),
    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
    
]);
Scores.Add(69, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Six)
]);
Scores.Add(68, [
    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Ten)
]);
Scores.Add(67, [
    new ThrowScore(Multiplier.Triple, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(66, [
    new ThrowScore(Multiplier.Triple, BoardScore.Ten)
,    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(65, [
    new ThrowScore(Multiplier.Triple, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(64, [
    new ThrowScore(Multiplier.Triple, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(63, [
    new ThrowScore(Multiplier.Triple, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(62, [
    new ThrowScore(Multiplier.Triple, BoardScore.Ten)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(61, [
    new ThrowScore(Multiplier.Triple, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(60, [
    new ThrowScore(Multiplier.Single, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(59, [
    new ThrowScore(Multiplier.Single, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(58, [
    new ThrowScore(Multiplier.Single, BoardScore.Eighteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(57, [
    new ThrowScore(Multiplier.Single, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(56, [
    new ThrowScore(Multiplier.Single, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(55, [
    new ThrowScore(Multiplier.Single, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(54, [
    new ThrowScore(Multiplier.Single, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(53, [
    new ThrowScore(Multiplier.Single, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(52, [
    new ThrowScore(Multiplier.Single, BoardScore.Twenty)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(51, [
    new ThrowScore(Multiplier.Single, BoardScore.Nineteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(50, [
    new ThrowScore(Multiplier.Single, BoardScore.BullsEye)
]);
Scores.Add(49, [
    new ThrowScore(Multiplier.Single, BoardScore.Seventeen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(48, [
    new ThrowScore(Multiplier.Single, BoardScore.Sixteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(47, [
    new ThrowScore(Multiplier.Single, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(46, [
    new ThrowScore(Multiplier.Single, BoardScore.Fourteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(45, [
    new ThrowScore(Multiplier.Single, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(44, [
    new ThrowScore(Multiplier.Single, BoardScore.Twelve)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(43, [
    new ThrowScore(Multiplier.Single, BoardScore.Eleven)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(42, [
    new ThrowScore(Multiplier.Single, BoardScore.Ten)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(41, [
    new ThrowScore(Multiplier.Single, BoardScore.Nine)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(40, [
    new ThrowScore(Multiplier.Double, BoardScore.Twenty)
]);
Scores.Add(39, [
    new ThrowScore(Multiplier.Single, BoardScore.Seven)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(38, [
    new ThrowScore(Multiplier.Double, BoardScore.Nineteen)
]);
Scores.Add(37, [
    new ThrowScore(Multiplier.Single, BoardScore.Five)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(36, [
    new ThrowScore(Multiplier.Double, BoardScore.Eighteen)
]);
Scores.Add(35, [
    new ThrowScore(Multiplier.Single, BoardScore.Three)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(34, [
    new ThrowScore(Multiplier.Double, BoardScore.Seventeen)
]);
Scores.Add(33, [
    new ThrowScore(Multiplier.Single, BoardScore.One)
,    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(32, [
    new ThrowScore(Multiplier.Double, BoardScore.Sixteen)
]);
Scores.Add(31, [
    new ThrowScore(Multiplier.Single, BoardScore.Fifteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(30, [
    new ThrowScore(Multiplier.Double, BoardScore.Fifteen)
]);
Scores.Add(29, [
    new ThrowScore(Multiplier.Single, BoardScore.Thirteen)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(28, [
    new ThrowScore(Multiplier.Double, BoardScore.Fourteen)
]);
Scores.Add(27, [
    new ThrowScore(Multiplier.Single, BoardScore.Eleven)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(26, [
    new ThrowScore(Multiplier.Double, BoardScore.Thirteen)
]);
Scores.Add(25, [
    new ThrowScore(Multiplier.Single, BoardScore.Nine)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(24, [
    new ThrowScore(Multiplier.Double, BoardScore.Twelve)
]);
Scores.Add(23, [
    new ThrowScore(Multiplier.Single, BoardScore.Seven)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(22, [
    new ThrowScore(Multiplier.Double, BoardScore.Eleven)
]);
Scores.Add(21, [
    new ThrowScore(Multiplier.Single, BoardScore.Five)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(20, [
    new ThrowScore(Multiplier.Double, BoardScore.Ten)
]);
Scores.Add(19, [
    new ThrowScore(Multiplier.Single, BoardScore.Three)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(18, [
    new ThrowScore(Multiplier.Double, BoardScore.Nine)
]);
Scores.Add(17, [
    new ThrowScore(Multiplier.Single, BoardScore.One)
,    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(16, [
    new ThrowScore(Multiplier.Double, BoardScore.Eight)
]);
Scores.Add(15, [
    new ThrowScore(Multiplier.Single, BoardScore.Seven)
,    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(14, [
    new ThrowScore(Multiplier.Double, BoardScore.Seven)
]);
Scores.Add(13, [
    new ThrowScore(Multiplier.Single, BoardScore.Five)
,    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(12, [
    new ThrowScore(Multiplier.Double, BoardScore.Six)
]);
Scores.Add(11, [
    new ThrowScore(Multiplier.Single, BoardScore.Three)
,    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(10, [
    new ThrowScore(Multiplier.Double, BoardScore.Five)
]);
Scores.Add(9, [
    new ThrowScore(Multiplier.Single, BoardScore.One)
,    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(8, [
    new ThrowScore(Multiplier.Double, BoardScore.Four)
]);
Scores.Add(7, [
    new ThrowScore(Multiplier.Single, BoardScore.Three)
,    new ThrowScore(Multiplier.Double, BoardScore.Two)
]);
Scores.Add(6, [
    new ThrowScore(Multiplier.Double, BoardScore.Three)
]);
Scores.Add(5, [
    new ThrowScore(Multiplier.Single, BoardScore.One)
,    new ThrowScore(Multiplier.Double, BoardScore.Two)
]);
Scores.Add(4, [
    new ThrowScore(Multiplier.Double, BoardScore.Two)
]);
Scores.Add(3, [
    new ThrowScore(Multiplier.Single, BoardScore.One)
,    new ThrowScore(Multiplier.Double, BoardScore.One)
]);
Scores.Add(2, [
    new ThrowScore(Multiplier.Double, BoardScore.One)
]);


    }
}