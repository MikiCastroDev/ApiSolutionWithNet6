# Ejemplo de Api Rest con Net 6

- [Definición de proyecto]
	- [Resumen]
	- [Librerías]
	- [APIs externas]
- [Configuración]
- [Historial de documentación]

# Definición de proyecto

## Resumen

El proyecto actual muestra la creción de un Api Rest con tecnología NET 6, que implementa un controllador
con las siguientes caracteristicas:

1. El controlador dispondra de dos endpoints.
2. Un primer endpoint encargado de registrar pedidos compuestos por una cabecera y un detalle de pedido.
3. El registro se realizara contra dos bases de datos. Una MySQL y otra MongoDB
4. El primer endpoint recibira un parámetro sandbox que decidira si el registro se realiza contra las bases de datos
	de producción o de desarrollo.
5. Se creara un segundo endpoint que recibira por parámetro una ciudad y recuperara la temperatura y humedad de esta
	en el período actual de una API externa perteneciente a WeatherStack.
6. Esta funcionalidad se aprovechara para registrar la humededad en el momento del registro del pedido.

## Librerías

1. Entity Framework Core 6
2. AutoMapper
3. NewtonSoft
4. MongoDB Driver

## APIs externas

Para la obtención de los datos del tiempo utilizaremos la API de [WeatherStack][url]:https://weatherstack.com/

# Configuración

Dentro del fichero de configuración appsettings.json se incluyen parámetros de configuración vacios por motivos de calidad.
Estos deberan ser cubiertos para el correcto funcionamiento de la aplicación. 

De WeatherStack necesitaremos una cuenta validad para obtener un token para las peticiones, así como incluir la base de la ruta.
Para las cadenas de conexión necesitaremos 2 por base de datos. Para las pruebas del proyecto se utilizarón las siguiente plataformas
para la obtención de unos entornos válidos. Para MySQL se uso la plataforma [PlanetScape][url]:https://planetscale.com/ mientrás que para
la base de datos MongoDB se uso la plataforma [Atlas][url]:https://www.mongodb.com/cloud/atlas/lp/try2?utm_content=rlsavisitor&utm_source=google&utm_campaign=gs_emea_rlsamulti_search_core_brand_atlas_desktop_rlsa&utm_term=mongodb%20atlas&utm_medium=cpc_paid_search&utm_ad=e&utm_ad_campaign_id=14412646455&adgroup=131761126452

# Historial de documentación

- V1: 15-08-2022, Primera versión