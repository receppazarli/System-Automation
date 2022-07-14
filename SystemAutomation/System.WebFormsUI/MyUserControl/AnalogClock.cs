using System;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Win.Gauges.Circular;
using DevExpress.XtraGauges.Core.Model;

namespace DevExpress.XtraGauges.Demos{
    public partial class AnalogClock : XtraUserControl
    {
        ArcScaleComponent scaleMinutes, scaleSeconds;
        int lockTimerCounter = 0;

        public AnalogClock() {
            InitializeComponent();
            scaleMinutes = circularGauge1.AddScale();
            scaleSeconds = circularGauge1.AddScale();

            scaleMinutes.Assign(scaleHours);
            scaleSeconds.Assign(scaleHours);

            arcScaleNeedleComponent2.ArcScale = scaleMinutes;
            arcScaleNeedleComponent3.ArcScale = scaleSeconds;
            timer.Start();
            OnTimerTick(null, null);
        }
        void OnTimerTick(object sender, System.EventArgs e) {
            if(lockTimerCounter == 0) {
                lockTimerCounter++;
                UpdateClock(DateTime.Now, scaleHours, scaleMinutes, scaleSeconds);
                lockTimerCounter--;
            }
        }
        void UpdateClock(DateTime dt, IArcScale h, IArcScale m, IArcScale s) {
            int hour = dt.Hour < 12 ? dt.Hour : dt.Hour - 12;
            int min = dt.Minute;
            int sec = dt.Second;
            h.Value = (float)hour + (float)(min) / 60.0f;
            m.Value = ((float)min + (float)(sec) / 60.0f) / 5f;
            s.Value = sec / 5.0f;
        }
    }
}
