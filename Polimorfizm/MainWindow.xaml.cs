using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Polimorfizm
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, INotifyPropertyChanged
  {


    private SeriesCollection _seriesCollection = new SeriesCollection();
    private string[] _labels;
    private Equasion _equation;
    private Integrator[] _integrators = new Integrator[]
        {
            new IntegratorA(),
            new IntegratorB()
        };

    public Integrator[] Integrators
    {
      get => _integrators; set => _integrators = value;
    }

    public string[] Labels
    {
      get => _labels;
      set
      {
        _labels = value;
        OnPropertyChanged();
      }
    }

    public SeriesCollection SeriesCollection
    {
      get => _seriesCollection;
      set
      {
        _seriesCollection = value;
        OnPropertyChanged();
      }
    }
    public MainWindow()
    {
      InitializeComponent();
      DataContext = this;
      ValueA.Focus();
    }

    void DrawFunction(double x1, double x2, Series series)
    {
      double _value;
      int N = Int32.Parse(ValueN.Text);
      double[] valueArr = new double[N];
      double h = (x2 - x1) / N;
      double[] x = new double[N];
      for (int i = 0; i < N; i++)
      {
        _value = _equation.Value(x1 + i * h);
        x[i] = (x1 + i * h);
        valueArr[i] = _value;
      }
      Labels = x.Select(i => i.ToString()).ToArray();
      series.Values = new ChartValues<double>(valueArr);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      double a = double.Parse(ValueA.Text);
      var integrator = ComboBoxIntegrator.SelectedItem as Integrator;
      if (integrator == null)
      {
        MessageBox.Show("Ne vibran integrator!");
        return;
      }
      var EquationName = ComboBoxEquation.Text;
      if (EquationName == "EquasionA")
      {
        double b = double.Parse(ValueB.Text);
        _equation = new EquasionA(a, b);
      }
      else if (EquationName == "EquasionB")
      {
        _equation = new EquasionB(a);
      }

      double x1 = double.Parse(X1.Text);
      double x2 = double.Parse(X2.Text);
      var serCollection = new SeriesCollection();
      LineSeries series = new LineSeries();
      DrawFunction(x1, x2, series);
      serCollection.Add(series);
      SeriesCollection = serCollection;

      int N = Int32.Parse(ValueN.Text);
      IntegratorResult.Text = integrator.Integrate(x1, x2, _equation, N).ToString();
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName]string prop = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    #endregion
  }
}
