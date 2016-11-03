**Chameleon-RCI** is a Xamarin Component that provides **Chameleon**, a lightweight, yet powerful, color framework for iOS. It is built on the idea that software applications should function effortlessly while simultaneously maintaining their beautiful interfaces.

With Chameleon, you can easily stop tinkering with RGB values, wasting hours figuring out the right color combinations to use in your app, and worrying about whether your text will be readable on the various background colors of your app. 

### Features

![Features](http://i.imgur.com/lA4J37o.png)

## Product Features

### 100% Flat & Gorgeous

Chameleon features over 24 hand-picked colors that come in both light and dark shades. 

![Swatches](http://i.imgur.com/wkGGWkN.png)

To generate a specific color:

    var color = ChameleonColor.FlatGreen;
    var colorDark = ChameleonColor.FlatGreenDark;

There are two ways to generate a random flat color. If you have no preference 
as to whether you want a light shade or a dark shade, you can do the following:

    var color = ChameleonColor.GetRandomColor();

Otherwise, you can perform the following method call to specify whether it 
should return either a light or dark shade:

    var color = ChameleonColor.GetRandomColor(ShadeStyle.Light);
    var colorDark = ChameleonColor.GetRandomColor(ShadeStyle.Dark);

### Flat Color Schemes

Chameleon equips you with 3 different classes of flat color schemes that can be generated from a flat or non-flat color. *In the examples below, the white stars indicate the color used to generate the schemes.*

###### Analogous Flat Color Scheme

![Analogous Scheme](http://i.imgur.com/cPAkSWA.png)

    var scheme = ChameleonColorArray.GetColors(ColorScheme.Analogous, ChameleonColor.FlatPurple, true);

###### Complementary Flat Color Scheme

![Complementary Scheme](http://i.imgur.com/kisXJsu.png)

    var scheme = ChameleonColorArray.GetColors(ColorScheme.Complementary, ChameleonColor.FlatCoffee, true);

###### Triadic Flat Color Scheme

![Triadic Scheme](http://i.imgur.com/Cy452jQ.png)

    var scheme = ChameleonColorArray.GetColors(ColorScheme.Triadic, ChameleonColor.FlatRed, true);

### Contrasting Text
With a plethora of color choices available for text, it's difficult to choose one that all users will appreciate and be able to read. Whether you're in doubt of your text and tint color choices, or afraid to let users customize their profile colors because it may disturb the legibility or usability of the app, you no longer have to worry. With Chameleon, you can ensure that all text stands out independent of the background color.

    var contrast = ChameleonColor.GetContrastingBlackOrWhiteColor(color, false);

Oh... Chameleon works with the status bar as well. : )

![Status Bar](http://s29.postimg.org/i1syd7bkn/Contrast.gif)

    this.SetStatusBarStyle (StatusBarStyle.Contrast);

### Navigation Bar Hairline

If you're seeking a true flat look, you can hide the hairline at the bottom 
of the navigation bar by doing the following: 

    NavigationController.HideNavigationBarHairline(true);
	
![No Hairline](http://i.imgur.com/tjwx53y.png)

### Themes ![Beta](http://i.imgur.com/JyYiUJq.png)

Chameleon now allows you easily theme your app with as little as **one line of code**. You can set a theme for all your views, and for specific views as well.

![Themes](http://i.imgur.com/ypfqpIn.png)

To set a global theme, you can do the following in your app delegate:

    Chameleon.SetGlobalTheme(
		ChameleonColor.FlatMint,
        ChameleonColor.FlatBlue,
		ContentStyle.Contrast);

But what if you want a different theme for a specific `UIViewController`? No 
problem, Chameleon allows you to override the global theme in any 
`UIViewController` and `UINavigationController`, by simply doing the following:

    this.SetTheme(
		ChameleonColor.FlatMint,
        ChameleonColor.FlatBlue,
		ContentStyle.Contrast);

### Colors From Images 

Chameleon allows you to seamlessly extract non-flat or flat color schemes from images without hassle. You can also generate the average color from an image with ease. You can now mold the UI colors of a profile, or product based on an image!

![Colors from images](http://i.imgur.com/6JjFzHo.png)

Non-flat color scheme from image:

    var colors = ChameleonColorArray.GetColors(image, false);

Flat color scheme from image:

    var colors = ChameleonColorArray.GetColors(image, true);

To extract the average color from an image, you can also do:

    var average = ChameleonColor.GetImageAverageColor(image);

### Gradient Colors
With iOS 7 & 8, Apple mainstreamed flat colors. Now, with the release of iOS 9, Chameleon strives to elevate the game once more. Say hello to gradient colors. Using one line of code, you can easily set any object's color properties to a gradient (background colors, text colors, tint colors, etc). Other features, like Chameleon's contrasting feature, can also be applied to create a seamless product. Experimentation is encouraged, and gutsiness is applauded!

![Gradients](http://i.imgur.com/7hTa5Pd.png)

![](http://i.imgur.com/2jN72eh.png)

    var colorArray = new UIColor[] { ChameleonColor.FlatYellow, ChameleonColor.FlatOrange };
    var gradient = ChameleonColor.GetGradientColor(GradientStyle.LeftToRight, View.Bounds, colorArray);


####Palettes
##### Storyboard Add-On
Using Chameleon's awesome palette in Storyboard is easy! Simply download and install [Chameleon Palette](https://github.com/ViccAlexander/Chameleon/blob/master/Extras/Chameleon.dmg?raw=true).

Once installed, make sure to restart Xcode. You'll find all of Chameleon's colors in the Palette Color Picker whenever they're needed! :)

![Chameleon Palette](http://i.imgur.com/XqpFUSt.png)

![Chameleon Palette](http://i.imgur.com/QhhPFHY.gif)

##### Photoshop Add-On
Using Chameleon's awesome palette in Sketch is easy! Simply download and install [Photoshop Palette](https://github.com/ViccAlexander/Chameleon/blob/master/Extras/Chameleon_Photoshop.aco?raw=true).

##### Sketch Add-On
Using Chameleon's awesome palette in Sketch is easy! Simply download and install [Sketch Palette](https://github.com/ViccAlexander/Chameleon/blob/master/Extras/Chameleon.sketchpalette?raw=true).

## Change Log

#### See [Changelog.md](https://github.com/ViccAlexander/Chameleon/blob/master/CHANGELOG.md) 👀
source: https://github.com/ViccAlexander/Chameleon

## Building

###Setup Xamarin Component
https://developer.xamarin.com/guides/cross-platform/advanced/submitting_components/component_submission_quickstart/

###Setup Cake & Chameleon
http://cakebuild.net/docs/tutorials/setting-up-a-new-project  
curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/osx  
chmod +x build.sh  
./build.sh  

### Update Component
./build.sh  
mono tools/XamarinComponent/tools/xamarin-component.exe package component


