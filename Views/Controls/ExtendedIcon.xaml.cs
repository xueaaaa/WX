using MauiIcons.Material;

namespace WX.Views.Controls;

public partial class ExtendedIcon : ContentView
{
	public static readonly BindableProperty PrimaryProperty =
		BindableProperty.Create("Primary", typeof(MaterialIcons), typeof(ExtendedIcon));

	public static readonly BindableProperty SecondaryProperty =
		BindableProperty.Create("Secondary", typeof(MaterialIcons), typeof(ExtendedIcon));

	public static readonly BindableProperty SecondaryMarginProperty =
		BindableProperty.Create("SecondaryMargin", typeof(Thickness), typeof(ExtendedIcon), defaultValue: new Thickness(-8.5,0,0,10));

	public MaterialIcons Primary
	{
		get => (MaterialIcons)GetValue(PrimaryProperty);
		set => SetValue(PrimaryProperty, value);
	}

	public MaterialIcons Secondary
	{
		get => (MaterialIcons)GetValue(SecondaryProperty);
		set => SetValue(SecondaryProperty, value);
	}

	public Thickness SecondaryMargin
	{
		get => (Thickness)GetValue(SecondaryMarginProperty);
		set => SetValue(SecondaryMarginProperty, value);
	}

	public ExtendedIcon()
	{
		InitializeComponent();
	}
}