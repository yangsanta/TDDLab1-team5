﻿using System;
using System.Collections.Generic;

namespace Budget_Lab
{
    public interface IBudgetRepo
    {
        List<Budget> GetAll();
    }

    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime FirstDay()
        {
            return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);
        }

        public int Days()
        {
            return DateTime.DaysInMonth(FirstDay().Year, FirstDay().Month);
        }

        public decimal DailyAmount()
        {
            return (decimal) Amount / Days();
        }

        public DateTime LastDay()
        {
            return new DateTime(FirstDay().Year, FirstDay().Month, Days());
        }

        public Period CreatePeriod()
        {
            return new Period(FirstDay(), LastDay());
        }

        public decimal OverlappingAmount(Period period)
        {
            return period.OverlappingDays( CreatePeriod()) * DailyAmount();
        }
    }
}
