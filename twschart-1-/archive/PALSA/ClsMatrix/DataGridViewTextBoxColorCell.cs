//Copyright Modulus Financial Engineering, Inc. - all rights reserved. 
//http://www.modulusfe.com 

//Colors last price grid red or green if up or down tick for n number of ms 

namespace PALSA.ClsMatrix
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class DataGridViewTextBoxColorColumn : DataGridViewTextBoxColumn
    {


        public DataGridViewTextBoxColorColumn()
        {
            this.CellTemplate = new DataGridViewTextBoxCell();
            this.ReadOnly = true;
        }

        public long MaxValue;

        public void CalcMaxValue()
        {
            int colIndex = this.DisplayIndex;
            for (int rowIndex = 0; rowIndex <= this.DataGridView.Rows.Count - 1; rowIndex++)
            {

                DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                MaxValue = Math.Max(MaxValue, (long)row.Cells[colIndex].Value);
            }
        }
    }


    public class DataGridViewTextBoxColorCell : DataGridViewTextBoxCell
    {
        //private Timer m_Timer = null;
        private double m_LastValue = 0;
        public Color m_Color;
        private int m_Interval = 2000;

        public DataGridViewTextBoxColorCell()
        {
            //m_Timer = new Timer();
            //m_Timer.Interval = 2000;
            //m_Timer.Tick += m_Timer_Tick;
        }

        public int Interval
        {
            get { return m_Interval; }
            set { m_Interval = value; }
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            double price = 0;
            object[] m_value = new object[2];
            m_value = (object[])value;

            Double.TryParse(m_value[0].ToString(), out price);

            //if (price > m_LastValue)
            //{
            //    m_Color = Color.Lime;
            //}
            //else if (price < m_LastValue)
            //{
            //    m_Color = Color.Red;
            //}
            //else
            //{
            //    m_Color = Color.Silver;
            //}        
            m_Color = (Color)m_value[1];

            this.Style.BackColor = m_Color;
            this.Style.SelectionBackColor = m_Color;
            m_LastValue = price;
            if (price == 0)
            {
                return base.SetValue(rowIndex, m_value[0].ToString());
            }
            else
            {
                return base.SetValue(rowIndex, price);
            }

            //Double.TryParse(value.ToString(), out price);

            //if (price > m_LastValue)
            //{
            //  m_Color = Color.Lime;
            //}
            //else if (price < m_LastValue) 
            //{
            //  m_Color = Color.Red;
            //}
            //else
            //{
            //  m_Color = Color.Silver;
            //}

            //this.Style.BackColor = m_Color;
            //this.Style.SelectionBackColor = m_Color;
            //m_LastValue = price;
            //return base.SetValue(rowIndex, value);

        }

        public override string ToString()
        {
            return m_LastValue.ToString();
        }

        private void m_Timer_Tick(object sender, System.EventArgs e)
        {
            if (DataGridView == null) return;
            this.Style.BackColor = DataGridView.DefaultCellStyle.BackColor;
            this.Style.SelectionBackColor = DataGridView.DefaultCellStyle.SelectionBackColor;
            //m_Timer.Enabled = false;
        }
    }
    public class DataGridViewBarTimeColumn : DataGridViewColumn
    {
        public DataGridViewBarTimeColumn()
        {
            this.CellTemplate = new DataGridViewBarTimeCell();
            this.ReadOnly = true;
        }

        public long MaximumValue { get; set; }

        public void CalculateMaxValue()
        {
            if (!DataGridView.VirtualMode)
            {
                int colIndex = this.DisplayIndex;
                int maximumValue = 0;
                for (int rowIndex = 0; rowIndex <= this.DataGridView.Rows.Count - 1; rowIndex++)
                {
                    DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                    if (null != row.Cells[colIndex].Value)
                        maximumValue = (int)Math.Max(maximumValue, double.Parse(row.Cells[colIndex].Value.ToString()));
                }
                MaximumValue = maximumValue;
            }
        }
    }
    public class DataGridViewBarTimeCell : DataGridViewTextBoxCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            List<long> cellValue;
            long sumCellValue = 0;
            if (value == null)
            {
                cellValue = new List<long>();
            }
            else
            {
                cellValue = (List<long>)value;
            }
            foreach (long item in cellValue)
            {
                sumCellValue += item;
            }
            //System.Diagnostics.Debug.WriteLine(rowIndex + " " + cellValue);
            //for (int i = 0; i < _tradeList.Count - 1; i++)
            //{
            //    tradeValue += _tradeList[i];
            //}
            //if (timeInterval <= TimeSpan.FromMinutes(1))
            //{
            //    if (_tradeList.Count == 0)
            //    {
            //        _tradeList.Add(cellValue);
            //        currentTime = DateTime.UtcNow;
            //        timeInterval = TimeSpan.FromMinutes(0);
            //    }
            //    else if (_tradeList.Count == 1)
            //        _tradeList.Add(cellValue - _tradeList[0]);
            //    else
            //        _tradeList[_tradeList.Count - 1] = cellValue - tradeValue;
            //}
            //else
            //{
            //    currentTime = DateTime.UtcNow;
            //    timeInterval = TimeSpan.FromMinutes(0);
            //    if (_tradeList.Count > 0)
            //    {
            //        _tradeList.Add(cellValue - tradeValue - _tradeList[_tradeList.Count - 1]);
            //    }
            //    else
            //    {
            //        _tradeList.Add(cellValue);
            //    }

            //}
            DataGridViewBarTimeColumn parent = (DataGridViewBarTimeColumn)this.OwningColumn;
            parent.CalculateMaxValue();
            long maxValue = parent.MaximumValue;
            decimal availableWidth = cellBounds.Width;
            if (maxValue != 0)
            {
                availableWidth = (decimal)(sumCellValue / (decimal)maxValue) * availableWidth;
            }
            if (sumCellValue != 0)
            {
                int colorpix=0;
                float startCo = cellBounds.X;
                int green = Color.DarkGreen.G;
                foreach (long item in cellValue)
                {
                    decimal percenatage = (decimal)(item / (decimal)sumCellValue) * availableWidth;
                    RectangleF finalRec = new RectangleF(startCo, cellBounds.Y, (float)percenatage, cellBounds.Height - 1);
                    startCo += (float)percenatage;
                    green = green + colorpix;
                    Brush brush = new SolidBrush(Color.FromArgb(colorpix, green<255 ? green: 255, colorpix));
                    colorpix = colorpix + 255 / cellValue.Count;
                    graphics.FillRectangle(brush, finalRec);
                }
            }
            
        }

    }

}