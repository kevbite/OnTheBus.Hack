namespace OnTheBus.Hack.Calculator.Messages.Events
{
    public class SubtractedEvent
    {
        public decimal Value1 { get; set; }
        
        public decimal Value2 { get; set; }

        public decimal Result { get; set; }
    }
}
