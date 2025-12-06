namespace app.Helpers
{
    /// <summary>
    /// Constantes centralizadas para todos los mensajes del sistema.
    /// </summary>
    public static class MensajesConstantes
    {
        #region Validaciones - Servicio

        public const string VALIDACION_SELECCIONE_LUGAR = "Seleccione un lugar";
        public const string VALIDACION_INGRESE_PROYECCION = "Ingrese una proyección de comensales";
        public const string VALIDACION_PROYECCION_VALIDA = "Ingrese una proyección válida (solo números)";
        public const string VALIDACION_PROYECCION_RANGO = "La proyección debe estar entre 0 y 1000 comensales";
        public const string VALIDACION_INVITADOS_VALIDO = "Ingrese un número válido de invitados";
        public const string VALIDACION_INVITADOS_RANGO = "Los invitados deben estar entre 0 y 500";

        #endregion

        #region Validaciones - Empleado

        public const string VALIDACION_INGRESE_CREDENCIAL = "Ingrese un número de credencial";
        public const string VALIDACION_CREDENCIAL_EN_USO = "Esta credencial ya está en uso";
        public const string VALIDACION_INGRESE_CREDENCIAL_EMPLEADO = "Ingrese el número de credencial";
        public const string VALIDACION_INGRESE_NOMBRE = "Ingrese el nombre";
        public const string VALIDACION_NOMBRE_SOLO_LETRAS = "El nombre solo puede contener letras, espacios, tildes y guiones";
        public const string VALIDACION_INGRESE_APELLIDO = "Ingrese el apellido";
        public const string VALIDACION_APELLIDO_SOLO_LETRAS = "El apellido solo puede contener letras, espacios, tildes y guiones";
        public const string VALIDACION_SELECCIONE_EMPRESA = "Seleccione una empresa";

        #endregion

        #region Validaciones - Empresa

        public const string VALIDACION_INGRESE_NOMBRE_EMPRESA = "Ingrese el nombre de la empresa";
        public const string VALIDACION_NOMBRE_MINIMO = "El nombre debe tener al menos 2 caracteres";
        public const string VALIDACION_NOMBRE_EMPRESA_CARACTERES = "El nombre de la empresa solo puede contener letras, números, espacios y guiones";
        public const string VALIDACION_EMPRESA_DUPLICADA = "Ya existe una empresa con ese nombre";

        #endregion

        #region Validaciones - Registro

        public const string VALIDACION_SERVICIO_INACTIVO = "No hay un servicio activo";
        public const string VALIDACION_SERVICIO_NO_ACTIVO = "El servicio no está activo";
        public const string VALIDACION_SELECCIONE_EMPLEADOS = "Seleccione al menos un empleado de la lista";
        public const string VALIDACION_INGRESE_CREDENCIAL_VALIDA = "Ingrese una credencial válida";

        #endregion

        #region Validaciones - Configuración

        public const string VALIDACION_INGRESE_CADENA_CONEXION = "Debe ingresar una cadena de conexión";

        #endregion

        #region Validaciones - Reportes

        public const string VALIDACION_NO_HAY_DATOS_EXPORTAR = "No hay datos para exportar. Genere un reporte primero.";
        public const string VALIDACION_RANGO_FECHAS_INVALIDO = "El rango de fechas es inválido (Desde > Hasta)";

        #endregion

        #region Advertencias - Estado de Servicio

        public const string ADVERTENCIA_REPORTES_SERVICIO_ACTIVO = "Reportes está disponible sólo con el servicio inactivo";
        public const string ADVERTENCIA_ADMIN_SERVICIO_ACTIVO = "Admin está disponible sólo con el servicio inactivo";
        public const string ADVERTENCIA_FINALIZAR_ANTES_SALIR = "Debe finalizar el servicio activo antes de salir de la aplicación.";
        public const string ADVERTENCIA_FINALIZAR_ANTES_CERRAR = "Debe finalizar el servicio activo antes de cerrar la aplicación.";

        #endregion

        #region Advertencias - Empresa

        public const string ADVERTENCIA_EMPRESA_CON_EMPLEADOS = 
            "No se puede desactivar la empresa '{0}' porque tiene {1} empleado(s) activo(s).\n\n" +
            "Primero desactive o transfiera los empleados a otra empresa.";

        #endregion

        #region Confirmaciones

        public const string CONFIRMACION_FINALIZAR_SERVICIO = "¿Está seguro de finalizar el servicio? Esta acción guardará todas las estadísticas.";
        public const string CONFIRMACION_SALIR_APLICACION = "¿Está seguro de salir de la aplicación?";
        public const string CONFIRMACION_DESACTIVAR_EMPLEADO = "¿Está seguro de desactivar al empleado?";
        public const string CONFIRMACION_DESACTIVAR_EMPRESA = "¿Está seguro de desactivar la empresa '{0}'?";
        public const string CONFIRMACION_GUARDAR_CONEXION = 
            "¿Está seguro de guardar la nueva cadena de conexión?\n\n" +
            "La aplicación se reiniciará.";
        public const string CONFIRMACION_CREAR_RESPALDO = 
            "¿Desea crear un respaldo de la base de datos?\n\n" +
            "Esta operación puede tardar varios minutos dependiendo del tamaño de la base de datos.";
        public const string CONFIRMACION_RESTAURAR_RESPALDO = 
            "Restaurar un respaldo ELIMINARÁ TODOS LOS DATOS ACTUALES de la base de datos " +
            "y los reemplazará con los datos del archivo de respaldo seleccionado.\n\n" +
            "Esta acción es IRREVERSIBLE.\n\n" +
            "¿Está seguro de que desea continuar?";

        #endregion

        #region Éxito

        public const string EXITO_EMPLEADO_GUARDADO = "Empleado guardado correctamente";
        public const string EXITO_EMPLEADO_DESACTIVADO = "Empleado desactivado correctamente";
        public const string EXITO_EMPRESA_GUARDADA = "Empresa guardada correctamente";
        public const string EXITO_EMPRESA_DESACTIVADA = "Empresa desactivada correctamente";
        public const string EXITO_CREDENCIAL_ACTUAL = "Credencial actual del empleado";
        public const string EXITO_CREDENCIAL_DISPONIBLE = "Credencial disponible";

        #endregion

        #region Información

        public const string INFO_EMPLEADO_YA_REGISTRADO = "El empleado {0} ya está registrado en este servicio";
        public const string INFO_EMPLEADO_NO_ENCONTRADO = "No se encontró un empleado con la credencial {0}";
        public const string INFO_REPORTE_GUARDADO = "Reporte guardado como PDF:\n{0}";
        public const string INFO_DESACTIVAR_EMPRESA = "¿Está seguro de desactivar la empresa '{0}'?";

        #endregion

        #region Errores - Configuración

        public const string ERROR_NO_CONECTAR_BD = "No se pudo conectar a la base de datos";
        public const string ERROR_NO_CONECTAR_NUEVA_CADENA = "No se pudo conectar con la nueva cadena de conexión";
        public const string ERROR_NO_GUARDAR_CADENA = "No se pudo guardar la cadena de conexión";
        public const string ERROR_CARGAR_INFO_RESPALDOS = "Error al cargar información de respaldos: {0}";
        public const string ERROR_GUARDAR_CONFIGURACION = "Error al guardar configuración: {0}";

        #endregion

        #region Errores - Reportes

        public const string ERROR_ARCHIVO_ABIERTO = 
            "No se pudo acceder al archivo. Asegúrese de que el archivo no esté abierto en otra aplicación.\n\n" +
            "Detalle: {0}";
        public const string ERROR_GENERAR_PDF = "Error al generar el PDF: {0}";
        public const string ERROR_EXPORTAR_REPORTE = "Error al exportar el reporte: {0}";

        #endregion

        #region Errores - General

        public const string ERROR_CARGAR_EMPRESAS = "Error al cargar empresas: {0}";
        public const string ERROR_CARGAR_SERVICIO = "Error al cargar servicio seleccionado: {0}";

        #endregion
    }
}
