using SkiaSharp;
using System.Drawing;
using System.Drawing.Imaging;

using Bitmap image = (Bitmap)Image.FromFile(@"C:\Temp\SkiaSharpTutorial\SkiaSharpTutorial\bin\Debug\net6.0\Hello World.tif");

var dimension = new FrameDimension(image.FrameDimensionsList[0]);
var frameCount = image.GetFrameCount(dimension);

for (int i = 0; i < frameCount; i++)
{
    using (Stream currentFram = new MemoryStream())
    {
        image.SelectActiveFrame(dimension, i);
        image.Save(currentFram, ImageFormat.Png);

        Bitmap tiffImage = (Bitmap)Image.FromStream(currentFram);
        Stream stream = new MemoryStream();

        tiffImage.Save(stream, ImageFormat.Png);

        stream.Seek(0, SeekOrigin.Begin);

        SKBitmap sKBitmap = SKBitmap.Decode(stream);
        SKImage sKImage = SKImage.FromBitmap(sKBitmap);

        //SaveImage(sKBitmap.Encode(SKEncodedImageFormat.Png, 100), $"sKBitmap_Tif{i}.png");

        Bitmap bitmap = new Bitmap(sKImage.Width, sKImage.Height, PixelFormat.Format32bppPArgb);
        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, sKImage.Width, sKImage.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

        SKPixmap pixmap = new SKPixmap(new SKImageInfo(data.Width, data.Height), data.Scan0, data.Stride);
            
        sKImage.ReadPixels(pixmap, 0, 0);
        
        bitmap.UnlockBits(data);
        bitmap.Save($"SkBitMap_To_Bitmap_{i}.png");
    }
}








































static void SaveImage(SKData sKData, string fileName)
{
    using (FileStream fileStream = File.Create(fileName))
    {
        sKData.AsStream().Seek(0, SeekOrigin.Begin);
        sKData.AsStream().CopyTo(fileStream);

        fileStream.Flush();
        fileStream.Close();
    }
}

static void DrawText(string text, SKEncodedImageFormat imageFormat = SKEncodedImageFormat.Png)
{
    SKSurface sKSurface = SKSurface.Create(new SKImageInfo(500, 90));
    SKCanvas sKCanvas = sKSurface.Canvas;
    SKPaint paint = new SKPaint();

    paint.Color = SKColors.Black;
    paint.TextSize = 60;
    paint.Typeface = SKTypeface.FromFamilyName("Arial");
    paint.IsAntialias = true;

    sKCanvas.Clear(SKColors.White);

    sKCanvas.DrawText(text, 10, 50, paint);

    SKBitmap sKBitmap = SKBitmap.FromImage(sKSurface.Snapshot());
    SKData sKData = sKBitmap.Encode(imageFormat, 100);

    SaveImage(sKData, $"{text.Replace(" ", "")}.{imageFormat}");
}

//SKBitmap bitmap = SKBitmap.Decode("favicon.ico");
//SKSurface sKSurface = SKSurface.Create(new SKImageInfo(500, 90));
//SKCanvas sKCanvas = sKSurface.Canvas;

//sKCanvas.Clear(SKColors.White);
//sKCanvas.DrawBitmap(bitmap, new SKPoint());

//SKBitmap bitmap2 = SKBitmap.FromImage(sKSurface.Snapshot());
//SKData data = bitmap2.Encode(SKEncodedImageFormat.Ico, 100);

//SaveImage(data, "favicon2.Ico");

//DrawText("Hello World JPEG", SKEncodedImageFormat.Jpeg);









































//SKBitmap bitmap = SKBitmap.Decode("HelloWorld.png");

//MemoryStream memStream = new MemoryStream();
//SKManagedWStream wstream = new SKManagedWStream(memStream);
//bool b = bitmap.Encode(wstream, SKEncodedImageFormat.Jpeg, 100);
//SKBitmap sKBitmap = SKBitmap.Decode(wstream);

//FileStream fileStream = File.Create($"HelloWorld.{SKEncodedImageFormat.Jpeg}");
//memStream.CopyTo(fileStream);

//fileStream.Flush();
//fileStream.Close();




//// open the stream
//var stream = new SKFileStream("HelloWorld.jpeg");

//// create the codec
//var codec = SKCodec.Create(stream);

//// we need a place to store the bytes
//var bitmap = new SKBitmap(codec.Info);

//SaveImage(bitmap.Encode(SKEncodedImageFormat.Png, 100), "HelloWorld.jpeg.png");

//// decode!
//// result should be SKCodecResult.Success, but you may get more information
//SKCodecResult result = codec.GetPixels(bitmap.Info, bitmap.GetPixels());

Console.WriteLine();




































//float resizeFacotor = 0.5f;
//SKBitmap bitmap = SKBitmap.Decode("HelloWOrld.png");

//int width = (int)Math.Round(bitmap.Width * resizeFacotor);
//int height = (int)Math.Round(bitmap.Height * resizeFacotor);

//SKBitmap bitmap2 = new SKBitmap(width, height, bitmap.ColorType, bitmap.AlphaType);

//SKCanvas canvas = new SKCanvas(bitmap2);

//canvas.SetMatrix(SKMatrix.CreateScale(resizeFacotor, resizeFacotor));
//canvas.DrawBitmap(bitmap, new SKPoint());
//canvas.ResetMatrix();
//canvas.Flush();

//SKImage sKImage = SKImage.FromBitmap(bitmap2);
//SKData sKData = sKImage.Encode(SKEncodedImageFormat.Png, 100);

//SaveImage(sKData, $"resized_{resizeFacotor}.png");


//SKSurface sKSurface = SKSurface.Create(new SKImageInfo(450, 90));
//SKCanvas sKCanvas = sKSurface.Canvas;
//SKBitmap sKBitmap1 = SKBitmap.Decode("HelloWorld2.png");

//SKPaint paint = new SKPaint();

//paint.ColorFilter = SKColorFilter.CreateColorMatrix(new float[]
//                    {
//                        0.21f, 0.72f, 0.07f, 0, 0,
//                        0.21f, 0.72f, 0.07f, 0, 0,
//                        0.21f, 0.72f, 0.07f, 0, 0,
//                        0,     0,     0,     1, 0
//                    });

//sKCanvas.DrawBitmap(sKBitmap1, new SKPoint(), paint);

//SKImage sKImage1 = sKSurface.Snapshot();
//SKData sKData1 = sKImage1.Encode(SKEncodedImageFormat.Png, 100);

//SaveImage(sKData1, "HelloWorld3.png");




//static void CreatEmptyImage(string fileName)
//{
//    SKBitmap sKBitmap = new SKBitmap(300, 300);
//    SKData sKData = sKBitmap.Encode(SKEncodedImageFormat.Png, 100);

//    SaveImage(sKData, fileName);
//}

//static void WindowsAPI()
//{
//    NativeMethods.MessageBox(new IntPtr(0), "hello world!", "Message box example", 1);


//    Console.WriteLine("Hello, World!");
//}

static void RotateImage()
{
    double angle = 60;
    string fileName = @"SkiaSharpText.png";
    string fileNameRotate = $"SkiaSharpText_Rotate{angle}.png";

    SKBitmap sKBitmap = SKBitmap.Decode(fileName);

    double radians = Math.PI * angle / 180;
    float sine = (float)Math.Abs(Math.Sin(radians));
    float cosine = (float)Math.Abs(Math.Cos(radians));
    int originalWidth = sKBitmap.Width;
    int originalHeight = sKBitmap.Height;
    int rotatedWidth = (int)(cosine * originalWidth + sine * originalHeight);
    int rotatedHeight = (int)(cosine * originalHeight + sine * originalWidth);

    SKBitmap rotatedBitmap = new SKBitmap(rotatedWidth, rotatedHeight);
    SKCanvas canvas = new SKCanvas(rotatedBitmap);

    canvas.Translate(rotatedWidth / 2, rotatedHeight / 2);
    canvas.RotateDegrees((float)angle);

    SKPaint sKPaint = new SKPaint();

    sKPaint.IsAntialias = true;
    sKPaint.FilterQuality = SKFilterQuality.High;

    canvas.DrawBitmap(sKBitmap, new SKPoint(-originalWidth / 2, -originalHeight / 2), sKPaint);

    SKData sKData = rotatedBitmap.Encode(SKEncodedImageFormat.Png, 100);

    SaveImage(sKData, fileNameRotate);
}

static void FlipImage()
{
    string fileName = @"SkiaSharpText.png";
    string fileNameFlip = $"SkiaSharpText_Flip_Height.png";
    SKBitmap sKBitmap = SKBitmap.Decode(fileName);
    SKBitmap flipBitmap = new SKBitmap(sKBitmap.Width, sKBitmap.Height);

    SKCanvas canvas = new SKCanvas(flipBitmap);

    canvas.Translate(0, sKBitmap.Height);
    canvas.Scale(1, -1, 0, 0);
    canvas.DrawBitmap(sKBitmap, 0, 0);

    SKData sKData = flipBitmap.Encode(SKEncodedImageFormat.Png, 100);

    SaveImage(sKData, fileNameFlip);
}

static void GetGifAnimation()
{
    Stream stream = File.Open("animation.gif", FileMode.Open);
    SKManagedStream skStream = new SKManagedStream(stream);
    SKCodec codec = SKCodec.Create(skStream);

    for (int i = 0; i < codec.FrameCount; i++)
    {
        SKImageInfo sKImageInfo = new SKImageInfo(codec.Info.Width, codec.Info.Height);
        SKBitmap bitmaps = new SKBitmap(sKImageInfo);
        IntPtr pointer = bitmaps.GetPixels();
        SKCodecOptions codecOptions = new SKCodecOptions(i);

        codec.GetPixels(sKImageInfo, pointer, codecOptions);
        SaveImage(bitmaps.Encode(SKEncodedImageFormat.Png, 100), $"animation_{i}.png");
    }
}