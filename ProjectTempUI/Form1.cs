using MidtermProject.input_output;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTempUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //TextDisplay.SelectionStart = TextDisplay.Text.Length;
            //TextDisplay.ScrollToCaret();
        }

        private void InputSubmitButton_Click(object sender, EventArgs e)
        {
            IO_Global.UiInput = TextInput.Text;
            IO_Global.SubmitPressed.Start();
            IO_Global.SubmitPressed = new Task(() => { });
            TextInput.Clear();

            //this used to be a separate button, but one button seems to be a smoother UX. 
            //for efficiency I should have some sort of 
            //filter that tells this if to do the top part or bottom and 
            //not just always fire both. 
           
            IO_Global.UiChangedCollection = TableViewer.DataSource;
            IO_Global.NextPressed.Start();
            IO_Global.NextPressed = new Task(() => { });
            

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //IO_Global.UiChangedCollection = TableViewer.DataSource;

            //IO_Global.NextPressed.Start();
            //IO_Global.NextPressed = new Task(() => { });
            //NextButton.BackColor = Color.MediumSeaGreen;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TableViewer.DefaultCellStyle.ForeColor = Color.Black;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            MidtermProject.GameMechanics.Getting_Started.init();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed


        }

        //this is the start button that doesn't want to rename
        //and also no longer exists... 
        private void button1_Click(object sender, EventArgs e)
        {
            //MidtermProject.GameMechanics.Getting_Started.TestingStuff();

            //MidtermProject.GameMechanics.Getting_Started.StartingPoint();




        }

        private void TableViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void subtitle_Click(object sender, EventArgs e)
        {

        }
    }
}
