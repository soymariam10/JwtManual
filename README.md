# 🚀 JWT Manual 🫧 C# .NetCore 🚦

¡Bienvenido/a al Proyecto de Creación Manual de JWT en .NET Core con C#! 🚀

## 🧩 Descripción

Este proyecto tiene como objetivo proporcionar un guía paso a paso para la creación manual de JSON Web Tokens (JWT) en un entorno .NET Core utilizando el lenguaje C#. A lo largo de este README, aprenderás desde la creación de un nuevo proyecto hasta la implementación de JWT de forma manual.


## 🎯 Objetivo

El enfoque principal de este readme es permitir a los interesados comprender el proceso detallado de generación de JWT en .NET Core, comprendiendo cada paso y componente involucrado en el proceso.

## 📋 Contenido Destacado

### [Configuración del Proyecto:] (##BLOQUE #1 Configuración del Proyecto: )
Inicia con la creación de un nuevo proyecto en .NET Core y la instalación de las dependencias necesarias.

### Configuración del Entorno: 
Aprende a configurar el entorno de desarrollo para garantizar una implementación suave.

### Generación de JWT: 
Sumérgete en la creación manual de JSON Web Tokens, comprendiendo los elementos esenciales y la estructura.

### Implementación: 
Descubre cómo integrar los JWT generados en tu aplicación .NET Core.

## Estructura del Proyecto Cuatro Capas
Estas son las carpertas de configuracion las cuales vamos a utilizar para nuestros proyectos

 - #### En Dominio
   📂 Aqui se crean las tablas que representan la BD y van a estar ubicadas las carpetas de Entidades e Interfaces.

 - #### En Persistencia  
    📂 Aqui se crea la instancia de conexion a la BD y van a estar ubicadas las carpetas de Data, Configuracion y Migraciones.

 - #### En Aplicacion  
    📂 Aqui se crea la inyeccion de dependecia para la comunicacion con el WebApi y van a estar ubicadas las carpetas de Unidad de trabajo y Repositorios.
        
 - #### En WebApi  
    📂 Aqui se crean clases encargadas de recibir peticiones de los clientes y van a estar ubicadas las carpetas de Controladores y Extenciones.



## BLOQUE #1 Configuración del Entorno: 
Generar la solucion del proyecto (desde la terminal)

```bash
dotnet new sln
```
Crear las carpetas necesarias para la solucion del proyecto, en este caso el proyecto es de cuatro capas
```bash
dotnet new classlib -o Domain
```
```bash
dotnet new classlib -o Persistence
```
```bash
dotnet new classlib -o Aplication
```
```bash
dotnet new webapi -o Api
```
Agregar los proyectos a la solucion
```bash
dotnet sln add ./Domain/
```
```bash
dotnet sln add ./Persistence/
```
```bash
dotnet sln add ./Aplication/
```
```bash
dotnet sln add ./Api/
```
Establecer referencias entre proyectos

<img src="/Img/Relaciones.png" alt="Relaciones" style="width: 3000px;">

✨ Desde la carpeta Aplication
```bash
dotnet add reference ../Domain/
```
```bash
dotnet add reference ../Persistence/
```
✨ Desde la carpeta Persistence
```bash
dotnet add reference ../Domain/
```
✨ Desde la carpeta Api
```bash
dotnet add reference ../Aplication/
```
### Instalacion de paquetes

En esta ocasion lo vamos a hacer desde el gestor de paquetes Nuget
(Ctrl + shift + p)

Dentro de la carpeta Api
<img src="/Img/api.png" alt="Relaciones" style="width: 3000px;">
Dentro de la carpeta Domain
<img src="/Img/Domain.png" alt="Relaciones" style="width: 3000px;">
Dentro de la carpeta Persistence
<img src="/Img/Persistencia.png" alt="Relaciones" style="width: 3000px;">



### ⚓ Conexion Base de Datos
Configuracion de la cadena de conexion.

### IMAGEN DE APPSETTINGS.JSON

Creacion del DbContext (esta es una capa de abstraccion que permite la interaccion con la base de datos)

inyectar el DbContext proyecto Api > Program.cs

```c#
builder.Services.AddDbContext<JwtManualContext>(options =>
{
    string ? connectionString = builder.Configuration.GetConnectionString("ConexMysql");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
```


