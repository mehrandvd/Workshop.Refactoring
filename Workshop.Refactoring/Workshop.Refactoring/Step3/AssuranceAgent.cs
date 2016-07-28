using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Refactoring.Step2;

namespace Workshop.Refactoring.Step3
{
    public interface IInsuranceDocPrinter<in T> where T : InsuranceDoc
    {
        void Print(T insuranceDoc);
    }

    public class InsuranceDocPrinter<T> : IInsuranceDocPrinter<T> where T : InsuranceDoc
    {

        public virtual void PrintImpl(T insuranceDoc)
        {
            Console.WriteLine($"Printing {insuranceDoc} with layout: {Layout}");
        }

        public void Print(T insuranceDoc)
        {
            PrintImpl(insuranceDoc);
        }

        public string Layout { get; set; }
    }

    public class CarInsuranceDocPrinter : InsuranceDocPrinter<CarInsuranceDoc>
    {
        public override void PrintImpl(CarInsuranceDoc insuranceDoc)
        {
            Console.WriteLine("Configuring Printer Settings for Car");
            base.PrintImpl(insuranceDoc);
            Console.WriteLine("Perforate");
        }
    }

    public class HouseInsuranceDocPrinter : InsuranceDocPrinter<HouseInsuranceDoc>
    {
        public override void PrintImpl(HouseInsuranceDoc insuranceDoc)
        {
            Console.WriteLine("Configuring Printer Settings for House");
            base.PrintImpl(insuranceDoc);
        }
    }
}
