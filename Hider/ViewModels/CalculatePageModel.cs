namespace Hider.ViewModels;

public partial class CalculatePageModel : ObservableObject
{
    [ObservableProperty]
     List<string> row1;
    [ObservableProperty]
     List<string> row2;
    [ObservableProperty]
     List<string> row3;
    [ObservableProperty] List<string> row4;

    [ObservableProperty]
    string displayText;

    [ObservableProperty]
    string answer;
    public CalculatePageModel()
    {
        Row1 = new List<string> { "7","4","1","0" };
        Row2 = new List<string> { "8", "5", "2", "." };
        Row3 = new List<string> { "9", "6", "3", "=" };
        Row4 = new List<string> { "Del", "÷", "x", "-" ,"+"};
    }
    [RelayCommand]
    async void ButtonPressed(string arg)
    {
        if (string.IsNullOrEmpty(arg)) return;
        if (arg == "Del")
        {
            if (DisplayText.Length > 0)
                DisplayText = DisplayText.Substring(0, DisplayText.Length - 1); ;
            return;
        }
        if (arg == "=")
        {
            string password = Preferences.Get("Password", null);

            if (DisplayText == password)
                await App.Current.MainPage.Navigation.PushAsync(new FingerprintPage());
            //Calculate 
            else
            {
                try
                {
                    var inputString = NormalizeInputString();
                    var expression = new Expression(inputString);
                    var result = expression.Evaluate();

                    Answer = result.ToString();
                }
                catch
                {
                    Answer = "Syntax Error";
                }
               
            }

        }
        else
        {
            if (!string.IsNullOrEmpty(Answer))
                Answer = "";
            DisplayText += arg;

        }
    }

     string NormalizeInputString()
    {
        Dictionary<string, string> _opMapper = new()
        {
            {"x", "*"},
            {"÷", "/"},
            
        };

        var retString = DisplayText;

        foreach (var key in _opMapper.Keys)
        {
            retString = retString.Replace(key, _opMapper[key]);
        }

        return retString;
    }
}
