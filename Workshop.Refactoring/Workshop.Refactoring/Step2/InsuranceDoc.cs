using System;

namespace Workshop.Refactoring.Step2
{
    public class InsuranceDoc
    {
        public virtual int Id { get; set; }
        public virtual string Code { get; set; }
        public virtual long? InitPrice { get; set; }
        public virtual long? TotalPrice { get; set; }

        public virtual long? MonthDuration { get; set; }

        public bool IsCaclulated { get; set; }
        public string History { get; set; }


        public virtual void CalculateImpl()
        {
            TotalPrice = InitPrice * MonthDuration;
        }

        public void Calculate()
        {

            // Always runs before
            LoadHistory();
            //

            OnCalculating();
            CalculateImpl();
            OnCalculated();

            // Always runs after
            IsCaclulated = true;
            //

        }

        private void LoadHistory()
        {
            History = "Some history from a web service or database.";
        }


        public void OnCalculated()
        {
            Calculated?.Invoke(this, null);
        }

        public void OnCalculating()
        {
            Calculating?.Invoke(this, null);
        }

        public event EventHandler Calculated ;
        public event EventHandler Calculating ;
    }

    public class CarInsuranceDoc : InsuranceDoc
    {
        public virtual long? FixedPrice { get; set; }
        public override void CalculateImpl()
        {
            TotalPrice = ( InitPrice + FixedPrice)  * MonthDuration;
        }
    }

    public class HouseInsuranceDoc : InsuranceDoc
    {
        
    }
}
