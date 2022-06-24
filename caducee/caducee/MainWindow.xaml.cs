using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace caducee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            generate_pdf();
        }

        public void generate_pdf()
        {
            string outFile = Environment.CurrentDirectory + "/caducee.pdf";

            Document doc = new Document(PageSize.A5 ); //...creation du document

            PdfWriter.GetInstance(doc, new FileStream(outFile, FileMode.Create));

            doc.Open(); //...ouverture du document

            string imageUrl = Environment.CurrentDirectory + "/img.png";

            BaseColor blue = new BaseColor(0, 75, 155);
            
            Font policeTitre =  new Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20f, iTextSharp.text.Font.BOLD, blue);

            Paragraph p2 = new Paragraph(prenom.Text + "\n\n");
            p2.Alignment = Element.ALIGN_RIGHT;
            doc.Add(p2);

            Paragraph p3 = new Paragraph(prenom.Text + "\n\n");
            p3.Alignment = Element.ALIGN_CENTER;
            doc.Add(p3);

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageUrl);
            jpg.ScaleToFit(120f, 200f);
            jpg.SpacingBefore = 10f;
            jpg.SpacingAfter = 2f;
            jpg.Alignment = Element.ALIGN_CENTER;
            doc.Add(jpg);
            doc.Close(); //...fermeture du document


            Process.Start(@"cmd.exe ", @outFile);

        }

       
    }
}
