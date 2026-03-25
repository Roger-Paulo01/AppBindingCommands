using AppBindingCommands.Views;

namespace AppBindingCommands
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void btnAtualizarInformacoes_Clicked(object sender, EventArgs e)
        {
            string informacoes = string.Empty;

            if (Preferences.ContainsKey("AcaoInicial"))
                informacoes += Preferences.Get("AcaoInicial", string.Empty);

            if (Preferences.ContainsKey("AcaoStart"))
                informacoes += Preferences.Get("AcaoStart", string.Empty);

            if (Preferences.ContainsKey("AcaoSleep"))
                informacoes += Preferences.Get("AcaoSleep", string.Empty);

            if (Preferences.ContainsKey("AcaoResume"))
                informacoes += Preferences.Get("AcaoResume", string.Empty);

            lblInformacoes.Text = informacoes;
        }


        //aqui vai o da aula passada/Completar Zzzzz


        public async Task ShowOptions()
        {
            string resul = await Application.Current.MainPage
                .DisplayActionSheet("Selecione uma opção: ", "",
                "Cancelar", "Limpar", "Contar Caracteres", "Exibir Saudação");

            if (resul != null)
            {
                if (resul.Equals("Limpar"))
                    await CleanConfirmation();
                if (resul.Equals("ContarCaracteres"))
                    await CountCharacters();
                if (resul.Equals("Exibir Saudação"))
                    await ShowMessage();
            }
        }

        public ICommand OptionCommand { get; }

        public UsuarioView()
        {
            ShowMessageCommand = new Command(ShowMessage);
            CountCommand = new Command(async () => await CountCharacters());
            CleanCommand = new Command(async () => await CleanConfirmation());
            OptionCommand = new Command(async () => await ShowOptions());
        }


    }
}
