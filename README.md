Api test for chubb

El controlador EmpleadosController.cs contiene inyección de dependencias.

Se agregaron para resolver las dependencias en el sección de servicios del sistema de inyección de dependencia en el archivo Startup.cs
La solución se dividió en proyectos para separar el acceso a datos y cumplir con el patrón de diseño de Repositorio.

Se incluhye un LocalDB a la cual debe cambiarse la ruta del connectionString si se desea ejecutar la solución en otro PC.

Se realizae en el archivo appsettings.json del proyecto 'Chubb_Api_Test'
