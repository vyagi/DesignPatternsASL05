// See https://aka.ms/new-console-template for more information

using AdapterPattern;

Console.WriteLine("Hello, World!");

var detectorMercury = new Detector(new MercuryThermometer());

Console.WriteLine(detectorMercury.Detect());

var detectorInternet = new Detector(new InternetThermometerAdapter(new InternetThermometer()));

Console.WriteLine(detectorInternet.Detect());


