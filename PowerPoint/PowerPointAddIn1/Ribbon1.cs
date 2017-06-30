using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace PowerPointAddIn1
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {

            PowerPoint.Application app =
                Globals.ThisAddIn.Application;

            PowerPoint.Presentation presentation = app.ActivePresentation;

            int slideCount = app.ActivePresentation.Slides.Count;
            PowerPoint.Slide slide = (PowerPoint.Slide)app.ActiveWindow.View.Slide;
            int slideIndex = slide.SlideIndex;

            PowerPoint.View view = app.ActiveWindow.View;


            foreach (var shape in slide.Shapes)
            {
                
                
            }

        }
    }
}
