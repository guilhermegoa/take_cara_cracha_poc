using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace CaraCrachaPocket;

public class Build : IDocument
{
    private readonly float baseOffsetWidth = PageSizes.A5.Landscape().Width / 20;
    private readonly float baseOffsetHeight = PageSizes.A5.Landscape().Height / 20;
    
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Size(PageSizes.A5.Landscape());
                page.Background(Colors.White);

                page.Content().Element(ComposeContent);
            });
    }
    
    private void ComposeContent(IContainer container)
    {
        container.Border(4)
            .BorderColor("#afafaf")
            .Column(columns =>
        {
            columns.Item()
                .Width(0)
                .Height(0)
                .Layers(layers =>
            {
                layers.PrimaryLayer().Canvas((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#cbdbe3"),
                    };
                    
                    canvas.DrawRoundRect(baseOffsetWidth * 11, baseOffsetHeight * 6, baseOffsetWidth * 10,
                        baseOffsetHeight * 10, 30, 30, paint);
                });
            });

            //  header layer
            columns.Item()
                .Width(baseOffsetWidth *12)
                .Height(baseOffsetHeight * 5)
                .Layers(layers =>
            {
                layers.PrimaryLayer().Canvas((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#18202f"),
                    };

                    canvas.DrawRect(0, 0, baseOffsetWidth * 20, baseOffsetHeight * 8, paint);
                });

                // write header layer
                layers.Layer()
                    .TranslateX(baseOffsetWidth)
                    .TranslateY(baseOffsetHeight / 2 + 20)
                    .Width(baseOffsetWidth * 10 + 30)
                    .Text("Digite aqui seu nome e sobrenome.")
                    .FontSize(22)
                    .FontColor("#00c0d0")
                    .Bold();
                    

                layers.Layer()
                    .TranslateX(baseOffsetWidth )
                    .TranslateY(baseOffsetHeight * 3 + 20)
                    .Width(baseOffsetWidth * 10 + 30)
                    .Text("Digite aqui a cidade/estado que mora.")
                    .FontSize(20)
                    .FontColor(Colors.White)
                    .Bold();

                layers.Layer()
                    .TranslateX(baseOffsetWidth)
                    .TranslateY(baseOffsetHeight * 5 + 20)
                    .Width(baseOffsetWidth * 10 + 30)
                    .Text("Digite aqui a area que ira trabalhar.")
                    .FontSize(16)
                    .FontColor(Colors.White);
            });

            // Line layer
            columns.Item()
                .Width(0)
                .Height(0)
                .TranslateY(- baseOffsetHeight * 5)
                .Layers(layers =>
            {
                layers.PrimaryLayer().Canvas((canvas, space) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#f05480"),
                        StrokeWidth = 4,
                    };
                    
                    canvas.DrawLine(baseOffsetWidth / 2, 0, baseOffsetWidth / 2, baseOffsetHeight * 10, paint);
                });
            });
            
            // text layer
            columns.Item()
                .Width(baseOffsetWidth * 9)
                .Height(baseOffsetHeight * 5)
                .Layers(layers =>
            {
                layers.PrimaryLayer().Canvas(((canvas, space) =>
                    {
                        using var paint = new SKPaint
                        {
                            Color = SKColor.Parse("#caeff0"),
                            IsStroke = true,
                            StrokeWidth = 2,
                        };
                    
                        canvas.DrawRect(baseOffsetWidth, baseOffsetHeight * 4, baseOffsetWidth * 8 + 40, baseOffsetHeight * 4, paint);
                        canvas.DrawRect(baseOffsetWidth, baseOffsetHeight * 9, baseOffsetWidth * 8 + 40, baseOffsetHeight * 2, paint);
                        canvas.DrawRect(baseOffsetWidth, baseOffsetHeight * 12, baseOffsetWidth * 8 + 40, baseOffsetHeight * 2, paint);
                    }));
                
                // write text layer
                layers.Layer()
                    .TranslateX(baseOffsetWidth + 10)
                    .TranslateY(baseOffsetHeight * 4)
                    .Width(baseOffsetWidth * 8 + 20)
                    .Height(baseOffsetHeight * 4)
                    .Text("Digite aqui um fato curioso da sua vida que gostaria de compartilhar com a gente!")
                    .FontSize(12)
                    .FontColor(Colors.Black)
                    .Bold();
                
                layers.Layer()
                    .TranslateX(baseOffsetWidth + 10)
                    .TranslateY(baseOffsetHeight * 9)
                    .Width(baseOffsetWidth * 8 + 20)
                    .Height(baseOffsetHeight * 2)
                    .Text("Digite aqui se passatempo favorito.")
                    .FontSize(12)
                    .FontColor(Colors.Black);
                
                layers.Layer()
                    .TranslateX(baseOffsetWidth + 10)
                    .TranslateY(baseOffsetHeight * 12)
                    .Width(baseOffsetWidth * 8 + 20)
                    .Height(baseOffsetHeight * 2)
                    .Text("Digite aqui estilo de musica, filmes e jogos de sua preferencia.")
                    .FontSize(12)
                    .FontColor(Colors.Black);

                layers.Layer()
                    .TranslateX(baseOffsetWidth * 12 + 20)
                    .TranslateY(baseOffsetHeight * 7)
                    .Width(baseOffsetWidth * 6)
                    .Height(baseOffsetHeight * 5)
                    .AlignCenter()
                    .Text("Deixe aqui uma mensagem de até 10 palavras pra os Take.seres!")
                    .FontSize(16)
                    .FontColor(Colors.Black);
            });

            //User image layer
            byte[] imageData = File.ReadAllBytes("../../../images/photo.png");
            columns.Item()
                .TranslateX(baseOffsetWidth * 13 - 30)
                .TranslateY(-baseOffsetHeight * 9)
                .Width(baseOffsetWidth * 7)
                .Height(baseOffsetHeight * 10)
                .Border(2)
                .BorderColor("#0eb7c5")
                .Image(imageData, ImageScaling.Resize);
        });
    }
}