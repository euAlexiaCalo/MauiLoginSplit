namespace MauiLoginSplit
{
    public partial class MainPage : ContentPage
    {
        private bool _showPassword = false; // Variável para controlar a visibilidade da senha

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnTogglePassword(object? sender, EventArgs e)
        {
            _showPassword = !_showPassword; // Alterna o estado da visibilidade da senha
            SenhaEntry.IsPassword = !_showPassword; // Atualiza a propriedade IsPassword do Entry
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text?.Trim(); // Remove espaços em branco extras
            var senha = SenhaEntry.Text; // Senha não deve ser alterada

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha)) // Verifica se os campos estão vazios
            {
                DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            if(email.Contains("@") && senha.Length >= 4) // Condição simples para validação
            {
                DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
            }
            else
            {
                DisplayAlert("Erro", "Email ou senha inválidos.", "OK");
            }
        }

        private async void OnShowTerms(object sender, EventArgs e)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("Termos.txt"); // Abre o arquivo de termos de uso

            using var reader = new StreamReader(stream); // Lê o conteúdo do arquivo

            var termos = await reader.ReadToEndAsync(); // Lê todo o conteúdo do arquivo
            await DisplayAlert("Termos de Uso", termos, "OK");
        }
    }
}
