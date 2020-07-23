namespace leetcode.basics
{
    public sealed class Pair<TFirst, TSecond>
    {
        #region [Fields]
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        #endregion

        #region [Construct]
        public Pair() { }
        public Pair(TFirst varFirst, TSecond varSecond)
        {
            First = varFirst;
            Second = varSecond;
        }
        #endregion

        #region [Business]
        public override int GetHashCode()
        {
            return (First.GetHashCode() << 5) ^ Second.GetHashCode();
        }
        public bool Equals(Pair<TFirst, TSecond> varOther)
        {
            return First.Equals(varOther.First) && Second.Equals(varOther.Second);
        }
        public override bool Equals(object varOther)
        {
            var otherPair = varOther as Pair<TFirst, TSecond>;
            return (otherPair != null && Equals(otherPair));
        }
        #endregion
    }
}