namespace WindowsFormsApp1
{
    partial class EditClient
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEditCredit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbChangeReimb = new System.Windows.Forms.TextBox();
            this.EditReimb = new System.Windows.Forms.Button();
            this.errorEdit = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change credit Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbEditCredit
            // 
            this.tbEditCredit.Location = new System.Drawing.Point(43, 137);
            this.tbEditCredit.Name = "tbEditCredit";
            this.tbEditCredit.Size = new System.Drawing.Size(171, 22);
            this.tbEditCredit.TabIndex = 1;
            this.tbEditCredit.Validating += new System.ComponentModel.CancelEventHandler(this.tbEditCredit_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change Credit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Change reimbursement value";
            // 
            // tbChangeReimb
            // 
            this.tbChangeReimb.Location = new System.Drawing.Point(43, 283);
            this.tbChangeReimb.Name = "tbChangeReimb";
            this.tbChangeReimb.Size = new System.Drawing.Size(175, 22);
            this.tbChangeReimb.TabIndex = 4;
            // 
            // EditReimb
            // 
            this.EditReimb.Location = new System.Drawing.Point(43, 332);
            this.EditReimb.Name = "EditReimb";
            this.EditReimb.Size = new System.Drawing.Size(188, 58);
            this.EditReimb.TabIndex = 5;
            this.EditReimb.Text = "Change Reimbursement Value";
            this.EditReimb.UseVisualStyleBackColor = true;
            this.EditReimb.Click += new System.EventHandler(this.EditReimb_Click);
            // 
            // errorEdit
            // 
            this.errorEdit.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enter client id";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(40, 57);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(173, 22);
            this.tbId.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 40);
            this.button2.TabIndex = 8;
            this.button2.Text = "Return to main menu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(348, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EditReimb);
            this.Controls.Add(this.tbChangeReimb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbEditCredit);
            this.Controls.Add(this.label1);
            this.Name = "EditClient";
            this.Text = "EditClient";
            ((System.ComponentModel.ISupportInitialize)(this.errorEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEditCredit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbChangeReimb;
        private System.Windows.Forms.Button EditReimb;
        private System.Windows.Forms.ErrorProvider errorEdit;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}