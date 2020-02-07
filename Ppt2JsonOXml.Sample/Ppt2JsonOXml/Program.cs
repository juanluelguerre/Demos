using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Everis.Automation.Ppt2JsonOXml
{
    /// <summary>
    /// PoC to learn about OpenXML woks !
    /// <seealso cref="https://docs.microsoft.com/en-us/office/open-xml/presentations"/>
    /// </summary>
    public static class Program
    {
        private const string FILE = "Prueba1.pptx";

        public static void Main(string[] args)
        {
            var pptxDoc = PresentationDocument.Open(FILE, false);
            var slidesCount = pptxDoc.PresentationPart.SlideParts.Count();

            Console.WriteLine($"{slidesCount} slides en el doc {FILE}");

            var titles = GetSlideTitles(pptxDoc);

            int i = 1;
            foreach (var title in titles)
            {
                Console.WriteLine($"{i++} - {title}");
            }

            Console.WriteLine("Pulse INTRO para finalizar...");
            Console.ReadLine();
        }

        // Get a list of the titles of all the slides in the presentation.
        private static IList<string> GetSlideTitles(PresentationDocument presentationDocument)
        {
            if (presentationDocument == null)
            {
                throw new ArgumentNullException(nameof(presentationDocument));
            }

            var titles = new List<string>();

            // Get a PresentationPart object from the PresentationDocument object.
            PresentationPart presentationPart = presentationDocument.PresentationPart;

            if (presentationPart != null &&
                presentationPart.Presentation != null)
            {
                // Get a Presentation object from the PresentationPart object.
                var presentation = presentationPart.Presentation;

                if (presentation.SlideIdList != null)
                {
                    // Get the title of each slide in the slide order.
                    foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())
                    {
                        var slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                        // Get the slide title.
                        string title = GetSlideTitle(slidePart);

                        // An empty title can also be added.
                        titles.Add(title);
                    }                    
                }
            }
            return titles;
        }

        public static string GetSlideTitle(SlidePart slidePart)
        {
            if (slidePart == null)
            {
                throw new ArgumentNullException(nameof(slidePart));
            }

            // Declare a paragraph separator.
            string paragraphSeparator = null;

            if (slidePart.Slide != null)
            {
                // Find all the title shapes.
                var shapes = from shape in slidePart.Slide.Descendants<Shape>()
                             where IsTitleShape(shape)
                             select shape;

                var paragraphText = new StringBuilder();

                foreach (var shape in shapes)
                {
                    // Get the text in each paragraph in this shape.
                    // foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())
                    foreach (var paragraph in shape.TextBody.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())
                    {
                        // Add a line break.
                        paragraphText.Append(paragraphSeparator);

                        // foreach (var text in paragraph.Descendants<D.Text>())
                        foreach (var text in paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text> ())
                        {
                            // paragraphText.Append(text.Text);
                            paragraphText.Append(text.InnerText);
                        }
                        paragraphSeparator = "\n";
                    }
                }
                return paragraphText.ToString();
            }
            return string.Empty;
        }

        private static bool IsTitleShape(Shape shape)
        {
            var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();
            if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)
            {
                switch ((PlaceholderValues)placeholderShape.Type)
                {
                    // Any title shape.
                    case PlaceholderValues.Title:

                    // A centered title.
                    case PlaceholderValues.CenteredTitle:
                        return true;

                    default:
                        return false;
                }
            }
            return false;
        }

        private static void SampleReadPptx(string file)
        {
            var openSettings = new OpenSettings
            {
                MarkupCompatibilityProcessSettings =
                new MarkupCompatibilityProcessSettings(
                    MarkupCompatibilityProcessMode.ProcessLoadedPartsOnly,
                    FileFormatVersions.Office2013)
            };

            using (var pptxDoc = PresentationDocument.Open(file, true, openSettings))
            {
                var slides = pptxDoc.PresentationPart.Presentation.SlideIdList;

                int i = 1;
                foreach (var s in slides)
                {
                    Console.WriteLine($"{i++} - {s.OuterXml}");
                    Console.WriteLine("---");
                }

            }
        }
    }
}
