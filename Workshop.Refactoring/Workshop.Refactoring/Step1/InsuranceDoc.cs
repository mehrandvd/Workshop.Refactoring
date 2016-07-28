namespace Workshop.Refactoring.Step1
{
    public class InsuranceDoc
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual double? InitPrice { get; set; }
        public virtual double? TotalPrice { get; set; }
        public double Discount { get; set; }


        public virtual long? MonthDuration { get; set; }

        public bool IsCaclulated { get; set; }

        public virtual void Calculate()
        {
            //LoadScore();

            TotalPrice = (InitPrice*MonthDuration)*(1 - Discount);

            //IsCaclulated = true;
        }

        private void LoadScore()
        {
            Discount = .2;
        }

    }

    public class CarInsuranceDoc : InsuranceDoc
    {
        public virtual long? FixedPrice { get; set; }
        public override void Calculate()
        {
            TotalPrice = ( InitPrice + FixedPrice)  * MonthDuration;
        }
    }

    public class HouseInsuranceDoc : InsuranceDoc
    {
        
    }
}


