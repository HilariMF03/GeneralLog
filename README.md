# 🧾 GeneralLog

**GeneralLog** es un microservicio desarrollado en .NET utilizando MongoDB, encargado de registrar y consultar logs generados por aplicaciones externas. Este servicio permite llevar un historial centralizado de eventos relacionados con operaciones realizadas por usuarios identificados mediante cédula.

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
