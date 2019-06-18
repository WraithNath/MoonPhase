using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WraithNath.MoonPhase.Engine;

namespace WraithNath.MoonPhase.Forms
{
    public partial class frmPickDate : Form
    {
        private DateTime _selectedDate = DateTime.Today;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
        }

        private double _moonPhase = double.Epsilon;
        private double _moonAge = double.Epsilon;

        public frmPickDate()
        {
            InitializeComponent();
            UpdateMoon();
        }

        private void monthCalendarDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            _selectedDate = monthCalendarDate.SelectionStart;
            UpdateMoon();
        }

        private void UpdateMoon()
        {
            _moonPhase = Moon.MoonPhase.GetMoonPhase(_selectedDate);
            _moonAge = Moon.MoonAge.GetMoonAge(_moonPhase);

            int moonAge = (int)Math.Floor(_moonAge);

            pictureBoxMoon.Image = Bitmap.FromHicon(
                new Icon(
                    ResourceManager.GetIcon(moonAge),
                    new Size(48,48))
               .Handle);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
