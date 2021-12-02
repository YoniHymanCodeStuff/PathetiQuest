
using ProjectTempUI.input_output;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectTempUI
{
    partial class Form1
    {
        //static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //this is the function called from outside to update the screen:
        //public void SyncScreen()
        //{
        //    TextDisplay.Text = WinformsUtils.GetScreenFeed();
        //}

        public void Clrscreen()
        {
            TextDisplay.Clear();
        }

        //this is currently just adding them all instantly since the 
        //task stuff i did crashed the world... 
        public async Task SlowAddText(string s)
        {
            TextDisplay.BringToFront();
            //giving up on this for now. will be back
            //myTimer.Interval = 10;
            //myTimer.Start();
            foreach (char c in s)
            {
                TextDisplay.AppendText((c).ToString());
                await Task.Delay(5);
            }

            TextDisplay.SelectionStart = TextDisplay.Text.Length;
            TextDisplay.ScrollToCaret();
        }

        public void ShowTable<T>(List<T> table)
        {
            TableViewer.BringToFront();
            TableViewer.DataSource = table;
        }

        public void BindTable<T>(BindingList<T> bl)
        {
            TableViewer.BringToFront();
            TableViewer.DataSource = bl;
        }

        public void NextButtonreadyIndicator()
        {
            NextButton.BackColor = Color.MediumSpringGreen;

        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TextDisplay = new System.Windows.Forms.RichTextBox();
            this.Title = new System.Windows.Forms.Label();
            this.TextInput = new System.Windows.Forms.TextBox();
            this.InputSubmitButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.TableViewer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TableViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // TextDisplay
            // 
            this.TextDisplay.BackColor = System.Drawing.Color.Black;
            this.TextDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextDisplay.ForeColor = System.Drawing.Color.LawnGreen;
            this.TextDisplay.Location = new System.Drawing.Point(22, 108);
            this.TextDisplay.Name = "TextDisplay";
            this.TextDisplay.ReadOnly = true;
            this.TextDisplay.Size = new System.Drawing.Size(571, 343);
            this.TextDisplay.TabIndex = 0;
            this.TextDisplay.Text = "";
            this.TextDisplay.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.MediumBlue;
            this.Title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Title.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(319, 9);
            this.Title.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.Title.Name = "Title";
            this.Title.Padding = new System.Windows.Forms.Padding(5);
            this.Title.Size = new System.Drawing.Size(245, 48);
            this.Title.TabIndex = 1;
            this.Title.Text = "PathetiQuest";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // TextInput
            // 
            this.TextInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextInput.Location = new System.Drawing.Point(612, 126);
            this.TextInput.Name = "TextInput";
            this.TextInput.PlaceholderText = "Text input...";
            this.TextInput.Size = new System.Drawing.Size(209, 29);
            this.TextInput.TabIndex = 2;
            this.TextInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // InputSubmitButton
            // 
            this.InputSubmitButton.BackColor = System.Drawing.Color.DarkViolet;
            this.InputSubmitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.InputSubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InputSubmitButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InputSubmitButton.Location = new System.Drawing.Point(619, 184);
            this.InputSubmitButton.Name = "InputSubmitButton";
            this.InputSubmitButton.Size = new System.Drawing.Size(75, 29);
            this.InputSubmitButton.TabIndex = 3;
            this.InputSubmitButton.Text = "Submit";
            this.InputSubmitButton.UseVisualStyleBackColor = false;
            this.InputSubmitButton.Click += new System.EventHandler(this.InputSubmitButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NextButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NextButton.Location = new System.Drawing.Point(725, 182);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 33);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.DarkCyan;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.Location = new System.Drawing.Point(676, 363);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 32);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TableViewer
            // 
            this.TableViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableViewer.DefaultCellStyle = dataGridViewCellStyle1;
            this.TableViewer.Location = new System.Drawing.Point(22, 108);
            this.TableViewer.Name = "TableViewer";
            this.TableViewer.RowTemplate.Height = 25;
            this.TableViewer.Size = new System.Drawing.Size(571, 343);
            this.TableViewer.TabIndex = 7;
            this.TableViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableViewer_CellContentClick);
            // 
            // Form1
            // 
            this.AcceptButton = this.InputSubmitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(833, 472);
            this.Controls.Add(this.TableViewer);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.InputSubmitButton);
            this.Controls.Add(this.TextInput);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.TextDisplay);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.Text = "RetroQuest";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextDisplay;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox TextInput;
        private System.Windows.Forms.Button InputSubmitButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.DataGridView TableViewer;
    }
}

