using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            //caricamento delle persone GetPeople()
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            //apertura form dedicato all'inserimento/modifica della persona
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            //apertura form dedicato all'inserimento/modifica della persona
        }

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            //cancellazione (previa conferma) della persona
        }
    }
}
