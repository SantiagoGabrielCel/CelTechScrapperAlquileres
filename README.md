# CelTechScrapperAlquileres
Scraper inteligente de propiedades de Argenprop con cálculo opcional de conectividad urbana mediante análisis geoespacial de POIs. 

## 🚀 Características principales

- 🔍 **Scraping por zona, tipo y operación** (ej: alquiler en Palermo)
- 📍 **Score de conectividad urbana**: calcula la cercanía a subte, colectivos y supermercados mediante Overpass API
- 💡 **Índice de oportunidad inmobiliaria**: combina precio y conectividad para detectar “gangas urbanas”
- ⚙️ **Paralelismo controlado** para máxima performance
- 💻 **Deployeado en Render** con Docker y Clean Architecture
- 🧱 **Código estructurado en capas**: Dominio, Aplicación, Infraestructura y WebAPI
- 🔧 **Activación opcional del análisis de conectividad**, ideal para evitar cálculos pesados en ambientes limitados

GET /api/propiedades

#### 🔹 Parámetros query:
| Parámetro       | Tipo    | Obligatorio | Descripción                              |
|----------------|---------|-------------|------------------------------------------|
| `tipo`         | string  | ✅          | `departamentos`, `casas`, etc.           |
| `operacion`    | string  | ✅          | `alquiler`, `venta`, etc.                |
| `zona`         | string  | ✅          | Nombre de barrio, ej: `palermo`, `villa-urquiza` |
| `maxPaginas`   | int     | ✅          | Cuántas páginas scrapea (máx 3 sugerido) |
| `ambientes`    | int     | ❌          | Ej: `2`, `3`, etc.                        |
| `incluirScore` | bool    | ❌          | Si querés el análisis de conectividad y oportunidad (`true` o `false`) |

#### 🧪 Ejemplo:

GET /api/propiedades?tipo=departamentos&operacion=alquiler&zona=palermo&maxPaginas=1&incluirScore=true

Json 
[
  {
    "titulo": "2 ambientes con balcón",
    "precio": "$ 450.000 + $100.000 expensas",
    "direccion": "Av. Córdoba 3200",
    "descripcion": "Luminoso, cerca subte D y H...",
    "url": "https://argenprop.com/...",
    "precioDecimal": 450000,
    "scoreConectividad": 7.2,
    "indiceOportunidad": 16.0
  }
]


Endpoints extra (en desarrollo)

Endpoint	Descripción
/api/indice-saturacion	Índice de saturación por zona (WIP)
/api/simulador-alquiler	Simulación de costos mensuales (WIP)


API online
Deploy actual:
🔗 https://celtechscrapperalquileres.onrender.com/swagger

Tech stack
ASP.NET Core 8

Docker

HtmlAgilityPack

Overpass API (OpenStreetMap)

Render.com

Arquitectura Hexagonal


 Autor
Santiago Gabriel Celestre
 Backend Developer – APIs, scraping, datos y performance.

