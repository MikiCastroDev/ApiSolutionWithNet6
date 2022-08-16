# Ejemplo de Api Rest con Net 6

- [Definici�n de proyecto]
	- [Resumen]
	- [Librer�as]
	- [APIs externas]
- [Configuraci�n]
- [Historial de documentaci�n]

# Definici�n de proyecto

## Resumen

El proyecto actual muestra la creci�n de un Api Rest con tecnolog�a NET 6, que implementa un controllador
con las siguientes caracteristicas:

1. El controlador dispondra de dos endpoints.
2. Un primer endpoint encargado de registrar pedidos compuestos por una cabecera y un detalle de pedido.
3. El registro se realizara contra dos bases de datos. Una MySQL y otra MongoDB
4. El primer endpoint recibira un par�metro sandbox que decidira si el registro se realiza contra las bases de datos
	de producci�n o de desarrollo.
5. Se creara un segundo endpoint que recibira por par�metro una ciudad y recuperara la temperatura y humedad de esta
	en el per�odo actual de una API externa perteneciente a WeatherStack.
6. Esta funcionalidad se aprovechara para registrar la humededad en el momento del registro del pedido.

## Librer�as

1. Entity Framework Core 6
2. AutoMapper
3. NewtonSoft
4. MongoDB Driver

## APIs externas

Para la obtenci�n de los datos del tiempo utilizaremos la API de [WeatherStack][url]:https://weatherstack.com/

# Configuraci�n

Dentro del fichero de configuraci�n appsettings.json se incluyen par�metros de configuraci�n vacios por motivos de calidad.
Estos deberan ser cubiertos para el correcto funcionamiento de la aplicaci�n. 

De WeatherStack necesitaremos una cuenta validad para obtener un token para las peticiones, as� como incluir la base de la ruta.
Para las cadenas de conexi�n necesitaremos 2 por base de datos. Para las pruebas del proyecto se utilizar�n las siguiente plataformas
para la obtenci�n de unos entornos v�lidos. Para MySQL se uso la plataforma [PlanetScape][url]:https://planetscale.com/ mientr�s que para
la base de datos MongoDB se uso la plataforma [Atlas][url]:https://www.mongodb.com/cloud/atlas/lp/try2?utm_content=rlsavisitor&utm_source=google&utm_campaign=gs_emea_rlsamulti_search_core_brand_atlas_desktop_rlsa&utm_term=mongodb%20atlas&utm_medium=cpc_paid_search&utm_ad=e&utm_ad_campaign_id=14412646455&adgroup=131761126452

# Historial de documentaci�n

- V1: 15-08-2022, Primera versi�n