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

    /// <summary>
    ///     📖 [jfversluis　＞　MauiFilePickerSample](https://github.com/jfversluis/MauiFilePickerSample)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void LoadImageFileButton_Clicked(object sender, EventArgs e)
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

    /// <summary>
    ///     📖 [jfversluis　＞　MauiFilePickerSample](https://github.com/jfversluis/MauiFilePickerSample)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void LoadSomeImagesButton_Clicked(object sender, EventArgs e)
    {
        // For custom file types            
        //var customFileType =
        //	new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        //	{
        //		 { DevicePlatform.iOS, new[] { "com.adobe.pdf" } }, // or general UTType values
        //       { DevicePlatform.Android, new[] { "application/pdf" } },
        //		 { DevicePlatform.WinUI, new[] { ".pdf" } },
        //		 { DevicePlatform.Tizen, new[] { "*/*" } },
        //		 { DevicePlatform.macOS, new[] { "pdf"} }, // or general UTType values
        //	});

        var results = await FilePicker.PickMultipleAsync(new PickOptions
        {
            //FileTypes = customFileType
        });

        foreach (var result in results)
        {
            // ファイルの読取ストリームを開くところまでしてくれる
            var stream = await result.OpenReadAsync();

            // 画像コントロールへ、画像データをセット
            myImage.Source = ImageSource.FromStream(() => stream);

            // ダイアログボックスのようなものを表示する
            // なんか初回は　ボタンがしばらくフリーズしていて押せない？
            await DisplayAlert("You picked...", result.FileName, "OK");
        }
    }
}