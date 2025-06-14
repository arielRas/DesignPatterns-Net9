# 🧠 Patrones de diseño en C# (.NET 9)

Este proyecto forma parte de mi formación universitaria con foco en la comprensión, análisis e implementación de **patrones de diseño de software** aplicados a C# y .NET.  
A través de ejemplos prácticos, fui desarrollando soluciones que respetan los principios SOLID y demuestran cómo aplicar estos patrones en proyectos reales o escalables.

Cada patrón está implementado dentro de su propia carpeta, con una estructura clara, documentación (`/docs`) y en muchos casos, diagramas UML y enunciados que dieron origen a la solución.

---

## 🏗️ Estructura actual del proyecto

### 🔨 Patrones Creacionales

- [`Factory Pattern`](./src/ConsoleApp/FactoryPattern)  
  Crea objetos sin exponer la lógica de instanciación, centralizando su creación a través de una fábrica.

- [`Abstract Factory Pattern`](./src/ConsoleApp/AbstractFactoryPattern)  
  Crea familias de objetos relacionados (factura + envío) según un contexto (ej. país), sin acoplarse a sus clases concretas.

---

### 🧱 Patrones Estructurales

- [`Composite Pattern`](./src/ConsoleApp/CompositePattern)  
  Modela estructuras jerárquicas como proyectos que contienen tareas, documentos o incluso otros subproyectos, permitiendo tratarlos de forma uniforme.

- [`Decorator Pattern`](./src/ConsoleApp/DecoratorPattern)  
  Permite extender dinámicamente el comportamiento de un notificador agregando funcionalidades como envío por distintos canales, log de eventos y medición de rendimiento, sin modificar la clase base.

---

### 🔁 Patrones de Comportamiento

- [`Memento Pattern`](./src/ConsoleApp/MementoPattern)  
  Permite deshacer y rehacer transformaciones sobre una imagen simulada, encapsulando el estado sin violar el principio de encapsulamiento.

- [`Visitor Pattern`](./src/ConsoleApp/VisitorPattern)  
  Aplica distintas validaciones de control de calidad a productos electrónicos sin modificar sus clases internas, separando operaciones del modelo.

- [`Observer Pattern`](./src/ConsoleApp/ObserverPattern)  
  Implementa un sistema de eventos deportivos en tiempo real con múltiples subscriptores (motor estadístico, notificaciones, etc.).

---

### 🧩 Otros / Arquitectura de Datos

- [`Repository Pattern`](./src/ConsoleApp/RepositoryPattern)  
  Este módulo representa una implementación completa del patrón Repository + Abstract Factory, capaz de operar sobre **tres motores de base de datos distintos** (MongoDB, SQL Server y Memoria) sin que el cliente conozca cuál está siendo usado.

  Características destacadas:
  - Interfaz `IRepository<T>` genérica y reutilizable.
  - Factories especializadas que devuelven repositorios según configuración (`DbEngineSettings`).
  - Implementaciones funcionales con:
    - **MongoDB.Driver** para NoSQL
    - **ADO.NET** para SQL Server
    - **LINQ + memoria** para pruebas/demostración
  - Repositorios desacoplados, seguros en tiempo de compilación y extensibles.
  - Test funcional demostrando la creación dinámica y el uso unificado de repositorios.

  Este módulo fue pensado para ser funcional y realista, y es un claro ejemplo de arquitectura limpia, separación de responsabilidades y desacoplamiento total.

---

## 📚 Enfoque académico y profesional

El origen de este proyecto es **académico**, pero fue desarrollado con una visión práctica y profesional. La idea no fue solo aplicar patrones por separado, sino **entender su motivación, aplicarlos correctamente y lograr soluciones limpias y escalables**.

---

## 🚀 Futuro del proyecto

El repositorio se encuentra en constante crecimiento. Próximamente se agregarán más patrones como:

- Adapter
- Builder
- Strategy
- State
- Chain of Responsibility
- Command
- Mediator
- Unit of Work

Cada uno con su respectiva solución, enunciado, test y documentación UML.

---

## 📁 Estructura recomendada del repositorio

Cada patrón tiene su propia carpeta con:

- Código fuente
- `docs/` con enunciado + diagrama UML
- Método de prueba (`TestPatternName`) ubicado en `Program.cs` o test dedicado

---
