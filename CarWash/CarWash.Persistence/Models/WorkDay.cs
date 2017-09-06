using System;
using System.Collections.Generic;

namespace CarWash.Persistence.Models
{
    public class WorkDay
    {
        private readonly int _startHour;
        private readonly int _endHour;
        private DateTime _day;
        private List<WorkHour> _workingHours;

        public WorkDay(DateTime day)
        {
            _day = day;
            _startHour = 8;
            _endHour = 16;
            InitWorkHours();
        }

        public int GetYear()
        {
            return _day.Year;
        }
        public int GetMonth()
        {
            return _day.Month;
        }
        public int GetDay()
        {
            return _day.Day;
        }
        public DayOfWeek GetDayOfWeek()
        {
            return _day.DayOfWeek;
        }
        public List<WorkHour> GetRemainingHours()
        {
            return _workingHours;
        }
        public void ModifyRemainingHours(List<WorkHour> hours)
        {
            _workingHours = hours;
        }
        public string GetDayDotMonthDescription()
        {
            string dayNo = GetDay() < 10 ? $"0{GetDay()}" : $"{GetDay()}";
            string monthNo = GetMonth() < 10 ? $"0{GetMonth()}" : $"{GetMonth()}";
            string dayRepresentation = dayNo + "." + monthNo;
            return dayRepresentation;
        }

        private void InitWorkHours()
        {
            List<WorkHour> result = new List<WorkHour>();

            int hour = setStartingHour();
            if (hour == -1) _workingHours = result;
            int minute = setStartingMinute();

            for (int i = hour; i < _endHour; i++)
            {
                for (int j = minute; j < 60; j += 15)
                {
                    result.Add(new WorkHour(i, j));
                }
                minute = 0;
            }

            _workingHours = result;
        }
        private int setStartingHour()
        {
            int hour;
            if (_day.Hour < _startHour)
            {
                return _startHour;
            }
            if (_day.Hour >= _endHour && _day.Minute >= 45)
            {
                return -1;
            }

            if (_day.Minute > 45)
            {
                hour = _day.Hour + 1;
            }
            else
            {
                hour = _day.Hour;
            }

            return hour;
        }
        private int setStartingMinute()
        {
            int min = 0;
            int currentMin = _day.Minute;
            if (_day.Hour < _startHour)
            {
                min = 0;
            } else
            {
                if (currentMin <= 15 && currentMin > 0) min = 15;
                if (currentMin <= 30 && currentMin > 15) min = 30;
                if (currentMin <= 45 && currentMin > 30) min = 45;
                if (currentMin < 60 && currentMin > 45) min = 0;
            }
            return min;
        }
    }
}
