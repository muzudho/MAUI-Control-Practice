namespace MauiControlPractice.Views;

using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls.Shapes;
using System.Diagnostics;

/// <summary>
///     😁 ドラッグ＆ドロップ練習ページ
/// </summary>
public partial class DragAndDropPage : ContentPage
{
	public DragAndDropPage()
	{
		InitializeComponent();
	}

    private void DragGestureRecognizer_OnDragStarting(object sender, DragStartingEventArgs e)
    {
        Shape shape = (sender as Element).Parent as Shape;

        // オブジェクトも追加できるはずだが、とりあえず 文字列を入れておく
        e.Data.Text = $"Square Width: {shape.Width}, Height: {shape.Height}";
        // e.Data.Properties.Add("Square", $"Square Width: {shape.Width}, Height: {shape.Height}");
    }

    private void DropGestureRecognizer_DragOver(object sender, DragEventArgs e)
    {
        // ドロップを許可しない場合
        // e.AcceptedOperation = DataPackageOperation.None;
    }

    async void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        string text = await e.Data.GetTextAsync();

        Trace.WriteLine($"[DragAndDropPage DropGestureRecognizer_Drop] text: {text}");
    }
}