using System;

namespace YandexHypothesis8
{
    class OrderLine
    {
        public DateTime Date { get; set; }
        public int Cutlery { get; set; }
        public int Tips { get; set; }
        public int OrderPrice { get; set; }
        public int Uid { get; set; }
        public int OrderId { get; set; }

        public string ToBackString()
        {
            return string.Join(",", Date, Cutlery, Tips, OrderPrice, Uid, OrderId);
        }
    }
}
