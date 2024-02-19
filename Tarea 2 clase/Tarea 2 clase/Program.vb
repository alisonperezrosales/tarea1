Imports System
Imports System.IO

Module Module1
    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim nombre, imc2 As String
        Dim peso, altura, imc As Double
        Do
            Try
                Console.Clear()
                Console.WriteLine("Menú de opciones:")
                Console.WriteLine("1.Calular IMC")
                Console.WriteLine("2.Ver historial")
                Console.WriteLine("3.Borrar historial")
                Console.WriteLine("4.Salir")
                Console.WriteLine("Seleccione una opción")
                opcion2 = Console.ReadKey()
                opcion = opcion2.KeyChar
                Console.Clear()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Select Case opcion
                Case "1"
                    Try
                        Console.Clear()
                        Console.WriteLine("Ingrese nombre")
                        nombre = Console.ReadLine()
                        Console.WriteLine("Ingrese peso (Kg)")
                        peso = Double.Parse(Console.ReadLine())
                        Console.WriteLine("Ingrese altura")
                        altura = Double.Parse(Console.ReadLine())
                        Console.Clear()
                        imc = peso / (altura * altura)
                        Dim resultado As String = If(imc <= 18.5, "Bajo peso",
                                             If(imc <= 24.9, "Peso normal",
                                              If(imc <= 29.9, "Sobrepeso",
                                               If(imc <= 34.9, "Obseidad grado I",
                                                If(imc <= 39.9, "Obesidad grado II", "Obesidad grado III (Obesidad morbida)")))))
                        imc2 = imc.ToString("F4")
                        Console.WriteLine("Su IMC es:" & imc2 & "" & resultado)
                        Dim historial As StreamWriter
                        historial = File.AppendText("historial_imc.txt")
                        historial.WriteLine(nombre & "," & peso & "," & altura & "," & imc2 & "," & resultado)
                        historial.Close()
                        Console.WriteLine("Resultados guardados en historial")
                    Catch ex As DivideByZeroException
                        Console.WriteLine("La altura no puede ser 0")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "2"
                    Console.Clear()
                    Try
                        Dim historial As StreamReader
                        historial = File.OpenText("historial_imc.txt")
                        Console.WriteLine("Nombre, Peso, Altural, IMC, Resultado")
                        Do Until historial.EndOfStream
                            Console.WriteLine(historial.ReadLine())
                        Loop
                        historial.Close()
                    Catch ex As FileNotFoundException
                        Console.WriteLine("El archivo de historial no existe")
                    End Try
                    Console.WriteLine("")
                    Console.WriteLine("Presione cualquier tecla")
                    Console.ReadKey()
                Case "3"
                    Dim historial As String = "historial_imc.txt"
                    File.Delete(historial)
                    Console.WriteLine("Borrar historial")
                    Console.ReadKey()
                Case "4"
                    Console.Clear()
                    Console.WriteLine("Hasta pronto.")
                    Exit Do
                    Console.ReadKey()
                Case Else
                    Console.WriteLine("Opicon no valida")
            End Select
        Loop

    End Sub
End Module
