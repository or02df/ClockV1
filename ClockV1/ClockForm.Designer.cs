namespace ClockV1
{
    partial class ClockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel_Clock = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Panel_Clock
            // 
            this.Panel_Clock.Location = new System.Drawing.Point(16, 6);
            this.Panel_Clock.Name = "Panel_Clock";
            this.Panel_Clock.Size = new System.Drawing.Size(300, 300);
            this.Panel_Clock.TabIndex = 0;
            this.Panel_Clock.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Clock_Paint);
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.Panel_Clock);
            this.Name = "ClockForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Clock;
    }
}

