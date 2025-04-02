# 🧾 GeneralLog

**GeneralLog** es un microservicio desarrollado en .NET utilizando MongoDB, encargado de registrar y consultar logs generados por aplicaciones externas. Este servicio permite llevar un historial centralizado de eventos relacionados con operaciones realizadas por usuarios identificados mediante cédula, RNC o Pasaporte.

---

## Arquitectura

El proyecto está construido bajo los principios de la **Onion Architecture**, lo que promueve:

- Separación de responsabilidades
- Alta mantenibilidad
- Facilidad para realizar pruebas y escalar

### Capas del proyecto:

- `GeneralLog.Domain`: Define las entidades y contratos principales.
- `GeneralLog.Application`: Contiene la lógica de negocio y servicios.
- `GeneralLog.Infrastructure`: Implementación del acceso a datos y configuración de MongoDB.
- `GeneralLog.WebApi`: Punto de entrada HTTP para consumir el servicio.

## Endpoints principales

| Método | Ruta                                | Descripción                                   |
|--------|-------------------------------------|-----------------------------------------------|
| POST   | `/api/GeneralLog`                   | Registrar un nuevo log                        |
| GET    | `/api/GeneralLog/GetByCedula/{id}`  | Consultar los logs filtrados por cédula, RNC o Pasaporte       |

