using Agenda.Domain;
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
        class PersonModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string DateOfBirth { get; set; }
            public string Nationality { get; set; }
        }

        readonly AgendaService _agenda;

        public MainForm()
        {
            InitializeComponent();

            _agenda = new AgendaService(Program.ConnectionString);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //caricamento delle persone GetPeople()
            LoadPeople();
        }

        private void LoadPeople()
        {
            try
            {
                var people = _agenda.GetPeople();
                if (people.Count == 0)
                {
                    MessageBox.Show("Nessun record presente", "Agenda vuota");
                }
                else
                {
                    //map to model
                    gvPeople.DataSource = people.Select((p) => new PersonModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Surname = p.Surname,
                        DateOfBirth = p.DateOfBirth.ToShortDateString(),
                        Nationality = p.Nationality.Name
                    })
                    .ToList();

                    gvPeople.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore sul caricamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            //apertura form dedicato all'inserimento/modifica della persona
            var personForm = new PersonForm();
            var result = personForm.ShowDialog(this);

            if (result == DialogResult.OK)
                LoadPeople();
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            //apertura form dedicato all'inserimento/modifica della persona
            if (gvPeople.SelectedRows.Count == 1)
            {
                var item = (PersonModel)gvPeople.SelectedRows[0].DataBoundItem;
                var personForm = new PersonForm(item.Id);
                var result = personForm.ShowDialog(this);

                if (result == DialogResult.OK)
                    LoadPeople();
            }
        }

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            try
            {
                //cancellazione (previa conferma) della persona
                if (gvPeople.SelectedRows.Count > 1)
                {
                    if (MessageBox.Show($"Cancellare la/le { gvPeople.SelectedRows.Count } persona/e selezionate?", "Conferma cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in gvPeople.SelectedRows)
                        {
                            var item = (PersonModel)row.DataBoundItem;

                            _agenda.DeletePerson(item.Id);
                        }

                        LoadPeople();
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO log
                MessageBox.Show($"Si è verificato un errore durante la cancellazione.{ Environment.NewLine }{ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvPeople_SelectionChanged(object sender, EventArgs e)
        {
            btnDeletePerson.Enabled = gvPeople.SelectedRows.Count > 1;
            btnEditPerson.Enabled = gvPeople.SelectedRows.Count == 1;
        }
    }
}
