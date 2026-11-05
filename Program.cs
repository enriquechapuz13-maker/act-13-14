using System;
/* -------------------------------------------------------------------------
 * INSTITUTO TECNOLÓGICO SUPERIOR DE COMALCALCO
 * Asignatura: Programación Avanzada
 * Semestre y Grupo: 7mo C
 * Alumno: Enrique de la Fuente Chapuz
 * Actividad: #14 Sistema de monitoreo de sensores industriales
 --------------------------------------------------------------------------*/
Console.WriteLine("SISTEMA DE MONITOREO DE SENSORES INDUSTRIALES");
Console.WriteLine();
// 1. SENSOR DE TEMPERATURA
Console.WriteLine("--- REGISTRO: SENSOR DE TEMPERATURA ---");
SensorTemperatura sensorTemp = new SensorTemperatura();
sensorTemp.CapturarDatosBase();
Console.Write("Ingrese el valor de la temperatura (°C): ");
sensorTemp.Valormedio = Convert.ToDouble(Console.ReadLine());
sensorTemp.MostrarDatos();
Console.WriteLine($"Evaluación: {sensorTemp.EvaluarCondicion()}");
Console.WriteLine();
// 2. SENSOR DE PRESIÓN
Console.WriteLine("--- REGISTRO: SENSOR DE PRESIÓN ---");
SensorPresion sensorPres = new SensorPresion();
sensorPres.CapturarDatosBase(); // Reutiliza la captura
Console.Write("Ingrese el valor medio de presión (bar): ");
sensorPres.Valormedio = Convert.ToDouble(Console.ReadLine());
sensorPres.MostrarDatos();
Console.WriteLine($"Evaluación: {sensorPres.EvaluarCondicion()}");
Console.WriteLine();
// 3. SENSOR DE DISTANCIA
Console.WriteLine("--- REGISTRO: SENSOR DE DISTANCIA ---");
SensorDistancia sensorDist = new SensorDistancia();
sensorDist.CapturarDatosBase(); // Reutiliza la captura
Console.Write("Ingrese el valor medio de distancia (cm): ");
sensorDist.Valormedio = Convert.ToDouble(Console.ReadLine());
sensorDist.MostrarDatos();
Console.WriteLine($"Evaluación: {sensorDist.EvaluarCondicion()}");
Console.WriteLine();
// CLASE BASE
class Sensor
{
    public string Identificador { get; set; } = "";
    public double Valormedio { get; set; }
    public bool Activo { get; set; }
    // Método para capturar las propiedades comunes
    public void CapturarDatosBase()
    {
        Console.Write("Ingrese el identificador del sensor: ");
        Identificador = Console.ReadLine() ?? "";

        Console.Write("¿El sensor está activo? (true/false): ");
        Activo = Convert.ToBoolean(Console.ReadLine());
    }
    public string ObtenerEstado()
    {
        if (Activo == true)
            return "Sensor activo / operando";
        else
            return "Sensor inactivo / fuera de servicio";
    }
    public void MostrarDatos()
    {
        Console.WriteLine();
        Console.WriteLine("DATOS DEL SENSOR");
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Valor medio:   {Valormedio}");
        Console.WriteLine($"Estado:        {ObtenerEstado()}");
    }
}
// CLASES DERIVADAS
// Subclase 1: Sensor de Temperatura
class SensorTemperatura : Sensor
{
    // Método propio para evaluar la condición específica (80 °C)
    public string EvaluarCondicion()
    {
        if (Valormedio > 80)
        {
            return "ALERTA: Supera el límite de 80°C. Requiere atención inmediata.";
        }
        else
        {
            return "Temperatura dentro del criterio establecido.";
        }
    }
}
// Subclase 2: Sensor de Presión
class SensorPresion : Sensor
{
    // Método propio para evaluar la condición específica (10 bar)
    public string EvaluarCondicion()
    {
        if (Valormedio > 10)
        {
            return "ALERTA: Supera el límite de 10 bar. Requiere atención inmediata.";
        }
        else
        {
            return "Presión dentro del criterio establecido.";
        }
    }
}
// Subclase 3: Sensor de Distancia
class SensorDistancia : Sensor
{
    // Método propio para evaluar la condición específica (menos de 20 cm)
    public string EvaluarCondicion()
    {
        if (Valormedio < 20)
        {
            return "ALERTA: Objeto a menos de 20 cm. Requiere atención por proximidad.";
        }
        else
        {
            return "Distancia dentro del criterio establecido.";
        }
    }
}