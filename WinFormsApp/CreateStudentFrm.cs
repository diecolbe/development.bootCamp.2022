
using development.Application.Interfaces;
using development.Domain;
using Domain;

namespace WinFormsApp
{
    public partial class CreateStudentFrm : Form
    {
        private readonly IStudentService studentService;
        List<Gender> genders = new List<Gender>();        

        public CreateStudentFrm(IStudentService studentService)
        {
            InitializeComponent();
            this.studentService = studentService;
            LoadGenderList();
            LoadGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveStudent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void SaveStudent()
        {
            var gender = (Gender)listBoxGender.SelectedItem;
            var student = new StudentDto()
            {
                IdStudent = studentService.GeMaxId(),
                Name = txtNames.Text,
                LastName = txtLastName.Text,
                Birthday = dateTimeBirthday.Value,
                Gender = gender.Description,
                Email = txtEmail.Text,
                PC = cbxPC.Checked,
                Internet = cbxInternet.Checked
            };

            bool exist = studentService.ExistStudent(student.IdStudent);
            if (!exist)
                studentService.SaveStudent(student);
            else
                MessageBox.Show($"Ya existe un estudiante registrado con el número de identificación: {student.IdStudent}");
            ClearFields();
            LoadGrid();
        }
        private void ClearFields()
        {
            txtLastName.Text = string.Empty;
            txtNames.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cbxPC.Checked = false;
            cbxInternet.Checked = false;
            dateTimeBirthday.Value = DateTime.Now;
            listBoxGender.SelectedItem = " ";
        }
        private void LoadGrid()
        {
            bindingSourceStudents.DataSource = studentService.GetStudents().Result;
            GridStudents.DataSource = null;
            GridStudents.DataSource = bindingSourceStudents;
        }
        private void LoadGenderList()
        {
            genders.Add(new Gender() { Id = 1, Description = "F" });
            genders.Add(new Gender() { Id = 2, Description = "M" });
            listBoxGender.DataSource = genders;
            listBoxGender.DisplayMember = "Description";
            listBoxGender.ValueMember = "Id";
        }
    }
}