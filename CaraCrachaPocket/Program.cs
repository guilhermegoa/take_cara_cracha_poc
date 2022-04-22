using System.Security.Cryptography;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using SkiaSharp;

// static method definition
// FontManager.RegisterFontType(Stream fontDataStream);

// perform similar invocation only once, when the application starts or during its initialization step
FontManager.RegisterFontType("Calibri", File.OpenRead("../../../font/calibri.ttf")); // use file name

// code in your main method
var document = Document.Create(container =>
{
    container.Page(page =>
    {
        //base config
        page.Size(PageSizes.A5.Landscape());
        page.Background(Colors.White);
        // page.Margin(2, Unit.Centimetre);
        // page.DefaultTextStyle(x => x.FontSize(20));
        
        //content
        page.Content()
            .Border(5)
            .BorderColor("#afafaf")
            .Layers(layers =>
            {
                //layers de escrita de 10 palavras
                layers.Layer().Canvas(((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#cbdbe3"),
                    };

                    canvas.DrawRoundRect(space.Width - 260, space.Height / 3 - 30, (space.Width / 3) * 2,
                        (space.Height / 3) * 2 - 50, 30, 30, paint);
                }));
                
                // layer header
                layers.PrimaryLayer().Canvas((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#18202f"),
                    };

                    canvas.DrawRect(0, 0, space.Width, space.Height / 3, paint);
                });

      
                // user layer
                layers.Layer().Canvas(((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#07c1d1"),
                    };

                    canvas.DrawRect(space.Width - 220,  0, space.Width / 4 + 50, (space.Height / 3) * 2 - 50, paint);
                }));
                
                //text area layer
                // user layer
                layers.Layer().Canvas(((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#cbdba3"),
                        IsStroke = true,
                        StrokeWidth = 2,
                    };

                    canvas.DrawRect(60, space.Height / 3 + 30, (space.Width / 8) * 3, space.Height / 6, paint);
                    canvas.DrawRect(60, space.Height / 3 + 130, (space.Width / 8) * 3, space.Height / 10, paint);
                    canvas.DrawRect(60, space.Height / 3 + 210, (space.Width / 8) * 3, space.Height / 10, paint);
                }));
            });


        // page.Header()
        //     .Text("Hello PDFfff!")
        //     .FontFamily("Calibri")
        //     .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

        // page.Content()
        //     .PaddingVertical(1, Unit.Centimetre)
        //     .Column(x =>
        //     {
        //         x.Spacing(20);
        //
        //         x.Item().Text(Placeholders.LoremIpsum()).FontFamily("Calibri");
        //         x.Item().Image(Placeholders.Image(200, 100));
        //     });

        // page.Footer()
        //     .AlignCenter()
        //     .Text(x =>
        //     {
        //         x.Span("Page ").FontFamily("Calibri");
        //         x.CurrentPageNumber().FontFamily("Calibri");
        //     });
    });
});

// instead of the standard way of generating a PDF file
document.GeneratePdf("hello.pdf");

// use the following invocation
// document.ShowInPreviewer();

// optionally, you can specify an HTTP port to communicate with the previewer host (default is 12500)
// document.ShowInPreviewer(12345);
