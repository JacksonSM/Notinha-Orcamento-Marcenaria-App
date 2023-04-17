public class DateTimeFormatConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value is DateTime dateTime)
        {
            // Formatar a data e hora para o formato brasileiro
            string formatoBrasileiro = "dd/MM/yyyy HH:mm:ss";
            return dateTime.ToString(formatoBrasileiro);
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
