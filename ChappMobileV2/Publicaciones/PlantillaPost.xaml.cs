namespace ChappMobileV2.Publicaciones;

public partial class PlantillaPost : ContentView
{
    private bool isExpanded = false;

    public PlantillaPost()
    {
        InitializeComponent();
    }

    private void OnMoreClicked(object sender, EventArgs e)
    {
        if (isExpanded)
        {
            // Contraer la descripción y ocultar el botón "Aplicar"
            DescripcionLabel.MaxLines = 3;
            AplicarButton.IsVisible = false;
            MoreButton.Text = "Más";
        }
        else
        {
            // Expandir la descripción y mostrar el botón "Aplicar"
            DescripcionLabel.MaxLines = int.MaxValue; 
            AplicarButton.IsVisible = true;
            MoreButton.Text = "Menos";
        }
        isExpanded = !isExpanded;
    }

    private void OnAplicarClicked(object sender, EventArgs e)
    {
        // Lógica para aplicar al trabajo
        Application.Current.MainPage.DisplayAlert("Aplicar", "Has aplicado a este trabajo.", "OK");
    }
}

