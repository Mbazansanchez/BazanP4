namespace sprocket.model
{
    public class SteelSprocket : Sprocket
    {
        public SteelSprocket()
        {
        }

        public SteelSprocket(int itemId, int numItems, int numTeeth) : base(itemId, numItems, numTeeth)
        {
        }

        protected override decimal Calc()
        {
            return NumTeeth*NumItems*0.05m;
        }

        public override string ToString()
        {
            return base.ToString() + " Material: steel";
        }
    }
}