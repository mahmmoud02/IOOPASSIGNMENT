using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project_2._0
{
    public class PrintingService
    {
        public string ServiceType { get; set; }
        public string size { get; set; }
        public double FeesPerUnit { get; set; }
        public int DiscountPercentage { get; set; }
        public bool IsUrgent { get; set; }
        public int Pages { get; set; }

        public double CalculateTotalPrice()
        {
            double total = 0;

            if (ServiceType == "Printing A4– Black and White" && size == "A4")
            {
                if (Pages >= 100 && IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages;
                    double t2 = t1 * 0.1; // Calculate 10% discount
                    double t3 = t1 * 0.30; // Add 30% surcharge fee
                    total = (t1 + t3) - t2; // Subtract discount
                }
                else if (Pages >= 100 && !IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages;
                    double t2 = t1 * 0.1;
                    total = (t1 - t2);
                }
                else if (Pages < 99 && IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages;
                    double t3 = t1 * 0.30; // Add 30% surcharge fee
                    total = t1 + t3;
                }
                else
                {
                    double t1 = FeesPerUnit * Pages;
                    total = t1;
                }
            }
            else if (ServiceType == "Printing A4– color" && size == "A4")
            {
                if (Pages >= 100 && IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages;
                    double t2 = t1 * 0.1; // Calculate 10% discount
                    double t3 = t1 * 0.30; // Add 30% surcharge fee
                    total = (t1 + t3) - t2; // Subtract discount
                }
                else if (Pages >= 100 && !IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages;
                    double t2 = t1 * 0.1;
                    total = (t1 - t2);
                }
                else if (Pages < 99 && IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages;
                    double t3 = t1 * 0.30; // Add 30% surcharge fee
                    total = t1 + t3;
                }
                else
                {
                    double t1 = FeesPerUnit * Pages;
                    total = t1;
                }
            }
            else if (ServiceType == "Binding – Comb Binding")
            {
                if (IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages; // Assume 1 book = 1 page for simplicity
                    double t3 = t1 * 0.30; // Add 30% surcharge fee
                    total = t1 + t3;
                }
                else
                {
                    double t1 = FeesPerUnit * Pages; // Assume 1 book = 1 page for simplicity

                    total = t1;
                }
            }
            else if (ServiceType == "Binding – Thick Cover ")
            {
                if (IsUrgent)
                {
                    double t1 = FeesPerUnit * Pages; // Assume 1 book = 1 page for simplicity
                    double t3 = t1 * 0.30; // Add 30% surcharge fee
                    total = t1 + t3;
                }
                else
                {
                    double t1 = FeesPerUnit * Pages; // Assume 1 book = 1 page for simplicity
                    total = t1;
                }
            }
            else if (ServiceType == "Printing - Poster" )
            {
                if (size == "A0 , A1")
                {
                    if (Pages >= 100 && IsUrgent)
                    {
                        double t1 = FeesPerUnit * Pages;
                        double t2 = t1 * 0.1; // Calculate 10% discount
                        double t3 = t1 * 0.30; // Add 30% surcharge fee
                        total = (t1 + t3) - t2; // Subtract discount
                    }
                    else if (Pages >= 100 && !IsUrgent)
                    {
                        double t1 = FeesPerUnit * Pages;
                        double t2 = t1 * 0.1;
                        total = (t1 - t2);
                    }
                    else if (Pages < 99 && IsUrgent)
                    {
                        double t1 = FeesPerUnit * Pages;
                        double t3 = t1 * 0.30; // Add 30% surcharge fee
                        total = t1 + t3;
                    }
                    else
                    {
                        double t1 = FeesPerUnit * Pages;
                        total = t1;
                    }
                }
            }
            else if (ServiceType == "Printing - Posterr")
            {
                if (size == "A2 , A3")
                {
                    if (Pages >= 100 && IsUrgent)
                    {
                        double t1 = FeesPerUnit * Pages;
                        double t2 = t1 * 0.1; // Calculate 10% discount
                        double t3 = t1 * 0.30; // Add 30% surcharge fee
                        total = (t1 + t3) - t2; // Subtract discount
                    }
                    else if (Pages >= 100 && !IsUrgent)
                    {
                        double t1 = FeesPerUnit * Pages;
                        double t2 = t1 * 0.1;
                        total = (t1 - t2);
                    }
                    else if (Pages < 99 && IsUrgent)
                    {
                        double t1 = FeesPerUnit * Pages;
                        double t3 = t1 * 0.30; // Add 30% surcharge fee
                        total = t1 + t3;
                    }
                    else
                    {
                        double t1 = FeesPerUnit * Pages;
                        total = t1;
                    }
                }
            }

            return total;
        }
    }
}
