# 📡 Guía de Implementación - Lector RFID

## Índice

1. [Introducción](#introducción)
2. [Configuración del Hardware](#configuración-del-hardware)
3. [Implementación en el Sistema](#implementación-en-el-sistema)

---

## Introducción

Esta guía detalla el proceso para integrar un lector RFID al Sistema de Control de Almuerzos, permitiendo el registro automático de comensales mediante credenciales RFID.

### Beneficios de la Integración RFID

- **Registro instantáneo**: Los empleados solo acercan su tarjeta/credencial y quedan registrados automáticamente
- **Reducción de errores**: Elimina errores de escritura manual del número de credencial
- **Mayor velocidad**: Proceso de registro más rápido, especialmente en horas pico
- **Trazabilidad**: Cada lectura RFID genera un registro preciso con timestamp
- **Modo híbrido**: El sistema mantiene el modo manual como respaldo en caso de fallo del lector

### Alcance de la Guía

Esta guía cubre exclusivamente:
- Configuración física del hardware RFID
- Implementación de la clase `RFIDReader.cs` para comunicación serial
- Integración con el módulo de registro de comensales (`ucRegistroManual`)
- Configuración de parámetros en `App.config`

**Nota:** Para la configuración del panel de administración del lector en `ucConfiguracion`, consultar `Guia_ucConfiguracion.md` - Sección "Lector RFID (FUTURO)".

---

## Configuración del Hardware

### Paso 1: Conexión al Sistema

1. Conectar el lector por USB
2. Windows instalará drivers automáticamente
3. Verificar en **Administrador de Dispositivos**:
   - Buscar en "Puertos (COM y LPT)"
   - Anotar el puerto asignado (ejemplo: COM3)
4. Si no detecta, instalar drivers manualmente

### Paso 2: Probar el Hardware

- Descargar herramienta de prueba del fabricante
- Ejecutar y verificar detección
- Acercar una tarjeta
- Confirmar que muestre el UID

---

## Implementación en el Sistema

### Visión General

Se agregará una nueva clase `RFIDReader.cs` en la capa de negocio que manejará:
- Detección automática del puerto COM
- Conexión con el lector
- Lectura continua de tarjetas
- Eventos para notificar al sistema

---

### Paso 1: Crear Clase RFIDReader

**Ubicación:** `SCA/negocio/RFIDReader.cs`

**Responsabilidades:**
- Gestionar la comunicación serial con el lector
- Detectar automáticamente el puerto COM
- Implementar anti-rebote (evitar lecturas duplicadas)
- Disparar eventos cuando se lee una tarjeta

**Estructura de la clase:**
```
RFIDReader
├── Propiedades
│   ├── TiempoAntiRebote (segundos entre lecturas)
│   ├── IsConnected (estado de conexión)
│   └── Puerto (puerto COM actual)
├── Eventos
│   ├── OnCardRead (cuando se lee una tarjeta)
│   ├── OnError (cuando ocurre un error)
│   └── OnConnectionChanged (cambio de conexión)
├── Métodos Públicos
│   ├── DetectarPuerto() - Busca automáticamente el lector
│   ├── Conectar(puerto) - Establece conexión
│   ├── IniciarLectura() - Comienza a leer tarjetas
│   ├── DetenerLectura() - Pausa la lectura
│   └── Desconectar() - Cierra la conexión
└── Métodos Privados
    ├── BucleLectura() - Lee continuamente
    ├── ProcesarLectura() - Valida y filtra lecturas
    └── LimpiarCardId() - Limpia el UID leído
```

**Funcionalidades clave:**
-  Detecta automáticamente el puerto COM del lector
-  Lee el UID de las tarjetas RFID
-  Implementa anti-rebote (evita lecturas duplicadas)
-  Notifica mediante eventos cuando se lee una tarjeta
-  Manejo robusto de errores

---

### Paso 2: Configurar Panel en ucConfiguracion

**Ver:** `Guia_ucConfiguracion.md` - Sección "Lector RFID (FUTURO)"

Esta guía contiene toda la información sobre:
- Controles del panel de configuración RFID
- Métodos auxiliares (`CargarConfiguracionRFID`)
- Eventos de botones (`btnDetectarPuertos_Click`, `btnConfigurarRFID_Click`, `btnProbarLector_Click`)
- Procedimientos almacenados necesarios

---

### Paso 3: Integrar RFID en Registro de Comensales

**Ubicación:** `ucRegistroManual.cs`

**Modificaciones:**

1. **Agregar variable privada:**
   ```csharp
   private RFIDReader rfidReader;
   ```

2. **Modificar método `SetServicio()`:**
   - Agregar llamada a `InicializarRFID()`

3. **Crear método `InicializarRFID()`:**
   - Obtener puerto configurado de `App.config`
   - Crear instancia de `RFIDReader`
   - Suscribir evento `OnCardRead`
   - Conectar y comenzar lectura
   - Actualizar label "MODO: RFID AUTOMÁTICO"

4. **Crear método `RfidReader_OnCardRead()`:**
   - Verificar `InvokeRequired`
   - Llamar a `RegistrarConCredencial()` automáticamente

5. **Refactorizar registro:**
   - Extraer lógica del evento KeyPress a método `RegistrarConCredencial(string)`
   - Este método ahora sirve para RFID y modo manual

6. **Agregar cleanup:**
   - En el evento FormClosing, desconectar y liberar recursos

**Flujo resultante:**
```
Usuario acerca tarjeta
  ↓
Lector lee UID
  ↓
Evento OnCardRead dispara
  ↓
RegistrarConCredencial(uid)
  ↓
Buscar empleado en BD
  ↓
Validar estado activo
  ↓
Registrar almuerzo
  ↓
Actualizar UI y estadísticas
```

---

### Paso 4: Configuración en App.config

**Ubicación:** `SCA/app/App.config`

**Agregar dentro de `<appSettings>`:**

```xml
<!-- Configuración RFID -->
<add key="RFID_Enabled" value="true"/>
<add key="RFID_Puerto" value="COM3"/>
<add key="RFID_BaudRate" value="9600"/>
<add key="RFID_TiempoAntiRebote" value="3"/>
```

**Crear método helper para leer configuración:**

```csharp
private string ObtenerPuertoConfigurado()
{
    try
    {
        bool enabled = bool.Parse(
            ConfigurationManager.AppSettings["RFID_Enabled"] ?? "false"
        );
        
        if (!enabled)
            return null;
            
        return ConfigurationManager.AppSettings["RFID_Puerto"];
    }
    catch
    {
        return null;
    }
}
```

**Ajustar según necesidad:**
- `RFID_Enabled`: `true` para activar, `false` para usar solo modo manual
- `RFID_Puerto`: Cambiar según el puerto detectado (COM3, COM4, etc.)
- `RFID_TiempoAntiRebote`: Segundos mínimos entre lecturas de la misma tarjeta

---

##  Resumen de Implementación

### Archivos a Crear
1. `SCA/negocio/RFIDReader.cs` - Clase principal del lector

### Archivos a Modificar
1. `SCA/app/UserControls/ucConfiguracion.cs` - Panel de configuración (ver `Guia_ucConfiguracion.md`)
2. `SCA/app/UserControls/ucConfiguracion.Designer.cs` - Controles visuales (ver `Guia_ucConfiguracion.md`)
3. `SCA/app/UserControls/ucRegistroManual.cs` - Integración con registro
4. `SCA/app/App.config` - Configuración del puerto

### Flujo de Trabajo
1. Usuario conecta lector USB
2. Sistema detecta puerto automáticamente (ver `Guia_ucConfiguracion.md` para detalles del panel)
3. Administrador configura en ucConfiguracion
4. Al iniciar servicio, RFID se activa automáticamente
5. Usuario acerca tarjeta → Registro instantáneo
6. Modo manual sigue disponible como backup

---

**Nota:** Para los detalles completos del panel de configuración RFID en `ucConfiguracion`, consultar `Guia_ucConfiguracion.md`.

---


