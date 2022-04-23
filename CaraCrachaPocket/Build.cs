using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace CaraCrachaPocket;

public class Build : IDocument
{
    private readonly float baseOffsetWidth = PageSizes.A5.Landscape().Width / 10;
    private readonly float baseOffsetHeight = PageSizes.A5.Landscape().Height / 10;
    
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Size(PageSizes.A5.Landscape());
                page.Background(Colors.White);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
    }

    private void ComposeHeader(IContainer container)
    {
        container.Layers(layers =>
        {
            // layer header
            layers.PrimaryLayer().Canvas((canvas, space) =>
            {
                using var paint = new SKPaint
                {
                    Color = SKColor.Parse("#18202f"),
                };

                canvas.DrawRect(0, 0, baseOffsetWidth * 10, baseOffsetHeight * 4, paint);
            });

            // Line layer
             layers.Layer().Canvas(((canvas, space) =>
             {
                 using var paint = new SKPaint
                 {
                     Color = SKColor.Parse("#f05480"),
                     StrokeWidth = 3
                 };

                 canvas.DrawLine(baseOffsetWidth / 2,  0, baseOffsetWidth / 2, baseOffsetHeight * 6, paint);
             }));

            // // user layer
            //  layers.Layer().Canvas(((canvas, space) =>
            //  {
            //      using var paint = new SKPaint
            //      {
            //          Color = SKColor.Parse("#07c1d1"),
            //      };
            //
            //      canvas.DrawRect(space.Width - 220,  0, space.Width / 4 + 50, (space.Height / 3) * 2 - 50, paint);
            //  }));
            //  
            //  //Image layers
            //
            //  byte[] imageData = File.ReadAllBytes("../../../images/photo.png");
            //  layers.Layer().Image(imageData, ImageScaling.FitWidth);


            // write header layer
            layers.Layer()
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
        });
    }

    private void ComposeContent(IContainer container)
    {
        //layers de escrita de 10 palavras
        container.Layers(layers =>
        {
             layers.PrimaryLayer().Canvas(((canvas, space) =>
             {
                 using var paint = new SKPaint
                 {
                     Color = SKColor.Parse("#cbdbe3"),
                 };

                 canvas.DrawRoundRect(baseOffsetWidth * 6 ,  -baseOffsetHeight * 7, baseOffsetWidth * 5, 
                     baseOffsetHeight * 4, 30, 30, paint);
             }));
        });
    }

    private void ComposeFooter(IContainer container)
    {
       
    }
}