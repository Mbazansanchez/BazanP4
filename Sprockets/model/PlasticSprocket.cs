namespace sprocket.model
{
    public class PlasticSprocket : Sprocket
    {
        public PlasticSprocket()
        {
        }

        public PlasticSprocket(int itemId, int numItems, int numTeeth) : base(itemId, numItems, numTeeth)
        {
        }

        protected override decimal Calc()
        {
            return NumTeeth*NumItems*0.02m;
        }

        public override string ToString()
        {
            return base.ToString() + " Material: plastic";
        }
    }
}