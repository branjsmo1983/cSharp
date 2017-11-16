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


        private void BtnNewPerson_Click(object sender, EventArgs e)
        {
            //apertura form inserimento  della persona
        }

        private void BtnChangePerson_Click(object sender, EventArgs e)
        {
            //apertura form modifica della persona
        }

        private void BtnDeletePerson_Click(object sender, EventArgs e)
        {
            //apertura cancellazione persona
        }
    }
}
