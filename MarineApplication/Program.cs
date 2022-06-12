// See https://aka.ms/new-console-template for more information
var builder = MarineUnitBuilder
    .Initialize()
    .SetName("Marina")
    .SetIntendedUse(new UnitIntendedUse(TypeOfUse.MarineLeisure, "Transport", "Cargo"))
    .SetDimensions(new Dimensions(100, 100, 100))
    .SetMechanicalInstallation(new MechanicalInstallation())
    .SetVersatileInstallation(new VersatileInstallation())
    .SetElectricalInstallation(new ElectricalInstallation())
    .SetElectricalInstallation(new ElectricalInstallation())
    .SetElectricalInstallation(new ElectricalInstallation())
    .AndNoMoreElectricalInstallations()
    .SetBrandAndModel("Ford", "Mondeo")
    .Build();

IMarineUnitBuilder oszukanyBuilder = (IMarineUnitBuilder) MarineUnitBuilder
    .Initialize()
    .SetName("Marina");

oszukanyBuilder.Build();

var builderX = MarineUnitBuilder
    .Initialize()
    .SetName("Marina")
    .SetIntendedUse(new UnitIntendedUse(TypeOfUse.MarineLeisure, "Transport", "Cargo"))
    .SetDimensions(new Dimensions(100, 100, 100))
    .SetMechanicalInstallation(new MechanicalInstallation())
    .SetVersatileInstallation(new VersatileInstallation());

var electicalInstallationsToAdd = new List<ElectricalInstallation>
{
    new ElectricalInstallation(),
    new ElectricalInstallation(),
    new ElectricalInstallation(),
    new ElectricalInstallation(),
    new ElectricalInstallation(),
    new ElectricalInstallation(),
    new ElectricalInstallation(),
    new ElectricalInstallation(),
};

foreach (var electricalInstallation in electicalInstallationsToAdd)
{
    builderX.SetElectricalInstallation(electricalInstallation);
}

builderX.AndNoMoreElectricalInstallations();



public class MarineUnitBuilder : 
    INameSetter, 
    IIntendedUseSetter, 
    IDimensionsSetter,
    IMechanicalInstallationSetter, 
    IVersatileInstallationSetter,
    IElectricalInstallationSetter,
    IBrandAndModelSetter,
    IMarineUnitBuilder
{
    private readonly MarineUnit _unit = new();

    private readonly List<ElectricalInstallation> _electricalInstallations = new();

    public static INameSetter Initialize() => new MarineUnitBuilder();

    public IIntendedUseSetter SetName(string name)
    {
        _unit.UnitName = name;
        return this;
    }

    public IDimensionsSetter SetIntendedUse(UnitIntendedUse unitIntendedUse)
    {
        _unit.UnitIntendedUse = unitIntendedUse;
        return this;
    }

    public IMechanicalInstallationSetter SetDimensions(Dimensions dimensions)
    {
        _unit.Dimensions = dimensions;
        return this;
    }

    public IVersatileInstallationSetter SetMechanicalInstallation(MechanicalInstallation mechanicalInstallation)
    {
        _unit.MechanicalInstallation = mechanicalInstallation;
        return this;
    }
    public IElectricalInstallationSetter SetVersatileInstallation(VersatileInstallation versatileInstallation)
    {
        _unit.VersatileInstallation = versatileInstallation;
        return this;
    }

    public IElectricalInstallationSetter SetElectricalInstallation(ElectricalInstallation electricalInstallation)
    {
        _electricalInstallations.Add(electricalInstallation);
        return this;
    }

    public IBrandAndModelSetter AndNoMoreElectricalInstallations()
    {
        _unit.ElectricalInstallation = _electricalInstallations.ToArray();
        return this;
    }

    public IMarineUnitBuilder SetBrandAndModel(string brand, string model)
    {
        _unit.Brand = brand;
        _unit.Model = model;
        return this;
    }

    public MarineUnit Build() => _unit;
}

public interface INameSetter
{
    IIntendedUseSetter SetName(string name);
}

public interface IIntendedUseSetter
{
    IDimensionsSetter SetIntendedUse(UnitIntendedUse unitIntendedUse);
}

public interface IDimensionsSetter
{
    IMechanicalInstallationSetter SetDimensions(Dimensions dimensions);
}

public interface IMechanicalInstallationSetter
{
    IVersatileInstallationSetter SetMechanicalInstallation(MechanicalInstallation mechanicalInstallation);
}

public interface IVersatileInstallationSetter
{
    IElectricalInstallationSetter SetVersatileInstallation(VersatileInstallation versatileInstallation);
}

public interface IElectricalInstallationSetter
{
    IElectricalInstallationSetter SetElectricalInstallation(ElectricalInstallation electricalInstallation);
    IBrandAndModelSetter AndNoMoreElectricalInstallations();
}

public interface IBrandAndModelSetter
{
    IMarineUnitBuilder SetBrandAndModel(string brand, string model);
}

public interface IMarineUnitBuilder
{
    MarineUnit Build();
}
public class MarineUnit
{
    internal MarineUnit() { }

    public string UnitName { get; internal set; }

    public UnitIntendedUse UnitIntendedUse { get; internal set; }

    public Dimensions Dimensions { get; internal set; }

    public MechanicalInstallation MechanicalInstallation { get; internal set; }

    public VersatileInstallation VersatileInstallation { get; internal set; }

    public ElectricalInstallation[] ElectricalInstallation { get; internal set; }

    public string Brand { get; internal set; }

    public string Model { get; internal set; }

    //Other methods...
}

public class UnitIntendedUse
{
    public UnitIntendedUse(TypeOfUse typeOfUse, string lineOfBusiness, string unitPurpose)
    {
        TypeOfUse = typeOfUse;
        LineOfBusiness = lineOfBusiness;
        UnitPurpose = unitPurpose;
    }

    public TypeOfUse TypeOfUse { get; internal set; }
    public string LineOfBusiness { get; internal set; }
    public string UnitPurpose { get; internal set; }
}

public enum TypeOfUse
{
    MarineCommercial,
    MarineLeisure
}

public struct Dimensions
{
    public Dimensions(int length, int width, int weight)
    {
        Length = length;
        Width = width;
        Weight = weight;
    }
    public int Length { get; internal set; }
    public int Width { get; internal set; }
    public int Weight { get; internal set; }
}

public class MechanicalInstallation : Installation { }

public class ElectricalInstallation : Installation { }

public class VersatileInstallation : Installation { }

public abstract class Installation
{
    public IList<Driveline> Drivelines { get; internal set; }
}

public class Driveline
{
    public Engine Engine { get; set; }
}

public class Engine { }