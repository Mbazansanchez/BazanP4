namespace sprocket.model
{
    public abstract class Sprocket
    {
        public int NumItems { get; set; }
        public int NumTeeth { get; set; }
    
        public decimal Price { get { return Calc(); } }
        public int ItemId { get; }

        public Sprocket() { }

        public Sprocket(int itemId, int numItems, int numTeeth) {
            ItemId = itemId;
            NumItems = numItems;
            NumTeeth = numTeeth;
        }

        protected abstract decimal Calc();

        public override string ToString()
        {
            return $"Order num: {ItemId} Number: {NumItems} Teeth: {NumTeeth} Price: ${Price}";
        }

    }
}