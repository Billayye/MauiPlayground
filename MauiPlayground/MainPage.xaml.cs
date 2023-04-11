namespace MauiPlayground;

public partial class MainPage : ContentPage
{

    #region - - - - - - Fields - - - - - -

    private int ClickCount = 0;
    private string TranslatedNumber = "";

    #endregion Fields

    #region - - - - - - Constructors - - - - - -

    public MainPage()
    {
        InitializeComponent();

        // Subscribing Event Handlers to Events on Controls
        CounterBtn.Clicked += OnCounterClicked;
        ButtonToCallNumber.Clicked += OnCallButtonClicked;
        ButtonToCallNumber.Clicked += OnTranslateButtonClicked;
        ButtonToCallNumber.Clicked -= OnTranslateButtonClicked;
        ButtonToTranslateNumber.Clicked += OnTranslateButtonClicked;
    }

    #endregion Constructors

    #region - - - - - - Methods - - - - - -

    async void OnCallButtonClicked(object sender, EventArgs e)
    {
        if (await DisplayAlert(
                "Dial a Number",
                $"Would you like to call {TranslatedNumber} ?",
                "Yes",
                "No"))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(TranslatedNumber);
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }
        }
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        ClickCount++;

        if (ClickCount == 1)
            CounterBtn.Text = $"Clicked {ClickCount} time";

        else
            CounterBtn.Text = $"Clicked {ClickCount} times, when u gunna stop?";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void OnTranslateButtonClicked(object sender, EventArgs e)
    {
        TranslatedNumber = PhonewordTranslator.ToNumber(TextInputPhoneNumber.Text);

        if (!string.IsNullOrEmpty(TranslatedNumber))
        {
            ButtonToCallNumber.IsEnabled = true;
            ButtonToCallNumber.Text = $"Call {TranslatedNumber}";
            SemanticScreenReader.Announce(ButtonToCallNumber.Text);
        }

        else
        {
            ButtonToCallNumber.IsEnabled = false;
            ButtonToCallNumber.Text = "Call";
        }
    }

    #endregion Methods

}
