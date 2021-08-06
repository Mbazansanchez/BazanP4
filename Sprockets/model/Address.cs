namespace sprocket.model
{
    public class Address
    {
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Street { get; set; }
        
        public string ZipCode { get; set; }
        
        public override string ToString()
        {
            return $"{Street}\n{City} {State} {ZipCode}";
        }

    }
}