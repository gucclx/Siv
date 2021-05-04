﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class VentaModelo
    {
        LoteModelo lote;
        uint unidades;
        decimal precioVentaUnidad;

        public int Id { get; set; }
        public string Fecha { get; set; }

        /// <summary>
        /// Se situa la propiedad loteId por simplicidad a la hora de presentar
        /// la propiedad en un datagridview.
        /// ej. solo se necesita realizar venta.lote = miLote;
        /// en vez de venta.lote = miLote; venta.loteId = miLote.Id;
        /// ya que el DataPropertyName de la columna en el datagridview
        /// sera VentaModelo.LoteId y datagridview no soporta propiedades hijas.
        /// </summary>
        public LoteModelo Lote 
        { 
            get { return lote; } 
            set 
            {
                lote = value ?? throw new ArgumentException("El lote de la venta no puede ser null."); 
                LoteId = value.Id; 
            } 
        }
        public int LoteId { get; set; }
        public string ProductoDescripcion => Lote.Producto.Descripcion;
        public string ProductoNombre => Lote.Producto.Nombre;
        public uint Unidades
        {
            get => unidades;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Las cantidad de unidades de la venta no puede ser menor a 1.");
                }
                unidades = value;
            }
        }

        public decimal PrecioVentaUnidad
        {
            get => precioVentaUnidad;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El precio de venta de la unidad no debe ser negativo.");
                }
                precioVentaUnidad = value;
            }
        }
        public decimal Total => PrecioVentaUnidad * Unidades;
        public ClienteModelo Cliente { get; set; }
    }
}
