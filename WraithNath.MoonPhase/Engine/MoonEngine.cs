using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WraithNath.MoonPhase.Properties;
using System.Collections;
using WraithNath.MoonPhase.Forms;
using Microsoft.Win32;
using WraithNath.MoonPhase.Moon;

namespace WraithNath.MoonPhase.Engine
{
    /// <summary>
    /// Class to calculate moon age
    /// </summary>
    public class MoonEngine : IDisposable
    {
        #region Members

        private NotifyIcon _notifyIcon;
        private System.Timers.Timer _timer;
        private const string AppName = "WraithNath.MoonPhase";

        #endregion Members

        #region Constructors / Dispose

        /// <summary>
        /// Static Constructor
        /// </summary>
        static MoonEngine()
        {
            StateManager.CurrentDate = DateTime.Today;
            StateManager.AutoUpdate = true;
            StateManager.AutoRun = AutoRunHelper.IsAutoRunEnabled(AppName);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MoonEngine()
        {
            InitNotifyIcon();
            InitTimer();
            Update();
            Start();
        }

        /// <summary>
        /// Disposes of all resources
        /// </summary>
        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        #endregion Constructors / Dispose

        #region Timer

        /// <summary>
        /// Inits the Timer
        /// </summary>
        void InitTimer()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 3600000; // 1 hour
            _timer.Elapsed += _timer_Elapsed;
        }

        /// <summary>
        /// Updates the moon to the current date
        /// </summary>
        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (StateManager.AutoUpdate)
                ChangeDate(DateTime.Today);
        }

        #endregion Timer

        #region Notify Icon

        /// <summary>
        /// Inits the Notify icon and context menu
        /// </summary>
        void InitNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.ContextMenu = new ContextMenu();
            _notifyIcon.ContextMenu.Popup += ContextMenu_Popup;
        }

        /// <summary>
        /// Adds the items to the context menu dynamically
        /// </summary>
        void ContextMenu_Popup(object sender, EventArgs e)
        {
            _notifyIcon.ContextMenu.MenuItems.Clear();

            MenuItem seperatorMenuItem = new MenuItem("-");

            MenuItem currentDateMenuItem = new MenuItem(StateManager.CurrentDate.ToLongDateString());
            currentDateMenuItem.Enabled = false;
            _notifyIcon.ContextMenu.MenuItems.Add(currentDateMenuItem);

            _notifyIcon.ContextMenu.MenuItems.Add(seperatorMenuItem);

            MenuItem yesterdayMenuItem = new MenuItem("Previous Day", new EventHandler(PreviousDay));
            _notifyIcon.ContextMenu.MenuItems.Add(yesterdayMenuItem);

            MenuItem todayMenuItem = new MenuItem("Today", new EventHandler(Today));
            _notifyIcon.ContextMenu.MenuItems.Add(todayMenuItem);

            MenuItem tomorrowMenuItem = new MenuItem("Next Day", new EventHandler(NextDay));
            _notifyIcon.ContextMenu.MenuItems.Add(tomorrowMenuItem);

            MenuItem pickDateMenuItem = new MenuItem("Pick Date", new EventHandler(PickDate));
            _notifyIcon.ContextMenu.MenuItems.Add(pickDateMenuItem);

            seperatorMenuItem = new MenuItem("-");
            _notifyIcon.ContextMenu.MenuItems.Add(seperatorMenuItem);

            MenuItem autoUpdateMenuItem = new MenuItem("Auto Update Phase", new EventHandler(ToggleAutoupdate));
            autoUpdateMenuItem.Checked = StateManager.AutoUpdate;
            _notifyIcon.ContextMenu.MenuItems.Add(autoUpdateMenuItem);

            MenuItem runOnStartUpMenuItem = new MenuItem("Run on startup", new EventHandler(ToggleAutoRun));
            runOnStartUpMenuItem.Checked = StateManager.AutoRun;
            _notifyIcon.ContextMenu.MenuItems.Add(runOnStartUpMenuItem);

            seperatorMenuItem = new MenuItem("-");
            _notifyIcon.ContextMenu.MenuItems.Add(seperatorMenuItem);

            MenuItem aboutMenuItem = new MenuItem("About", new EventHandler(About));
            _notifyIcon.ContextMenu.MenuItems.Add(aboutMenuItem);

            seperatorMenuItem = new MenuItem("-");
            _notifyIcon.ContextMenu.MenuItems.Add(seperatorMenuItem);

            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
            _notifyIcon.ContextMenu.MenuItems.Add(exitMenuItem);
        }

        /// <summary>
        /// Updates the notify icon tooltip
        /// </summary>
        void UpdateNotifyIcon()
        {
            int moonAge = (int)Math.Floor(StateManager.MoonAge);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(StateManager.CurrentDate.ToLongDateString());
            sb.AppendLine();
            sb.AppendFormat("Moon Age: {0} {1}", StateManager.MoonAge, moonAge == 1 ? "day" : "days");

            _notifyIcon.Text = sb.ToString();
            _notifyIcon.Icon = ResourceManager.GetIcon(moonAge);

            sb = null;
        }

        #endregion Notify Icon

        #region Menu Items

        /// <summary>
        /// Exits the program
        /// </summary>
        void Exit(object o, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// Subtracts 1 from the date
        /// </summary>
        void PreviousDay(object o, EventArgs e)
        {
            ChangeDate(StateManager.CurrentDate.AddDays(-1));
        }

        /// <summary>
        /// Goes to todays date
        /// </summary>
        void Today(object o, EventArgs e)
        {
            ChangeDate(DateTime.Today);
        }

        /// <summary>
        /// Adds 1 to the Date
        /// </summary>
        void NextDay(object o, EventArgs e)
        {
            ChangeDate(StateManager.CurrentDate.AddDays(+1));
        }

        /// <summary>
        /// Shows the Date Picker form
        /// </summary>
        void PickDate(object o, EventArgs e)
        {
            using (frmPickDate pickDate = new frmPickDate())
            {
                if (pickDate.ShowDialog() == DialogResult.OK)
                    ChangeDate(pickDate.SelectedDate);
            }
        }

        /// <summary>
        /// Toggles Auto Update on and off
        /// </summary>
        void ToggleAutoupdate(object o, EventArgs e)
        {
            StateManager.AutoUpdate = !StateManager.AutoUpdate;
        }

        /// <summary>
        /// Toggles Auto Run on and Off
        /// </summary>
        void ToggleAutoRun(object o, EventArgs e)
        {
            StateManager.AutoRun = !StateManager.AutoRun;
            UpdateRunOnStartUp();
        }

        /// <summary>
        /// Shows an About Box
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void About(object o, EventArgs e)
        {
            MessageBox.Show("Moon Phase Tray Icon\r\n\r\nCopyright Nathan Freeman-Smith 2014", "Moon Phase Tray Icon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Menu Items

        #region Registry

        /// <summary>
        /// Updates the registry to run on startup
        /// </summary>
        /// <param name="runOnStartup">whether to run on startup</param>
        void UpdateRunOnStartUp()
        {
            AutoRunHelper.SetAutoRunEnabled(AppName, Application.ExecutablePath.ToString(), StateManager.AutoRun);
        }

        #endregion Registry

        #region Program

        /// <summary>
        /// Starts application running
        /// </summary>
        void Start()
        {
            _timer.Start();
            _notifyIcon.Visible = true;
        }

        /// <summary>
        /// Stops the Application
        /// </summary>
        void Stop()
        {
            _timer.Stop();
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// Changes the Date
        /// </summary>
        /// <param name="date">the Date</param>
        void ChangeDate(DateTime date)
        {
            StateManager.CurrentDate = date;
            Update();
        }

        /// <summary>
        /// Updates the phase and application based on current selected date
        /// </summary>
        void Update()
        {
            StateManager.MoonPhase = Moon.MoonPhase.GetMoonPhase(StateManager.CurrentDate);
            StateManager.MoonAge = Moon.MoonAge.GetMoonAge(StateManager.CurrentDate);

            UpdateNotifyIcon();
        }

        #endregion Program
    }
}
