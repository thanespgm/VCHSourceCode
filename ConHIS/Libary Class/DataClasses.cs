using System;
using System.Drawing;

namespace ConHIS
{
    internal class DataClasses
    {
    }

    #region Headers

    public class Header
    {
        public string HeaderText { get; set; }

        public int StartLocation { get; set; }

        public string HeaderTextInsteadOfTime { get; set; }

        public DateTime Time { get; set; }
    }

    #endregion Headers

    #region ChartBarDate

    public class ChartBarDate
    {
        internal class Location
        {
            public Point Right { get; set; } = new Point(0, 0);

            public Point Left { get; set; } = new Point(0, 0);
        }

        public DateTime StartValue { get; set; }

        public DateTime EndValue { get; set; }

        public Color Color { get; set; }

        public Color HoverColor { get; set; }

        public string Text { get; set; }

        public object Value { get; set; }

        public int RowIndex { get; set; }

        public bool HideFromMouseMove { get; set; } = false;

        internal Location TopLocation { get; set; } = new Location();

        internal Location BottomLocation { get; set; } = new Location();
    }

    #endregion ChartBarDate

    #region BarInformation

    public class BarInformation
    {
        public string RowText { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public Color Color { get; set; }

        public Color HoverColor { get; set; }

        public int Index { get; set; }

        public BarInformation()
        {
        }

        public BarInformation(string rowText, DateTime fromTime, DateTime totime, Color color, Color hoverColor, int index)
        {
            RowText = rowText;
            FromTime = fromTime;
            ToTime = totime;
            Color = color;
            HoverColor = hoverColor;
            Index = index;
        }
    }

    #endregion BarInformation
}