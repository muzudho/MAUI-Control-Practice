namespace MauiControlPractice.Views;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    async void FilePickerPageButton_Clicked(object sender, EventArgs e)
    {
        var shellNavigationState = new ShellNavigationState("//FilePickerPage");

        await Shell.Current.GoToAsync(
            state: shellNavigationState);
        // ここは通り抜ける。恐らく、UIスレッドを抜けた後に画面遷移する
    }
}

