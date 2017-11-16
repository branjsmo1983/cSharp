namespace Agenda
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

      

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewPerson = new System.Windows.Forms.Button();
            this.gvPeople = new System.Windows.Forms.DataGridView();
            this.btnChangePerson = new System.Windows.Forms.Button();
            this.btnDeletePerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewPerson
            // 
            this.btnNewPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewPerson.Location = new System.Drawing.Point(947, 42);
            this.btnNewPerson.Name = "btnNewPerson";
            this.btnNewPerson.Size = new System.Drawing.Size(220, 46);
            this.btnNewPerson.TabIndex = 0;
            this.btnNewPerson.Text = "Aggiungi Persona";
            this.btnNewPerson.UseVisualStyleBackColor = true;
            this.btnNewPerson.Click += new System.EventHandler(this.BtnNewPerson_Click);
            // 
            // gvPeople
            // 
            this.gvPeople.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPeople.Location = new System.Drawing.Point(56, 263);
            this.gvPeople.Name = "gvPeople";
            this.gvPeople.RowTemplate.Height = 28;
            this.gvPeople.Size = new System.Drawing.Size(1101, 316);
            this.gvPeople.TabIndex = 1;
            // 
            // btnChangePerson
            // 
            this.btnChangePerson.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChangePerson.AutoSize = true;
            this.btnChangePerson.Location = new System.Drawing.Point(515, 43);
            this.btnChangePerson.Name = "btnChangePerson";
            this.btnChangePerson.Size = new System.Drawing.Size(205, 45);
            this.btnChangePerson.TabIndex = 2;
            this.btnChangePerson.Text = "Modifica Persona";
            this.btnChangePerson.UseVisualStyleBackColor = true;
            this.btnChangePerson.Click += new System.EventHandler(this.BtnChangePerson_Click);
            // 
            // btnDeletePerson
            // 
            this.btnDeletePerson.Location = new System.Drawing.Point(56, 42);
            this.btnDeletePerson.Name = "btnDeletePerson";
            this.btnDeletePerson.Size = new System.Drawing.Size(205, 45);
            this.btnDeletePerson.TabIndex = 3;
            this.btnDeletePerson.Text = "Cancella Persona";
            this.btnDeletePerson.UseVisualStyleBackColor = true;
            this.btnDeletePerson.Click += new System.EventHandler(this.BtnDeletePerson_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 651);
            this.Controls.Add(this.btnDeletePerson);
            this.Controls.Add(this.btnChangePerson);
            this.Controls.Add(this.gvPeople);
            this.Controls.Add(this.btnNewPerson);
            this.Name = "MainForm";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewPerson;
        private System.Windows.Forms.DataGridView gvPeople;
        private System.Windows.Forms.Button btnChangePerson;
        private System.Windows.Forms.Button btnDeletePerson;
    }
}

