using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer;

public interface IInvestor { void Update(string stockSymbol, decimal price); }

public class Stock {
    private readonly List<IInvestor> _investors = new();
    public string Symbol { get; }
    private decimal _price;

    public Stock(string symbol, decimal price) { Symbol = symbol; _price = price; }
    public void Attach(IInvestor i) => _investors.Add(i);
    public void SetPrice(decimal price) {
        _price = price;
        foreach (var i in _investors) i.Update(Symbol, _price);
    }
}
