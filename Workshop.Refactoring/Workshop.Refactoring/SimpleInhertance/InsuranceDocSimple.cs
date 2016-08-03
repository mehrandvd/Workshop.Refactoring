namespace Workshop.Refactoring
{
    public class InsuranceDocSimple
    {
        public virtual int Id { get; set; }
    }

    public class CarInsuranceDocSimple : InsuranceDocSimple
    {
        #region To move up
        public virtual string Code { get; set; }
        public virtual double? InitPrice { get; set; }
        public virtual double? TotalPrice { get; set; }
        public double Discount { get; set; }


        public virtual long? MonthDuration { get; set; }

        public bool IsCaclulated { get; set; }

        public virtual void Calculate()
        {
            //LoadScore();

            TotalPrice = (InitPrice * MonthDuration) * (1 - Discount);

            //IsCaclulated = true;
        }

        private void LoadScore()
        {
            Discount = .2;
        }

        #endregion


        public virtual long? FixedPrice { get; set; }
        //public override void Calculate()
        //{
        //    TotalPrice = ( InitPrice + FixedPrice)  * MonthDuration;
        //}
    }

    public class HouseInsuranceDocSimple : InsuranceDocSimple
    {
        public int HousePrice { get; set; }
    }
}


