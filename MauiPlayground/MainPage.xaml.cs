namespace MauiPlayground;

public partial class MainPage : ContentPage
{

    #region - - - - - - Fields - - - - - -

    private int count = 0;

    #endregion Fields

    #region - - - - - - Constructors - - - - - -

    public MainPage()
    {
        InitializeComponent();
    }

    #endregion Constructors

    #region - - - - - - Methods - - - - - -

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times, when u gunna stop?";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    #endregion Methods

}
