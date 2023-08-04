namespace MauiControlPractice.Views;

/// <summary>
///		😁 ファイル・ピッカー練習ページ
/// </summary>
public partial class FilePickerPage : ContentPage
{
	public FilePickerPage()
	{
		InitializeComponent();
	}

    async void LoadFileButton_Clicked(object sender, EventArgs e)
    {
        // 非同期で画像ファイル選択
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Image Please",
            FileTypes = FilePickerFileType.Images
        });

        // ファイルを選んでいなければ終了
        if (result == null)
            return;

        // ファイルの読取ストリームを開くところまでしてくれる
        var stream = await result.OpenReadAsync();

        // 画像コントロールへ、画像データをセット
        myImage.Source = ImageSource.FromStream(() => stream);
    }
}