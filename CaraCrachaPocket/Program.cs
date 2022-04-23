using CaraCrachaPocket;
using QuestPDF.Drawing;
using QuestPDF.Fluent;

FontManager.RegisterFontType("Calibri", File.OpenRead("../../../font/calibri.ttf"));

var build = new Build();
build.GeneratePdf("hello.pdf");
