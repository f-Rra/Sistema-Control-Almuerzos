# Instrucciones para modificar ucEmpleados.Designer.cs

## Patrón a aplicar (basado en gbxServicios/gbxUltimo de frmPrincipal)

### Estructura actual:
```
gbListaEmpleados (ThunderGroupBox)
├── dgvEmpleados
├── txtBuscarEmpleado
├── cbFiltroEmpresa
├── btnNuevoEmpleado
└── otros controles
```

### Estructura objetivo (como gbxServicios):
```
gbListaEmpleados (ThunderGroupBox)
└── pnlListaEmpleados (Panel #232221, BorderStyle.FixedSingle)
    ├── lblTituloLista (Label "Lista de Empleados")
    ├── txtBuscarEmpleado
    ├── cbFiltroEmpresa
    ├── btnNuevoEmpleado
    ├── lblBuscar, label1, lblTotalEmpleados
    └── pnlListaEmpleadosI (Panel #32373A, BorderStyle.FixedSingle)
        └── dgvEmpleados

gbEmpleadoDetalle (ThunderGroupBox)
└── pnlEmpleadoDetalle (Panel #232221, BorderStyle.FixedSingle)
    ├── lblTituloDetalle (Label "Detalle del Empleado")
    └── pnlEmpleadoDetalleI (Panel #32373A, BorderStyle.FixedSingle)
        └── todos los controles del formulario
```

## Pasos en Visual Studio Designer:

1. **Abrir ucEmpleados en modo Designer**

2. **Para gbListaEmpleados:**
   - Agregar Panel "pnlListaEmpleados"
     - BackColor: 35, 34, 33
     - BorderStyle: FixedSingle
     - Dock: Fill o ajustar tamaño manualmente
   
   - Dentro de pnlListaEmpleados, agregar Panel "pnlListaEmpleadosI"
     - BackColor: 50, 55, 58
     - BorderStyle: FixedSingle
     - Contiene el dgvEmpleados

3. **Para gbEmpleadoDetalle:**
   - Agregar Panel "pnlEmpleadoDetalle"
     - BackColor: 35, 34, 33
     - BorderStyle: FixedSingle
   
   - Dentro de pnlEmpleadoDetalle, agregar Panel "pnlEmpleadoDetalleI"
     - BackColor: 50, 55, 58
     - BorderStyle: FixedSingle
     - Contiene todos los TextBox, Labels, Buttons, etc.

4. **Mover controles existentes** a los nuevos paneles interiores

5. **Ajustar posiciones y tamaños** para que coincidan con el diseño original

## Ventajas de esta estructura:
- ✅ Efecto visual de profundidad/sombra
- ✅ Bordes bien definidos
- ✅ Consistencia con frmPrincipal
- ✅ Carga más rápida (con SuspendLayout/ResumeLayout ya implementado en .cs)
