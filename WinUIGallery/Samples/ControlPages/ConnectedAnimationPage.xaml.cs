// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using WinUIGallery.SamplePages;

namespace WinUIGallery.ControlPages;

public sealed partial class ConnectedAnimationPage : Page
{
    public ConnectedAnimationPage()
    {
        this.InitializeComponent();

        // For 1st sample
        CollectionContentFrame.Navigate(typeof(CollectionPage));

        // For 2nd sample
        CardFrame.Navigate(typeof(CardPage));

        // For 3rd sample
        ContentFrame.Navigate(typeof(SamplePage1));
    }

    private ConnectedAnimationConfiguration GetConfiguration()
    {
        if (this.ConfigurationPanel == null)
        {
            return null;
        }

        var selectedName = (ConfigurationPanel.SelectedItem as RadioButton).Content.ToString();
        switch (selectedName)
        {
            case "Gravity":
                return new GravityConnectedAnimationConfiguration();
            case "Direct":
                return new DirectConnectedAnimationConfiguration();
            case "Basic":
                return new BasicConnectedAnimationConfiguration();
            default:
                return null;
        }
    }

    private void NavigateButton_Click(object sender, RoutedEventArgs e)
    {
        var currentContent = ContentFrame.Content;

        if (currentContent as SamplePage1 != null)
        {
            (currentContent as SamplePage1).PrepareConnectedAnimation(GetConfiguration());
            ContentFrame.Navigate(typeof(SamplePage2), null, new SuppressNavigationTransitionInfo());
        }
        else if (currentContent as SamplePage2 != null)
        {
            (currentContent as SamplePage2).PrepareConnectedAnimation(GetConfiguration());
            ContentFrame.Navigate(typeof(SamplePage1), null, new SuppressNavigationTransitionInfo());
        }
    }
}

// Sample data object used to populate the collection page.
public class CustomDataObject
{
    public string Title { get; set; }
    public string ImageLocation { get; set; }
    public string Views { get; set; }
    public string Likes { get; set; }
    public string Description { get; set; }

    public CustomDataObject()
    {
    }

    public static List<CustomDataObject> GetDataObjects(bool includeAllItems = false)
    {
        string[] dummyTexts = new[] {
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer id facilisis lectus. Cras nec convallis ante, quis pulvinar tellus. Integer dictum accumsan pulvinar. Pellentesque eget enim sodales sapien vestibulum consequat.",
            @"Nullam eget mattis metus. Donec pharetra, tellus in mattis tincidunt, magna ipsum gravida nibh, vitae lobortis ante odio vel quam.",
            @"Quisque accumsan pretium ligula in faucibus. Mauris sollicitudin augue vitae lorem cursus condimentum quis ac mauris. Pellentesque quis turpis non nunc pretium sagittis. Nulla facilisi. Maecenas eu lectus ante. Proin eleifend vel lectus non tincidunt. Fusce condimentum luctus nisi, in elementum ante tincidunt nec.",
            @"Aenean in nisl at elit venenatis blandit ut vitae lectus. Praesent in sollicitudin nunc. Pellentesque justo augue, pretium at sem lacinia, scelerisque semper erat. Ut cursus tortor at metus lacinia dapibus.",
            @"Ut consequat magna luctus justo egestas vehicula. Integer pharetra risus libero, et posuere justo mattis et.",
            @"Proin malesuada, libero vitae aliquam venenatis, diam est faucibus felis, vitae efficitur erat nunc non mauris. Suspendisse at sodales erat.",
            @"Aenean vulputate, turpis non tincidunt ornare, metus est sagittis erat, id lobortis orci odio eget quam. Suspendisse ex purus, lobortis quis suscipit a, volutpat vitae turpis.",
            @"Duis facilisis, quam ut laoreet commodo, elit ex aliquet massa, non varius tellus lectus et nunc. Donec vitae risus ut ante pretium semper. Phasellus consectetur volutpat orci, eu dapibus turpis. Fusce varius sapien eu mattis pharetra.",
        };

        Random rand = new Random();
        int numberOfLocations = includeAllItems ? 13 : 8;
        List<CustomDataObject> objects = new List<CustomDataObject>();
        for (int i = 0; i < numberOfLocations; i++)
        {
            objects.Add(new CustomDataObject()
            {
                Title = $"Item {i + 1}",
                ImageLocation = $"/Assets/SampleMedia/LandscapeImage{i + 1}.jpg",
                Views = rand.Next(100, 999).ToString(),
                Likes = rand.Next(10, 99).ToString(),
                Description = dummyTexts[i % dummyTexts.Length],
            });
        }

        return objects;
    }

}
