namespace Workshop.Refactoring.Step1
{
    public class InsuranceDoc
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual long? InitPrice { get; set; }
        public virtual long? TotalPrice { get; set; }
        public double Tavarom { get; set; }


        public virtual long? MonthDuration { get; set; }

        public bool IsCaclulated { get; set; }

        public virtual void Calculate()
        {
            //LoadInitDataFromDb();

            TotalPrice = InitPrice*MonthDuration;
            
            //IsCaclulated = true;
        }

        private void LoadInitDataFromDb()
        {
            Tavarom = .23;
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


