using MauiIcons.Material;

namespace WX.Views.Controls;

public partial class Alert : ContentView
{
	public static readonly BindableProperty AlertBackgroundProperty =
		BindableProperty.Create("AlertBackground", typeof(Color), typeof(Alert));

	public static readonly BindableProperty AlertColorProperty =
		BindableProperty.Create("AlertColor", typeof(Color), typeof(Alert));

	public static readonly BindableProperty TitleProperty =
		BindableProperty.Create("Title", typeof(string), typeof(Alert));

	public static readonly BindableProperty TextProperty =
		BindableProperty.Create("Text", typeof(string), typeof(Alert));

	public static readonly BindableProperty IconProperty =
		BindableProperty.Create("Icon", typeof(MaterialIcons), typeof(Alert));

	public Color AlertBackground
	{
		get => (Color)GetValue(AlertBackgroundProperty);
		set => SetValue(AlertBackgroundProperty, value);
	}

	public Color AlertColor
	{
		get => (Color)GetValue(AlertColorProperty);
		set => SetValue(AlertColorProperty, value);
	}

	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public MaterialIcons Icon
	{
		get => (MaterialIcons)GetValue(IconProperty);
		set => SetValue(IconProperty, value);
	}

	public Alert()
	{
		InitializeComponent();
	}
}