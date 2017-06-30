using Microsoft.CodeAnalysis;

string ownerPropertyName = "Name";
string ownerPropertySurName = "SurName";
string ownerPropertyAddress = "Address";
string ownerPropertyBirtDate = "BirthDate";

string petPropertyName = "Name";


Output[@"Program.cs"].WriteLine($@"
    using System;
    namespace POLAR.Dna.Demo1
    {{
        public class Program
        {{
            static void Main(string[] args)
            {{
                    Owner o = new Owner();

                    Console.WriteLine(""Owner Info:"");
                    Console.WriteLine($""Nombre: {{o.Name}}"");
                    Console.WriteLine($""Apellidos: {{o.SurName}}"");
                    Console.WriteLine($""Direccion: {{o.Address}}"");
                    Console.WriteLine($""Fecha nacimiento: {{o.BirthDate}}"");

                    Console.WriteLine(""Pulse Intro para finalizar..."");
                    Console.ReadLine();
                }}
        }}
    }}
");

Output[@"Owner.cs"].WriteLine($@"
    using System;
    namespace POLAR.Dna.Demo1
    {{
        public class Owner 
        {{ 
          public string {ownerPropertyName} => ""Juan Luis""; 
          public string {ownerPropertySurName} => ""Guerrero Minero"";
          public string {ownerPropertyAddress} => ""Americo Vespucio, 5"";
          public DateTime {ownerPropertyBirtDate} => DateTime.Now;
        }}
    }}
");

Output[@"Pet.cs"].WriteLine($@"
    // {DateTime.Now}
     using System;
    namespace POLAR.Dna.Demo1
    {{
        public class Pet 
        {{ 
          public string {petPropertyName} {{get; set;}}
        }}
    }}
 ");


