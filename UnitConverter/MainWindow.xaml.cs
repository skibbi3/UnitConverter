using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Creating the conversion table
        Dictionary<string, double> lengthConversionTable = new Dictionary<string, double>();
        Dictionary<string, double> areaConversionTable = new Dictionary<string, double>();
        Dictionary<string, double> volumeConversionTable = new Dictionary<string, double>();


        public MainWindow()
        {
            InitializeComponent();

            /*
             * The conversion table works by providing the unit of measure as the key and a float value.
             * The value represents how many metres in 1 of that unit of measure.
             * All conversions will use metres as an intermediary.
             */

            // Length conversion table - value represents how many of the key is in a metre
            lengthConversionTable.Add("Kilometres (km)", 0.001);
            lengthConversionTable.Add("Metres (m)", 1);
            lengthConversionTable.Add("Centimetres (cm)", 100);
            lengthConversionTable.Add("Milimetres (mm)", 1000);
            lengthConversionTable.Add("Miles (mi)", 0.00062137119);
            lengthConversionTable.Add("Yards (yd)", 1.093613298);
            lengthConversionTable.Add("Feet (ft)", 3.280839895);
            lengthConversionTable.Add("Inches (in)", 39.37007874);

            // Area conversion table - value represents how many of the key is in a sq metre
            areaConversionTable.Add("Sq Kilometres (km²)", 0.000001);
            areaConversionTable.Add("Hectares (ha)", 0.0001);
            areaConversionTable.Add("Sq Metres (m²)", 1);
            areaConversionTable.Add("Sq Centimetres (cm²)", 10000);
            areaConversionTable.Add("Sq Milimetres (mm²)", 1000000);
            areaConversionTable.Add("Sq Miles (mi²)", 3.861 * Math.Pow(10,-7));
            areaConversionTable.Add("Acre (ac)", 0.000247105);
            areaConversionTable.Add("Sq Yards (yd²)", 1.19599);
            areaConversionTable.Add("Sq Feet (ft²)", 10.7639);
            areaConversionTable.Add("Sq Inches (in² )", 1550);

            // Volume conversion table - value represents how many of the key is in a Litre 
            volumeConversionTable.Add("Cubic Metres (m³)", 0.001);
            volumeConversionTable.Add("Litres (L)", 1);
            volumeConversionTable.Add("Mililitres (mL)", 1000);
            volumeConversionTable.Add("Imperial Gallons (gal)", 0.219969);
            volumeConversionTable.Add("Imperial Pints (pt)", 1.76056);
            volumeConversionTable.Add("Cubic inches (in³)", 61.0237);
        }

        private void Length_Button_Click(object sender, RoutedEventArgs e)
        {
            // Deal with exception handling for invalid inputs later
            double inputValue = Convert.ToDouble(lengthInput.Text);
            
            string inputUnitOfMeasure = FromLength.SelectedValue.ToString().Substring(37);
            double toMetreConversion = lengthConversionTable[inputUnitOfMeasure];

            string outputUnitOfMeasure = ToLength.SelectedValue.ToString().Substring(37);
            double fromMetreConversion = lengthConversionTable[outputUnitOfMeasure];

            // Converting the input unit of measure into metres. 
            double valueInMetres = inputValue / toMetreConversion;
            double outputUnitValue = valueInMetres * fromMetreConversion;

            // Changing label text
            lengthOutputTextBlock.Text = inputValue.ToString() + " " + inputUnitOfMeasure + " = " + outputUnitValue.ToString() + " " + outputUnitOfMeasure ;
           
        }

        private void Area_Button_Click(object sender, RoutedEventArgs e)
        {
            // Deal with exception handling for invalid inputs later
            double inputValue = Convert.ToDouble(areaInput.Text);

            string inputUnitOfMeasure = FromArea.SelectedValue.ToString().Substring(37);
            double toMetre2Conversion = areaConversionTable[inputUnitOfMeasure];

            string outputUnitOfMeasure = ToArea.SelectedValue.ToString().Substring(37);
            double fromMetre2Conversion = areaConversionTable[outputUnitOfMeasure];

            // Converting the input unit of measure into metres. 
            double valueInMetres = inputValue / toMetre2Conversion;
            double outputUnitValue = valueInMetres * fromMetre2Conversion;

            // Changing label text
            areaOutputTextBlock.Text = inputValue.ToString() + " " + inputUnitOfMeasure + " = " + outputUnitValue.ToString() + " " + outputUnitOfMeasure;
        }

        private void Volume_Button_Click(object sender, RoutedEventArgs e)
        {
            // Deal with exception handling for invalid inputs later
            double inputValue = Convert.ToDouble(volumeInput.Text);

            string inputUnitOfMeasure = FromVolume.SelectedValue.ToString().Substring(37);
            double toMetre3Conversion = volumeConversionTable[inputUnitOfMeasure]; 

            string outputUnitOfMeasure = ToVolume.SelectedValue.ToString().Substring(37);
            double fromMetre3Conversion = volumeConversionTable[outputUnitOfMeasure];

            // Converting the input unit of measure into metres. 
            double valueInMetres = inputValue / toMetre3Conversion;
            double outputUnitValue = valueInMetres * fromMetre3Conversion;

            // Changing label text
            volumeOutputTextBlock.Text = inputValue.ToString() + " " + inputUnitOfMeasure + " = " + outputUnitValue.ToString() + " " + outputUnitOfMeasure;
        }
    }
}
