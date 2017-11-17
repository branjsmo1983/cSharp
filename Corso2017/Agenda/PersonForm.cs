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
    public partial class PersonForm : Form
    {
        readonly int? _currentPersonId;
        readonly AgendaService _agenda;

        public PersonForm() : this(null)
        {
        }

        public PersonForm(int? personId = null)
        {
            InitializeComponent();

            _currentPersonId = personId;
            _agenda = new AgendaService(Program.ConnectionString);
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboNationality.DataSource = _agenda.GetNationalities();

                Person currentPerson;
                if (_currentPersonId == null)
                {
                    currentPerson = new Person
                    {
                        Id = -1,
                        DateOfBirth = DateTime.Today - new TimeSpan(6570, 0, 0, 0, 0) //18 anni
                    };

                    this.Text = "Creazione nuova persona";
                }
                else
                {
                    currentPerson = _agenda.GetPerson(_currentPersonId.Value);
                    this.Text = $"Modifica di {currentPerson.Name} { currentPerson.Surname }";
                }

                txtId.Text = currentPerson.Id.ToString();
                txtName.Text = currentPerson.Name;
                txtSurname.Text = currentPerson.Surname;
                dtpDateOfBirth.Value = currentPerson.DateOfBirth;
                if (currentPerson.Nationality != null)
                    cboNationality.SelectedValue = currentPerson.Nationality.Id;
            }
            catch (Exception ex)
            {
                //TODO log
                MessageBox.Show($"Si è verificato un errore durante il caricamento.{ Environment.NewLine }{ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _agenda.SavePerson(new Person
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Nationality = new Nationality
                    {
                        Id = (int)cboNationality.SelectedValue,
                        Name = cboNationality.Text
                    }
                });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                //TODO log
                MessageBox.Show($"Si è verificato un errore durante il salvataggio.{ Environment.NewLine }{ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckMandatory(object sender, EventArgs e)
        {
            btnSave.Enabled =
                !string.IsNullOrWhiteSpace(txtName.Text) &&
                !string.IsNullOrWhiteSpace(txtSurname.Text);
        }
    }
}
