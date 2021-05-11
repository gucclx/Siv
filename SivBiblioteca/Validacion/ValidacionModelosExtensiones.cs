using SivBiblioteca.AccesoDatos;
using SivBiblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SivBiblioteca.SqliteConfig;


namespace SivBiblioteca.Validacion
{
    /// <summary>
    /// Provee extensiones para validar los diferentes modelos 
    /// antes de realizar una operacion en la base de datos con estos.
    /// </summary>
    public static class ValidacionModelosExtensiones
    {
        public static void ValidarProducto(this ProductoModelo producto, bool verificarQueNoExista = false)
        {
            if (producto == null)
            {
                throw new ArgumentException("El producto fue null.");
            }

            if (string.IsNullOrEmpty(producto.Nombre))
            {
                throw new ArgumentException(@"El nombre del producto esta vacio o fue null.");
            }

            if (verificarQueNoExista == false) return;

            if (ConfigGlobal.conexion.ProductoExiste(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto ya existe en la base de datos.");
            }
        }

        public static void ValidarCategorias(this List<CategoriaModelo> categorias, bool verificarQueNoExistan = false)
        {
            if (categorias == null)
            {
                throw new ArgumentException("La lista de categorias fue null.");
            }

            foreach (var categoria in categorias)
            {
                if (categoria == null)
                {
                    throw new ArgumentException("Al menos una categoria fue null.");
                }
                if (string.IsNullOrEmpty(categoria.Nombre))
                {
                    throw new ArgumentException("El nombre de la categoria esta vacio o fue null.");
                }

                if (verificarQueNoExistan == false) continue;

                if (ConfigGlobal.conexion.CategoriaExiste(categoria.Nombre))
                {
                    throw new ArgumentException("El nombre de la categoria ya existe en la base de datos.");
                }
            }
        }

        public static void ValidarVentas(this List<VentaModelo> ventas)
        {
            if (ventas == null)
            {
                throw new ArgumentException("La lista de ventas fue null.");
            }

            foreach (var venta in ventas)
            {
                if (venta == null)
                {
                    throw new ArgumentException("Al menos una venta en la lista fue null.");
                }

                if (venta.Lote == null)
                {
                    throw new ArgumentException("El lote de la venta fue null.");
                }

                if (venta.Unidades > ConfigGlobal.conexion.UnidadesDisponiblesLote(venta.Lote.Id))
                {
                    throw new ArgumentException($"El numero de unidades a vender sobrepasa las disponibles en el lote.");
                }

                if (venta.PrecioVentaUnidad > SqliteMoneda.MonedaMaximo)
                {
                    throw new ArgumentException("El precio de venta por unidad es demasiado grande.");
                }
            }
        }

        public static void ValidarCliente(this ClienteModelo cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentException("El cliente fue null.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente esta vacio o fue null.");
            }
        }

        public static void ValidarLote(this LoteModelo lote)
        {
            if (lote == null)
            {
                throw new ArgumentException("El lote fue null.");
            }

            if (lote.Producto == null)
            {
                throw new ArgumentException("El producto del lote fue null.");
            }

            if (lote.Inversion > SqliteMoneda.MonedaMaximo)
            {
                throw new OverflowException("El valor de la inversión del lote es demasiado grande.");
            }

            if (lote.PrecioVentaUnidad > SqliteMoneda.MonedaMaximo)
            {
                throw new ArgumentException("Precio de venta de la unidad demasiado grande.");
            }

            // Cargar unidades disponibles del lote desde la base de datos.
            var unidadesDisponibles = ConfigGlobal.conexion.UnidadesDisponiblesLote(lote.Id);

            if (unidadesDisponibles == null)
            {
                // El lote no existe.
                return;
            }

            // Validar que no se agreguen mas unidades al lote existente.
            // esto es util cuando se valida el lote a la hora de editarlo.
            if (lote.UnidadesDisponibles > unidadesDisponibles)
            {
                throw new ArgumentException($@"Unidades disponibles solicitadas invalidas.
                                                    La cantidad de unidades disponibles solicitada es mayor a la cantidad de unidades disponibles en la base de datos.
                                                    Cantidad solicitada: { lote.UnidadesDisponibles }, cantidad en la base de datos: { unidadesDisponibles }.
                                                    No se permite agregar unidades al lote.");
            }
        }
    }
}
