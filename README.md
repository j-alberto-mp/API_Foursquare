<h1 align="center">API Foursquare 🗺️</h1>
Desarrollo web en .NET Core, con la integración de la API de Foursquare

- Búsqueda de lugares por categoría
- Guardar un lugar en favoritos
- Consultar los favoritos

## ✨ Crear la base de datos
Editar el archivo `appsettings.json` o  `appsettings.Development.json` para cambiar los datos de la cadena de conexión: servidor, usuario y contraseña.

- Una vez realizados los cambios, abrir la consola de NuGet y cambiar al proyecto de `APIFoursquare.Repository`.
- Ejecutar el comando `add-migration Initial` para crear la primer migración.
- Ejecutar el comando `update-database` para crear la base de datos y las tablas.

Inserts en la base de datos:
```sh
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (10027, 'Museos');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (10056, 'Zoológicos');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (11045, 'Bancos');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (13003, 'Bares');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (13032, 'Cafeterías');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (13065, 'Restaurantes');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (15014, 'Hospitales');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (17145, 'Farmacias');
INSERT INTO dbo.Categorias (Id, Nombre) VALUES (18021, 'Gimnasios');

INSERT INTO dbo.Usuarios ([Nombre]) VALUES ('Usuario pruebas');
```

## 📝 License

Autor: [José Alberto MP](https://github.com/j-alberto-mp).<br />
This project is [GPL-3.0](https://github.com/j-alberto-mp/API_Foursquare/blob/main/LICENSE) licensed.

---
