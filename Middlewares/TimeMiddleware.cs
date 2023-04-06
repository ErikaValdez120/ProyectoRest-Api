public class TimeMiddleware
{

  readonly RequestDelegate next;

  public TimeMiddleware(RequestDelegate nextRequest)
  {
      next= nextRequest;
  }

  public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
  {
      await next(context);

      if(context.Request.Query.Any(p => p.Key == "time"))
      {
        await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
      }

  }

 
}

 public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<TimeMiddleware>();
    }
}

/*
-------------------Explicacion del codigo linea por linea-----------------------------------
El código anterior muestra un middleware para una aplicación ASP.NET Core. 
El middleware se encarga de cerrar la solicitud si se encuentra una consulta de "tiempo" en 
la solicitud HTTP. A continuación, se detalla línea por línea qué significa cada sección del 
código:

La primera línea indica que esta clase es pública y se llama TimeMiddleware.
La segunda línea define una variable de solo lectura llamada "next" de tipo RequestDelegate. La variable "next" se utiliza para invocar el siguiente middleware en la cadena.
El constructor de la clase tiene un parámetro de entrada del tipo RequestDelegate que también se llama nextRequest. El valor de nextRequest se asigna a la propiedad "next".
La tercera línea define un método async llamado Invoke. Este es el método principal del middleware. Recibe el objeto HttpContext.
La línea "await next(context);" llama al siguiente middleware en la cadena.
La línea "if(context.Request.Query.Any(p => p.Key == "time"))" comprueba si hay una consulta de "tiempo" en la solicitud HTTP.
Si la consulta de "tiempo" está presente en la solicitud, la línea siguiente llama al método WriteAsync para escribir la fecha y hora actual en el contexto.
La clase TimeMiddlewareExtension define una extensión que permite agregar este middleware al pipeline de ASP.NET Core. Este método es estático y se llama UseTimeMiddleware.
El método UseTimeMiddleware acepta un objeto IApplicationBuilder y luego llama al método UseMiddleware con la clase TimeMiddleware como parámetro.

-----------------------------------------Middleware--------------------------------------------

Un middleware en C# es una herramienta que permite gestionar los datos que pasan por una 
aplicación, proporcionando una capa de abstracción y flexibilidad entre el servidor y las 
solicitudes del cliente. Esencialmente, el middleware actúa como un intermediario entre los 
componentes de software, permitiendo que el proceso de comunicación se realice de manera más 
eficiente.

Usualmente, el middleware en C# se utiliza para añadir funcionalidades y características a 
una aplicación, tales como la autenticación, la compresión de datos, la validación de clientes,
el enrutamiento, el almacenamiento en caché, etc.

El middleware en C# se puede implementar mediante la creación de clases o componentes que 
interceptan las solicitudes y respuestas HTTP, procesan los datos y luego los pasan al 
siguiente middleware o componente de la aplicación. Además, se pueden crear middleware 
personalizados con Visual Studio y .NET Core, utilizando lenguajes como C# o F#, para añadir
funcionalidades adicionales a la aplicación.

---------------------------------------Invoke---------------------------------------------------

Invoke es el método principal en middleware porque es el método que se encarga de procesar y
responder a las solicitudes entrantes. Cuando se recibe una solicitud, el middleware llama 
al método Invoke para procesar la solicitud y enviar una respuesta de vuelta al cliente. 
Además, el método Invoke proporciona una interfaz común para todos los middleware, lo que 
hace que sea fácil agregar, quitar o cambiar el orden de los middleware en la tubería de 
procesamiento. Esto permite una mayor flexibilidad y modularidad en la construcción de 
aplicaciones de middleware y aumenta la reutilización del código y los componentes.

---------------------------------------Swagger--------------------------------------------

Swagger en C# es una herramienta de documentación automática de APIs que permite a los 
desarrolladores de software documentar y probar sus APIs fácilmente. Con Swagger, los 
desarrolladores pueden describir la estructura de su API en un archivo YAML o JSON y luego 
utilizarlo para generar automáticamente un conjunto de documentación legible y fácil de usar, 
así como herramientas para probar la API. Swagger también permite a los desarrolladores crear 
definiciones de modelo que describen los objetos que se utilizan en su API, lo que facilita la
comprensión de la estructura de datos para cualquier persona que utilice la API.



*/




