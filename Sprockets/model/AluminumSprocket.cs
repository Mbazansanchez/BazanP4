namespace sprocket.model
{
    public class AluminumSprocket : Sprocket
    {
        public AluminumSprocket()
        {
        }

        public AluminumSprocket(int itemId, int numItems, int numTeeth) : base(itemId, numItems, numTeeth)
        {
        }

        protected override decimal Calc()
        {
            return NumTeeth*NumItems*0.04m;
        }

        public override string ToString()
        {
            return base.ToString() + " Material: aluminum";
        }
    }
}