# 🍳 CocinaClub

[http://www.cocinaclub.somee.com/](http://www.cocinaclub.somee.com/)

***Aplicación Web que permite a cocineros registrados crear eventos culinarios, exponiendo sus propias recetas para que sean evaluadas por comensales.***

***Cada evento ofrece diferentes recetas para que los comensales elijan qué comer.***

***Los comensales podrán realizar las reservas y elegir una de las recetas del evento. Además, tendrán la oportunidad de comentar y evaluar los eventos ya finalizados.***

![www cocinaclub somee com_ (1)](https://user-images.githubusercontent.com/58083159/145864945-f6daf16e-8cce-474d-ac0e-565fb95bbaa6.jpg)

# 🛠️ Tecnologías utilizadas:

- .NET 5
- Entity Framework Core 5
- C#
- SQL Server
- Bootstrap 5
- Patrón de diseño MVC

# ⚙️ Detalles técnicos:

- Se utiliza una base de datos SQL Server para almacenar los datos.
- La capa de acceso a datos fue realizada con Entity Framework Core 5.
- La capa Web fue realizada utilizando el patrón de diseño MVC.
- Las validaciones se dan tanto del lado del cliente como del servidor.
- Se utilizan sesiones para el inicio de sesión de los usuarios.
- Se utiliza BCrypt para el hashing de contraseñas de los usuarios.
- La funcionalidad Cancelar Evento se realiza mediante una llamada AJAX a un servicio web desarrollado con ASP.NET Core Web API.
- Todos los errores no capturados redirigen a una vista de error con el fin de no mostrar al usuario detalles de código.
- Al ingresar una URL inválida la aplicación redirige a una vista de 404.

# ✅ Funcionalidades:

## ✔️ Generales:

- Registro e inicio de sesión de cocineros y comensales.
- Autorización según perfil de usuario en toda la aplicación.
- Cualquier usuario puede visualizar los detalles de un evento con sus reseñas, puntajes, y puntuación promedio.

## 👨‍🍳 Cocinero:

- **Crear recetas de cocina:** El cocinero puede crear recetas de cocina que son las que ofrecerá en los eventos.
- **Crear eventos de comida:** El cocinero creará eventos en donde cocinará algunas de las recetas que ya tiene vinculadas en su perfil dentro del sistema. En los eventos, los cocineros harán una o varias de sus recetas para una cantidad de comensales definida por él.
- **Cancelar eventos:** El cocinero podrá cancelar eventos pendientes con 1 día o más de antelación.
- **Finalizar eventos:** El cocinero podrá finalizar un evento una vez haya pasado la fecha del mismo.
- **Ver su perfil con sus eventos y recetas:** El cocinero dentro de su perfil podrá ver la fecha de registración, su E-Mail y la cantidad de recetas y eventos creados. Además, podrá ver el listado de sus recetas y eventos.

![www cocinaclub somee com_cocineros_perfil](https://user-images.githubusercontent.com/58083159/145865062-359804c4-c4dc-4e25-875a-e9f6819313b1.jpg)

## 🧑 Comensal:

- **Reservar evento:** Los comensales podrán reservar su asistencia a un evento, elegiendo una de las recetas del mismo y anotando la cantidad de comensales que asistirán.
- **Ver sus reservas:** El comensal podrá ver el listado de todas las reservas que tiene asociadas (pendientes,
canceladas y finalizadas).
- **Puntuar y opinar eventos finalizados asistidos:** El comensal tiene la opción de agregar un comentario y una puntuación (de 1 a 5 estrellas) a los eventos finalizados que haya asistido.

![www cocinaclub somee com_comensales_reservas (1)](https://user-images.githubusercontent.com/58083159/145865079-deaf1598-133e-488d-b276-15eca42c2d62.jpg)
