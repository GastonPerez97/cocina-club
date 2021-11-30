# CocinaClub 🍳

_Proyecto creado pensado en la organización de los eventos y la inscripción por parte de los comensales que gustan de la buena comida. Creado para Programación Web III de la Tecnicatura en Desarrollo Web de la UNLaM._

## Comenzando 🚀

_Para poner en marcha el proyecto clonar el repositorio, abrirlo en Visual Studio, restaurar paquetes de Nuget y crear la DB. Ejecutar los proyectos pw3-proyecto y pw3-proyecto.API._

### Pre-requisitos 📋

_Necesitas tener Visual Studio 2019 y SQL Server._


## Respuestas del TP 📝

_**a) ¿Qué nota creen que deberían sacar en el tp? (1-10, donde para 7 debe estar toda la funcionalidad pedida) y por qué.**_

_Creemos que el proyecto cumple con las mejores prácticas, cumple con todas la funcionalidades solicitadas, y tiene un diseño acorde al modelo de negocio. Pensamos que la nota adecuada sería un 9._

_**b) ¿Qué cosas creen que podrían mejorarse?**_

- _Un detalle sería que el precio del evento llegue con decimales a la DB (intentamos pero al momento de llegar al controlador .NET no toma bien el formato decimal), probamos con varios DataAnnotations, modificaciones en las vistas y en los controladores, modificaciones en el campo de la DB y aún así no logramos que tome los decimales del precio._

- _Algunos DataAnnotations están en ingles porque estan seteados dinámicamente en algunas vistas (por ejemplo, cuando se usa min y max en el input), y no encontramos forma de traducirlo._

- _Se intentó finalizar el evento automaticamente despues de 24 horas en la DB y no pude, los triggers funcionan solo cuando se utiliza INSERT, UPDATE o DELETE, y hacerlo con un SELECT es peligroso. Si bien el enunciado no lo pide, implementar la finalización automática de los eventos después de 24 horas sería una interesante regla de negocio para agregar, así los comensales pueden dejar su reseña después de 24 horas y no esperar al cocinero a que finalice el evento manualmente._

_**c) ¿Qué les resultó más complicado?**_

_Nos resulto complicado la creación del evento por las validaciones que lleva, la fecha con un custom DataAnnotation, la carga de imagen que necesita un servicio ad hoc, vincular las recetas elegidas con el evento, etc._


## Construido con 🛠️

_Menciona las herramientas que utilizaste para crear tu proyecto._

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) 
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [SQL Server](https://www.microsoft.com/es-es/sql-server/)
* [Bootstrap 5](https://getbootstrap.com/docs/5.0/getting-started/introduction/)
* [Patrón de diseño MVC](https://es.wikipedia.org/wiki/Modelo%E2%80%93vista%E2%80%93controlador)

## Autores ✒️

* **Gastón Pérez**   - [GastonPerez97](https://github.com/GastonPerez97)
* **Ivan Kek**       - [ivankek](https://github.com/ivankek)
* **Mariano Perri**  - [marianoperri](https://github.com/marianoperri)
