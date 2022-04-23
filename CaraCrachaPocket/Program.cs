using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using SkiaSharp;

FontManager.RegisterFontType("Calibri", File.OpenRead("../../../font/calibri.ttf"));

// code in your main method
var document = Document.Create(container =>
{
    container.Page(page =>
    {
        //base config
        page.Size(PageSizes.A5.Landscape());
        page.Background(Colors.White);
        
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
                layers.Layer().Canvas((canvas, space) =>
                    {
                        using var paint = new SKPaint
                        {
                            Color = SKColor.Parse("#18202f"),
                        };

                        canvas.DrawRect(0, 0, space.Width, space.Height / 3, paint);
                    });

                // write header layer
                layers.PrimaryLayer()
                    .PaddingLeft(60)
                    .PaddingTop(20)
                    .Text("Digite aqui seu nome e sobrenome")
                    .FontSize(16).FontColor("#00c0d0")
                    .Bold();

                layers.Layer()
                    .PaddingLeft(60)
                    .PaddingTop(60)
                    .Text("Digite aqui a cidade/estado que mora")
                    .FontSize(16).FontColor(Colors.White)
                    .Bold();

                layers.Layer()
                    .PaddingLeft(60)
                    .PaddingTop(100)
                    .Text("Digite aqui a area que ira trabalhar")
                    .FontSize(16).FontColor(Colors.White);

                // line layer
                layers.Layer().Canvas((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#f05480"),
                        StrokeWidth = 4,
                    };

                    canvas.DrawLine(space.Width / 20, 0, space.Width / 20, space.Height / 2, paint);
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
               
                // text layer
                layers.Layer().Canvas(((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#cbdba3"),
                        IsStroke = true,
                        StrokeWidth = 2,
                    };

                    canvas.DrawRect(60, space.Height / 3 + 30, (space.Width / 9) * 4, space.Height / 6, paint);
                    canvas.DrawRect(60, space.Height / 3 + 130, (space.Width / 9) * 4, space.Height / 10, paint);
                    canvas.DrawRect(60, space.Height / 3 + 210, (space.Width / 9) * 4, space.Height / 10, paint);
                }));

                // write text layer
                layers.Layer()
                    .PaddingLeft(70)
                    .PaddingTop(170)
                    .Text("Digite aqui seu nome e sobrenome")
                    .FontSize(16).FontColor("#00c0d0")
                    .Bold();
            });
    });
});

// instead of the standard way of generating a PDF file
document.GeneratePdf("hello.pdf");
