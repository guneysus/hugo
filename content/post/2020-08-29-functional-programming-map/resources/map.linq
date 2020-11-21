<Query Kind="Statements">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

var celciusValues = new List<Celcius>() { -40, 0, 100 };

var celciusToFahrenheitValues = map (celciusValues, convertCtoF);

var celciusToKelvinValues = map<Celcius, Kelvin> (new List<Celcius>() { -273, 0, 100 }, value => value + 273.0);

celciusToFahrenheitValues.Dump ("Fahrenheit");

celciusToKelvinValues.Dump ("Kelvin");

var fahrenheitToCelciusValues = map<Fahrenheit, Celcius> (celciusToFahrenheitValues, value => (value - 32) / 1.8);

fahrenheitToCelciusValues.Dump ("Celcius");


IEnumerable<TResult> map<T, TResult> (IEnumerable<T> values, Func<T, TResult> convertor)
{
  foreach (var value in values)
    yield return convertor (value);
}

Fahrenheit convertCtoF (Celcius value) => value * 1.8 + 32.0;

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