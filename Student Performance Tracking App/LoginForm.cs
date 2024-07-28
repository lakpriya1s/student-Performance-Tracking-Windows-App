namespace Student_Performance_Tracking_App
{
    using System;
    using System.Net.Http;
    using System.Windows.Forms;

    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        private TaskService _taskService;

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _userService.RegisterAsync(txtRegisterUsername.Text, txtRegisterEmail.Text, txtRegisterPassword.Text);
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var token = await _userService.LoginAsync(txtLoginUsername.Text, txtLoginPassword.Text);
                MessageBox.Show("Login successful");

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                _taskService = new TaskService(httpClient);

                var mainForm = new MainForm(_taskService);
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
