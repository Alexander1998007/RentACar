using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.BLL.BusinessModels
{
    public class FilterByDate
    {
        private static FilterByDate _instance;

        [Display(Name = "From")]
        public DateTime DateFrom { get; private set; }

        [Display(Name = "To")]
        public DateTime DateTo { get; private set; }

        private FilterByDate()
        {
            SetDefaultDates();
        }

        private void SetDefaultDates()
        {
            DateFrom = DateTime.Today;
            DateTo = DateTime.Today.AddMonths(1);
        }

        public static FilterByDate Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FilterByDate();
                }
                return _instance;
            }
        }

        public void SetDateFrom(DateTime dateFrom)
        {
            if (DateTo < dateFrom)
            {
                throw new Exception("Date from cannot be earlier than date to!");
            }
            if (dateFrom < DateTime.Today)
            {
                throw new Exception("Date from cannot be earlier than todays date!");
            }
            if (DateFrom == dateFrom) return;
            DateFrom = dateFrom;
        }

        public void SetDateTo(DateTime dateTo)
        {
            if (DateFrom > dateTo)
            {
                throw new Exception("Date to cannot be later than date from!");
            }
            if (DateTo < DateTime.Today)
            {
                throw new Exception("Date to cannot be earlier than todays date!");
            }
            if (DateTo == dateTo) return;
            DateTo = dateTo;
        }
    }
}
