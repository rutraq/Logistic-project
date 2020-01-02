using System;

namespace LogisticProgram
{
    class Transport
    {
        public int Number { get; set; }
        public string StateNubmer { get; set; }
        public string DateShipping { get; set; }
        public string DateShipped { get; set; }
        public decimal Weight { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return $"{Number}, {StateNubmer}, {DateShipping}, {DateShipped}, {Weight}, {Price}, {Currency}\n";
        }
    }
}
