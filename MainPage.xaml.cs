using Microsoft.Maui.Controls;

namespace CalculatriceMaui;

public partial class MainPage : ContentPage
{
    private double premierNombre = 0;
    private string op = "";
    private bool nouveauNombre = true;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnNumberClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (LblResultat.Text == "0" || nouveauNombre)
        {
            LblResultat.Text = btn.Text;
            nouveauNombre = false;
        }
        else
        {
            LblResultat.Text += btn.Text;
        }
    }

    private void OnOperationClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        premierNombre = double.Parse(LblResultat.Text);
        op = btn.Text;
        LblOperation.Text = $"{premierNombre} {op}";
        nouveauNombre = true;
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(op)) return;

        double secondNombre = double.Parse(LblResultat.Text);
        double resultat = 0;

        if (op == "÷" && secondNombre == 0)
        {
            LblResultat.Text = "Erreur : Div / 0";
            LblOperation.Text = "";
            nouveauNombre = true;
            return;
        }

        switch (op)
        {
            case "+": resultat = premierNombre + secondNombre; break;
            case "-": resultat = premierNombre - secondNombre; break;
            case "×": resultat = premierNombre * secondNombre; break;
            case "÷": resultat = premierNombre / secondNombre; break;
        }

        LblOperation.Text = $"{premierNombre} {op} {secondNombre} =";
        LblResultat.Text = resultat.ToString();
        op = "";
        nouveauNombre = true;
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        LblResultat.Text = "0";
        LblOperation.Text = "";
        premierNombre = 0;
        op = "";
        nouveauNombre = true;
    }

    private void OnEraseClicked(object sender, EventArgs e)
    {
        if (LblResultat.Text.Length > 1)
            LblResultat.Text = LblResultat.Text.Substring(0, LblResultat.Text.Length - 1);
        else
            LblResultat.Text = "0";
    }

    private void OnSignClicked(object sender, EventArgs e)
    {
        if (double.TryParse(LblResultat.Text, out double val))
            LblResultat.Text = (-val).ToString();
    }

    private void OnPercentClicked(object sender, EventArgs e)
    {
        if (double.TryParse(LblResultat.Text, out double val))
            LblResultat.Text = (val / 100).ToString();
    }
}