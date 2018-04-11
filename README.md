# Introducción
Nuestro sitio web va a ser un portal de películas basado en IMDB (http://www.imdb.com).

Te recordamos que puedes usar las tecnologías (base de datos, lenguajes de programación y frameworks con los que te sientas más cómodo).

## Recomendaciones
- Te recomendamos que traigas un portatil ya configurado con tu editor preferido, base de datos, etc. La organización de cualquier forma facilitará un portatil, teclado, ratón y una pantalla adicional para la realización de la prueba.En el primer día de la prueba, se dispondrá de un tiempo cercano a una hora (16:00 a 17:00) para que cada usuario pueda configurarse su puesto.

- Cada día se realizará y se evaluará un modulo. Al comienzo del mismo se entregarán sus instrucciones, bocetos y un checklist para su evaluación. Es conveniente leer cuidadosamente todos los items del checklist y seleccionar los más favorables. La prueba está dimensionada para que sea fácil realizar algunos items, pero no la finalización de todos ellos. En función de la arquitectura que se elija para hacer la aplicación hay items que no tiene sentido completar. 

- Utiliza los datos previos que te proporcionamos. No esperes a hacer un trabajo previo al día del examen si puedes ya llevarlo preparado. Lleva así mismo una arquitectura tipo para tu aplicación, con las librerías que utilices, etc..


## Fechas y valoración de las pruebas
**Módulo I: Planificación, material gráfico y diseño web**
17 de Abril de 17:00 a 20:00 horas. 25% de la valoración final
De 16:00 a 17:00 h. Comprobación de herramientas y adaptación al puesto
De 17:00 a 20:00 h. Realizacin de la prueba

## Pasos previos
 - Para realizar la prueba necesitaremos unos datos para su visualización, en este caso será listado de películas en formato json. **Es tarea tuya convertirlo al formato que te resulte conveniente (para importación a base de datos relacional, por ejemplo)**. En la prueba del segundo día se trabajará el acceso a datos y esta conversión de los datos de prueba a la base de datos es un trabajo que puedes hacer ya y así ahorrar un tiempo valioso para la prueba.
 
### Script obtención datos para la prueba
El script de generación del listado y las instrucciones de uso del mismo por si te viene bien modificar algo.
Listado de las mejores películas en imdb. El resultado de la ejecución del script está en el fichero *pelis.json*

Se utiliza python 3. 

Forma de ejecución:
```
pip install -r requirements.txt # instalación de dependencias
python imdb.py # ejecución de script
```

El resultado de la ejecución del script se muestra el fichero *pelis.json*
