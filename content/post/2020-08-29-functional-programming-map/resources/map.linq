<Query Kind="Statements">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

var celcius = new List<Celcius>() { -40, 0, 100 };

var fahrenheit = map (celcius, convertCtoF);

var kelvin = map<Celcius, Kelvin> (celcius, convertCtoK);

fahrenheit.Dump ("Fahrenheit");

kelvin.Dump ("Kelvin");

var fahrenheitToCelcius = map<Fahrenheit, Celcius> (fahrenheit, convertFtoC);

fahrenheitToCelcius.Dump ("Celcius");

/* mapper functions
  High order of function function which is analogous to Select function of LINQ 

*/
IEnumerable<TResult> map<T, TResult> (IEnumerable<T> values, Func<T, TResult> convertor)
{
foreach (var value in values)
yield return convertor (value);
}

/* Pure functions which maps a single inputs to a new output without mutating them */
Fahrenheit convertCtoF (Celcius value) => value * 1.8 + 32.0;
Kelvin convertCtoK (Celcius value) => value + 273.0;
Celcius convertFtoC (Fahrenheit value) => (value - 32) / 1.8;

public class Temperature
{
  protected double _value;

  protected Temperature () { }

  public Temperature (double value) => this._value = value;

  public double GetValue() => _value;
}

public class Fahrenheit : Temperature
{
  public Fahrenheit (double value) : base (value) { }

  public static implicit operator Fahrenheit (double value) => new Fahrenheit (value);
  public static implicit operator double (Fahrenheit celcius) => celcius.GetValue();

  public override string ToString() => $"{_value:N2}°F";
}

public class Celcius : Temperature
{
  public Celcius (double value) : base (value) { }

  public static implicit operator Celcius (double value) => new Celcius (value);
  public static implicit operator double (Celcius celcius) => celcius.GetValue();

  public override string ToString() => $"{_value:N2}°C";

}

public class Kelvin : Temperature
{
  public Kelvin (double value) : base (value) { }

  public static implicit operator Kelvin (double value) => new Kelvin (value);
  public static implicit operator double (Kelvin celcius) => celcius.GetValue();

  public override string ToString() => $"{_value:N2}°K";
}