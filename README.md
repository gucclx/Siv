# Bubblegum

Bubblegum es un programa que permite registrar la adquisición y venta de productos por lotes.

## Bubblegum permite crear:

* Productos.
* Categorías para los productos.
* Clientes.

## Bubblegum permite:

* Agregar lotes de productos al inventario.
* Vender unidades de productos.
* Mantener un registro de los clientes.

## Bubblegum genera y presenta:

* Una tabla de las adquisiciones de los lotes con información pertinente.
* Una tabla de las ventas de las unidades de los productos con información pertinente.
* Una tabla de los productos en el inventario con pertinente con información pertinente.

## Bubblegum y filtros

Bubblegum permite filtrar las tablas generadas a traves de parametros como tipo de producto,
fechas, clientes o categorías.

## Bubblegum permite exportar:

* Datos de las tablas generadas a archivos .CSV.
* Historial de adquisición de lotes.
* Historial de ventas.
* Información del inventario.

## Bubblegum permite editar:

* Productos.
* Lotes.
* Clientes.

## Bubblegum permite eliminar:
* Ventas.
* Categorias.

## Funcionalidad: Inventario y ventas

Bubblegum permite almacenar en el inventario cualquier tipo de producto que pueda ser parte de un lote.
Un lote es un conjunto de unidades, que son de un unico tipo de producto.

Una vez se agregan las unidades al inventario, Bubblegum presenta al usuario con un id único para ese lote.
Se tiene la intención de que este id se utilice para indentificar físicamente a todos los productos de dicho lote.

A la hora de vender, el id del lote es ingresado, junto con la cantidad de unidades que se desean vender.


## Acerca de las listas generadas:

Bubblegum limita el numero de filas en las tablas presentadas al usuario.
El limite es 1000 filas. Si el usuario desea acceder a un mayor numero de filas,
este puede exportar los datos a traves del apartado 'exportar'.

# Link de descarga

[Haga click aquí](https://github.com/gucclx/Siv/raw/master/publish/setup.exe)
