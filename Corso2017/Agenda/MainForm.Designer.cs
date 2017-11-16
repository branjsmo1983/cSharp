namespace Agenda
{
    partial class MainForm
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
            this.btnNewPerson = new System.Windows.Forms.Button();
            this.gvPeople = new System.Windows.Forms.DataGridView();
            this.btnEditPerson = new System.Windows.Forms.Button();
            this.btnDeletePerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewPerson
            // 
            this.btnNewPerson.Location = new System.Drawing.Point(13, 12);
            this.btnNewPerson.Name = "btnNewPerson";
            this.btnNewPerson.Size = new System.Drawing.Size(99, 23);
            this.btnNewPerson.TabIndex = 0;
            this.btnNewPerson.Text = "Nuova persona";
            this.btnNewPerson.UseVisualStyleBackColor = true;
            this.btnNewPerson.Click += new System.EventHandler(this.btnNewPerson_Click);
            // 
            // gvPeople
            // 
            this.gvPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPeople.Location = new System.Drawing.Point(13, 41);
            this.gvPeople.Name = "gvPeople";
            this.gvPeople.Size = new System.Drawing.Size(497, 289);
            this.gvPeople.TabIndex = 1;
            // 
            // btnEditPerson
            // 
            this.btnEditPerson.Location = new System.Drawing.Point(118, 12);
            this.btnEditPerson.Name = "btnEditPerson";
            this.btnEditPerson.Size = new System.Drawing.Size(99, 23);
            this.btnEditPerson.TabIndex = 0;
            this.btnEditPerson.Text = "Modifica persona";
            this.btnEditPerson.UseVisualStyleBackColor = true;
            this.btnEditPerson.Click += new System.EventHandler(this.btnEditPerson_Click);
            // 
            // btnDeletePerson
            // 
            this.btnDeletePerson.Location = new System.Drawing.Point(223, 12);
            this.btnDeletePerson.Name = "btnDeletePerson";
            this.btnDeletePerson.Size = new System.Drawing.Size(99, 23);
            this.btnDeletePerson.TabIndex = 0;
            this.btnDeletePerson.Text = "Cancella persona";
            this.btnDeletePerson.UseVisualStyleBackColor = true;
            this.btnDeletePerson.Click += new System.EventHandler(this.btnDeletePerson_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 342);
            this.Controls.Add(this.gvPeople);
            this.Controls.Add(this.btnDeletePerson);
            this.Controls.Add(this.btnEditPerson);
            this.Controls.Add(this.btnNewPerson);
            this.Name = "MainForm";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewPerson;
        private System.Windows.Forms.DataGridView gvPeople;
        private System.Windows.Forms.Button btnEditPerson;
        private System.Windows.Forms.Button btnDeletePerson;
    }
}

