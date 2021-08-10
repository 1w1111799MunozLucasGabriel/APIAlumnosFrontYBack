# APIAlumnosFrontYBack
Front + API con métodos GET, POST, PUT,DELETE en .NET Core 3.1


el proyecto es un  asp.net core webApi con c#. 
Se utilizó una extension para VS-CODE llamada "vscode-solution-explorer", la que nos permite ver de una forma más agradable la estructura de nuestra api; Mediante el plugin "nuget gallery" pudimos instalar algunos paquetes que utilizamos en la API
    * Para poder utilizar "Swagger" se instaló un paquete llamado "Swashbuckle.AspNetCore", que lo encontraremos dentro de nuget gallery, y lo configuramos para su uso dentro de la clase "Startup.cs"
    * La api corre en https porque le generamos un certificado valido mediante el comando "dotnet dev-certs https --trust"
    * Utilizamos el enfoque DataBaseFirst, y mediante el comando "scaffold" obtenemos el mapeo de nuestra base de datos 
    * Comunicamos el front con el back mediante el uso de javascript, las API call las hacemos mediante jQuery $.ajax()

la API funciona conectada a postgreSQL donde tenemos creada una base de datos con una tabla sexo y otra tabla alumnos, dejaré el script para crearla en un archivo .txt para que pueda replicarse y probar en ejecucion. es necesario tener la base de datos creada para el funcionamiento de la api y para cargar el combobox y la lista del FRONTEND

Aquí debajo dejaré el comando que se deberá ejecutar para hacer el scaffold desde la base local. En este caso utilizo mi usuario "prog3" y mi contraseña "123456" que debera modificarse según el nombre que tenga el servidor local donde se replique la base de datos generada

dotnet ef dbcontext scaffold "User ID=prog3; Password=123456; Server=localhost; Database=alumnospr3; Integrated Security=true; Pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models

