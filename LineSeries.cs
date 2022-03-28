using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCRGame
{
    public class LineSeries:NotifierBase
    {
        private ObservableCollection<DataPoint> m_chartData = new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> ChartData
        {
            get { return m_chartData; }
            set
            {
                SetProperty(ref m_chartData, value);
            }
        }

        private string m_Name = "";
        public string Name
        {
            get { return m_Name; }
            set
            {
                SetProperty(ref m_Name, value);
            }
        }

        public bool IsSelected { get; internal set; }
    }
}
