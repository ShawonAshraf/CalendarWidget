using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace CalenderWidget
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Color> backColors; // for holding color info
        private Dictionary<string, double> opacityValues; // for holding opacity values
        public Form1()
        {
            InitializeComponent();
            InitColorDictionary();
            InitOpacityDictionary();
            SetIcon();
        }


        // set the icon

        private void SetIcon()
        {
            this.Icon = new Icon("icons/icon_ico.ico");
        }

        // inits colorDictionary with values
        private void InitColorDictionary()
        {
            backColors = new Dictionary<string, Color>();

            backColors.Add("Black", Color.Black);
            backColors.Add("Red", Color.Red);
            backColors.Add("White", Color.White);
            backColors.Add("Blue", Color.Blue);
            backColors.Add("Green", Color.Green);
        }

        // inits opacityDictionary with values
        private void InitOpacityDictionary()
        {
            opacityValues = new Dictionary<string, double>();

            opacityValues.Add("70%", 70);
            opacityValues.Add("80%", 80);
            opacityValues.Add("90%", 90);
            opacityValues.Add("100%", 100);
        }


         // changers the back color of the form
        private void ChangeBackColor(string color)
        {
            this.BackColor = backColors[color];
        }


        // sets the opacity of the form
        // a bit buggy for now, doesn't work properly,
        // looking for a fix
        private void SetOpacity(string opacValue)
        {
            this.Opacity = opacityValues[opacValue];
        }



        // to say the date, either todays or selected
        private void SayTheDate(string date)
        {
            SpeechSynthesizer speaker = new SpeechSynthesizer();
            speaker.SpeakAsync(date);
        }

        // getting the selected date from calendar
        // as a string
        private string GetSelectedDate()
        {
            string retVal = null;
            retVal = monthCalendar.SelectionRange.Start.ToLongDateString();

            return retVal;
        }

        // getting today's date from calendar
        private string GetTodaysDate()
        {
            string retVal = null;
            retVal = monthCalendar.TodayDate.ToLongDateString();

            return retVal;
        }


        //
        //
        //

        // event handlers

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBackColor( ( (ToolStripMenuItem)sender ).Text );
        }

        private void OpacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetOpacity( ( (ToolStripMenuItem)sender ).Text );
        }

        private void sayTodaysDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string date = GetTodaysDate();
            SayTheDate(date);
        }

        private void whatsTheDaySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string date = GetSelectedDate();
            SayTheDate(date);
        }
    }
}
