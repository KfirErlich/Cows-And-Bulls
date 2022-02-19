
namespace Ex05.UI
{
    partial class GamePropertiesForm
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
            this.m_ButtonOfChances = new System.Windows.Forms.Button();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonOfChances
            // 
            this.m_ButtonOfChances.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_ButtonOfChances.Location = new System.Drawing.Point(108, 80);
            this.m_ButtonOfChances.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.m_ButtonOfChances.Name = "m_ButtonOfChances";
            this.m_ButtonOfChances.Size = new System.Drawing.Size(713, 65);
            this.m_ButtonOfChances.TabIndex = 2;
            this.m_ButtonOfChances.Text = "Number of chances: 4";
            this.m_ButtonOfChances.UseVisualStyleBackColor = true;
            this.m_ButtonOfChances.Click += new System.EventHandler(this.buttonOfChances_Click);
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_ButtonStart.Location = new System.Drawing.Point(212, 353);
            this.m_ButtonStart.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(510, 80);
            this.m_ButtonStart.TabIndex = 1;
            this.m_ButtonStart.Text = "Start";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // GamePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 550);
            this.Controls.Add(this.m_ButtonOfChances);
            this.Controls.Add(this.m_ButtonStart);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "GamePropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GamePropertiesForm";
            this.Load += new System.EventHandler(this.GamePropertiesForm_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button m_ButtonStart;
        private System.Windows.Forms.Button m_ButtonOfChances;
    }

}