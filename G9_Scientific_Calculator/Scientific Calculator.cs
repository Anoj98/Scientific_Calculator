using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G9_Scientific_Calculator
{
    public partial class ScientificCalculatorForm : Form
    {     

        public ScientificCalculatorForm()
        {            
            InitializeComponent();

            Thread newthread = new Thread(new ThreadStart(ShowSplashScreen));
            newthread.Start();
            Thread.Sleep(8000);
            newthread.Abort();

            panelMenu.Width = 62;
        }

        public void ShowSplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        private void FileStandardMenu_Click(object sender, EventArgs e)
        {
            StanderdForm newStandaed = new StanderdForm();
            newStandaed.MdiParent = this;
            newStandaed.Size = new Size(454, 485);
            newStandaed.Show();            
        }

        private void FileScientificMenu_Click(object sender, EventArgs e)
        {
            ScientificForm newScientific = new ScientificForm();
            newScientific.MdiParent = this;
            newScientific.Size = new Size(658, 537);
            newScientific.Show();            
        }

        private void FileConversionMenu_Click(object sender, EventArgs e)
        {
            ConverterForm newConverter = new ConverterForm();
            newConverter.MdiParent = this;
            newConverter.Size = new Size(980, 418);
            newConverter.Show();            
        }        
        
        private void Scientific_Click(object sender, EventArgs e)
        {            
            FileScientificMenu.PerformClick();            
        }

        private void Converter_Click(object sender, EventArgs e)
        {            
            FileConversionMenu.PerformClick();
        }

        private void Standard_Click(object sender, EventArgs e)
        {
            FileStandardMenu.PerformClick();            
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            exitMenu.PerformClick();
        }

        private void forward_Click(object sender, EventArgs e)
        {
            panelMenu.Width = 200;
            forward.Visible = false;
            back.Visible = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            panelMenu.Width = 62;
            forward.Visible = true;
            back.Visible = false;
        }    
              
        private void clear_Click(object sender, EventArgs e)
        {
            closeMenu.PerformClick();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            DialogResult exitResult = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }        

        private void ScientificCalculatorForm_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(222, 222, 222);
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = false;
                    frm.Dispose();                    
                }
            }
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            AboutForm newAbout = new AboutForm();
            newAbout.MdiParent = this;
            newAbout.Size = new Size(540, 512);
            newAbout.Show();
        }

        private void about_Click(object sender, EventArgs e)
        {
            aboutMenu.PerformClick();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ScientificCalculatorForm newMain = new ScientificCalculatorForm();
            newMain.Show();

        }
    }
}
