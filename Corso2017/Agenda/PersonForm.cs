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
            _agenda = new AgendaService(Program.CONNECTION_STRING);
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            cboNationality.DataSource = _agenda.GetNationalities();

            Person currentPerson;
            if (_currentPersonId == null)
            {
                currentPerson = new Person
                {
                    Id = -1,
                    DateOfBirth = DateTime.Today
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            _agenda.SavePerson(new Person
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Surname = txtName.Text,
                DateOfBirth = dtpDateOfBirth.Value,
                Nationality = new Nationality
                {
                    Id = (int)cboNationality.SelectedValue,
                    Name = cboNationality.SelectedText
                }
            });

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
